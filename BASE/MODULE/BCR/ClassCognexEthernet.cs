using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Drawing;
using System.Xml;

using Cognex.DataMan.SDK.Discovery;
using Cognex.DataMan.SDK.Utils;
using Cognex.DataMan.SDK;

using BASE.MASTER;
using BASE.VO;

namespace BASE.MODULE.BCR
{
  public class ClassCognexEthernet
  {
    private static ClassCognexEthernet cInstatnce;
    private static object syncLock = new object();

    ////////////////////////////////////////////////////////////////////////////
    //Cognex Values
    ////////////////////////////////////////////////////////////////////////////
    private static SynchronizationContext _syncContext = System.Windows.Forms.WindowsFormsSynchronizationContext.Current;
    private static EthSystemDiscoverer cEther = null;
    private static DataManSystem cSystem = null;
    private static ISystemConnector _connector = null;
    private static List<EthSystemDiscoverer.SystemInfo> arrInfo = new List<EthSystemDiscoverer.SystemInfo>();
    private ResultCollector cResults;

    private bool bKeepAlive = false;
    private bool bLive = false;
    private System.Windows.Forms.PictureBox picLiveImage = new System.Windows.Forms.PictureBox();
    private int iMaxWidth = 1280;
    private int iMaxHeight = 960;
    private Rectangle sROI = new Rectangle();

    private string strBcr = "";
    private Image readImage = null;


    protected ClassCognexEthernet()
    {
      arrInfo.Clear();
      cEther = new EthSystemDiscoverer();
      cEther.SystemDiscovered += new EthSystemDiscoverer.SystemDiscoveredHandler(OnEthSystemDiscovered);
    }

