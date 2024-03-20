using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BASE
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      bool bnew = false;
      System.Threading.Mutex mutex = new System.Threading.Mutex(true, "MutexName", out bnew);
      if (bnew)
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new FormMother());
        mutex.ReleaseMutex();
      }
      else
      {
        MessageBox.Show("Already exist on Process.");
        Application.Exit();
      } 
    }
  }
}