    public static ClassCognexEthernet Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassCognexEthernet();
          }
        }
      }
      return cInstatnce;
    }

    public bool Open_Port()
    {
      arrInfo.Clear();
      cEther.Discover();
      int nTimeOut = 10000;
      bool bExistDevice = false;
      int nStartTime = System.Environment.TickCount;
      while ((System.Environment.TickCount - nStartTime) < nTimeOut)
      {
        int nTime = (System.Environment.TickCount - nStartTime);
        if (arrInfo.Count != 0)
        {
          bExistDevice = true;
          break;
        }
      }
      if (bExistDevice == false)
      {
        return false;
      }
      if (arrInfo.Count <= 0)
      {
        return false;
      }

      if (cSystem == null)
      {
        try
        {
          //EthSystemDiscoverer.SystemInfo system_info = arrInfo[0];
          //EthSystemDiscoverer.SystemInfo eth_system_info = system_info as EthSystemDiscoverer.SystemInfo;
          //EthSystemConnector conn = new EthSystemConnector(eth_system_info.IPAddress, eth_system_info.Port);

          System.Net.IPAddress IP =  System.Net.IPAddress.Parse(BASE.VO.CVo.cParaSys.strBCR_IPAddress);//new System.Net.IPAddress(BASE.VO.CVo.cParaSys.strBCR);
          EthSystemConnector conn = new EthSystemConnector(IP, 23);


          conn.UserName = "admin";
          conn.Password = "";

          _connector = conn;

          cSystem = new DataManSystem(_connector);
          cSystem.DefaultTimeout = 5000;

          // Subscribe to events that are signalled when the system is connected / disconnected.
          cSystem.SystemConnected += new SystemConnectedHandler(OnSystemConnected);
          cSystem.SystemDisconnected += new SystemDisconnectedHandler(OnSystemDisconnected);
          cSystem.SystemWentOnline += new SystemWentOnlineHandler(OnSystemWentOnline);
          cSystem.SystemWentOffline += new SystemWentOfflineHandler(OnSystemWentOffline);
          cSystem.KeepAliveResponseMissed += new KeepAliveResponseMissedHandler(OnKeepAliveResponseMissed);
          cSystem.BinaryDataTransferProgress += new BinaryDataTransferProgressHandler(OnBinaryDataTransferProgress);
          cSystem.OffProtocolByteReceived += new OffProtocolByteReceivedHandler(OffProtocolByteReceived);
          cSystem.AutomaticResponseArrived += new AutomaticResponseArrivedHandler(AutomaticResponseArrived);

          // Subscribe to events that are signalled when the device sends auto-responses.
          ResultTypes requested_result_types = ResultTypes.ReadXml | ResultTypes.Image | ResultTypes.ImageGraphics;
          cResults = new ResultCollector(cSystem, requested_result_types);
          cResults.ComplexResultCompleted += Results_ComplexResultCompleted;
          cResults.SimpleResultDropped += Results_SimpleResultDropped;

          cSystem.SetKeepAliveOptions(bKeepAlive, 3000, 1000);
          cSystem.Connect();
          try
          {
            cSystem.SetResultTypes(requested_result_types);
          }
          catch
          { 
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          CleanupConnection();
          return false;
        }
      }

      SetLiveROI(GetROI());
      return true;
    }

    public void Close_Port()
    {
      if (cSystem == null)
      {
        return;
      }
      if (cSystem.State != ConnectionState.Connected)
      {
        return;
      }
      Live(false);
      cSystem.Disconnect();
      CleanupConnection();

      cResults.ClearCachedResults();
      cResults = null;
    }

    public bool Check_Open()
    {
      if (cSystem == null)
      {
        return false;
      }
      bool bConnect = (cSystem.State == ConnectionState.Connected);
      return bConnect;
    }

    public void SetPictureBox(System.Windows.Forms.PictureBox pic)
    {
      picLiveImage = pic;
    }

    public void Live(bool on)
    {
      if (Check_Open() == false)
      {
        return;
      }

      bLive = on;
      try
      {
        if (bLive)
        {
          cSystem.SendCommand("SET LIVEIMG.MODE 2");
          cSystem.BeginGetLiveImage(
            ImageFormat.jpeg,
            ImageSize.Sixteenth,
            ImageQuality.Medium,
            OnLiveImageArrived,
            null);
        }
        else
        {
          cSystem.SendCommand("SET LIVEIMG.MODE 0");
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
      }
    }

    public bool Check_Live()
    {
      return bLive;
    }

    public void Trigger(bool on)
    {
      if (Check_Open() == false)
      {
        strBcr = "";
        return;
      }
      Live(false);
      try
      {
        if (on)
        {
          readImage = null;
          strBcr = "";
          cSystem.SendCommand("TRIGGER ON");
        }
        else
        {
          cSystem.SendCommand("TRIGGER OFF");
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
      }
    }

    public string Read()
    {
      if (Check_Open() == false)
      {
        strBcr = "";
        return strBcr;
      }
      Live(false);
      strBcr = "";
      Trigger(true);
      Thread.Sleep(200);
      Trigger(false);
      int nTimeOut = 1000;
      int nStartTime = System.Environment.TickCount;
      while ((System.Environment.TickCount - nStartTime) < nTimeOut)
      {
        int nTime = (System.Environment.TickCount - nStartTime);
        if (strBcr.CompareTo("") != 0)
        {
          break;
        }
      }
      return strBcr;
    }

    public Image Get_Image()
    {
      return readImage;
    }

    public Rectangle GetROI()
    {
      Rectangle cResult_Fail = new Rectangle(-100, -100, 1, 1);
      Rectangle cResult;
      if (Check_Open() == false)
      {
        return cResult_Fail;
      }
      if (Check_Live())
      {
        Live(false);
      }
      try
      {
        DmccResponse result = cSystem.SendCommand("GET DECODER.ROI");
        string[] arrData = result.PayLoad.ToString().Split(' ');
        if (arrData.Length < 4)
        {
          return cResult_Fail;
        }
        cResult = new Rectangle(new Point(Convert.ToInt32(arrData[0]), Convert.ToInt32(arrData[2])), new Size(Convert.ToInt32(arrData[1]) - Convert.ToInt32(arrData[0]), Convert.ToInt32(arrData[3]) - Convert.ToInt32(arrData[2])));
      }
      catch (Exception)
      {
        return cResult_Fail;
      }
      return cResult;
    }
    public bool SetROI(Rectangle rect)
    {
      if (Check_Open() == false)
      {
        return true;
      }
      if (rect.Right < rect.Left)
      {
        return false;
      }
      if (rect.Bottom < rect.Top)
      {
        return false;
      }
      if (rect.Right < 64 || iMaxWidth < rect.Right)
      {
        return false;
      }
      if (rect.Bottom < 64 || iMaxHeight < rect.Bottom)
      {
        return false;
      }
      if (rect.Left % 8 != 0
       || rect.Right % 8 != 0
       || rect.Top % 8 != 0
       || rect.Bottom % 8 != 0)
      {
        return false;
      }

      if (Check_Live())
      {
        Live(false);
      }
      string strData = string.Format("SET DECODER.ROI {0} {1} {2} {3}", rect.Left, rect.Right, rect.Top, rect.Bottom);
      try
      {
        cSystem.SendCommand(strData);
        SetLiveROI(rect);
      }
      catch (Exception)
      {
        return false;
      }
      return true;
    }

    public Rectangle GetROI_Live()
    {
      Rectangle cResult_Fail = new Rectangle(-100, -100, 1, 1);
      if (Check_Open() == false)
      {
        return cResult_Fail;
      }
      if (Check_Live())
      {
        return cResult_Fail;
      }
      return sROI;
    }
    public bool SetLiveROI(Rectangle rect)
    {
      if (Check_Open() == false)
      {
        return true;
      }
      if (rect.Right < rect.Left)
      {
        return false;
      }
      if (rect.Bottom < rect.Top)
      {
        return false;
      }
      if (rect.Right < 64 || iMaxWidth < rect.Right)
      {
        return false;
      }
      if (rect.Bottom < 64 || iMaxHeight < rect.Bottom)
      {
        return false;
      }
      if (rect.Left % 8 != 0
       || rect.Right % 8 != 0
       || rect.Top % 8 != 0
       || rect.Bottom % 8 != 0)
      {
        return false;
      }
      sROI = rect;
      return true;
    }

    public string GetResult()
    {
      return strBcr;
    }



    #region Event
    private void CleanupConnection()
    {
      if (null != cSystem)
      {
        cSystem.SystemConnected -= OnSystemConnected;
        cSystem.SystemDisconnected -= OnSystemDisconnected;
        cSystem.SystemWentOnline -= OnSystemWentOnline;
        cSystem.SystemWentOffline -= OnSystemWentOffline;
        cSystem.KeepAliveResponseMissed -= OnKeepAliveResponseMissed;
        cSystem.BinaryDataTransferProgress -= OnBinaryDataTransferProgress;
        cSystem.OffProtocolByteReceived -= OffProtocolByteReceived;
        cSystem.AutomaticResponseArrived -= AutomaticResponseArrived;
      }

      _connector = null;
      cSystem = null;
    }

    private void OnEthSystemDiscovered(EthSystemDiscoverer.SystemInfo systemInfo)
    {
      arrInfo.Add(systemInfo);
      //_syncContext.Post(
      //  new SendOrPostCallback(
      //    delegate
      //    {
      //      arrInfo.Add(systemInfo);
      //    }), null);
    }

    private void OnSystemConnected(object sender, EventArgs args)
    {
      //  _syncContext.Post(
      //delegate
      //{
      //  AddListItem("System connected");
      //  RefreshGui();
      //},
      //null);
    }

    private void OnSystemDisconnected(object sender, EventArgs args)
    {
      //  _syncContext.Post(
      //delegate
      //{
      //  AddListItem("System disconnected");
      //  bool reset_gui = false;

      //  if (!_closing && _autoconnect && cbAutoReconnect.Checked)
      //  {
      //    frmReconnecting frm = new frmReconnecting(this, _system);

      //    if (frm.ShowDialog() == DialogResult.Cancel)
      //      reset_gui = true;
      //  }
      //  else
      //  {
      //    reset_gui = true;
      //  }

      //  if (reset_gui)
      //  {
      //    btnConnect.Enabled = true;
      //    btnDisconnect.Enabled = false;
      //    btnTrigger.Enabled = false;
      //    cbLiveDisplay.Enabled = false;

      //    picResultImage.Image = null;
      //    lbReadString.Text = "";
      //  }
      //},
      //null);
    }

    private void OnKeepAliveResponseMissed(object sender, EventArgs args)
    {
      //  _syncContext.Post(
      //delegate
      //{
      //  AddListItem("Keep-alive response missed");
      //},
      //null);
    }

    private void OnSystemWentOnline(object sender, EventArgs args)
    {
      //  _syncContext.Post(
      //delegate
      //{
      //  AddListItem("System went online");
      //},
      //null);
    }

    private void OnSystemWentOffline(object sender, EventArgs args)
    {
      //  _syncContext.Post(
      //delegate
      //{
      //  AddListItem("System went offline");
      //},
      //null);
    }

    private void OnBinaryDataTransferProgress(object sender, BinaryDataTransferProgressEventArgs args)
    {
      //Log("OnBinaryDataTransferProgress", string.Format("{0}: {1}% of {2} bytes (Type={3}, Id={4})", args.Direction == TransferDirection.Incoming ? "Receiving" : "Sending", args.TotalDataSize > 0 ? (int)(100 * (args.BytesTransferred / (double)args.TotalDataSize)) : -1, args.TotalDataSize, args.ResultType.ToString(), args.ResponseId));    
    }

    private void OffProtocolByteReceived(object sender, OffProtocolByteReceivedEventArgs args)
    {
      //Log("OffProtocolByteReceived", string.Format("{0}", (char)args.Byte));
    }

    private void AutomaticResponseArrived(object sender, AutomaticResponseArrivedEventArgs args)
    {
      //Log("AutomaticResponseArrived", string.Format("Type={0}, Id={1}, Data={2} bytes", args.DataType.ToString(), args.ResponseId, args.Data != null ? args.Data.Length : 0));
    }


    private void Results_ComplexResultCompleted(object sender, ComplexResult e)
    {
      ShowResult(e);
      //lock (this)
      //{
      //  string read_result = null;
      //  int result_id = -1;
      //  ResultTypes collected_results = ResultTypes.None;
      //  foreach (var simple_result in e.SimpleResults)
      //  {
      //    collected_results |= simple_result.Id.Type;
      //    switch (simple_result.Id.Type)
      //    {
      //      case ResultTypes.Image:
      //        break;
      //      case ResultTypes.ImageGraphics:
      //        break;
      //      case ResultTypes.ReadXml:
      //        read_result = GetReadStringFromResultXml(simple_result.GetDataAsString());
      //        result_id = simple_result.Id.Id;
      //        break;

      //      case ResultTypes.ReadString:
      //        read_result = simple_result.GetDataAsString();
      //        result_id = simple_result.Id.Id;
      //        break;
      //      default:
      //        break;
      //    }
      //  }
      //  strBcr = read_result;
      //}




      //    _syncContext.Post(
      //delegate
      //{
      //  ShowResult(e);
      //},
      //null);
    }

    private void Results_SimpleResultDropped(object sender, SimpleResult e)
    {

      //    _syncContext.Post(
      //delegate
      //{
      //  ReportDroppedResult(e);
      //},
      //null);
    }

    private void OnLiveImageArrived(IAsyncResult result)
    {
      try
      {
        Image image = cSystem.EndGetLiveImage(result);
        var bitmap = new Bitmap(image, iMaxWidth, iMaxHeight);
        using (var gp = Graphics.FromImage(bitmap))
        {
          Pen pen_Blue = new Pen(Color.Blue, 2);
          gp.DrawRectangle(pen_Blue, sROI);
        }
        image = bitmap;

        Size image_size = Gui.FitImageInControl(image.Size, picLiveImage.Size);
        Image fitted_image = Gui.ResizeImageToBitmap(image, image_size);
        picLiveImage.Image = fitted_image;
        picLiveImage.Invalidate();

        if (bLive)
        {
          cSystem.BeginGetLiveImage(
            ImageFormat.jpeg,
            ImageSize.Sixteenth,
            ImageQuality.Medium,
            OnLiveImageArrived,
            null);
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
      }
    }

    private void ShowResult(ComplexResult complexResult)
    {
      List<Image> images = new List<Image>();
      List<string> image_graphics = new List<string>();
      string read_result = null;
      int result_id = -1;
      ResultTypes collected_results = ResultTypes.None;

      // Take a reference or copy values from the locked result info object. This is done
      // so that the lock is used only for a short period of time.
      lock (this)
      {
        foreach (var simple_result in complexResult.SimpleResults)
        {
          collected_results |= simple_result.Id.Type;

          switch (simple_result.Id.Type)
          {
            case ResultTypes.Image:
              Image image = ImageArrivedEventArgs.GetImageFromImageBytes(simple_result.Data);
              if (image != null)
                images.Add(image);
              break;

            case ResultTypes.ImageGraphics:
              Type d = simple_result.GetType();
              image_graphics.Add(simple_result.GetDataAsString());
              break;

            case ResultTypes.ReadXml:
              read_result = GetReadStringFromResultXml(simple_result.GetDataAsString());
              result_id = simple_result.Id.Id;
              break;

            case ResultTypes.ReadString:
              read_result = simple_result.GetDataAsString();
              result_id = simple_result.Id.Id;
              break;
          }
        }
      }
      strBcr = read_result;
      //AddListItem(string.Format("Complex result arrived: resultId = {0}, read result = {1}", result_id, read_result));
      //Log("Complex result contains", string.Format("{0}", collected_results.ToString()));

      // 바코드 인식 실패 처리 하고 저장할 것
      if (images.Count > 0)
      {
        Image first_image = images[0];
        readImage = (Image)first_image.Clone();

        Size image_size = Gui.FitImageInControl(first_image.Size, picLiveImage.Size);
        Image fitted_image = Gui.ResizeImageToBitmap(first_image, image_size);

        if (image_graphics.Count > 0)
        {
          using (Graphics g = Graphics.FromImage(fitted_image))
          {
            foreach (var graphics in image_graphics)
            {
              ResultGraphics rg = GraphicsResultParser.Parse(graphics, new Rectangle(0, 0, image_size.Width, image_size.Height));
              ResultGraphicsRenderer.PaintResults(g, rg);
            }
          }
        }

        if (picLiveImage.Image != null)
        {
          var image = picLiveImage.Image;
          picLiveImage.Image = null;
          image.Dispose();
        }

        picLiveImage.Image = fitted_image;
        picLiveImage.Invalidate();
      }

      //if (read_result != null)
      //  picLiveImage.Text = read_result;
    }

    private string GetReadStringFromResultXml(string resultXml)
    {
      try
      {
        XmlDocument doc = new XmlDocument();

        doc.LoadXml(resultXml);

        XmlNode full_string_node = doc.SelectSingleNode("result/general/full_string");

        if (full_string_node != null && cSystem != null && cSystem.State == ConnectionState.Connected)
        {
          XmlAttribute encoding = full_string_node.Attributes["encoding"];
          if (encoding != null && encoding.InnerText == "base64")
          {
            if (!string.IsNullOrEmpty(full_string_node.InnerText))
            {
              byte[] code = Convert.FromBase64String(full_string_node.InnerText);
              return cSystem.Encoding.GetString(code, 0, code.Length);
            }
            else
            {
              return "";
            }
          }

          return full_string_node.InnerText;
        }
      }
      catch
      {
      }

      return "";
    }

    #endregion
  }
}
