using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.IO;

using BASE.MASTER;
using BASE.FORM;
using BASE.PROCESS;
using BASE.MODULE.MOTION;


namespace BASE.VO
{

  #region Alarm
  public enum enumAlarmStop
  {
    NONE = 0,
    B2140_PLC_AW_LE_Ready_Error,
    B2141_PLC_AW_LE_Motor_Error,
    B2142_PLC_AW_LE_Limit_Error,
    B2143_PLC_AW_LE_PLC_Error,
    B2144_PLC_AW_UE1_Ready_Error,
    B2145_PLC_AW_UE1_Motor_Error,
    B2146_PLC_AW_UE1_Limit_Error,
    B2147_PLC_AW_UE1_PLC_Error,
    B2148_PLC_AW_UE2_Ready_Error,
    B2149_PLC_AW_UE2_Motor_Error,
    B214A_PLC_AW_UE2_Limit_Error,
    B214B_PLC_AW_UE2_PLC_Error,
    B214C_PLC_AW_UE3_Ready_Error,
    B214D_PLC_AW_UE3_Motor_Error,
    B214E_PLC_AW_UE3_Limit_Error,
    B214F_PLC_AW_UE3_PLC_Error,
    B2150_PLC_AW_UE4_Ready_Error,
    B2151_PLC_AW_UE4_Motor_Error,
    B2152_PLC_AW_UE4_Limit_Error,
    B2153_PLC_AW_UE4_PLC_Error,
    B2154_PLC_AW_BCX_Ready_Error,
    B2155_PLC_AW_BCX_Motor_Error,
    B2156_PLC_AW_BCX_Limit_Error,
    B2157_PLC_AW_BCX_PLC_Error,
    B2158_PLC_AW_BCY_Ready_Error,
    B2159_PLC_AW_BCY_Motor_Error,
    B215A_PLC_AW_BCY_Limit_Error,
    B215B_PLC_AW_BCY_PLC_Error,
    B215C_PLC_AW_LP_Ready_Error,
    B215D_PLC_AW_LP_Motor_Error,
    B215E_PLC_AW_LP_Limit_Error,
    B215F_PLC_AW_LP_PLC_Error,
    B2160_PLC_AW_UPX_Ready_Error,
    B2161_PLC_AW_UPX_Motor_Error,
    B2162_PLC_AW_UPX_Limit_Error,
    B2163_PLC_AW_UPX_PLC_Error,
    B2164_PLC_AW_UPY_Ready_Error,
    B2165_PLC_AW_UPY_Motor_Error,
    B2166_PLC_AW_UPY_Limit_Error,
    B2167_PLC_AW_UPY_PLC_Error,
    B2168_PLC_AW_Z1_Ready_Error,
    B2169_PLC_AW_Z1_Motor_Error,
    B216A_PLC_AW_Z1_Limit_Error,
    B216B_PLC_AW_Z1_PLC_Error,
    B216C_PLC_AW_Z2_Ready_Error,
    B216D_PLC_AW_Z2_Motor_Error,
    B216E_PLC_AW_Z2_Limit_Error,
    B216F_PLC_AW_Z2_PLC_Error,
    B2170_PLC_AW_ALX_Ready_Error,
    B2171_PLC_AW_ALX_Motor_Error,
    B2172_PLC_AW_ALX_Limit_Error,
    B2173_PLC_AW_ALX_PLC_Error,
    B2174_PLC_AW_ALY_Ready_Error,
    B2175_PLC_AW_ALY_Motor_Error,
    B2176_PLC_AW_ALY_Limit_Error,
    B2177_PLC_AW_ALY_PLC_Error,
    B2178_PLC_AW_X1_Ready_Error,
    B2179_PLC_AW_X1_Motor_Error,
    B217A_PLC_AW_X1_Limit_Error,
    B217B_PLC_AW_X1_PLC_Error,
    B217C_PLC_AW_X2_Ready_Error,
    B217D_PLC_AW_X2_Motor_Error,
    B217E_PLC_AW_X2_Limit_Error,
    B217F_PLC_AW_X2_PLC_Error,
    B2180_PLC_AW_PR1_Ready_Error,
    B2181_PLC_AW_PR1_Motor_Error,
    B2182_PLC_AW_PR1_Limit_Error,
    B2183_PLC_AW_PR1_PLC_Error,
    B2184_PLC_AW_PR2_Ready_Error,
    B2185_PLC_AW_PR2_Motor_Error,
    B2186_PLC_AW_PR2_Limit_Error,
    B2187_PLC_AW_PR2_PLC_Error,
    B2188_PLC_AW_PR3_Ready_Error,
    B2189_PLC_AW_PR3_Motor_Error,
    B218A_PLC_AW_PR3_Limit_Error,
    B218B_PLC_AW_PR3_PLC_Error,
    B218C_PLC_AW_PR4_Ready_Error,
    B218D_PLC_AW_PR4_Motor_Error,
    B218E_PLC_AW_PR4_Limit_Error,
    B218F_PLC_AW_PR4_PLC_Error,
    B2190_PLC_,
    B2191_PLC_,
    B2192_PLC_,
    B2193_PLC_,
    B2194_PLC_,
    B2195_PLC_,
    B2196_PLC_,
    B2197_PLC_,
    B2198_PLC_,
    B2199_PLC_,
    B219A_PLC_,
    B219B_PLC_,
    B219C_PLC_,
    B219D_PLC_,
    B219E_PLC_,
    B219F_PLC_,
    B21A0_PLC_,
    B21A1_PLC_,
    B21A2_PLC_,
    B21A3_PLC_,
    B21A4_PLC_,
    B21A5_PLC_,
    B21A6_PLC_,
    B21A7_PLC_,
    B21A8_PLC_,
    B21A9_PLC_,
    B21AA_PLC_,
    B21AB_PLC_,
    B21AC_PLC_,
    B21AD_PLC_,
    B21AE_PLC_,
    B21AF_PLC_,
    B21B0_PLC_,
    B21B1_PLC_,
    B21B2_PLC_,
    B21B3_PLC_,
    B21B4_PLC_,
    B21B5_PLC_,
    B21B6_PLC_,
    B21B7_PLC_,
    B21B8_PLC_,
    B21B9_PLC_,
    B21BA_PLC_,
    B21BB_PLC_,
    B21BC_PLC_,
    B21BD_PLC_,
    B21BE_PLC_,
    B21BF_PLC_,
    B21C0_PLC_AW_LE_Position_Data_Error,
    B21C1_PLC_AW_UE1_Position_Data_Error,
    B21C2_PLC_AW_UE2_Position_Data_Error,
    B21C3_PLC_AW_UE3_Position_Data_Error,
    B21C4_PLC_AW_UE4_Position_Data_Error,
    B21C5_PLC_AW_BCX_Position_Data_Error,
    B21C6_PLC_AW_BCY_Position_Data_Error,
    B21C7_PLC_AW_LP_Position_Data_Error,
    B21C8_PLC_AW_UPX_Position_Data_Error,
    B21C9_PLC_AW_UPY_Position_Data_Error,
    B21CA_PLC_AW_Z1_Position_Data_Error,
    B21CB_PLC_AW_Z2_Position_Data_Error,
    B21CC_PLC_AW_ALX_Position_Data_Error,
    B21CD_PLC_AW_ALY_Position_Data_Error,
    B21CE_PLC_AW_X1_Position_Data_Error,
    B21CF_PLC_AW_X2_Position_Data_Error,
    B21D0_PLC_AW_PR1_Position_Data_Error,
    B21D1_PLC_AW_PR2_Position_Data_Error,
    B21D2_PLC_AW_PR3_Position_Data_Error,
    B21D3_PLC_AW_PR4_Position_Data_Error,
    B21D4_PLC_,
    B21D5_PLC_,
    B21D6_PLC_,
    B21D7_PLC_,
    B21D8_PLC_,
    B21D9_PLC_,
    B21DA_PLC_,
    B21DB_PLC_,
    B21DC_PLC_,
    B21DD_PLC_,
    B21DE_PLC_,
    B21DF_PLC_,
    B21E0_PLC_,
    B21E1_PLC_,
    B21E2_PLC_,
    B21E3_PLC_,
    B21E4_PLC_,
    B21E5_PLC_,
    B21E6_PLC_,
    B21E7_PLC_,
    B21E8_PLC_,
    B21E9_PLC_,
    B21EA_PLC_,
    B21EB_PLC_,
    B21EC_PLC_,
    B21ED_PLC_,
    B21EE_PLC_,
    B21EF_PLC_,
    B21F0_PLC_,
    B21F1_PLC_,
    B21F2_PLC_,
    B21F3_PLC_,
    B21F4_PLC_,
    B21F5_PLC_,
    B21F6_PLC_,
    B21F7_PLC_,
    B21F8_PLC_,
    B21F9_PLC_,
    B21FA_PLC_,
    B21FB_PLC_,
    B21FC_PLC_,
    B21FD_PLC_,
    B21FE_PLC_,
    B21FF_PLC_,
    B2200_PLC_AW_Front_EMO_Error,
    B2201_PLC_AW_Left_EMO_Error,
    B2202_PLC_AW_Back_EMO_Error,
    B2203_PLC_AW_Right_EMO_Error,
    B2204_PLC_AW_Main_Air_Low_Pressure_Error,
    B2205_PLC_AW_CP_ELCB_TRIP_Error,
    B2206_PLC_AW_Stage1_Probe_Collision_Error,
    B2207_PLC_AW_Stage2_Probe_Collision_Error,
    B2208_PLC_,
    B2209_PLC_,
    B220A_PLC_,
    B220B_PLC_,
    B220C_PLC_,
    B220D_PLC_,
    B220E_PLC_AW_Power_Switch_Off_Error,
    B220F_PLC_AW_Servo_Off_Error,
    B2210_PLC_,
    B2211_PLC_,
    B2212_PLC_,
    B2213_PLC_,
    B2214_PLC_,
    B2215_PLC_,
    B2216_PLC_,
    B2217_PLC_,
    B2218_PLC_,
    B2219_PLC_,
    B221A_PLC_,
    B221B_PLC_,
    B221C_PLC_,
    B221D_PLC_,
    B221E_PLC_,
    B221F_PLC_,
    B2220_PLC_BH_Door_Open_Error_Home,
    B2221_PLC_,
    B2222_PLC_BH_Moving_Error_Home,
    B2223_PLC_BH_Home_Not_Complete_Error_Home,
    B2224_PLC_BH_LP_Up_Sensor_Off_Error_Home,
    B2225_PLC_BH_UP_Up_Sensor_Off_Error_Home,
    B2226_PLC_,
    B2227_PLC_,
    B2228_PLC_,
    B2229_PLC_BH_Z1_Over_Ready_Position_Error_Home,
    B222A_PLC_BH_Z2_Over_Ready_Position_Error_Home,
    B222B_PLC_BH_LE_ZeroPos_Over_Error_Home,
    B222C_PLC_,
    B222D_PLC_,
    B222E_PLC_,
    B222F_PLC_,
    B2230_PLC_OB_Door_Open_Error_Home,
    B2231_PLC_OB_LP_Up_Sensor_Off_Error_Home,
    B2232_PLC_OB_UP_Up_Sensor_Off_Error_Home,
    B2233_PLC_,
    B2234_PLC_,
    B2235_PLC_,
    B2236_PLC_,
    B2237_PLC_,
    B2238_PLC_,
    B2239_PLC_,
    B223A_PLC_,
    B223B_PLC_,
    B223C_PLC_,
    B223D_PLC_,
    B223E_PLC_,
    B223F_PLC_,
    B2240_PLC_BH_Door_Open_Error_Teaching,
    B2241_PLC_BH_No_Speed_Error_Teaching,
    B2242_PLC_BH_Moving_Error_Teaching,
    B2243_PLC_BH_Home_Not_Complete_Error_Teaching,
    B2244_PLC_BH_LP_Up_Sensor_Off_Error_Teaching,
    B2245_PLC_BH_UP_Up_Sensor_Off_Error_Teaching,
    B2246_PLC_BH_Stage1_Probe_Collision_Error_Teaching,
    B2247_PLC_BH_Stage2_Probe_Collision_Error_Teaching,
    B2248_PLC_,
    B2249_PLC_BH_Z1_Over_Ready_Position_Error_Teaching,
    B224A_PLC_BH_Z2_Over_Ready_Position_Error_Teaching,
    B224B_PLC_BH_LE_ZeroPos_Over_Error_Teaching,
    B224C_PLC_BH_LP_Collision_Error,
    B224D_PLC_BH_BCX_ZeroPos_Over_Error,
    B224E_PLC_,
    B224F_PLC_,
    B2250_PLC_OB_Door_Open_Error_Teaching,
    B2251_PLC_OB_Stage1_Probe_Collision_Error_Teaching,
    B2252_PLC_OB_Stage2_Probe_Collision_Error_Teaching,
    B2253_PLC_,
    B2254_PLC_,
    B2255_PLC_,
    B2256_PLC_,
    B2257_PLC_,
    B2258_PLC_,
    B2259_PLC_,
    B225A_PLC_,
    B225B_PLC_,
    B225C_PLC_,
    B225D_PLC_,
    B225E_PLC_,
    B225F_PLC_,
    B2260_PLC_BH_Door_Open_Error_LEAlignReady,
    B2261_PLC_BH_No_Speed_Error_LEAlignReady,
    B2262_PLC_BH_Moving_Error_LEAlignReady,
    B2263_PLC_BH_Home_Not_Complete_Error_LEAlignReady,
    B2264_PLC_BH_LE_No_Product_Error_LEAlignReady,
    B2265_PLC_,
    B2266_PLC_,
    B2267_PLC_,
    B2268_PLC_,
    B2269_PLC_,
    B226A_PLC_,
    B226B_PLC_,
    B226C_PLC_,
    B226D_PLC_,
    B226E_PLC_,
    B226F_PLC_,
    B2270_PLC_OB_LE_Align_Fail_Error_LEAlignReady,
    B2271_PLC_OB_LE_Lot_Complete_LEAlignReady,
    B2272_PLC_OB_Max_Limit_Over_Error_LEAlignReady,
    B2273_PLC_,
    B2274_PLC_,
    B2275_PLC_,
    B2276_PLC_,
    B2277_PLC_,
    B2278_PLC_,
    B2279_PLC_,
    B227A_PLC_,
    B227B_PLC_,
    B227C_PLC_,
    B227D_PLC_,
    B227E_PLC_,
    B227F_PLC_,
    B2280_PLC_BH_Door_Open_Error_UE1AlignReady,
    B2281_PLC_BH_No_Speed_Error_UE1AlignReady,
    B2282_PLC_BH_Moving_Error_UE1AlignReady,
    B2283_PLC_BH_Home_Not_Complete_Error_UE1AlignReady,
    B2284_PLC_,
    B2285_PLC_,
    B2286_PLC_,
    B2287_PLC_,
    B2288_PLC_,
    B2289_PLC_,
    B228A_PLC_,
    B228B_PLC_,
    B228C_PLC_,
    B228D_PLC_,
    B228E_PLC_,
    B228F_PLC_,
    B2290_PLC_OB_UE1_Align_Fail_Error_UE1AlignReady,
    B2291_PLC_,
    B2292_PLC_,
    B2293_PLC_,
    B2294_PLC_,
    B2295_PLC_,
    B2296_PLC_,
    B2297_PLC_,
    B2298_PLC_,
    B2299_PLC_,
    B229A_PLC_,
    B229B_PLC_,
    B229C_PLC_,
    B229D_PLC_,
    B229E_PLC_,
    B229F_PLC_,
    B22A0_PLC_BH_Door_Open_Error_UE2AlignReady,
    B22A1_PLC_BH_No_Speed_Error_UE2AlignReady,
    B22A2_PLC_BH_Moving_Error_UE2AlignReady,
    B22A3_PLC_BH_Home_Not_Complete_Error_UE2AlignReady,
    B22A4_PLC_,
    B22A5_PLC_,
    B22A6_PLC_,
    B22A7_PLC_,
    B22A8_PLC_,
    B22A9_PLC_,
    B22AA_PLC_,
    B22AB_PLC_,
    B22AC_PLC_,
    B22AD_PLC_,
    B22AE_PLC_,
    B22AF_PLC_,
    B22B0_PLC_OB_UE2_Align_Fail_Error_UE2AlignReady,
    B22B1_PLC_,
    B22B2_PLC_,
    B22B3_PLC_,
    B22B4_PLC_,
    B22B5_PLC_,
    B22B6_PLC_,
    B22B7_PLC_,
    B22B8_PLC_,
    B22B9_PLC_,
    B22BA_PLC_,
    B22BB_PLC_,
    B22BC_PLC_,
    B22BD_PLC_,
    B22BE_PLC_,
    B22BF_PLC_,
    B22C0_PLC_BH_Door_Open_Error_UE3AlignReady,
    B22C1_PLC_BH_No_Speed_Error_UE3AlignReady,
    B22C2_PLC_BH_Moving_Error_UE3AlignReady,
    B22C3_PLC_BH_Home_Not_Complete_Error_UE3AlignReady,
    B22C4_PLC_,
    B22C5_PLC_,
    B22C6_PLC_,
    B22C7_PLC_,
    B22C8_PLC_,
    B22C9_PLC_,
    B22CA_PLC_,
    B22CB_PLC_,
    B22CC_PLC_,
    B22CD_PLC_,
    B22CE_PLC_,
    B22CF_PLC_,
    B22D0_PLC_OB_UE3_Align_Fail_Error_UE3AlignReady,
    B22D1_PLC_,
    B22D2_PLC_,
    B22D3_PLC_,
    B22D4_PLC_,
    B22D5_PLC_,
    B22D6_PLC_,
    B22D7_PLC_,
    B22D8_PLC_,
    B22D9_PLC_,
    B22DA_PLC_,
    B22DB_PLC_,
    B22DC_PLC_,
    B22DD_PLC_,
    B22DE_PLC_,
    B22DF_PLC_,
    B22E0_PLC_BH_Door_Open_Error_UE4AlignReady,
    B22E1_PLC_BH_No_Speed_Error_UE4AlignReady,
    B22E2_PLC_BH_Moving_Error_UE4AlignReady,
    B22E3_PLC_BH_Home_Not_Complete_Error_UE4AlignReady,
    B22E4_PLC_,
    B22E5_PLC_,
    B22E6_PLC_,
    B22E7_PLC_,
    B22E8_PLC_,
    B22E9_PLC_,
    B22EA_PLC_,
    B22EB_PLC_,
    B22EC_PLC_,
    B22ED_PLC_,
    B22EE_PLC_,
    B22EF_PLC_,
    B22F0_PLC_OB_UE4_Align_Fail_Error_UE4AlignReady,
    B22F1_PLC_,
    B22F2_PLC_,
    B22F3_PLC_,
    B22F4_PLC_,
    B22F5_PLC_,
    B22F6_PLC_,
    B22F7_PLC_,
    B22F8_PLC_,
    B22F9_PLC_,
    B22FA_PLC_,
    B22FB_PLC_,
    B22FC_PLC_,
    B22FD_PLC_,
    B22FE_PLC_,
    B22FF_PLC_,
    B2300_PLC_BH_Door_Open_Error_LEtoLP,
    B2301_PLC_BH_No_Speed_Error_LEtoLP,
    B2302_PLC_BH_Moving_Error_LEtoLP,
    B2303_PLC_BH_Home_Not_Complete_Error_LEtoLP,
    B2304_PLC_BH_LP_Up_Sensor_Off_Error_LEtoLP,
    B2305_PLC_,
    B2306_PLC_,
    B2307_PLC_BH_LP_Air_On_Error_LEtoLP,
    B2308_PLC_,
    B2309_PLC_BH_Barcode_ReadFail_Error_LEtoLP,
    B230A_PLC_BH_LE_PCB_Not_Exist_Error_LEtoLP,
    B230B_PLC_,
    B230C_PLC_,
    B230D_PLC_,
    B230E_PLC_,
    B230F_PLC_,
    B2310_PLC_OH_LP_Up_Sensor_Off_Error_LEtoLP,
    B2311_PLC_OH_LP_Down_Sensor_Off_Error_LEtoLP,
    B2312_PLC_OH_LP_Air_Error_LEtoLP,
    B2313_PLC_,
    B2314_PLC_,
    B2315_PLC_,
    B2316_PLC_,
    B2317_PLC_,
    B2318_PLC_,
    B2319_PLC_,
    B231A_PLC_,
    B231B_PLC_,
    B231C_PLC_,
    B231D_PLC_,
    B231E_PLC_,
    B231F_PLC_,
    B2320_PLC_BH_Door_Open_Error_LPtoAL,
    B2321_PLC_BH_No_Speed_Error_LPtoAL,
    B2322_PLC_BH_Moving_Error_LPtoAL,
    B2323_PLC_BH_Home_Not_Complete_Error_LPtoAL,
    B2324_PLC_,
    B2325_PLC_,
    B2326_PLC_,
    B2327_PLC_BH_LP_Air_Error_LPtoAL,
    B2328_PLC_,
    B2329_PLC_BH_AL_PCB_Exist_Error_LPtoAL,
    B232A_PLC_,
    B232B_PLC_,
    B232C_PLC_,
    B232D_PLC_,
    B232E_PLC_,
    B232F_PLC_,
    B2330_PLC_OB_LP_Up_Sensor_Off_Error_LPtoAL,
    B2331_PLC_OB_LP_Down_Sensor_Off_Error_LPtoAL,
    B2332_PLC_OB_LP_Air_Error_LPtoAL,
    B2333_PLC_OB_Align_No_PCB_Error_LPtoAL,
    B2334_PLC_,
    B2335_PLC_OB_LP_PCB_Drop_Error_LPtoAL,
    B2336_PLC_,
    B2337_PLC_,
    B2338_PLC_,
    B2339_PLC_,
    B233A_PLC_,
    B233B_PLC_,
    B233C_PLC_,
    B233D_PLC_,
    B233E_PLC_,
    B233F_PLC_,
    B2340_PLC_BH_Door_Open_Error_AL,
    B2341_PLC_BH_No_Speed_Error_AL,
    B2342_PLC_BH_Moving_Error_AL,
    B2343_PLC_BH_Home_Not_Complete_Error_AL,
    B2344_PLC_BH_LP_Up_Sensor_Off_Error_AL,
    B2345_PLC_,
    B2346_PLC_,
    B2347_PLC_,
    B2348_PLC_,
    B2349_PLC_BH_Align_No_PCB_Error_AL,
    B234A_PLC_BH_ALX_ReadyPos_Over_Error_AL,
    B234B_PLC_BH_ALY_ReadyPos_Over_Error_AL,
    B234C_PLC_BH_ALX_Align_BackOffset_Over_Error_AL,
    B234D_PLC_BH_ALY_Align_BackOffset_Over_Error_AL,
    B234E_PLC_,
    B234F_PLC_,
    B2350_PLC_,
    B2351_PLC_,
    B2352_PLC_,
    B2353_PLC_,
    B2354_PLC_,
    B2355_PLC_,
    B2356_PLC_,
    B2357_PLC_,
    B2358_PLC_,
    B2359_PLC_,
    B235A_PLC_,
    B235B_PLC_,
    B235C_PLC_,
    B235D_PLC_,
    B235E_PLC_,
    B235F_PLC_,
    B2360_PLC_BH_Door_Open_Error_ALtoLP,
    B2361_PLC_BH_No_Speed_Error_ALtoLP,
    B2362_PLC_BH_Moving_Error_ALtoLP,
    B2363_PLC_BH_Home_Not_Complete_Error_ALtoLP,
    B2364_PLC_BH_LP_Up_Sensor_Off_Error_ALtoLP,
    B2365_PLC_,
    B2366_PLC_,
    B2367_PLC_BH_LP_Air_On_Error_ALtoLP,
    B2368_PLC_,
    B2369_PLC_,
    B236A_PLC_,
    B236B_PLC_,
    B236C_PLC_,
    B236D_PLC_,
    B236E_PLC_,
    B236F_PLC_,
    B2370_PLC_OH_LP_Up_Sensor_Off_Error_ALtoLP,
    B2371_PLC_OH_LP_Down_Sensor_Off_Error_ALtoLP,
    B2372_PLC_OH_LP_Air_Error_ALtoLP,
    B2373_PLC_OH_AL_PCB_Exist_Error_ALtoLP,
    B2374_PLC_,
    B2375_PLC_,
    B2376_PLC_,
    B2377_PLC_,
    B2378_PLC_,
    B2379_PLC_,
    B237A_PLC_,
    B237B_PLC_,
    B237C_PLC_,
    B237D_PLC_,
    B237E_PLC_,
    B237F_PLC_,
    B2380_PLC_BH_Door_Open_Error_LPtoStage1,
    B2381_PLC_BH_No_Speed_Error_LPtoStage1,
    B2382_PLC_BH_Moving_Error_LPtoStage1,
    B2383_PLC_BH_Home_Not_Complete_Error_LPtoStage1,
    B2384_PLC_BH_LP_Up_Sensor_Off_Error_LPtoStage1,
    B2385_PLC_,
    B2386_PLC_BH_Stage1_Air_On_Error_LPtoStage1,
    B2387_PLC_BH_LP_Air_Off_Error_LPtoStage1,
    B2388_PLC_,
    B2389_PLC_,
    B238A_PLC_BH_Z1_Reade_Position_Error_LPtoStage1,
    B238B_PLC_,
    B238C_PLC_,
    B238D_PLC_,
    B238E_PLC_,
    B238F_PLC_,
    B2390_PLC_OB_LP_Up_Sensor_Off_Error_LPtoStage1,
    B2391_PLC_OB_LP_Down_Sensor_Off_Error_LPtoStage1,
    B2392_PLC_OB_LP_Air_Error_LPtoStage1,
    B2393_PLC_OB_Stage1_Air_Error_LPtoStage1,
    B2394_PLC_,
    B2395_PLC_OB_LP_PCB_Drop_Error_LPtoStage1,
    B2396_PLC_,
    B2397_PLC_,
    B2398_PLC_,
    B2399_PLC_,
    B239A_PLC_,
    B239B_PLC_,
    B239C_PLC_,
    B239D_PLC_,
    B239E_PLC_,
    B239F_PLC_,
    B23A0_PLC_BH_Door_Open_Error_LPtoStage2,
    B23A1_PLC_BH_No_Speed_Error_LPtoStage2,
    B23A2_PLC_BH_Moving_Error_LPtoStage2,
    B23A3_PLC_BH_Home_Not_Complete_Error_LPtoStage2,
    B23A4_PLC_BH_LP_Up_Sensor_Off_Error_LPtoStage2,
    B23A5_PLC_,
    B23A6_PLC_BH_Stage2_Air_On_Error_LPtoStage2,
    B23A7_PLC_BH_LP_Air_Off_Error_LPtoStage2,
    B23A8_PLC_,
    B23A9_PLC_,
    B23AA_PLC_BH_Z2_Reade_Position_Error_LPtoStage2,
    B23AB_PLC_,
    B23AC_PLC_,
    B23AD_PLC_,
    B23AE_PLC_,
    B23AF_PLC_,
    B23B0_PLC_OB_LP_Up_Sensor_Off_Error_LPtoStage2,
    B23B1_PLC_OB_LP_Down_Sensor_Off_Error_LPtoStage2,
    B23B2_PLC_OB_LP_Air_Error_LPtoStage2,
    B23B3_PLC_OB_Stage2_Air_Error_LPtoStage2,
    B23B4_PLC_,
    B23B5_PLC_OB_LP_PCB_Drop_Error_LPtoStage2,
    B23B6_PLC_,
    B23B7_PLC_,
    B23B8_PLC_,
    B23B9_PLC_,
    B23BA_PLC_,
    B23BB_PLC_,
    B23BC_PLC_,
    B23BD_PLC_,
    B23BE_PLC_,
    B23BF_PLC_,
    B23C0_PLC_BH_Door_Open_Error_Stage1Zero,
    B23C1_PLC_BH_No_Speed_Error_Stage1Zero,
    B23C2_PLC_BH_Moving_Error_Stage1Zero,
    B23C3_PLC_BH_Home_Not_Complete_Error_Stage1Zero,
    B23C4_PLC_,
    B23C5_PLC_,
    B23C6_PLC_BH_Stage1_Air_On_Error_Stage1Zero,
    B23C7_PLC_,
    B23C8_PLC_,
    B23C9_PLC_,
    B23CA_PLC_,
    B23CB_PLC_,
    B23CC_PLC_,
    B23CD_PLC_,
    B23CE_PLC_,
    B23CF_PLC_,
    B23D0_PLC_,
    B23D1_PLC_,
    B23D2_PLC_,
    B23D3_PLC_OB_Stage1_Air_Error_Stage1Zero,
    B23D4_PLC_OB_Stage1_Probe_Collision_Error_Stage1Zero,
    B23D5_PLC_,
    B23D6_PLC_,
    B23D7_PLC_,
    B23D8_PLC_,
    B23D9_PLC_,
    B23DA_PLC_,
    B23DB_PLC_,
    B23DC_PLC_,
    B23DD_PLC_,
    B23DE_PLC_,
    B23DF_PLC_,
    B23E0_PLC_BH_Door_Open_Error_Stage2Zero,
    B23E1_PLC_BH_No_Speed_Error_Stage2Zero,
    B23E2_PLC_BH_Moving_Error_Stage2Zero,
    B23E3_PLC_BH_Home_Not_Complete_Error_Stage2Zero,
    B23E4_PLC_,
    B23E5_PLC_,
    B23E6_PLC_BH_Stage2_Air_On_Error_Stage2Zero,
    B23E7_PLC_,
    B23E8_PLC_,
    B23E9_PLC_,
    B23EA_PLC_,
    B23EB_PLC_,
    B23EC_PLC_,
    B23ED_PLC_,
    B23EE_PLC_,
    B23EF_PLC_,
    B23F0_PLC_,
    B23F1_PLC_,
    B23F2_PLC_,
    B23F3_PLC_OB_Stage2_Air_Error_Stage2Zero,
    B23F4_PLC_OB_Stage2_Probe_Collision_Error_Stage2Zero,
    B23F5_PLC_,
    B23F6_PLC_,
    B23F7_PLC_,
    B23F8_PLC_,
    B23F9_PLC_,
    B23FA_PLC_,
    B23FB_PLC_,
    B23FC_PLC_,
    B23FD_PLC_,
    B23FE_PLC_,
    B23FF_PLC_,
    B2400_PLC_BH_Door_Open_Error_Stage1Measure,
    B2401_PLC_BH_No_Speed_Error_Stage1Measure,
    B2402_PLC_BH_Moving_Error_Stage1Measure,
    B2403_PLC_BH_Home_Not_Complete_Error_Stage1Measure,
    B2404_PLC_,
    B2405_PLC_,
    B2406_PLC_BH_Stage1_Air_Off_Error_Stage1Measure,
    B2407_PLC_,
    B2408_PLC_,
    B2409_PLC_,
    B240A_PLC_,
    B240B_PLC_,
    B240C_PLC_,
    B240D_PLC_,
    B240E_PLC_,
    B240F_PLC_,
    B2410_PLC_,
    B2411_PLC_,
    B2412_PLC_,
    B2413_PLC_OB_Stage1_Air_Error_Stage1Measure,
    B2414_PLC_OB_Stage1_Probe_Collision_Error_Stage1Measure,
    B2415_PLC_,
    B2416_PLC_,
    B2417_PLC_,
    B2418_PLC_,
    B2419_PLC_,
    B241A_PLC_,
    B241B_PLC_,
    B241C_PLC_,
    B241D_PLC_,
    B241E_PLC_,
    B241F_PLC_,
    B2420_PLC_BH_Door_Open_Error_Stage2Measure,
    B2421_PLC_BH_No_Speed_Error_Stage2Measure,
    B2422_PLC_BH_Moving_Error_Stage2Measure,
    B2423_PLC_BH_Home_Not_Complete_Error_Stage2Measure,
    B2424_PLC_,
    B2425_PLC_,
    B2426_PLC_BH_Stage2_Air_Off_Error_Stage2Measure,
    B2427_PLC_,
    B2428_PLC_,
    B2429_PLC_,
    B242A_PLC_,
    B242B_PLC_,
    B242C_PLC_,
    B242D_PLC_,
    B242E_PLC_,
    B242F_PLC_,
    B2430_PLC_,
    B2431_PLC_,
    B2432_PLC_,
    B2433_PLC_OB_Stage2_Air_Error_Stage2Measure,
    B2434_PLC_OB_Stage2_Probe_Collision_Error_Stage2Measure,
    B2435_PLC_,
    B2436_PLC_,
    B2437_PLC_,
    B2438_PLC_,
    B2439_PLC_,
    B243A_PLC_,
    B243B_PLC_,
    B243C_PLC_,
    B243D_PLC_,
    B243E_PLC_,
    B243F_PLC_,
    B2440_PLC_BH_Door_Open_Error_Stage1toUP,
    B2441_PLC_BH_No_Speed_Error_Stage1toUP,
    B2442_PLC_BH_Moving_Error_Stage1toUP,
    B2443_PLC_BH_Home_Not_Complete_Error_Stage1toUP,
    B2444_PLC_,
    B2445_PLC_BH_UP_Up_Sensor_Off_Error_Stage1toUP,
    B2446_PLC_BH_Stage1_Air_Error_Stage1toUP,
    B2447_PLC_,
    B2448_PLC_BH_UP_Air_On_Error_Stage1toUP,
    B2449_PLC_,
    B244A_PLC_,
    B244B_PLC_,
    B244C_PLC_,
    B244D_PLC_,
    B244E_PLC_,
    B244F_PLC_,
    B2450_PLC_OB_UP_Up_Sensor_Off_Error_Stage1toUP,
    B2451_PLC_OB_UP_Down_Sensor_Off_Error_Stage1toUP,
    B2452_PLC_OB_UP_Air_Error_Stage1toUP,
    B2453_PLC_OB_Stage1_Air_Error_Stage1toUP,
    B2454_PLC_,
    B2455_PLC_,
    B2456_PLC_,
    B2457_PLC_,
    B2458_PLC_,
    B2459_PLC_,
    B245A_PLC_,
    B245B_PLC_,
    B245C_PLC_,
    B245D_PLC_,
    B245E_PLC_,
    B245F_PLC_,
    B2460_PLC_BH_Door_Open_Error_Stage2toUP,
    B2461_PLC_BH_No_Speed_Error_Stage2toUP,
    B2462_PLC_BH_Moving_Error_Stage2toUP,
    B2463_PLC_BH_Home_Not_Complete_Error_Stage2toUP,
    B2464_PLC_,
    B2465_PLC_BH_UP_Up_Sensor_Off_Error_Stage2toUP,
    B2466_PLC_BH_Stage2_Air_On_Error_Stage2toUP,
    B2467_PLC_,
    B2468_PLC_BH_UP_Air_On_Error_Stage2toUP,
    B2469_PLC_,
    B246A_PLC_,
    B246B_PLC_,
    B246C_PLC_,
    B246D_PLC_,
    B246E_PLC_,
    B246F_PLC_,
    B2470_PLC_OB_UP_Up_Sensor_Off_Error_Stage2toUP,
    B2471_PLC_OB_UP_Down_Sensor_Off_Error_Stage2toUP,
    B2472_PLC_OB_UP_Air_Error_Stage2toUP,
    B2473_PLC_OB_Stage1_Air_Error_Stage2toUP,
    B2474_PLC_,
    B2475_PLC_,
    B2476_PLC_,
    B2477_PLC_,
    B2478_PLC_,
    B2479_PLC_,
    B247A_PLC_,
    B247B_PLC_,
    B247C_PLC_,
    B247D_PLC_,
    B247E_PLC_,
    B247F_PLC_,
    B2480_PLC_BH_Door_Open_Error_UPtoUE,
    B2481_PLC_BH_No_Speed_Error_UPtoUE,
    B2482_PLC_BH_Moving_Error_UPtoUE,
    B2483_PLC_BH_Home_Not_Complete_Error_UPtoUE,
    B2484_PLC_,
    B2485_PLC_BH_UP_Up_Sensor_Off_Error_UPtoUE,
    B2486_PLC_,
    B2487_PLC_,
    B2488_PLC_BH_UP_Air_Off_Error_UPtoUE,
    B2489_PLC_,
    B248A_PLC_,
    B248B_PLC_,
    B248C_PLC_,
    B248D_PLC_,
    B248E_PLC_,
    B248F_PLC_,
    B2490_PLC_OB_UP_Up_Sensor_Off_Error_UPtoUE,
    B2491_PLC_OB_UP_Down_Sensor_Off_Error_UPtoUE,
    B2492_PLC_OB_UP_Air_Error_UPtoUE,
    B2493_PLC_,
    B2494_PLC_,
    B2495_PLC_OB_UP_PCB_Drop_Error_UPtoUE,
    B2496_PLC_,
    B2497_PLC_,
    B2498_PLC_,
    B2499_PLC_,
    B249A_PLC_,
    B249B_PLC_,
    B249C_PLC_,
    B249D_PLC_,
    B249E_PLC_,
    B249F_PLC_,
    B24A0_PLC_BH_Door_Open_Error_Stage1Clean,
    B24A1_PLC_BH_No_Speed_Error_Stage1Clean,
    B24A2_PLC_BH_Moving_Error_Stage1Clean,
    B24A3_PLC_BH_Home_Not_Complete_Error_Stage1Clean,
    B24A4_PLC_BH_LP_Up_Sensor_Off_Error_Stage1Clean,
    B24A5_PLC_BH_UP_Up_Sensor_Off_Error_Stage1Clean,
    B24A6_PLC_BH_Stage1_Air_Error_Stage1Clean,
    B24A7_PLC_,
    B24A8_PLC_,
    B24A9_PLC_,
    B24AA_PLC_,
    B24AB_PLC_,
    B24AC_PLC_,
    B24AD_PLC_,
    B24AE_PLC_,
    B24AF_PLC_,
    B24B0_PLC_,
    B24B1_PLC_,
    B24B2_PLC_,
    B24B3_PLC_,
    B24B4_PLC_OB_Stage1_Probe_Collision_Error_Stage1Clean,
    B24B5_PLC_,
    B24B6_PLC_,
    B24B7_PLC_,
    B24B8_PLC_,
    B24B9_PLC_,
    B24BA_PLC_,
    B24BB_PLC_,
    B24BC_PLC_,
    B24BD_PLC_,
    B24BE_PLC_,
    B24BF_PLC_,
    B24C0_PLC_BH_Door_Open_Error_Stage2Clean,
    B24C1_PLC_BH_No_Speed_Error_Stage2Clean,
    B24C2_PLC_BH_Moving_Error_Stage2Clean,
    B24C3_PLC_BH_Home_Not_Complete_Error_Stage2Clean,
    B24C4_PLC_BH_LP_Up_Sensor_Off_Error_Stage2Clean,
    B24C5_PLC_BH_UP_Up_Sensor_Off_Error_Stage2Clean,
    B24C6_PLC_BH_Stage2_Air_Error_Stage2Clean,
    B24C7_PLC_,
    B24C8_PLC_,
    B24C9_PLC_,
    B24CA_PLC_,
    B24CB_PLC_,
    B24CC_PLC_,
    B24CD_PLC_,
    B24CE_PLC_,
    B24CF_PLC_,
    B24D0_PLC_,
    B24D1_PLC_,
    B24D2_PLC_,
    B24D3_PLC_,
    B24D4_PLC_OB_Stage2_Probe_Collision_Error_Stage2Clean,
    B24D5_PLC_,
    B24D6_PLC_,
    B24D7_PLC_,
    B24D8_PLC_,
    B24D9_PLC_,
    B24DA_PLC_,
    B24DB_PLC_,
    B24DC_PLC_,
    B24DD_PLC_,
    B24DE_PLC_,
    B24DF_PLC_,
    B24E0_PLC_,
    B24E1_PLC_,
    B24E2_PLC_,
    B24E3_PLC_,
    B24E4_PLC_,
    B24E5_PLC_,
    B24E6_PLC_,
    B24E7_PLC_,
    B24E8_PLC_,
    B24E9_PLC_,
    B24EA_PLC_,
    B24EB_PLC_,
    B24EC_PLC_,
    B24ED_PLC_,
    B24EE_PLC_,
    B24EF_PLC_,
    B24F0_PLC_,
    B24F1_PLC_,
    B24F2_PLC_,
    B24F3_PLC_,
    B24F4_PLC_,
    B24F5_PLC_,
    B24F6_PLC_,
    B24F7_PLC_,
    B24F8_PLC_,
    B24F9_PLC_,
    B24FA_PLC_,
    B24FB_PLC_,
    B24FC_PLC_,
    B24FD_PLC_,
    B24FE_PLC_,
    B24FF_PLC_,




    N0001_AUTO_RunTimeOut_UE1_Cassette_Wait,
    N0002_AUTO_RunTimeOut_UE2_Cassette_Wait,
    N0003_AUTO_RunTimeOut_UE3_Cassette_Wait,
    N0004_AUTO_RunTimeOut_UE4_Cassette_Wait,
    //N0244_AUTO_RunTimeOut_LP_to_Stage1,
    //N0245_AUTO_RunTimeOut_LP_to_Stage2,
  } // Machine Stop Alarm
  public enum enumAlarmWarn
  {
    NONE = 0,
    OK,
    LoginWrongPassword,
    LoginNoExistUserDBData,
    LoginNoExistID,
    LoginUnallowbleSpace,
    LoginUnallowbleLetter,
    LoginWrongIDPW,
    LoginCanNotAccess,
    LoginBlankRequiredField,
    LoginExistID,
    LoginCreatePwNotCorrect,
    LoginCreateFail,
    LoginManageLoadFail,
    LoginManageNotSelect,
    LoginManageDelFail,
    LoadIoFail,
    WrongData,
    PLCSaveFail,
    PLCLoadFail,
    RecipeNameIsWrong,
    RecipeLoadFail,
    RecipeNoExist,
    RecipeCanNotOpenCurrent,
    RecipeFileNameIsNull,
    RecipeFileNameIsExist,
    RecipeNoSelectedSourceFile,
    RecipeCanNotCreateSameName,
    RecipeCanNotDeleteCurrent,
    RecipeMeasureSaveFail,
    RecipePCBInfoSaveFail,
    SystemStdElevatorSaveFail,
    SystemStdZSaveFail,
    SystemStdUnloaderSaveFail,
    SystemStdStageSaveFail,
    SystemStdLoaderSaveFail,
    SystemStdProbeSaveFail,
    SystemStdAlignSaveFail,
    SystemStdAllSaveFail,
    SystemReadyPosSaveFail,
    SystemNormalSpdSaveFail,
    SystemLowSpdSaveFail,
    SystemAxisAllSaveFail,
    SystemDataAllSaveFail,
    SystemLimitMotorSaveFail,
    SystemLimitAirSaveFail,
    SystemLimitAllSaveFail,
    SystemTimeErrorDelaySaveFail,
    SystemTimeDelaySaveFail,
    SystemTimeRunTimeSaveFail,
    SystemTimeAllSaveFail,
    SystemDataDataSaveFail,
    SystemDataLampSaveFail,
    SystemDataUseProbeSaveFail,
    RecipeBCRROISaveFail,
    DataLogSearchFail,
    DataLogSearchDataWrong,
    SystemComunicationFail,
    LanguageChanged,
    LotEnd, // 랏 엔드 
    PleaseErrorReset, // 에러 상태중 외부 입력 들어왔을때
    DataAlarmSearchFail,
    SystemDataUseSkipSaveFail,
    SystemDataProbeOffsetSaveFail,
    SystemAutoCountAmountSaveFail,
    SystemSafetyZPosSaveFail,
    RecipeOffsetSaveFail,
    SystemSafetyProbePosSaveFail,
    RecipeRangeSaveFail,
    RecipeMeasurePointTypeNotSelected,
    BCRLotDataWrong, // 랏 바코드 데이터 이상
    BCRNotMatched, // 바코드 혼입
    BCRNotRead, // 바코드 미인식
    ExistInBCB, // 처음 랏 구동시 제품이 안에 있음
    InitNotComplete, // 스타트버튼 홈동작 안되어 있음
    MovingNotComplete, // 스타트버튼 구동중
    SMSFail, // SMS 관련 데이터 열기 실패
    SystemDataDisplayColor, // 표시색 저장 실패 
    SMSWriteFail, // SMS 관련 데이터 쓰기 실패
    RemovePCB_LP, // LP 제품 제거 안됨 제품 제거하세요.
    RemovePCB_UP, // UP 제품 제거 안됨 제품 제거하세요.
    RemovePCB_ST1, // ST1 제품 제거 안됨 제품 제거하세요.
    RemovePCB_ST2, // ST2 제품 제거 안됨 제품 제거하세요.
  } // Warning Alarm (non stop)


  /// <summary>
  /// NONE: Cancel
  /// A: AbortRetryIgnore
  /// B: OK
  /// C: OKCancel
  /// D: RetryCancel
  /// E: YesNo
  /// F: YesNoCancel
  /// </summary>
  public enum enumMsg
  {
    NONE_NONE, // Default
    InitialCheck_C, // 이니셜 버튼 누를때 확인
    AllLogView_E, //  로그 전체 검색시 확인
    LotClearCheck_C, // 랏 클리어지 확인
    DataSaveCheck_E, // 데이터 저장시 랏 클리어 할지 확인함.
    ChangeRecipe_E, // 레시피 변경시 확인창 랏도 클리어 됨
    ProgramExit_E,
    RecipeDelete_E,
  }
  #endregion

  #region Language
  public enum enumLanguageType
  {
    Default_Caption = 0, //Do not change Default_Caption!!!
    English,
    Korean,
    Chinese,
    Japanese
  } //Language Type
  #endregion

  #region Login
  public enum enumUserLevel
  {
    Operator = 0,
    Maintenance,
    Administator,
    Developer
  } //Level
  public struct StructUser
  {
    public string strId;
    public string strPw;
    public string strInfo;
    public enumUserLevel eLevel;
  } //User
  #endregion

  #region Form Common
  public enum enumFolderWindowType
  {
    Creat,
    Copy,
  }

  public enum enumTowerLamp
  {
    On,
    Blink,
    Off,
  }

  public enum enumBuzzer
  {
    End,
    Error,
    Off
  }

  public enum enumUEUseMode
  {
    USE_1,
    USE_2,
    USE_3,
    USE_4
  }

  public enum enumRejectZone
  {
    A,
    B,
    C,
    D,
  }

  public enum enumPointType
  {
    NONE,
    Dummy,
    Unit,
  }
  #endregion

  #region Parameter
  [Serializable]
  public class ClassSystemPara
  {
    public ClassSystemPara GetValues()
    {
      using (MemoryStream stream = new MemoryStream())
      {
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        formatter.Serialize(stream, this);
        stream.Position = 0;
        return (ClassSystemPara)formatter.Deserialize(stream);
      }
    } // Deep Copy
    public int iCountAmount { get; set; } // 메인 화면 표기 제품 갯수

    public string strPLC_HostAddress { get; set; }
    public int iPLC_IONumber { get; set; }
    public int iPLC_TimeOut { get; set; }
    public int iPLC_StationNumber { get; set; }
    public int iPLC_CpuType { get; set; }

    public string strBCR_IPAddress { get; set; }

    public string strProbe1_Com { get; set; }
    public string strProbe1_Baudrate { get; set; }
    public string strProbe2_Com { get; set; }
    public string strProbe2_Baudrate { get; set; }

    public int iShakeCount { get; set; }
    public int iLEAirBlowMode { get; set; }
    public int iZerosetPeriod { get; set; }
    public int iStageCleanCount { get; set; }
    public int iProbeCleanCount { get; set; }
    public int iReMeasureCount { get; set; }
    public int iPreStageCleanCount { get; set; }
    public int iAfterStageCleanCount { get; set; }

    public int iLanguage { get; set; }
    public int iDeleteLogPeriod { get; set; }

    public double dLE_LimitCw { get; set; }
    public double dLP_LimitCw { get; set; }
    public double dBCX_LimitCw { get; set; }
    public double dBCY_LimitCw { get; set; }
    public double dALX_LimitCw { get; set; }
    public double dALY_LimitCw { get; set; }
    public double dX1_LimitCw { get; set; }
    public double dX2_LimitCw { get; set; }
    public double dZ1_LimitCw { get; set; }
    public double dZ2_LimitCw { get; set; }
    public double dPR1_LimitCw { get; set; }
    public double dPR2_LimitCw { get; set; }
    public double dPR3_LimitCw { get; set; }
    public double dPR4_LimitCw { get; set; }
    public double dUPX_LimitCw { get; set; }
    public double dUPY_LimitCw { get; set; }
    public double dUE1_LimitCw { get; set; }
    public double dUE2_LimitCw { get; set; }
    public double dUE3_LimitCw { get; set; }
    public double dUE4_LimitCw { get; set; }

    public double dLE_LimitCcw { get; set; }
    public double dLP_LimitCcw { get; set; }
    public double dBCX_LimitCcw { get; set; }
    public double dBCY_LimitCcw { get; set; }
    public double dALX_LimitCcw { get; set; }
    public double dALY_LimitCcw { get; set; }
    public double dX1_LimitCcw { get; set; }
    public double dX2_LimitCcw { get; set; }
    public double dZ1_LimitCcw { get; set; }
    public double dZ2_LimitCcw { get; set; }
    public double dPR1_LimitCcw { get; set; }
    public double dPR2_LimitCcw { get; set; }
    public double dPR3_LimitCcw { get; set; }
    public double dPR4_LimitCcw { get; set; }
    public double dUPX_LimitCcw { get; set; }
    public double dUPY_LimitCcw { get; set; }
    public double dUE1_LimitCcw { get; set; }
    public double dUE2_LimitCcw { get; set; }
    public double dUE3_LimitCcw { get; set; }
    public double dUE4_LimitCcw { get; set; }

    public double dZ1_Safety_Limit { get; set; }
    public double dZ2_Safety_Limit { get; set; }

    public double dProbe_Stage1_Safety_Gap { get; set; }
    public double dProbe_Stage2_Safety_Gap { get; set; }

    public double dMainAir_CylinderLimitMinus { get; set; }
    public double dMainAir_VaccumLimitMinus { get; set; }
    public double dLP_Vacuum_LimitMinus { get; set; }
    public double dUP_Vacuum_LimitMinus { get; set; }
    public double dStage1_Vacuum_LimitMinus { get; set; }
    public double dStage2_Vacuum_LimitMinus { get; set; }

    public double dLP_Vacuum_LimitPlus { get; set; }
    public double dUP_Vacuum_LimitPlus { get; set; }
    public double dStage1_Vacuum_LimitPlus { get; set; }
    public double dStage2_Vacuum_LimitPlus { get; set; }

    public int iErrorDelayTime_Cylinder { get; set; }
    public int iErrorDelayTime_LPVacuum { get; set; }
    public int iErrorDelayTime_UPVacuum { get; set; }
    public int iErrorDelayTime_Stage1Vacuum { get; set; }
    public int iErrorDelayTime_Stage2Vacuum { get; set; }

    public int iDelayTime_Cylinder { get; set; }
    public int iDelayTime_LPVacuum { get; set; }
    public int iDelayTime_UPVacuum { get; set; }
    public int iDelayTime_Stage1Vacuum { get; set; }
    public int iDelayTime_Stage2Vacuum { get; set; }
    public int iDelayTime_Measure { get; set; }
    public int iDelayTime_Align { get; set; }

    public int iRunTime_AirBlow { get; set; }

    public bool bUsePB1 { get; set; } // 프로브 1 사용유무
    public bool bUsePB2 { get; set; } // 프로브 2 사용유무
    public bool bUsePB3 { get; set; } // 프로브 3 사용유무
    public bool bUsePB4 { get; set; } // 프로브 4 사용유무

    public bool bUseBarcode_1D { get; set; } // 1D 바코드 사용 유무
    public bool bUseBarcode_2D { get; set; } // 2D 바코드 사용 유무
    public bool bUseLoadingShake { get; set; } // 털기동작 사용유무

    public double dProbeOffset_1 { get; set; } // 프로브1 측정 offset
    public double dProbeOffset_2 { get; set; } // 프로브2 측정 offset
    public double dProbeOffset_3 { get; set; } // 프로브3 측정 offset
    public double dProbeOffset_4 { get; set; } // 프로브4 측정 offset

    public int iMinDisplayColor { get; set; } // 오토화면 표기 Min 색
    public int iMaxDisplayColor { get; set; } // 오토화면 표기 Max 색

    public int iProbeValueAverageCount { get; set; } // 측정 값 평균낼 갯수 카운터
    public int iProbeValueAverageMin { get; set; } // 측정 값 평균 내기전 min값 뺄 갯수
    public int iProbeValueAverageMax { get; set; } // 측정 값 평균 내기전 max값 뺄 갯수

    public double dCycleTimeOut { get; set; }  //구동 타임아웃

    public double dLE_Ready_Pos { get; set; }
    public double dLP_Ready_Pos { get; set; }
    public double dBCX_Ready_Pos { get; set; }
    public double dBCY_Ready_Pos { get; set; }
    public double dALX_Ready_Pos { get; set; }
    public double dALY_Ready_Pos { get; set; }
    public double dX1_Ready_Pos { get; set; }
    public double dX2_Ready_Pos { get; set; }
    public double dZ1_Ready_Pos { get; set; }
    public double dZ2_Ready_Pos { get; set; }
    public double dPR1_Ready_Pos { get; set; }
    public double dPR2_Ready_Pos { get; set; }
    public double dPR3_Ready_Pos { get; set; }
    public double dPR4_Ready_Pos { get; set; }
    public double dUPX_Ready_Pos { get; set; }
    public double dUPY_Ready_Pos { get; set; }
    public double dUE1_Ready_Pos { get; set; }
    public double dUE2_Ready_Pos { get; set; }
    public double dUE3_Ready_Pos { get; set; }
    public double dUE4_Ready_Pos { get; set; }

    public double dLE_Normal_Spd { get; set; }
    public double dLP_Normal_Spd { get; set; }
    public double dBCX_Normal_Spd { get; set; }
    public double dBCY_Normal_Spd { get; set; }
    public double dALX_Normal_Spd { get; set; }
    public double dALY_Normal_Spd { get; set; }
    public double dX1_Normal_Spd { get; set; }
    public double dX2_Normal_Spd { get; set; }
    public double dZ1_Normal_Spd { get; set; }
    public double dZ2_Normal_Spd { get; set; }
    public double dPR1_Normal_Spd { get; set; }
    public double dPR2_Normal_Spd { get; set; }
    public double dPR3_Normal_Spd { get; set; }
    public double dPR4_Normal_Spd { get; set; }
    public double dUPX_Normal_Spd { get; set; }
    public double dUPY_Normal_Spd { get; set; }
    public double dUE1_Normal_Spd { get; set; }
    public double dUE2_Normal_Spd { get; set; }
    public double dUE3_Normal_Spd { get; set; }
    public double dUE4_Normal_Spd { get; set; }

    public double dLE_Low_Spd { get; set; }
    public double dLP_Low_Spd { get; set; }
    public double dBCX_Low_Spd { get; set; }
    public double dBCY_Low_Spd { get; set; }
    public double dALX_Low_Spd { get; set; }
    public double dALY_Low_Spd { get; set; }
    public double dX1_Low_Spd { get; set; }
    public double dX2_Low_Spd { get; set; }
    public double dZ1_Low_Spd { get; set; }
    public double dZ2_Low_Spd { get; set; }
    public double dPR1_Low_Spd { get; set; }
    public double dPR2_Low_Spd { get; set; }
    public double dPR3_Low_Spd { get; set; }
    public double dPR4_Low_Spd { get; set; }
    public double dUPX_Low_Spd { get; set; }
    public double dUPY_Low_Spd { get; set; }
    public double dUE1_Low_Spd { get; set; }
    public double dUE2_Low_Spd { get; set; }
    public double dUE3_Low_Spd { get; set; }
    public double dUE4_Low_Spd { get; set; }

    public double dLE_ScanStart_Pos { get; set; }
    public double dUE1_ScanStart_Pos { get; set; }
    public double dUE2_ScanStart_Pos { get; set; }
    public double dUE3_ScanStart_Pos { get; set; }
    public double dUE4_ScanStart_Pos { get; set; }

    public double dLE_ScanEnd_Pos { get; set; }
    public double dUE1_ScanEnd_Pos { get; set; }
    public double dUE2_ScanEnd_Pos { get; set; }
    public double dUE3_ScanEnd_Pos { get; set; }
    public double dUE4_ScanEnd_Pos { get; set; }

    public double dLE_Cassette_Wait_Pos { get; set; }
    public double dUE1_Cassette_Wait_Pos { get; set; }
    public double dUE2_Cassette_Wait_Pos { get; set; }
    public double dUE3_Cassette_Wait_Pos { get; set; }
    public double dUE4_Cassette_Wait_Pos { get; set; }

    public double dLE_DownOffset_Pos { get; set; }

    public double dPR1_Center_Pos { get; set; }
    public double dPR2_Center_Pos { get; set; }
    public double dPR3_Center_Pos { get; set; }
    public double dPR4_Center_Pos { get; set; }
    public double dPR1_Clean_Pos { get; set; }
    public double dPR2_Clean_Pos { get; set; }
    public double dPR3_Clean_Pos { get; set; }
    public double dPR4_Clean_Pos { get; set; }
    public double dPR1_Change_Pos { get; set; }
    public double dPR2_Change_Pos { get; set; }
    public double dPR3_Change_Pos { get; set; }
    public double dPR4_Change_Pos { get; set; }

    public double dALX_Loading_Pos { get; set; }
    public double dALY_Loading_Pos { get; set; }

    public double dALX_Unloading_Pos { get; set; }
    public double dALY_Unloading_Pos { get; set; }

    public double dALX_AlignBackOffset_Pos { get; set; }
    public double dALY_AlignBackOffset_Pos { get; set; }

    public double dALX_AlignStart_Pos { get; set; }
    public double dALY_AlignStart_Pos { get; set; }

    public double dLP_LE_Pos { get; set; }
    public double dLP_AL_Pos { get; set; }
    public double dLP_AL_Unloading_Pos { get; set; }
    public double dLP_Stage1_Pos { get; set; }
    public double dLP_Stage2_Pos { get; set; }

    public double dUPX_UE1_Pos { get; set; }
    public double dUPX_UE2_Pos { get; set; }
    public double dUPX_UE3_Pos { get; set; }
    public double dUPX_UE4_Pos { get; set; }
    public double dUPX_Stage1_Pos { get; set; }
    public double dUPX_Stage2_Pos { get; set; }

    public double dUPY_UE1_Pos { get; set; }
    public double dUPY_UE2_Pos { get; set; }
    public double dUPY_UE3_Pos { get; set; }
    public double dUPY_UE4_Pos { get; set; }
    public double dUPY_Stage1_Pos { get; set; }
    public double dUPY_Stage2_Pos { get; set; }

    public double dX1_Loading_Pos { get; set; }
    public double dX1_Unloading_Pos { get; set; }
    public double dX1_Center_Pos { get; set; }
    public double dX1_CleanStart_Pos { get; set; }
    public double dX1_CleanEnd_Pos { get; set; }
    public double dX1_CleanProbe_Pos { get; set; }
    public double dX1_Interlock_Minus { get; set; }
    public double dX1_Interlock_Plus { get; set; }

    public double dX2_Loading_Pos { get; set; }
    public double dX2_Unloading_Pos { get; set; }
    public double dX2_Center_Pos { get; set; }
    public double dX2_CleanStart_Pos { get; set; }
    public double dX2_CleanEnd_Pos { get; set; }
    public double dX2_CleanProbe_Pos { get; set; }
    public double dX2_Interlock_Minus { get; set; }
    public double dX2_Interlock_Plus { get; set; }

    public double dZ1_Loading_Pos { get; set; }
    public double dZ1_Unloading_Pos { get; set; }
    public double dZ1_Center_Pos { get; set; }

    public double dZ2_Loading_Pos { get; set; }
    public double dZ2_Unloading_Pos { get; set; }
    public double dZ2_Center_Pos { get; set; }

    public int iLampNone_R { get; set; }
    public int iLampNone_Y { get; set; }
    public int iLampNone_G { get; set; }
    public int iLampNone_BlinkTime { get; set; }
    public int iBuzzNone_Mode { get; set; }
    public int iBuzzNone_Time { get; set; }

    public int iLampInitail_R { get; set; }
    public int iLampInitail_Y { get; set; }
    public int iLampInitail_G { get; set; }
    public int iLampInitail_BlinkTime { get; set; }
    public int iBuzzInitail_Mode { get; set; }
    public int iBuzzInitail_Time { get; set; }

    public int iLampIdle_R { get; set; }
    public int iLampIdle_Y { get; set; }
    public int iLampIdle_G { get; set; }
    public int iLampIdle_BlinkTime { get; set; }
    public int iBuzzIdle_Mode { get; set; }
    public int iBuzzIdle_Time { get; set; }

    public int iLampAuto_R { get; set; }
    public int iLampAuto_Y { get; set; }
    public int iLampAuto_G { get; set; }
    public int iLampAuto_BlinkTime { get; set; }
    public int iBuzzAuto_Mode { get; set; }
    public int iBuzzAuto_Time { get; set; }

    public int iLampStop_R { get; set; }
    public int iLampStop_Y { get; set; }
    public int iLampStop_G { get; set; }
    public int iLampStop_BlinkTime { get; set; }
    public int iBuzzStop_Mode { get; set; }
    public int iBuzzStop_Time { get; set; }

    public int iLampErrorAuto_R { get; set; }
    public int iLampErrorAuto_Y { get; set; }
    public int iLampErrorAuto_G { get; set; }
    public int iLampErrorAuto_BlinkTime { get; set; }
    public int iBuzzErrorAuto_Mode { get; set; }
    public int iBuzzErrorAuto_Time { get; set; }

    public int iLampErrorCycle_R { get; set; }
    public int iLampErrorCycle_Y { get; set; }
    public int iLampErrorCycle_G { get; set; }
    public int iLampErrorCycle_BlinkTime { get; set; }
    public int iBuzzErrorCycle_Mode { get; set; }
    public int iBuzzErrorCycle_Time { get; set; }

    public int iLampCycle_R { get; set; }
    public int iLampCycle_Y { get; set; }
    public int iLampCycle_G { get; set; }
    public int iLampCycle_BlinkTime { get; set; }
    public int iBuzzCycle_Mode { get; set; }
    public int iBuzzCycle_Time { get; set; }
  }

  [Serializable]
  public class ClassRecipePara
  {
    public ClassRecipePara GetValues()
    {
      using (MemoryStream stream = new MemoryStream())
      {
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        formatter.Serialize(stream, this);
        stream.Position = 0;
        return (ClassRecipePara)formatter.Deserialize(stream);
      }
    } // Deep Copy

    public double dPCB_Width { get; set; }
    public double dPCB_Height { get; set; }
    public double dPCB_Thick { get; set; }
    public double dPCB_Barcode_BCX_Pos { get; set; }
    public double dPCB_Barcode_BCY_Pos { get; set; }
    public double dPCB_Align_ALX_Pos { get; set; }
    public double dPCB_Align_ALY_Pos { get; set; }
    public int iUEMode { get; set; }
    public int iRejectZone { get; set; }

    public int iBCR_SX { get; set; }
    public int iBCR_SY { get; set; }
    public int iBCR_EX { get; set; }
    public int iBCR_EY { get; set; }

    public int iPointCount { get; set; } // 측정 동작 반복 횟수
    public double[] adPointX { get; set; } // X 좌표
    public double[] adPointY1 { get; set; } // Y1 좌표
    public double[] adPointY2 { get; set; } // Y2 좌표
    public bool[] abUsePointX { get; set; } // X 사용유무
    public bool[] abUsePointY_Two { get; set; } // true: Y 2개 사용 false: Y 1개 사용

    public int[] aiPointY1_Type { get; set; } // Y1 포인트 타입 Dummy : Unit
    public int[] aiPointY2_Type { get; set; } // Y2 포인트 타입 Dummy : Unit

    // Offset
    public double[] adPointY1_Stage1_Offset { get; set; } // Stage1 Y1 포인트 Offset
    public double[] adPointY2_Stage1_Offset { get; set; } // Stage1 Y2 포인트 Offset
    public double[] adPointY1_Stage2_Offset { get; set; } // Stage2 Y1 포인트 Offset
    public double[] adPointY2_Stage2_Offset { get; set; } // Stage2 Y2 포인트 Offset

    // Range 분류 범위
    public double[] abPointY_Range_Min_A { get; set; }
    public double[] abPointY_Range_Max_A { get; set; }
    public double[] abPointY_Range_Min_B { get; set; }
    public double[] abPointY_Range_Max_B { get; set; }
    public double[] abPointY_Range_Min_C { get; set; }
    public double[] abPointY_Range_Max_C { get; set; }
  }
  #endregion

  #region Thread
  public enum enumCycleStatus
  {
    NONE,
    LE_Align,
    LE_Cassette_Wait,
    UE1_Align,
    UE1_Cassette_Wait,
    UE2_Align,
    UE2_Cassette_Wait,
    UE3_Align,
    UE3_Cassette_Wait,
    UE4_Align,
    UE4_Cassette_Wait,
    LE_to_LP,
    LP_to_AL,
    Align,
    AL_to_LP,
    LP_to_Stage1,
    LP_to_Stage2,
    Stage1_Zero,
    Stage2_Zero,
    Stage1_Measure,
    Stage2_Measure,
    Stage1_to_UP,
    Stage2_to_UP,
    UP_to_UE1,
    UP_to_UE2,
    UP_to_UE3,
    UP_to_UE4,
    Stage1_Clean,
    Stage2_Clean,
    Stage1_Probe_Clean,
    Stage2_Probe_Clean,
    ProbeChange,
  }

  public struct structCycleStatus // Cycle Status (For Moving)
  {
    public bool bExtrenStart;     // 구동시작시 변경

    public bool bCycleStart;      // 상태 모니터링                           from PLC
    public bool bMoving;          // 상태 모니터링                           from PLC
    public bool bComplete;        // 사태 모니터링 완료                      from PLC
    public bool bError;           // 상태 모니터링 에러 확인용               from PLC
  }

  public enum enumMachineEvent
  {
    LotStart,
    LotEnd,
    StopButton,
    StartButton,
    InitialButton,
    LotClearButton,
    ResetButton,
  }
  #endregion

  #region State
  public enum enumVirtualBit
  {
    None,
    Start,
    Stop,
    Init,
    Reset,
  }

  public enum enumMachineStatus
  {
    None,         // 원점복귀 미완료 초기 상태
    Initial,      // 원점복귀중
    Idle,         // 원점복귀 완료된 대기상태
    Auto,         // 자동운전중
    Stop,         // 자동작업중 정지
    ErrorAuto,    // 자동작업중 에러
    Error,        // 오토가 아닌 작업중 에러
    Cycle,        // 단위동작(메뉴얼)
  }
  #endregion

  #region Product Data
  public enum enumPCBResult
  {
    A,
    B,
    C,
    D,
    NONE,
  }

  public enum enumProbe
  {
    PR1,
    PR2,
    PR3,
    PR4,
    NONE,
  }

  public enum enumPoint
  {
    Y1,
    Y2,
    NONE,
  }

  public struct structZeroSetData
  {
    public double Value;
    public double X;
    public enumProbe ProbeType;
    public enumPoint PointType;
  }

  public struct structPCBData
  {
    public System.DateTime Total_StartTime;
    public System.DateTime Total_EndTime;

    public System.DateTime LE_StartTime;
    public System.DateTime LE_EndTime;

    public System.DateTime Barcode_StartTime;
    public System.DateTime Barcode_EndTime;

    public System.DateTime LEtoLP_StartTime;
    public System.DateTime LEtoLP_EndTime;

    public System.DateTime LPtoAL_StartTime;
    public System.DateTime LPtoAL_EndTime;

    public System.DateTime AL_StartTime;
    public System.DateTime AL_EndTime;

    public System.DateTime ALtoLP_StartTime;
    public System.DateTime ALtoLP_EndTime;

    public System.DateTime LPtoStage_StartTime;
    public System.DateTime LPtoStage_EndTime;

    public System.DateTime Measure_StartTime;
    public System.DateTime Measure_EndTime;

    public System.DateTime Zeroset_StartTime;
    public System.DateTime Zeroset_EndTime;

    public System.DateTime ProbeClean_StartTime;
    public System.DateTime ProbeClean_EndTime;

    public System.DateTime StagetoUP_StartTime;
    public System.DateTime StagetoUP_EndTime;

    public System.DateTime UPtoUE_StartTime;
    public System.DateTime UPtoUE_EndTime;

    public bool PerfectlyOut; // 생산완료가 된 제품인지 확인하는 비트
    public bool BCR_OK; // 바코드 성공 비트
    public string BCR; // 바코드 정보
    public List<double> MeasurePointValue; // 측정이 된 값만 순차 적으로 저장할 버퍼
    public List<int> PointIndex;// 포인트 인덱스 저장 버퍼
    public List<enumPointType> PointType; // 포인트 타입 (Dummy, Unit)
    public enumPCBResult Result; // 최종 결과 정보
    public enumProbe[] ProbeInfo; // 각 포인트 측정한 프로브 정보
    public int[] X_Index; // X 인덱스 번호
    public enumPoint[] PointInfo; // 각 포인트 정보
    public enumPCBResult[] PointResult; // 각 포인트 결과 정보
    public double[] MeasureValue; // 측정 포인트 값
    public double[] OriginValue; // 측정 포인트 프로브 절대값
    public double[] PointOffset; // 측정 포인트 옵셋
    public double[] ZeroValue; // 측정 포인트에 저장된 제로값
    public double Min;
    public double Max;
    public double Total;
    public double Average;
    public double Gap;
    public int StageNumber; // 생산된 스테이지 번호
  }
  #endregion

  public static class CVo
  {
    // Program Version
    public static bool bLaptopTestMode = false; // 노트북 에서 시뮬레이션 테스트할때 이비트 켠다.
    public static string strVersion = "20170801_0_MxComponent";

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    #region Test
    // Debuging 
    public static int iDebug_Open_Index = 0;
    public static int iDebug_Write_Index = 0;
    public static int[] iDebug_Test_Buffer = new int[3];

    // 테스트 동작용 스타트 비트
    public static bool bTestMeasure1 = false;
    public static bool bTestMeasure2 = false;
    public static bool bTestZeroSet1 = false;
    public static bool bTestZeroSet2 = false;
    public static bool bTestMeasure_Bust1 = false;
    public static bool bTestMeasure_Bust2 = false;
    public static bool bTestZeroSet_Bust1 = false;
    public static bool bTestZeroSet_Bust2 = false;

    // 테스트 동작용 러닝 비트
    public static bool bTest_Running_Measure1 = false;
    public static bool bTest_Running_Measure2 = false;
    public static bool bTest_Running_ZeroSet1 = false;
    public static bool bTest_Running_ZeroSet2 = false;
    public static bool bTest_Running_Measure_Bust1 = false;
    public static bool bTest_Running_Measure_Bust2 = false;
    public static bool bTest_Running_ZeroSet_Bust1 = false;
    public static bool bTest_Running_ZeroSet_Bust2 = false;

    // 테스트 동작용 파라메터
    public static int iTestRepeat_Bust1 = 100;
    public static int iTestRepeat_Bust2 = 100;
    public static int iTestDelay_Bust1 = 100;
    public static int iTestDelay_Bust2 = 100;

    public static bool TestRunning()
    {
      bool bResult
         = bTest_Running_Measure1
        || bTest_Running_Measure2
        || bTest_Running_ZeroSet1
        || bTest_Running_ZeroSet2
        || bTest_Running_Measure_Bust1
        || bTest_Running_Measure_Bust2
        || bTest_Running_ZeroSet_Bust1
        || bTest_Running_ZeroSet_Bust2;

      return bResult;
    }


    #endregion

    #region Extern Form
    #endregion

    #region Login
    public const string SUPER_ID = "SUPER";
    public const string SUPER_PW = "0000";
    public static string strCurrentUser = "NONE";
    public static enumUserLevel eCurrentUserLevel = enumUserLevel.Operator;
    public static string[] arrExcept = new string[] 
    { 
      "`", "~", "!", "@", "#",
      "$", "%", "^", "&", "*",
      "(", ")", "-", "+", "=",
      "[", "{", "]", "}", "\\",
      "|", ";", ":", "\"", "'",
      ",", "<", ".", ">", "/",
      "?"
    };
    public static List<StructUser> listUser = new List<StructUser>();
    #endregion

    // Language
    public static enumLanguageType eCurrentLanguage = enumLanguageType.English;


    #region Path
    //Root
    public static string ROOT_PATH = "";

    //UI
    public static string UI_PATH = "";
    public static string UI_NAME_LANGUAGE = "";
    public static string UI_NAME_ALARM = "";
    public static string UI_NAME_MESSAGE = "";
    public static string UI_NAME_USER = "";

    //LOG
    public static List<string> LOG_DELETE_PATH = new List<string>();
    public static string LOG_PATH = "";

    public static string LOG_PATH_DEBUG = ""; // Exception 로그 저장 경로
    public static string LOG_NAME_DEBUG = "";

    public static string LOG_PATH_EVENT = ""; // 유저 이벤트 로그 저장 경로
    public static string LOG_NAME_EVENT = "";

    public static string LOG_PATH_ALARM_STOP = ""; // 중 알람 로그 저장 경로
    public static string LOG_NAME_ALARM_STOP = "";

    public static string LOG_PATH_ALARM_WARN = ""; // 경 알람 및 알림 로그 저장 경로
    public static string LOG_NAME_ALARM_WARN = "";

    public static string LOG_PATH_MOTON_EVENT = ""; // 단위동작 구동 시작 로그
    public static string LOG_NAME_MOTION_EVENT = "";

    public static string LOG_PATH_MACHINE_EVENT = ""; // 장비 구동 이벤트 저장 경로
    public static string LOG_NAME_MACHINE_EVENT = "";

    public static string LOG_PATH_DATA = ""; // 1장당 측정 데이터 저장 경로
    public static string LOG_NAME_DATA = "";

    public static string LOG_PATH_CHANGE_PARAMETER = ""; // 파라메터 변경 로그 저장 경로
    public static string LOG_NAME_CHANGE_PARAMETER = "";

    public static string LOG_PATH_LOT_INFO = ""; // 랏 끝날때 결과 저장 경로
    public static string LOG_NAME_LOT_INFO = "";

    public static string LOG_PATH_TEST = ""; // 테스트 동작 데이터 경로
    public static string LOG_NAME_TEST_MEASURE1 = "";
    public static string LOG_NAME_TEST_MEASURE2 = "";
    public static string LOG_NAME_TEST_ZEROSET1 = "";
    public static string LOG_NAME_TEST_ZEROSET2 = "";
    public static string LOG_NAME_TEST_MEASURE_BUST1 = "";
    public static string LOG_NAME_TEST_MEASURE_BUST2 = "";
    public static string LOG_NAME_TEST_ZEROSET_BUST1 = "";
    public static string LOG_NAME_TEST_ZEROSET_BUST2 = "";

    //SYSTEM
    public static string SYSTEM_PATH = "";
    public static string SYSTEM_NAME = "";
    public static string SYSTEM_NAME_INPUT = "";
    public static string SYSTEM_NAME_OUTPUT = "";
    public static string SYSTEM_MANE_PLC = "";
    public static string SYSTEM_NAME_MOTION = "";            // 모터 구동시 선언된 (거리,속도,가감속,타임아웃)배열값 저장 이름  
    public static string SYSTEM_NAME_MOTION_SETTING = "";    // 모터 구동시 필요한 (조그속도, 거리 또는 속도 리미트) 저장 이름
    public static string SYSTEM_NAME_Ajin = "";               // 아진 모션 모션 파일 

    //RECIPE
    public static string RECIPE_PATH = "";
    public static string RECIPE_CURRENT = "";
    public static string RECIPE_BUFFER_NAME = "";
    public static string RECIPE_NAME = "";
    public static string RECIPE_NAME_MOTION = "";
    #endregion

    #region Alarm
    public static bool bBuzzOff = false; // buzzer Off 비트 이비트 살면 버저 꺼짐

    public static enumAlarmStop eAlarmStop = enumAlarmStop.NONE;
    public static string[] arrAlarmStopName = null;
    public static string[] arrAlarmStopInfo = null;
    public static List<string> listAlarmStopTime = new List<string>();
    public static List<enumAlarmStop> listAlarmStopName = new List<enumAlarmStop>();
    public static bool bOnAlarmStop = false;
    //public static bool bOnAlarmStopOnece = false;
    public static void OnAlaramStop(enumAlarmStop name)
    {
      for (int i = 0; i < listAlarmStopName.Count; i++)
      {
        if (name == listAlarmStopName[i])
        {
          return;
        }
      }
      listAlarmStopTime.Add(System.DateTime.Now.ToString("yyyyMMddHHmmss"));
      listAlarmStopName.Add(name);
      eAlarmStop = name;
      bOnAlarmStop = true;

    }

    public static enumAlarmWarn eAlarmWarn = enumAlarmWarn.NONE;
    public static string[] arrAlarmWarnName = null;
    public static string[] arrAlarmWarnInfo = null;
    public static bool bOnAlarmWarn = false;
    #endregion

    #region Message
    public static enumMsg eMsg = enumMsg.NONE_NONE;
    public static string[] arrMsgName = null;
    public static string[] arrMsgInfo = null;
    #endregion

    #region Parameter
    public static int MAX_POINT = 20;
    public static ClassSystemPara cParaSys = new ClassSystemPara();
    public static ClassRecipePara cParaRcp = new ClassRecipePara();

    //public static int iAirScale_Main = 1;
    public static int iAirScale = 1;
    public static int iTimeScale = 100;

    public static bool Allow_Limit(enumMotorName name, double value)
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      bool bResult = false;
      switch (name)
      {
        case enumMotorName.LE:
          if (cSys.dLE_LimitCcw <= value && value <= cSys.dLE_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.LP:
          if (cSys.dLP_LimitCcw <= value && value <= cSys.dLP_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.BCX:
          if (cSys.dBCX_LimitCcw <= value && value <= cSys.dBCX_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.BCY:
          if (cSys.dBCY_LimitCcw <= value && value <= cSys.dBCY_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.ALX:
          if (cSys.dALX_LimitCcw <= value && value <= cSys.dALX_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.ALY:
          if (cSys.dALY_LimitCcw <= value && value <= cSys.dALY_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.X1:
          if (cSys.dX1_LimitCcw <= value && value <= cSys.dX1_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.X2:
          if (cSys.dX2_LimitCcw <= value && value <= cSys.dX2_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.Z1:
          if (cSys.dZ1_LimitCcw <= value && value <= cSys.dZ1_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.Z2:
          if (cSys.dZ2_LimitCcw <= value && value <= cSys.dZ2_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.PR1:
          if (cSys.dPR1_LimitCcw <= value && value <= cSys.dPR1_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.PR2:
          if (cSys.dPR2_LimitCcw <= value && value <= cSys.dPR2_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.PR3:
          if (cSys.dPR3_LimitCcw <= value && value <= cSys.dPR3_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.PR4:
          if (cSys.dPR4_LimitCcw <= value && value <= cSys.dPR4_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.UPX:
          if (cSys.dUPX_LimitCcw <= value && value <= cSys.dUPX_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.UPY:
          if (cSys.dUPY_LimitCcw <= value && value <= cSys.dUPY_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.UE1:
          if (cSys.dUE1_LimitCcw <= value && value <= cSys.dUE1_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.UE2:
          if (cSys.dUE2_LimitCcw <= value && value <= cSys.dUE2_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.UE3:
          if (cSys.dUE3_LimitCcw <= value && value <= cSys.dUE3_LimitCw)
          {
            bResult = true;
          }
          break;
        case enumMotorName.UE4:
          if (cSys.dUE4_LimitCcw <= value && value <= cSys.dUE4_LimitCw)
          {
            bResult = true;
          }
          break;
        default:
          break;
      }

      return bResult;
    }
    public static bool Check_PointTypeSelected(ClassRecipePara rcp)
    {
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (rcp.abUsePointX[i])
        {
          if (rcp.aiPointY1_Type[i] == (int)enumPointType.NONE)
          {
            return false;
          }
          if (rcp.aiPointY2_Type[i] == (int)enumPointType.NONE)
          {
            return false;
          }
        }
      }
      return true;
    }
    #endregion

    #region Thread
    public static int iStage1_ZeroSetCount = 0; // Stage1 ZeroSet Count
    public static int iStage2_ZeroSetCount = 0; // Stage2 ZeroSet Count

    public static bool bSetupMode = false; // 셋업, 안전모드 비트
    public static bool bLotEndWait = false; // 랏 종료 대기 비트
    public static bool bLotRunning = false; // 랏 진행중 비트
    public static bool bLotUserConfirmWait = false; // 랏엔드를 유저가 보고 확인햇는지 확인하는 비트
    public static bool bLastPCBLost = false; // 마지막 소재 작업중 잃어버렸을때
    public static int iRunTimeOut = 30000; // 싸이클동작 TimeOut 시간

    // 홈 구동 플래그
    public static bool bInit_All = false;
    public static bool bInit_Loading = false;
    public static bool bInit_Stage = false;
    public static bool bInit_Unloading = false;

    public static structCycleStatus[] sCycleStatus = new structCycleStatus[Enum.GetNames(typeof(enumCycleStatus)).Length]; // 각 싸이클 동작 상태

    // 각 쓰레드 다음 진행할 동작 버퍼
    public static enumCycleStatus eNextSeq_LE = enumCycleStatus.NONE;
    public static enumCycleStatus eNextSeq_LP = enumCycleStatus.NONE;
    public static enumCycleStatus eNextSeq_Stage1 = enumCycleStatus.NONE;
    public static enumCycleStatus eNextSeq_Stage2 = enumCycleStatus.NONE;
    public static enumCycleStatus eNextSeq_UL = enumCycleStatus.NONE;
    public static enumCycleStatus eNextSeq_UE1 = enumCycleStatus.NONE;
    public static enumCycleStatus eNextSeq_UE2 = enumCycleStatus.NONE;
    public static enumCycleStatus eNextSeq_UE3 = enumCycleStatus.NONE;
    public static enumCycleStatus eNextSeq_UE4 = enumCycleStatus.NONE;

    // 오토중 정지후 다시 진행할때 간섭되는 동작을 순차적으로 진행하기 위해 이 비트로 제어한다.
    public static bool bLE_to_LP_Wait = false;
    public static bool bLP_to_Stage1_Wait = false;
    public static bool bLP_to_Stage2_Wait = false;
    public static bool bStage1_to_UP_Wait = false;
    public static bool bStage2_to_UP_Wait = false;
    public static bool bUP_to_UE1_Wait = false;
    public static bool bUP_to_UE2_Wait = false;
    public static bool bUP_to_UE3_Wait = false;
    public static bool bUP_to_UE4_Wait = false;

    // 분기동작 결정 비트 또는 동작중 대기 비트
    public static bool bStageSelectWait = false;
    public static bool bStage1_Measuring = false;
    public static bool bStage2_Measuring = false;
    public static int iStage1_Cur_ReMeasure_Count = 0;
    public static int iStage2_Cur_ReMeasure_Count = 0;

    // UE까지 소재가 빠지고 정렬동작 했는지 결정 짓는 비트
    public static bool bLELastOut = false;
    public static bool bUE1LastOut = false;
    public static bool bUE2LastOut = false;
    public static bool bUE3LastOut = false;
    public static bool bUE4LastOut = false;

    // 가상동작용 가상 비트
    public static bool bStage1_PCB_Exist = false;
    public static bool bStage2_PCB_Exist = false;
    public static bool bUP_PCB_Exist = false;
    public static bool bLP_PCB_Exist = false;
    public static bool bPCB_Empty = false;

    // 쓰레드 -> 쓰레드 넘길때 확인하는 비트
    public static bool bWaitLE = false;
    public static bool bWaitLP = false;
    public static bool bWaitStage1 = false;
    public static bool bWaitStage2 = false;
    public static bool bWaitStage1_to_UP = false;
    public static bool bWaitStage2_to_UP = false;
    public static bool bWaitUE1 = false;
    public static bool bWaitUE2 = false;
    public static bool bWaitUE3 = false;
    public static bool bWaitUE4 = false;
    public static bool bWaitStage1ZeroSet = false;
    public static bool bWaitStage2ZeroSet = false;

    // 단일동작 구동중인지 PLC로부터 실시간으로 읽고있는 비트
    public static bool bRunning_All = false;

    public static bool bRunningLE = false;
    public static bool bRunningLP = false;
    public static bool bRunningStage1 = false;
    public static bool bRunningStage2 = false;
    public static bool bRunningUP = false;
    public static bool bRunningUE1 = false;
    public static bool bRunningUE2 = false;
    public static bool bRunningUE3 = false;
    public static bool bRunningUE4 = false;

    // 전체 텍타임 계산용 버퍼
    public static System.DateTime sTactTime_LotStart = System.DateTime.Now;
    public static System.DateTime sTactTime_LotEnd = System.DateTime.Now;

    public static List<double> listOutTact = new List<double>();
    public static System.DateTime sPreviousOutTime = System.DateTime.Now;
    public static System.DateTime sCurrentOutTime = System.DateTime.Now;

    public static enumVirtualBit eVirtualBit = enumVirtualBit.None; // 버튼 눌림 상태
    public static enumMachineStatus eMachineStatus = enumMachineStatus.None; // 장비 상태
    public static bool bManualRun = false; //오토 동작중인지 확인하는 비트

    public static bool bAllHome = false; // 전체 원점 확인 비트
    public static bool Check_All_Moving() // 전체 무빙중인지 확인하는 비트
    {
      for (int i = 0; i < Enum.GetNames(typeof(enumCycleStatus)).Length; i++)
      {
        if (sCycleStatus[i].bMoving == true)
        {
          return true;
        }
      }
      return false;
    }
    public static bool Check_MachineStatus() // 오토 또는 싸이클 동작시 True 반환
    {
      return eMachineStatus == enumMachineStatus.Auto || eMachineStatus == enumMachineStatus.Cycle;
    }
    public static void CycleStatus_Reset(enumCycleStatus cycle) // 싸이클 상태 리셋
    {
      sCycleStatus[(int)cycle].bExtrenStart = false;
      sCycleStatus[(int)cycle].bCycleStart = false;
      sCycleStatus[(int)cycle].bMoving = false;
      sCycleStatus[(int)cycle].bComplete = false;
      sCycleStatus[(int)cycle].bError = false;
    }
    public static void CycleStatus_Moving(enumCycleStatus cycle) // 싸이클 상태 무빙중
    {
      sCycleStatus[(int)cycle].bMoving = true;
      sCycleStatus[(int)cycle].bComplete = false;
      sCycleStatus[(int)cycle].bError = false;
    }
    public static void CycleStatus_Error(enumCycleStatus cycle) // 싸이클 상태 에러
    {
      sCycleStatus[(int)cycle].bMoving = false;
      sCycleStatus[(int)cycle].bComplete = false;
      sCycleStatus[(int)cycle].bError = true;
    }
    public static void CycleStatus_Complete(enumCycleStatus cycle) // 싸이클 상태 완료
    {
      if (CVo.bLaptopTestMode)
      {
        Random rd = new Random();
        int irand = rd.Next(500, 2000);
        System.Threading.Thread.Sleep(irand);
      }
      sCycleStatus[(int)cycle].bMoving = false;
      sCycleStatus[(int)cycle].bComplete = true;
      sCycleStatus[(int)cycle].bError = false;
    }
    public static bool Check_CycleStart(enumCycleStatus cycle) // 싸이클 시작신호 확인
    {
      return sCycleStatus[(int)cycle].bExtrenStart || sCycleStatus[(int)cycle].bCycleStart;
    }
    public static void Reset_LotData()
    {
      listOutTact.Clear();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
      CVo.bLotRunning = false;
      CVo.bLotEndWait = false;
      CVo.bWaitLE = false;
      CVo.bWaitLP = false;
      CVo.bWaitStage1 = false;
      CVo.bWaitStage2 = false;
      CVo.bWaitStage1_to_UP = false;
      CVo.bWaitStage2_to_UP = false;
      CVo.bWaitUE1 = false;
      CVo.bWaitUE2 = false;
      CVo.bWaitUE3 = false;
      CVo.bWaitUE4 = false;
      CVo.bLELastOut = false;
      CVo.bUE1LastOut = false;
      CVo.bUE2LastOut = false;
      CVo.bUE3LastOut = false;
      CVo.bUE4LastOut = false;
      CVo.bStageSelectWait = false;

      CVo.bLE_to_LP_Wait = false;
      CVo.bLP_to_Stage1_Wait = false;
      CVo.bLP_to_Stage2_Wait = false;
      CVo.bStage1_to_UP_Wait = false;
      CVo.bStage2_to_UP_Wait = false;
      CVo.bUP_to_UE1_Wait = false;
      CVo.bUP_to_UE2_Wait = false;
      CVo.bUP_to_UE3_Wait = false;
      CVo.bUP_to_UE4_Wait = false;

      CVo.bStage1_Measuring = false;
      CVo.bStage2_Measuring = false;

      CVo.Init_PCBData();
    }

    #endregion

    #region ProductData
    public static string strLotBCR = ""; // 1D 바코드 정보
    public static uint uiProductTotalCount = 0; // 총 제품 배출 수량
    public static uint uiproductLotCount = 0; // 해당 랏 배출 수량

    // 오토 화면 표기용
    public static bool bRefreshInfo = false;
    public static double dTactTime_Previous = 0.0;
    public static double dTactTime_Currnet = 0.0;
    public static double dTactTime_Total = 0.0;
    public static double dTactTime_Average = 0.0;

    public static int iPCBIndex_LE = 0;
    public static int iPCBIndex_Loader = 0;
    public static int iPCBIndex_Stage1 = 0;
    public static int iPCBIndex_Stage2 = 0;
    public static int iPCBIndex_Unloader = 0;
    public static int iPCBIndex_UE1 = 0;
    public static int iPCBIndex_UE2 = 0;
    public static int iPCBIndex_UE3 = 0;
    public static int iPCBIndex_UE4 = 0;

    public static int iPointMax = 20; // 측정 횟수

    public static bool bZeroSetStatus_Stage1 = false; // Zero Set 데이터를 가지고 있는지 확인한다.
    public static bool bZeroSetStatus_Stage2 = false; // Zero Set 데이터를 가지고 있는지 확인한다.
    public static structZeroSetData[] asZeroData_Stage1 = new structZeroSetData[iPointMax * 2]; // Zero Set Data Stage1
    public static structZeroSetData[] asZeroData_Stage2 = new structZeroSetData[iPointMax * 2]; // Zero Set Data Stage2
    public static void Reset_ZeroSetData(int stageNumber/*0~1 0:스테이지1 1:스테이지2*/) // 제로셋 초기화 함수
    {
      if (stageNumber == 0)
      {
        // 스테이지 1 ZerosetData Clear
        bZeroSetStatus_Stage1 = false;
        for (int i = 0; i < iPointMax * 2; i++)
        {
          asZeroData_Stage1[i].PointType = enumPoint.NONE;
          asZeroData_Stage1[i].ProbeType = enumProbe.NONE;
          asZeroData_Stage1[i].Value = double.MinValue;
        }
      }
      if (stageNumber == 1)
      {
        // 스테이지 2 ZerosetData Clear
        bZeroSetStatus_Stage2 = false;
        for (int i = 0; i < iPointMax * 2; i++)
        {
          asZeroData_Stage2[i].PointType = enumPoint.NONE;
          asZeroData_Stage2[i].ProbeType = enumProbe.NONE;
          asZeroData_Stage2[i].Value = double.MinValue;
        }
      }
    }

    public static structPCBData[] sPCBData = new structPCBData[10000];
    public static void Reset_PCBData()
    {
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      for (int i = 0; i < sPCBData.Length; i++)
      {
        // 텍타임 데이터 초기화
        sPCBData[i].Total_StartTime = System.DateTime.Now;
        sPCBData[i].Total_EndTime = System.DateTime.Now;
        sPCBData[i].LE_StartTime = System.DateTime.Now;
        sPCBData[i].LE_EndTime = System.DateTime.Now;
        sPCBData[i].Barcode_StartTime = System.DateTime.Now;
        sPCBData[i].Barcode_EndTime = System.DateTime.Now;
        sPCBData[i].LEtoLP_StartTime = System.DateTime.Now;
        sPCBData[i].LEtoLP_EndTime = System.DateTime.Now;
        sPCBData[i].LPtoAL_StartTime = System.DateTime.Now;
        sPCBData[i].LPtoAL_EndTime = System.DateTime.Now;
        sPCBData[i].AL_StartTime = System.DateTime.Now;
        sPCBData[i].AL_EndTime = System.DateTime.Now;
        sPCBData[i].ALtoLP_StartTime = System.DateTime.Now;
        sPCBData[i].ALtoLP_EndTime = System.DateTime.Now;
        sPCBData[i].LPtoStage_StartTime = System.DateTime.Now;
        sPCBData[i].LPtoStage_EndTime = System.DateTime.Now;
        sPCBData[i].Measure_StartTime = System.DateTime.Now;
        sPCBData[i].Measure_EndTime = System.DateTime.Now;
        sPCBData[i].Zeroset_StartTime = System.DateTime.Now;
        sPCBData[i].Zeroset_EndTime = System.DateTime.Now;
        sPCBData[i].ProbeClean_StartTime = System.DateTime.Now;
        sPCBData[i].ProbeClean_EndTime = System.DateTime.Now;
        sPCBData[i].StagetoUP_StartTime = System.DateTime.Now;
        sPCBData[i].StagetoUP_EndTime = System.DateTime.Now;
        sPCBData[i].UPtoUE_StartTime = System.DateTime.Now;
        sPCBData[i].UPtoUE_EndTime = System.DateTime.Now;

        // 결과 데이터 초기화
        sPCBData[i].PerfectlyOut = false; // 생산완료가 된 제품인지 확인하는 비트
        sPCBData[i].BCR = ""; // 바코드 정보
        sPCBData[i].BCR_OK = false;
        sPCBData[i].MeasurePointValue = new List<double>(); ; // 측정이 된 값만 순차 적으로 저장할 버퍼
        sPCBData[i].MeasurePointValue.Clear(); // 측정이 된 값만 순차 적으로 저장할 버퍼
        sPCBData[i].PointIndex = new List<int>(); // 포인트 인덱스 저장 버퍼
        sPCBData[i].PointIndex.Clear(); // 포인트 인덱스 저장 버퍼
        sPCBData[i].PointType = new List<enumPointType>();
        sPCBData[i].PointType.Clear();
        sPCBData[i].Result = enumPCBResult.NONE; // 최종 결과 정보
        sPCBData[i].StageNumber = -1; // 생산된 스테이지 번호
        sPCBData[i].ProbeInfo = new enumProbe[CVo.iPointMax * 2]; // 각 포인트 측정한 프로브 정보
        sPCBData[i].X_Index = new int[CVo.iPointMax * 2]; // X 인덱스 정보
        sPCBData[i].PointInfo = new enumPoint[CVo.iPointMax * 2]; // 각 포인트 정보
        sPCBData[i].PointResult = new enumPCBResult[CVo.iPointMax * 2]; // 각 포인트 결과 정보
        sPCBData[i].MeasureValue = new double[CVo.iPointMax * 2]; // 측정 포인트 값
        sPCBData[i].OriginValue = new double[CVo.iPointMax * 2]; // 측정 포인트 프로브 절대값
        sPCBData[i].PointOffset = new double[CVo.iPointMax * 2]; // 측정 포인트 옵셋
        sPCBData[i].ZeroValue = new double[CVo.iPointMax * 2]; // 측정 포인트에 저장된 제로값
        for (int j = 0; j < CVo.iPointMax * 2; j++)
        {
          sPCBData[i].ProbeInfo[j] = enumProbe.NONE; // 각 포인트 측정한 프로브 정보
          sPCBData[i].X_Index[j] = -1; // X 인덱스 정보
          sPCBData[i].PointInfo[j] = enumPoint.NONE; // 각 포인트 정보
          sPCBData[i].PointResult[j] = enumPCBResult.NONE; // 각 포인트 결과 정보
          sPCBData[i].MeasureValue[j] = double.MinValue; // 측정 포인트 값
          sPCBData[i].OriginValue[j] = double.MinValue; // 측정 포인트 프로브 절대값
          sPCBData[i].PointOffset[j] = double.MinValue; // 측정 포인트 옵셋
          sPCBData[i].ZeroValue[j] = double.MinValue; // 측정 포인트에 저장된 제로값
        }
        sPCBData[i].Min = double.MaxValue;
        sPCBData[i].Max = double.MinValue;
        sPCBData[i].Total = 0;
        sPCBData[i].Average = 0;
        sPCBData[i].Gap = 0;
      }
    }

    public static void Init_PCBData()
    {
      iPCBIndex_LE = 0;
      iPCBIndex_Loader = -999;
      iPCBIndex_Stage1 = -999;
      iPCBIndex_Stage2 = -999;
      iPCBIndex_Unloader = -999;
      iPCBIndex_UE1 = -999;
      iPCBIndex_UE2 = -999;
      iPCBIndex_UE3 = -999;
      iPCBIndex_UE4 = -999;
      Reset_PCBData();
    }
    #endregion

    #region Initialize
    public static void Init_()
    {
      #region Path
      //////////////////////////////////////////////
      //Path
      //////////////////////////////////////////////
      //ROOT_PATH
      ROOT_PATH = System.Windows.Forms.Application.StartupPath;
      ROOT_PATH = ROOT_PATH.Replace("x86\\", "");

      for (int i = 0; i < 3; i++)
      {
        ROOT_PATH = System.IO.Directory.GetParent(ROOT_PATH).ToString();
      }
      ROOT_PATH += "\\";

      //UI_PATH
      UI_PATH = ROOT_PATH + "UI\\";
      UI_NAME_LANGUAGE = "Language.mdb";
      UI_NAME_USER = "User.mdb";
      UI_NAME_ALARM = "Alarm.mdb";
      UI_NAME_MESSAGE = "Message.mdb";

      //LOG_PATH
      LOG_PATH = ROOT_PATH + "LOG\\";
      LOG_PATH_DEBUG = LOG_PATH + "Debug\\";
      LOG_NAME_DEBUG = "Debug.csv";

      LOG_PATH_EVENT = LOG_PATH + "Event\\";
      LOG_NAME_EVENT = "Event.csv";

      LOG_PATH_ALARM_STOP = LOG_PATH + "Alarm_Stop\\";
      LOG_NAME_ALARM_STOP = "AlarmStop.csv";

      LOG_PATH_ALARM_WARN = LOG_PATH + "Alarm_Warn\\";
      LOG_NAME_ALARM_WARN = "AlarmWarn.csv";

      LOG_PATH_MOTON_EVENT = LOG_PATH + "MotionEvent\\";
      LOG_NAME_MOTION_EVENT = "MotionEvent.csv";

      LOG_PATH_MACHINE_EVENT = LOG_PATH + "MachineEvent\\";
      LOG_NAME_MACHINE_EVENT = "MachineEvent.csv";

      LOG_PATH_DATA = LOG_PATH + "DataLog\\";
      LOG_NAME_DATA = "DataLog.csv";

      LOG_PATH_CHANGE_PARAMETER = LOG_PATH + "ParameterChanged\\";
      LOG_NAME_CHANGE_PARAMETER = "ChangeParameter.csv";

      LOG_PATH_LOT_INFO = LOG_PATH + "LotInfoData\\";
      LOG_NAME_LOT_INFO = "LotEnd.csv";

      LOG_PATH_TEST = LOG_PATH + "TestData\\";
      LOG_NAME_TEST_MEASURE1 = "MeasureTest_Stage1.csv";
      LOG_NAME_TEST_MEASURE2 = "MeasureTest_Stage2.csv";
      LOG_NAME_TEST_ZEROSET1 = "ZerosetTest_Stage1.csv";
      LOG_NAME_TEST_ZEROSET2 = "ZerosetTest_Stage2.csv";
      LOG_NAME_TEST_MEASURE_BUST1 = "MeasureTest_Stage1_Bust.csv";
      LOG_NAME_TEST_MEASURE_BUST2 = "MeasureTest_Stage2_Bust.csv";
      LOG_NAME_TEST_ZEROSET_BUST1 = "ZerosetTest_Stage1_Bust.csv";
      LOG_NAME_TEST_ZEROSET_BUST2 = "ZerosetTest_Stage2_Bust.csv";

      LOG_DELETE_PATH.Clear();
      LOG_DELETE_PATH.Add(LOG_PATH_DEBUG);
      LOG_DELETE_PATH.Add(LOG_PATH_EVENT);
      LOG_DELETE_PATH.Add(LOG_PATH_ALARM_STOP);
      LOG_DELETE_PATH.Add(LOG_PATH_ALARM_WARN);
      LOG_DELETE_PATH.Add(LOG_PATH_MOTON_EVENT);
      LOG_DELETE_PATH.Add(LOG_PATH_DATA);
      LOG_DELETE_PATH.Add(LOG_PATH_CHANGE_PARAMETER);
      LOG_DELETE_PATH.Add(LOG_PATH_LOT_INFO);
      LOG_DELETE_PATH.Add(LOG_PATH_MACHINE_EVENT);

      //SYSTEM_PATH
      SYSTEM_PATH = ROOT_PATH + "SYSTEM\\";
      SYSTEM_NAME = "System.ini";
      SYSTEM_NAME_INPUT = "Input.csv";
      SYSTEM_NAME_OUTPUT = "Output.csv";
      SYSTEM_MANE_PLC = "Plc.ini";
      SYSTEM_NAME_MOTION = "SystemMotion.ini";
      SYSTEM_NAME_MOTION_SETTING = "SystemMotionSetting.ini";
      SYSTEM_NAME_Ajin = "AjinMotion.mot";

      //MODEL_PATH
      RECIPE_PATH = ROOT_PATH + "RECIPE\\";
      RECIPE_CURRENT = "Default\\";
      RECIPE_BUFFER_NAME = "Using_Recipe.ini";
      RECIPE_NAME = "Recipe.ini";
      RECIPE_NAME_MOTION = "RecipeMotion.ini";
      Get_Recipe_Buffer();
      #endregion

      #region Alarm
      //////////////////////////////////////////////
      //Alarm Default Init
      //////////////////////////////////////////////
      arrAlarmStopName = new string[Enum.GetNames(typeof(enumAlarmStop)).Length];
      arrAlarmStopInfo = new string[Enum.GetNames(typeof(enumAlarmStop)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumAlarmStop)).Length; i++)
      {
        arrAlarmStopName[i] = ((enumAlarmStop)i).ToString();
        arrAlarmStopInfo[i] = ((enumAlarmStop)i).ToString();
      } //Stop Alarm

      arrAlarmWarnName = new string[Enum.GetNames(typeof(enumAlarmWarn)).Length];
      arrAlarmWarnInfo = new string[Enum.GetNames(typeof(enumAlarmWarn)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumAlarmWarn)).Length; i++)
      {
        arrAlarmWarnName[i] = ((enumAlarmWarn)i).ToString();
        arrAlarmWarnInfo[i] = ((enumAlarmWarn)i).ToString();
      } //Warn Alarm
      #endregion

      #region Message
      //////////////////////////////////////////////
      //Message Default Init
      //////////////////////////////////////////////
      arrMsgName = new string[Enum.GetNames(typeof(enumMsg)).Length];
      arrMsgInfo = new string[Enum.GetNames(typeof(enumMsg)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumMsg)).Length; i++)
      {
        arrMsgName[i] = ((enumMsg)i).ToString();
        arrMsgInfo[i] = ((enumMsg)i).ToString();
      } // Message
      #endregion

      #region Parameter Init
      // 파라메터 초기화 하고 -> 레시피 및 시스템 로드하는 부분
      #region System
      cParaSys.iCountAmount = 500;

      cParaSys.strPLC_HostAddress = "1.1.1.2";
      cParaSys.iPLC_IONumber = 1023;
      cParaSys.iPLC_TimeOut = 3000;
      cParaSys.iPLC_StationNumber = 255;
      cParaSys.iPLC_CpuType = 147;

      cParaSys.strBCR_IPAddress = "169.254.0.10";

      cParaSys.strProbe1_Com = "2";
      cParaSys.strProbe1_Baudrate = "9600";

      cParaSys.strProbe2_Com = "3";
      cParaSys.strProbe2_Baudrate = "9600";

      cParaSys.iShakeCount = 3;
      cParaSys.iLEAirBlowMode = 0;
      cParaSys.iZerosetPeriod = 100;

      cParaSys.iStageCleanCount = 3;
      cParaSys.iProbeCleanCount = 4;
      cParaSys.iReMeasureCount = 1;
      cParaSys.iPreStageCleanCount = 0;
      cParaSys.iAfterStageCleanCount = 0;

      cParaSys.iLanguage = (int)enumLanguageType.Default_Caption;
      cParaSys.iDeleteLogPeriod = 60;

      cParaSys.dLE_LimitCw = 1000.0;
      cParaSys.dLP_LimitCw = 1000.0;
      cParaSys.dBCX_LimitCw = 1000.0;
      cParaSys.dBCY_LimitCw = 1000.0;
      cParaSys.dALX_LimitCw = 1000.0;
      cParaSys.dALY_LimitCw = 1000.0;
      cParaSys.dX1_LimitCw = 1000.0;
      cParaSys.dX2_LimitCw = 1000.0;
      cParaSys.dZ1_LimitCw = 1000.0;
      cParaSys.dZ2_LimitCw = 1000.0;
      cParaSys.dPR1_LimitCw = 1000.0;
      cParaSys.dPR2_LimitCw = 1000.0;
      cParaSys.dPR3_LimitCw = 1000.0;
      cParaSys.dPR4_LimitCw = 1000.0;
      cParaSys.dUPX_LimitCw = 1000.0;
      cParaSys.dUPY_LimitCw = 1000.0;
      cParaSys.dUE1_LimitCw = 1000.0;
      cParaSys.dUE2_LimitCw = 1000.0;
      cParaSys.dUE3_LimitCw = 1000.0;
      cParaSys.dUE4_LimitCw = 1000.0;

      cParaSys.dLE_LimitCcw = -2.0;
      cParaSys.dLP_LimitCcw = -2.0;
      cParaSys.dBCX_LimitCcw = -2.0;
      cParaSys.dBCY_LimitCcw = -2.0;
      cParaSys.dALX_LimitCcw = -2.0;
      cParaSys.dALY_LimitCcw = -2.0;
      cParaSys.dX1_LimitCcw = -2.0;
      cParaSys.dX2_LimitCcw = -2.0;
      cParaSys.dZ1_LimitCcw = -2.0;
      cParaSys.dZ2_LimitCcw = -2.0;
      cParaSys.dPR1_LimitCcw = -2.0;
      cParaSys.dPR2_LimitCcw = -2.0;
      cParaSys.dPR3_LimitCcw = -2.0;
      cParaSys.dPR4_LimitCcw = -2.0;
      cParaSys.dUPX_LimitCcw = -2.0;
      cParaSys.dUPY_LimitCcw = -2.0;
      cParaSys.dUE1_LimitCcw = -2.0;
      cParaSys.dUE2_LimitCcw = -2.0;
      cParaSys.dUE3_LimitCcw = -2.0;
      cParaSys.dUE4_LimitCcw = -2.0;

      cParaSys.dZ1_Safety_Limit = 30.0;
      cParaSys.dZ2_Safety_Limit = 30.0;

      cParaSys.dProbe_Stage1_Safety_Gap = 30.0;
      cParaSys.dProbe_Stage2_Safety_Gap = 30.0;

      cParaSys.dMainAir_CylinderLimitMinus = 0.0;
      cParaSys.dMainAir_VaccumLimitMinus = 0.0;
      cParaSys.dLP_Vacuum_LimitMinus = 0.0;
      cParaSys.dUP_Vacuum_LimitMinus = 0.0;
      cParaSys.dStage1_Vacuum_LimitMinus = 0.0;
      cParaSys.dStage2_Vacuum_LimitMinus = 0.0;

      cParaSys.dLP_Vacuum_LimitPlus = 100.0;
      cParaSys.dUP_Vacuum_LimitPlus = 100.0;
      cParaSys.dStage1_Vacuum_LimitPlus = 100.0;
      cParaSys.dStage2_Vacuum_LimitPlus = 100.0;

      cParaSys.iErrorDelayTime_Cylinder = 0;
      cParaSys.iErrorDelayTime_LPVacuum = 0;
      cParaSys.iErrorDelayTime_UPVacuum = 0;
      cParaSys.iErrorDelayTime_Stage1Vacuum = 0;
      cParaSys.iErrorDelayTime_Stage2Vacuum = 0;

      cParaSys.iDelayTime_Cylinder = 0;
      cParaSys.iDelayTime_LPVacuum = 0;
      cParaSys.iDelayTime_UPVacuum = 0;
      cParaSys.iDelayTime_Stage1Vacuum = 0;
      cParaSys.iDelayTime_Stage2Vacuum = 0;
      cParaSys.iDelayTime_Measure = 0;
      cParaSys.iDelayTime_Align = 0;

      cParaSys.iRunTime_AirBlow = 1000;

      cParaSys.dCycleTimeOut = 20000;

      cParaSys.dLE_Ready_Pos = 0.0;
      cParaSys.dLP_Ready_Pos = 0.0;
      cParaSys.dBCX_Ready_Pos = 0.0;
      cParaSys.dBCY_Ready_Pos = 0.0;
      cParaSys.dALX_Ready_Pos = 0.0;
      cParaSys.dALY_Ready_Pos = 0.0;
      cParaSys.dX1_Ready_Pos = 0.0;
      cParaSys.dX2_Ready_Pos = 0.0;
      cParaSys.dZ1_Ready_Pos = 0.0;
      cParaSys.dZ2_Ready_Pos = 0.0;
      cParaSys.dPR1_Ready_Pos = 0.0;
      cParaSys.dPR2_Ready_Pos = 0.0;
      cParaSys.dPR3_Ready_Pos = 0.0;
      cParaSys.dPR4_Ready_Pos = 0.0;
      cParaSys.dUPX_Ready_Pos = 0.0;
      cParaSys.dUPY_Ready_Pos = 0.0;
      cParaSys.dUE1_Ready_Pos = 0.0;
      cParaSys.dUE2_Ready_Pos = 0.0;
      cParaSys.dUE3_Ready_Pos = 0.0;
      cParaSys.dUE4_Ready_Pos = 0.0;

      cParaSys.dLE_Normal_Spd = 20.0;
      cParaSys.dLP_Normal_Spd = 20.0;
      cParaSys.dBCX_Normal_Spd = 20.0;
      cParaSys.dBCY_Normal_Spd = 20.0;
      cParaSys.dALX_Normal_Spd = 20.0;
      cParaSys.dALY_Normal_Spd = 20.0;
      cParaSys.dX1_Normal_Spd = 20.0;
      cParaSys.dX2_Normal_Spd = 20.0;
      cParaSys.dZ1_Normal_Spd = 20.0;
      cParaSys.dZ2_Normal_Spd = 20.0;
      cParaSys.dPR1_Normal_Spd = 20.0;
      cParaSys.dPR2_Normal_Spd = 20.0;
      cParaSys.dPR3_Normal_Spd = 20.0;
      cParaSys.dPR4_Normal_Spd = 20.0;
      cParaSys.dUPX_Normal_Spd = 20.0;
      cParaSys.dUPY_Normal_Spd = 20.0;
      cParaSys.dUE1_Normal_Spd = 20.0;
      cParaSys.dUE2_Normal_Spd = 20.0;
      cParaSys.dUE3_Normal_Spd = 20.0;
      cParaSys.dUE4_Normal_Spd = 20.0;

      cParaSys.dLE_Low_Spd = 10.0;
      cParaSys.dLP_Low_Spd = 10.0;
      cParaSys.dBCX_Low_Spd = 10.0;
      cParaSys.dBCY_Low_Spd = 10.0;
      cParaSys.dALX_Low_Spd = 10.0;
      cParaSys.dALY_Low_Spd = 10.0;
      cParaSys.dX1_Low_Spd = 10.0;
      cParaSys.dX2_Low_Spd = 10.0;
      cParaSys.dZ1_Low_Spd = 10.0;
      cParaSys.dZ2_Low_Spd = 10.0;
      cParaSys.dPR1_Low_Spd = 10.0;
      cParaSys.dPR2_Low_Spd = 10.0;
      cParaSys.dPR3_Low_Spd = 10.0;
      cParaSys.dPR4_Low_Spd = 10.0;
      cParaSys.dUPX_Low_Spd = 10.0;
      cParaSys.dUPY_Low_Spd = 10.0;
      cParaSys.dUE1_Low_Spd = 10.0;
      cParaSys.dUE2_Low_Spd = 10.0;
      cParaSys.dUE3_Low_Spd = 10.0;
      cParaSys.dUE4_Low_Spd = 10.0;

      cParaSys.dLE_ScanStart_Pos = 1.0;
      cParaSys.dUE1_ScanStart_Pos = 1.0;
      cParaSys.dUE2_ScanStart_Pos = 1.0;
      cParaSys.dUE3_ScanStart_Pos = 1.0;
      cParaSys.dUE4_ScanStart_Pos = 1.0;

      cParaSys.dLE_ScanEnd_Pos = 10.0;
      cParaSys.dUE1_ScanEnd_Pos = 10.0;
      cParaSys.dUE2_ScanEnd_Pos = 10.0;
      cParaSys.dUE3_ScanEnd_Pos = 10.0;
      cParaSys.dUE4_ScanEnd_Pos = 10.0;

      cParaSys.dLE_Cassette_Wait_Pos = 5.0;
      cParaSys.dUE1_Cassette_Wait_Pos = 5.0;
      cParaSys.dUE2_Cassette_Wait_Pos = 5.0;
      cParaSys.dUE3_Cassette_Wait_Pos = 5.0;
      cParaSys.dUE4_Cassette_Wait_Pos = 5.0;

      cParaSys.dLE_DownOffset_Pos = 5.0;

      cParaSys.dPR1_Center_Pos = 10.0;
      cParaSys.dPR2_Center_Pos = 10.0;
      cParaSys.dPR3_Center_Pos = 10.0;
      cParaSys.dPR4_Center_Pos = 10.0;
      cParaSys.dPR1_Clean_Pos = 20.0;
      cParaSys.dPR2_Clean_Pos = 20.0;
      cParaSys.dPR3_Clean_Pos = 20.0;
      cParaSys.dPR4_Clean_Pos = 20.0;

      cParaSys.dPR1_Change_Pos = 20.0;
      cParaSys.dPR2_Change_Pos = 20.0;
      cParaSys.dPR3_Change_Pos = 20.0;
      cParaSys.dPR4_Change_Pos = 20.0;

      cParaSys.dALX_Loading_Pos = 1.0;
      cParaSys.dALY_Loading_Pos = 1.0;

      cParaSys.dALX_Unloading_Pos = 1.0;
      cParaSys.dALY_Unloading_Pos = 1.0;

      cParaSys.dALX_AlignBackOffset_Pos = 0.5;
      cParaSys.dALY_AlignBackOffset_Pos = 0.5;

      cParaSys.dALX_AlignStart_Pos = 5.0;
      cParaSys.dALY_AlignStart_Pos = 5.0;

      cParaSys.dLP_LE_Pos = 50.0;
      cParaSys.dLP_AL_Pos = 30.0;
      cParaSys.dLP_AL_Unloading_Pos = 30.0;
      cParaSys.dLP_Stage1_Pos = 20.0;
      cParaSys.dLP_Stage2_Pos = 10.0;

      cParaSys.dUPX_UE1_Pos = 10.0;
      cParaSys.dUPX_UE2_Pos = 20.0;
      cParaSys.dUPX_UE3_Pos = 30.0;
      cParaSys.dUPX_UE4_Pos = 40.0;
      cParaSys.dUPX_Stage1_Pos = 10.0;
      cParaSys.dUPX_Stage2_Pos = 10.0;

      cParaSys.dUPY_UE1_Pos = 10.0;
      cParaSys.dUPY_UE2_Pos = 10.0;
      cParaSys.dUPY_UE3_Pos = 10.0;
      cParaSys.dUPY_UE4_Pos = 10.0;
      cParaSys.dUPY_Stage1_Pos = 1.0;
      cParaSys.dUPY_Stage2_Pos = 1.0;

      cParaSys.dX1_Loading_Pos = 1.0;
      cParaSys.dX1_Unloading_Pos = 100.0;
      cParaSys.dX1_Center_Pos = 50.0;
      cParaSys.dX1_CleanStart_Pos = 10.0;
      cParaSys.dX1_CleanEnd_Pos = 80.0;
      cParaSys.dX1_CleanProbe_Pos = 10.0;
      cParaSys.dX1_Interlock_Minus = 0;
      cParaSys.dX1_Interlock_Plus = 600;

      cParaSys.dX2_Loading_Pos = 1.0;
      cParaSys.dX2_Unloading_Pos = 100.0;
      cParaSys.dX2_Center_Pos = 50.0;
      cParaSys.dX2_CleanStart_Pos = 10.0;
      cParaSys.dX2_CleanEnd_Pos = 80.0;
      cParaSys.dX2_CleanProbe_Pos = 10.0;
      cParaSys.dX2_Interlock_Minus = 0;
      cParaSys.dX2_Interlock_Plus = 600;

      cParaSys.dZ1_Loading_Pos = 1.0;
      cParaSys.dZ1_Unloading_Pos = 1.0;
      cParaSys.dZ1_Center_Pos = 5.0;

      cParaSys.dZ2_Loading_Pos = 1.0;
      cParaSys.dZ2_Unloading_Pos = 1.0;
      cParaSys.dZ2_Center_Pos = 5.0;

      cParaSys.bUsePB1 = true;
      cParaSys.bUsePB2 = true;
      cParaSys.bUsePB3 = true;
      cParaSys.bUsePB4 = true;

      cParaSys.iMinDisplayColor = 0;
      cParaSys.iMaxDisplayColor = 0;

      cParaSys.bUseBarcode_1D = true;
      cParaSys.bUseBarcode_2D = true;
      cParaSys.bUseLoadingShake = true;

      cParaSys.dProbeOffset_1 = 0.0;
      cParaSys.dProbeOffset_2 = 0.0;
      cParaSys.dProbeOffset_3 = 0.0;
      cParaSys.dProbeOffset_4 = 0.0;

      cParaSys.iProbeValueAverageCount = 100;
      cParaSys.iProbeValueAverageMin = 1;
      cParaSys.iProbeValueAverageMax = 1;

      cParaSys.iLampNone_R = (int)enumTowerLamp.Off;
      cParaSys.iLampNone_Y = (int)enumTowerLamp.Off;
      cParaSys.iLampNone_G = (int)enumTowerLamp.Off;
      cParaSys.iLampNone_BlinkTime = 0;
      cParaSys.iBuzzNone_Mode = (int)enumBuzzer.Off;
      cParaSys.iBuzzNone_Time = 0;

      cParaSys.iLampInitail_R = (int)enumTowerLamp.Off;
      cParaSys.iLampInitail_Y = (int)enumTowerLamp.Blink;
      cParaSys.iLampInitail_G = (int)enumTowerLamp.Off;
      cParaSys.iLampInitail_BlinkTime = 500;
      cParaSys.iBuzzInitail_Mode = (int)enumBuzzer.Off;
      cParaSys.iBuzzInitail_Time = 0;

      cParaSys.iLampIdle_R = (int)enumTowerLamp.Off;
      cParaSys.iLampIdle_Y = (int)enumTowerLamp.On;
      cParaSys.iLampIdle_G = (int)enumTowerLamp.Off;
      cParaSys.iLampIdle_BlinkTime = 0;
      cParaSys.iBuzzIdle_Mode = (int)enumBuzzer.Off;
      cParaSys.iBuzzIdle_Time = 0;

      cParaSys.iLampAuto_R = (int)enumTowerLamp.Off;
      cParaSys.iLampAuto_Y = (int)enumTowerLamp.Off;
      cParaSys.iLampAuto_G = (int)enumTowerLamp.On;
      cParaSys.iLampAuto_BlinkTime = 0;
      cParaSys.iBuzzAuto_Mode = (int)enumBuzzer.Off;
      cParaSys.iBuzzAuto_Time = 0;

      cParaSys.iLampStop_R = (int)enumTowerLamp.On;
      cParaSys.iLampStop_Y = (int)enumTowerLamp.Off;
      cParaSys.iLampStop_G = (int)enumTowerLamp.Off;
      cParaSys.iLampStop_BlinkTime = 0;
      cParaSys.iBuzzStop_Mode = (int)enumBuzzer.Off;
      cParaSys.iBuzzStop_Time = 0;

      cParaSys.iLampErrorAuto_R = (int)enumTowerLamp.Blink;
      cParaSys.iLampErrorAuto_Y = (int)enumTowerLamp.Off;
      cParaSys.iLampErrorAuto_G = (int)enumTowerLamp.Off;
      cParaSys.iLampErrorAuto_BlinkTime = 500;
      cParaSys.iBuzzErrorAuto_Mode = (int)enumBuzzer.Off;
      cParaSys.iBuzzErrorAuto_Time = 0;

      cParaSys.iLampErrorCycle_R = (int)enumTowerLamp.Blink;
      cParaSys.iLampErrorCycle_Y = (int)enumTowerLamp.Off;
      cParaSys.iLampErrorCycle_G = (int)enumTowerLamp.Off;
      cParaSys.iLampErrorCycle_BlinkTime = 500;
      cParaSys.iBuzzErrorCycle_Mode = (int)enumBuzzer.Off;
      cParaSys.iBuzzErrorCycle_Time = 0;

      cParaSys.iLampCycle_R = (int)enumTowerLamp.Blink;
      cParaSys.iLampCycle_Y = (int)enumTowerLamp.Off;
      cParaSys.iLampCycle_G = (int)enumTowerLamp.Off;
      cParaSys.iLampCycle_BlinkTime = 500;
      cParaSys.iBuzzCycle_Mode = (int)enumBuzzer.Off;
      cParaSys.iBuzzCycle_Time = 0;
      #endregion

      #region Recipe
      cParaRcp.dPCB_Width = 10;
      cParaRcp.dPCB_Height = 10;
      cParaRcp.dPCB_Thick = 0.1;
      cParaRcp.dPCB_Barcode_BCX_Pos = 10.0;
      cParaRcp.dPCB_Barcode_BCY_Pos = 10.0;
      cParaRcp.dPCB_Align_ALX_Pos = 10.0;
      cParaRcp.dPCB_Align_ALY_Pos = 10.0;
      cParaRcp.iUEMode = (int)enumUEUseMode.USE_2;
      cParaRcp.iRejectZone = (int)enumRejectZone.C;

      cParaRcp.iBCR_SX = 0;
      cParaRcp.iBCR_SY = 0;
      cParaRcp.iBCR_EX = 1280;
      cParaRcp.iBCR_EY = 960;

      cParaRcp.adPointX = new double[MAX_POINT];
      cParaRcp.adPointY1 = new double[MAX_POINT];
      cParaRcp.adPointY2 = new double[MAX_POINT];
      cParaRcp.abUsePointX = new bool[MAX_POINT];
      cParaRcp.abUsePointY_Two = new bool[MAX_POINT];

      cParaRcp.aiPointY1_Type = new int[MAX_POINT];
      cParaRcp.aiPointY2_Type = new int[MAX_POINT];

      cParaRcp.adPointY1_Stage1_Offset = new double[MAX_POINT];
      cParaRcp.adPointY2_Stage1_Offset = new double[MAX_POINT];
      cParaRcp.adPointY1_Stage2_Offset = new double[MAX_POINT];
      cParaRcp.adPointY2_Stage2_Offset = new double[MAX_POINT];

      cParaRcp.abPointY_Range_Min_A = new double[MAX_POINT * 2];
      cParaRcp.abPointY_Range_Max_A = new double[MAX_POINT * 2];
      cParaRcp.abPointY_Range_Min_B = new double[MAX_POINT * 2];
      cParaRcp.abPointY_Range_Max_B = new double[MAX_POINT * 2];
      cParaRcp.abPointY_Range_Min_C = new double[MAX_POINT * 2];
      cParaRcp.abPointY_Range_Max_C = new double[MAX_POINT * 2];
      for (int i = 0; i < MAX_POINT; i++)
      {
        cParaRcp.adPointX[i] = 0.0;
        cParaRcp.adPointY1[i] = 0.0;
        cParaRcp.adPointY2[i] = 0.0;
        cParaRcp.abUsePointX[i] = false;
        cParaRcp.abUsePointY_Two[i] = false;

        cParaRcp.aiPointY1_Type[i] = (int)enumPointType.NONE;
        cParaRcp.aiPointY2_Type[i] = (int)enumPointType.NONE;

        cParaRcp.adPointY1_Stage1_Offset[i] = 0.0;
        cParaRcp.adPointY2_Stage1_Offset[i] = 0.0;
        cParaRcp.adPointY1_Stage2_Offset[i] = 0.0;
        cParaRcp.adPointY2_Stage2_Offset[i] = 0.0;

        cParaRcp.abPointY_Range_Min_A[i * 2] = 0;
        cParaRcp.abPointY_Range_Max_A[i * 2] = 0;
        cParaRcp.abPointY_Range_Min_B[i * 2] = 0;
        cParaRcp.abPointY_Range_Max_B[i * 2] = 0;
        cParaRcp.abPointY_Range_Min_C[i * 2] = 0;
        cParaRcp.abPointY_Range_Max_C[i * 2] = 0;

        cParaRcp.abPointY_Range_Min_A[i * 2 + 1] = 0;
        cParaRcp.abPointY_Range_Max_A[i * 2 + 1] = 0;
        cParaRcp.abPointY_Range_Min_B[i * 2 + 1] = 0;
        cParaRcp.abPointY_Range_Max_B[i * 2 + 1] = 0;
        cParaRcp.abPointY_Range_Min_C[i * 2 + 1] = 0;
        cParaRcp.abPointY_Range_Max_C[i * 2 + 1] = 0;
      }
      cParaRcp.iPointCount = 0;

      #endregion

      #endregion
    } // Only onece when program start up!
    #endregion

    #region Load/Save
    public static bool Set_Recipe_Buffer() // 현재 사용중인 레시피 이름 저장
    {
      string strPath = CVo.RECIPE_PATH + CVo.RECIPE_BUFFER_NAME;
      string strSection = "";
      string strKey = "";

      if (Directory.Exists(CVo.RECIPE_PATH) == false)
      {
        Directory.CreateDirectory(CVo.RECIPE_PATH);
      }

      if (0 == WritePrivateProfileString(strSection, strKey, CVo.RECIPE_CURRENT.ToString(), strPath))
      {
        return false;
      };
      return true;
    }
    public static bool Get_Recipe_Buffer() // 이전 사용중인 레시피 이름 로드
    {
      string strPath = CVo.RECIPE_PATH + CVo.RECIPE_BUFFER_NAME;
      string strSection = "";
      string strKey = "";
      int iSize = 32768;
      StringBuilder sbBuffer = new StringBuilder(iSize);

      if (Directory.Exists(CVo.RECIPE_PATH) == false)
      {
        Directory.CreateDirectory(CVo.RECIPE_PATH);
      }
      if (File.Exists(strPath) == false)
      {
        Set_Recipe_Buffer();
      }

      GetPrivateProfileString(strSection, strKey, "(NONE)", sbBuffer, iSize, strPath);
      if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
      {
        CVo.RECIPE_CURRENT = sbBuffer.ToString();
      }
      return true;
    }

    public static bool Load_Parameter_Recipe() // Load Parameter Recipe
    {
      string strPath = CVo.RECIPE_PATH + CVo.RECIPE_CURRENT + CVo.RECIPE_NAME;
      string strSection = "";
      string strKey = "";
      int iSize = 32768;
      StringBuilder sbBuffer = new StringBuilder(iSize);

      if (!Directory.Exists(CVo.RECIPE_PATH))
      {
        Directory.CreateDirectory(CVo.RECIPE_PATH);
      }
      if (!File.Exists(strPath))
      {
        return Save_Parameter_Recipe();
      }

      cParaRcp.aiPointY1_Type = new int[MAX_POINT];
      cParaRcp.aiPointY2_Type = new int[MAX_POINT];
      for (int i = 0; i < MAX_POINT; i++)
      {
        cParaRcp.aiPointY1_Type[i] = (int)enumPointType.NONE;
        cParaRcp.aiPointY2_Type[i] = (int)enumPointType.NONE;
      }

      var properties = cParaRcp.GetType().GetProperties();
      foreach (System.Reflection.PropertyInfo property in properties)
      {
        try
        {
          strKey = property.Name;
          sbBuffer.Clear();
          GetPrivateProfileString(strSection, strKey, "(NONE)", sbBuffer, iSize, strPath);
          if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
          {
            if (property.PropertyType.IsArray == true)
            {
              var val = sbBuffer.ToString().Split(',');
              Array arr = property.GetValue(cParaRcp, null) as Array;
              if (val.Length < arr.Length)
              {
                return false;
              }
              for (int i = 0; i < arr.Length; i++)
              {
                arr.SetValue(Convert.ChangeType(val[i], arr.GetType().GetElementType()), i);
              }
              property.SetValue(cParaRcp, arr, null);
            }
            else
            {
              var value = Convert.ChangeType(sbBuffer.ToString(), property.PropertyType);
              property.SetValue(cParaRcp, value, null);
            }
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          return false;
        }
      }
      return true;
    }
    public static bool Save_Parameter_Recipe() // Save Parameter Recipe
    {
      string strPath = CVo.RECIPE_PATH + CVo.RECIPE_CURRENT + CVo.RECIPE_NAME;
      string strSection = "";
      string strKey = "";

      if (!Directory.Exists(CVo.RECIPE_PATH))
      {
        Directory.CreateDirectory(CVo.RECIPE_PATH);
      }
      if (!Directory.Exists(CVo.RECIPE_PATH + CVo.RECIPE_CURRENT))
      {
        Directory.CreateDirectory(CVo.RECIPE_PATH + CVo.RECIPE_CURRENT);
      }

      var properties = cParaRcp.GetType().GetProperties();
      foreach (System.Reflection.PropertyInfo property in properties)
      {
        try
        {
          strKey = property.Name;
          var val = property.GetValue(cParaRcp, null);
          if (property.PropertyType.IsArray == true)
          {
            string strData = "";
            Array arr = property.GetValue(cParaRcp, null) as Array;
            for (int i = 0; i < arr.Length; i++)
            {
              if (i == 0)
              {
                strData += arr.GetValue(i).ToString();
              }
              else
              {
                strData += ("," + arr.GetValue(i).ToString());
              }
            }
            if (0 == WritePrivateProfileString(strSection, strKey, strData, strPath)) { return false; };
          }
          else
          {
            if (0 == WritePrivateProfileString(strSection, strKey, val.ToString(), strPath)) { return false; };
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          return false;
        }
      }
      return Load_Parameter_System();
    }
    public static bool Load_Parameter_System() // Load Parameter System
    {
      string strPath = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME;
      string strSection = "";
      string strKey = "";
      int iSize = 32768;
      StringBuilder sbBuffer = new StringBuilder(iSize);

      if (!Directory.Exists(CVo.SYSTEM_PATH))
      {
        Directory.CreateDirectory(CVo.SYSTEM_PATH);
      }
      if (!File.Exists(strPath))
      {
        return Save_Parameter_System();
      }

      var properties = cParaSys.GetType().GetProperties();
      foreach (System.Reflection.PropertyInfo property in properties)
      {
        try
        {
          strKey = property.Name;
          GetPrivateProfileString(strSection, strKey, "(NONE)", sbBuffer, iSize, strPath);
          if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
          {
            if (property.PropertyType.IsArray == true)
            {
              var val = sbBuffer.ToString().Split(',');
              Array arr = property.GetValue(cParaSys, null) as Array;
              if (val.Length < arr.Length)
              {
                return false;
              }
              for (int i = 0; i < arr.Length; i++)
              {
                arr.SetValue(Convert.ChangeType(val[i], arr.GetType().GetElementType()), i);
              }
              property.SetValue(cParaSys, arr, null);
            }
            else
            {
              var value = Convert.ChangeType(sbBuffer.ToString(), property.PropertyType);
              property.SetValue(cParaSys, value, null);
            }
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          return false;
        }
      }

      return true;
    }
    public static bool Save_Parameter_System() // Save Parameter System
    {
      string strPath = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME;
      string strSection = "";
      string strKey = "";

      if (!Directory.Exists(CVo.SYSTEM_PATH))
      {
        Directory.CreateDirectory(CVo.SYSTEM_PATH);
      }

      var properties = cParaSys.GetType().GetProperties();
      foreach (System.Reflection.PropertyInfo property in properties)
      {
        strKey = property.Name;
        var val = property.GetValue(cParaSys, null);
        if (property.PropertyType.IsArray == true)
        {
          string strData = "";
          Array arr = property.GetValue(cParaSys, null) as Array;
          for (int i = 0; i < arr.Length; i++)
          {
            if (i == 0)
            {
              strData += arr.GetValue(i).ToString();
            }
            else
            {
              strData += ("," + arr.GetValue(i).ToString());
            }
          }
          if (0 == WritePrivateProfileString(strSection, strKey, strData, strPath)) { return false; };
        }
        else
        {
          if (0 == WritePrivateProfileString(strSection, strKey, val.ToString(), strPath)) { return false; };
        }
      }

      return true;
    }

    public static bool Change_Parameter_System(ClassSystemPara sys) // 시스템 로그 저장
    {
      string strDate = System.DateTime.Now.ToString("yyyyMMdd");
      string strPath = CVo.LOG_PATH_CHANGE_PARAMETER;
      string strName = strDate + "_" + CVo.LOG_NAME_CHANGE_PARAMETER;
      string strPathFull = strPath + strName;
      bool bExist = false;
      if (!System.IO.Directory.Exists(strPath))
      {
        System.IO.Directory.CreateDirectory(strPath);
      }
      bExist = System.IO.File.Exists(strPathFull);
      bool bResult = true;
      System.IO.StreamWriter sw = null;

      ClassSystemPara cOld = CVo.cParaSys.GetValues(); // 기존 데이터 가지고 있기

      List<object> listChangedItems = new List<object>();
      listChangedItems.Clear();
      string strChangedDate = System.DateTime.Now.ToString("yyyyMMddHHmmss");
      try
      {
        string strData = "";
        sw = new System.IO.StreamWriter(strPathFull, true, System.Text.Encoding.UTF8);
        if (bExist == false)
        {
          strData = "Time,Type,RecipeName,ParameterName,OldValue,NewValue,ID,MachineStatus";
          sw.WriteLine(strData);
        }
        var properties = cParaSys.GetType().GetProperties();
        foreach (System.Reflection.PropertyInfo property in properties)
        {
          if (property.PropertyType.IsArray == true)
          {
            Array arr = property.GetValue(cParaSys, null) as Array;
            var properties2 = sys.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo property2 in properties2)
            {
              if (property.Name.CompareTo(property2.Name) == 0)
              {
                Array arr2 = property.GetValue(sys, null) as Array;
                for (int i = 0; i < arr.Length; i++)
                {
                  if (arr.GetValue(i).ToString().CompareTo(arr2.GetValue(i).ToString()) != 0)
                  {
                    string strParamName = property.Name.ToString() + "[" + i.ToString() + "]";
                    strData = string.Format("{0},{1},{2},{3},{4},{5},{6}", strChangedDate, "SystemData", "", strParamName, arr.GetValue(i).ToString(), arr2.GetValue(i).ToString(), CVo.strCurrentUser, CVo.eMachineStatus.ToString());
                    sw.WriteLine(strData);
                  }
                }
                break;
              }
            }
          }
          else
          {
            var properties2 = sys.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo property2 in properties2)
            {
              if (property.Name.CompareTo(property2.Name) == 0)
              {
                var val1 = property.GetValue(cParaSys, null);
                var val2 = property2.GetValue(sys, null);
                if (val1.ToString().CompareTo(val2.ToString()) != 0)
                {
                  strData = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", strChangedDate, "SystemData", "", property.Name.ToString(), val1, val2, CVo.strCurrentUser, CVo.eMachineStatus.ToString());
                  sw.WriteLine(strData);
                }
                break;
              }
            }
          }
        }
        CVo.cParaSys = sys.GetValues();
        bool bSave = CVo.Save_Parameter_System();
        if (bSave == false)
        {
          CVo.cParaSys = cOld.GetValues();
          if (sw != null)
          {
            sw.Close();
            sw = null;
          }
          return false;
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        if (sw != null)
        {
          sw.Close();
          sw = null;
        }
      }

      if (bResult == false)
      {
        return false;
      }
      return true;
    }
    public static bool Change_Parameter_Recipe(ClassRecipePara rcp) // 레시피 로그 저장
    {
      string strDate = System.DateTime.Now.ToString("yyyyMMdd");
      string strPath = CVo.LOG_PATH_CHANGE_PARAMETER;
      string strName = strDate + "_" + CVo.LOG_NAME_CHANGE_PARAMETER;
      string strPathFull = strPath + strName;
      bool bExist = false;
      if (!System.IO.Directory.Exists(strPath))
      {
        System.IO.Directory.CreateDirectory(strPath);
      }
      bExist = System.IO.File.Exists(strPathFull);
      bool bResult = true;
      System.IO.StreamWriter sw = null;

      ClassRecipePara cOld = CVo.cParaRcp.GetValues(); // 기존 데이터 가지고 있기

      List<object> listChangedItems = new List<object>();
      listChangedItems.Clear();
      string strChangedDate = System.DateTime.Now.ToString("yyyyMMddHHmmss");
      try
      {
        string strData = "";
        sw = new System.IO.StreamWriter(strPathFull, true, System.Text.Encoding.UTF8);
        if (bExist == false)
        {
          strData = "Time,Type,RecipeName,ParameterName,OldValue,NewValue,ID,MachineStatus";
          sw.WriteLine(strData);
        }
        var properties = cParaRcp.GetType().GetProperties();
        foreach (System.Reflection.PropertyInfo property in properties)
        {
          if (property.PropertyType.IsArray == true)
          {
            Array arr = property.GetValue(cParaRcp, null) as Array;
            var properties2 = rcp.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo property2 in properties2)
            {
              if (property.Name.CompareTo(property2.Name) == 0)
              {
                Array arr2 = property.GetValue(rcp, null) as Array;
                for (int i = 0; i < arr.Length; i++)
                {
                  if (arr.GetValue(i).ToString().CompareTo(arr2.GetValue(i).ToString()) != 0)
                  {
                    string strParamName = property.Name.ToString() + "[" + i.ToString() + "]";
                    strData = string.Format("{0},{1},{2},{3},{4},{5},{6}", strChangedDate, "RecipeData", CVo.RECIPE_CURRENT, strParamName, arr.GetValue(i).ToString(), arr2.GetValue(i).ToString(), CVo.strCurrentUser, CVo.eMachineStatus.ToString());
                    sw.WriteLine(strData);
                  }
                }
                break;
              }
            }
          }
          else
          {
            var properties2 = rcp.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo property2 in properties2)
            {
              if (property.Name.CompareTo(property2.Name) == 0)
              {
                var val1 = property.GetValue(cParaRcp, null);
                var val2 = property2.GetValue(rcp, null);
                if (val1.ToString().CompareTo(val2.ToString()) != 0)
                {
                  strData = string.Format("{0},{1},{2},{3},{4},{5},{6}", strChangedDate, "RecipeData", CVo.RECIPE_CURRENT, property.Name.ToString(), val1, val2, CVo.strCurrentUser, CVo.eMachineStatus.ToString());
                  sw.WriteLine(strData);
                }
                break;
              }
            }
          }
        }
        CVo.cParaRcp = rcp.GetValues();
        bool bSave = CVo.Save_Parameter_Recipe();
        if (bSave == false)
        {
          CVo.cParaRcp = cOld.GetValues();
          if (sw != null)
          {
            sw.Close();
            sw = null;
          }
          return false;
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        if (sw != null)
        {
          sw.Close();
          sw = null;
        }
      }

      if (bResult == false)
      {
        return false;
      }

      return true;
    }

    public static bool Save_MeasureData(int index) // 데이터 로그 저장 함수
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      string strDate = System.DateTime.Now.ToString("yyyyMMdd");
      string strDateTime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
      string strPath = CVo.LOG_PATH_DATA;
      string strName = strDate + "_" + CVo.LOG_NAME_DATA;
      string strPathFull = strPath + strName;
      bool bExist = false;
      if (System.IO.Directory.Exists(strPath) == false)
      {
        System.IO.Directory.CreateDirectory(strPath);
      }
      bExist = System.IO.File.Exists(strPathFull);
      bool bResult = true;
      System.IO.StreamWriter sw = null;

      try
      {
        string strData = "";
        sw = new System.IO.StreamWriter(strPathFull, true, System.Text.Encoding.UTF8);

        if (bExist == false)
        {
          strData = "Index,Time,Barcode,StageNum";
          for (int i = 0; i < CVo.MAX_POINT * 2; i++)
          {
            strData += ("," + (i + 1).ToString());
          }
          sw.WriteLine(strData);
        }

        strData =
          (index + 1).ToString() + ","
          + strDateTime + ","
          + CVo.sPCBData[index].BCR + ","
          + (CVo.sPCBData[index].StageNumber + 1).ToString();
        for (int i = 0; i < CVo.sPCBData[index].MeasurePointValue.Count; i++)
        {
          strData += ("," + CVo.sPCBData[index].MeasurePointValue[i].ToString());
        }
        sw.WriteLine(strData);
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        if (sw != null)
        {
          sw.Close();
          sw = null;
        }
      }

      if (bResult == false)
      {
        return false;
      }
      if (CVo.sPCBData[index].BCR_OK == false
       || CVo.sPCBData[index].BCR.Trim().CompareTo("SKIP") == 0)
      {
        return false;
      }
      return true;
    }

    public static bool Save_Lot_Log() // 랏 정보 저장
    {
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues(); // 레시피 정보
      ClassSystemPara cSys = CVo.cParaSys.GetValues(); // 시스템 정보

      int iPCB_Result_A = 0;
      int iPCB_Result_B = 0;
      int iPCB_Result_C = 0;
      int iPCB_Result_D = 0;
      int iPCBCount = 0; // 공정 완료 소재 갯수
      int iPointCount = 0;
      for (int i = 0; i < CVo.sPCBData.Length; i++)
      {
        if (CVo.sPCBData[i].PerfectlyOut)
        {
          iPCBCount++;
          switch (CVo.sPCBData[i].Result)
          {
            case enumPCBResult.A: iPCB_Result_A++; break;
            case enumPCBResult.B: iPCB_Result_B++; break;
            case enumPCBResult.C: iPCB_Result_C++; break;
            case enumPCBResult.D:
            case enumPCBResult.NONE:
            default:
              iPCB_Result_D++;
              break;
          }
          iPointCount = CVo.sPCBData[i].MeasurePointValue.Count; // 포인트 갯수
        }
      }

      TimeSpan LotTactTime = CVo.sTactTime_LotEnd - CVo.sTactTime_LotStart; // 텍타임 계산
      double dTotalTime = LotTactTime.TotalSeconds; // 총 랏 텍타임 정보
      double dCycleTime = dTotalTime / iPCBCount; // 개당 텍타임 정보(평균)

      string strDate = System.DateTime.Now.ToString("yyyyMMddHHmmss");
      string strPath = CVo.LOG_PATH_LOT_INFO;
      string strName = strDate + "_" + CVo.LOG_NAME_LOT_INFO;
      string strPathFull = strPath + strName;
      bool bExist = false;
      if (!System.IO.Directory.Exists(strPath))
      {
        System.IO.Directory.CreateDirectory(strPath);
      }
      bExist = System.IO.File.Exists(strPathFull);
      bool bResult = true;
      System.IO.StreamWriter sw = null;
      try
      {
        string strData = "";
        sw = new System.IO.StreamWriter(strPathFull, true, System.Text.Encoding.UTF8);


        if (bExist == false)
        {
          strData = ("Recipe Name:," + CVo.RECIPE_CURRENT.ToString());
          sw.WriteLine(strData);

          strData = ("UE Use Mode:," + ((enumUEUseMode)cRcp.iUEMode).ToString());
          sw.WriteLine(strData);

          strData = ("LOT Count:," + iPCBCount.ToString());
          sw.WriteLine(strData);

          strData = ("A Count:," + iPCB_Result_A.ToString());
          sw.WriteLine(strData);

          strData = ("B Count:," + iPCB_Result_B.ToString());
          sw.WriteLine(strData);

          strData = ("C Count:," + iPCB_Result_C.ToString());
          sw.WriteLine(strData);

          strData = ("D Count:," + iPCB_Result_D.ToString());
          sw.WriteLine(strData);

          strData = ("Total Tact Time:," + dTotalTime.ToString());
          sw.WriteLine(strData);

          strData = ("1Cycle Tact Time(Average):," + dCycleTime.ToString());
          sw.WriteLine(strData);

          strData = ("Number,Barcode,Stage,Start Time,Result");
          for (int i = 0; i < iPointMax * 2; i++)
          {
            strData += ("," + (i + 1).ToString());
          }
          sw.WriteLine(strData);


          int iTempIndex = -1;
          for (int i = 0; i < CVo.sPCBData.Length; i++)
          {
            if (CVo.sPCBData[i].PerfectlyOut)
            {
              iTempIndex++;
              strData = (iTempIndex + 1).ToString();
              strData += ("," + CVo.sPCBData[i].BCR.ToString());
              strData += ("," + (CVo.sPCBData[i].StageNumber + 1).ToString());
              strData += ("," + CVo.sPCBData[i].Total_StartTime.ToString("yyyyMMddHHmmss"));
              strData += ("," + CVo.sPCBData[i].Result.ToString());
              for (int j = 0; j < CVo.sPCBData[i].MeasurePointValue.Count; j++)
              {
                strData += ("," + CVo.sPCBData[i].MeasurePointValue[j].ToString("0.000"));
              }

              sw.WriteLine(strData);
            }
          }
        }

      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        if (sw != null)
        {
          sw.Close();
          sw = null;
        }
      }

      if (bResult == false)
      {
        return false;
      }

      CVo.dTactTime_Total = dTotalTime;
      CVo.dTactTime_Average = dCycleTime;
      CVo.bRefreshInfo = true;
      return true;
    }


    public static bool Save_Test_Log(string fileName/*Full File Name ex) test.csv*/, double[] values) // Test Log
    {
      string strFilePath = CVo.LOG_PATH_TEST;
      string strFileName = fileName;
      System.DateTime sDate = System.DateTime.Now;
      string strFileFullPath = strFilePath + strFileName;
      bool bError = false;

      System.IO.StreamWriter sw = null;
      try
      {
        if (System.IO.Directory.Exists(strFilePath) == false)
        {
          System.IO.Directory.CreateDirectory(strFilePath);
        }
        sw = new System.IO.StreamWriter(strFileFullPath, true, System.Text.Encoding.UTF8);
        string strData = "";
        for (int i = 0; i < values.Length; i++)
        {
          if (i == 0)
          {
            strData = values[i].ToString("0.000");
          }
          else
          {
            strData += ("," + values[i].ToString("0.000"));
          }
        }
        sw.WriteLine(strData);
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bError = true;
      }
      finally
      {
        if (sw != null)
        {
          sw.Close();
        }
      }
      if (bError)
      {
        return false;
      }

      return true;
    }

    #endregion

    #region Delete LogData
    public static bool Delete_Old_Log(int days)
    {
      try
      {
        System.DateTime date = System.DateTime.Now.AddDays(-days);
        for (int i = 0; i < LOG_DELETE_PATH.Count; i++)
        {
          if (System.IO.Directory.Exists(LOG_DELETE_PATH[i]) == false)
          {
            continue;
          }
          System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(LOG_DELETE_PATH[i]);
          System.IO.FileInfo[] fi = di.GetFiles();
          for (int j = 0; j < fi.Length; j++)
          {
            string strName = Path.GetFileName(fi[j].FullName);
            string[] arrName = strName.Split('_');
            if (arrName.Length > 1)
            {
              System.DateTime sTemp;
              if (System.DateTime.TryParseExact(arrName[0], "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sTemp) == false)
              {
                if (System.DateTime.TryParseExact(arrName[0], "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sTemp) == false)
                {
                  continue;
                }
              }
              if (sTemp < date)
              {
                System.IO.File.Delete(fi[j].FullName);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        return false;
      }
      return true;
    }
    #endregion

    #region Alarm
    public static bool Create_Alarm()
    {
      string strDBPath = UI_PATH + UI_NAME_ALARM;
      bool bResult = true;

      if (!System.IO.Directory.Exists(UI_PATH))
      {
        System.IO.Directory.CreateDirectory(UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        bool bCreated = false;
        try
        {
          string strNewDB =
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                        + strDBPath
                        + ";Jet OLEDB:Database Password="
                        + "";
          Type objClassType = Type.GetTypeFromProgID("ADOX.Catalog");
          if (objClassType != null)
          {
            object obj = Activator.CreateInstance(objClassType);
            // Create MDB file
            obj.GetType().InvokeMember("Create", System.Reflection.BindingFlags.InvokeMethod, null, obj, new object[] { "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strNewDB + ";" });
            bCreated = true;
            // Clean up
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        if (!bResult)
        {
          return false;
        }
        if (!bCreated)
        {
          return false;
        }

        System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
        System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
        try
        {
          conn.ConnectionString =
                        @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                        + strDBPath
                        + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                        + "";
          conn.Open();
          connCmd.Connection = conn;

          string strCaption = "Num text";
          for (int i = 0; i < Enum.GetNames(typeof(enumLanguageType)).Length; i++)
          {
            strCaption += string.Format(", {0}_Name text, {0}_Info text", ((enumLanguageType)i).ToString());
          }

          connCmd.CommandText = "CREATE TABLE "
                              + "tbAlarmStop" + "("
                              + strCaption
                              + ")";
          connCmd.ExecuteNonQuery();

          connCmd.CommandText = "CREATE TABLE "
                              + "tbAlarmWarn" + "("
                              + strCaption
                              + ")";

          connCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        finally
        {
          conn.Close();
        }
        if (!bResult)
        {
          return false;
        }

        try
        {
          conn.ConnectionString =
              @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
              + strDBPath
              + ";Mode=ReadWrite;Jet OLEDB:Database Password="
              + "";
          conn.Open();
          connCmd.Connection = conn;
          string strSql = "";
          for (int i = 0; i < Enum.GetNames(typeof(enumAlarmStop)).Length; i++)
          {
            strSql = string.Format("INSERT INTO tbAlarmStop VALUES('{0}'", i);
            for (int j = 0; j < Enum.GetNames(typeof(enumLanguageType)).Length; j++)
            {
              strSql += string.Format(",'{0}','{0}'", ((enumAlarmStop)i).ToString());
            }
            strSql += ");";
            connCmd.CommandText = strSql;
            connCmd.ExecuteNonQuery();
          }

          for (int i = 0; i < Enum.GetNames(typeof(enumAlarmWarn)).Length; i++)
          {
            strSql = string.Format("INSERT INTO tbAlarmWarn VALUES('{0}'", i);
            for (int j = 0; j < Enum.GetNames(typeof(enumLanguageType)).Length; j++)
            {
              strSql += string.Format(",'{0}','{0}'", ((enumAlarmWarn)i).ToString());
            }
            strSql += ");";
            connCmd.CommandText = strSql;
            connCmd.ExecuteNonQuery();
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        finally
        {
          conn.Dispose();
          conn.Close();
        }
        if (!bResult)
        {
          return false;
        }
      }
      return true;
    } //Create Alarm DB
    public static bool Organize_Alarm()
    {
      string strDBPath = UI_PATH + UI_NAME_ALARM;
      bool bResult = true;
      if (!System.IO.Directory.Exists(UI_PATH))
      {
        System.IO.Directory.CreateDirectory(UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        return Create_Alarm();
      }

      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
      System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
      System.Data.DataSet Ds = new System.Data.DataSet();
      System.Data.OleDb.OleDbDataAdapter pAdapter = new System.Data.OleDb.OleDbDataAdapter();
      string strSql = "SELECT Num, " + enumLanguageType.Default_Caption.ToString() + "_Name" + " FROM tbAlarmStop;";
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        pAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strSql, conn);
        pAdapter.Fill(Ds);
        connCmd.Connection = conn;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      List<int> listDelIndexStop = new List<int>();
      List<int> listAddIndexStop = new List<int>();
      listDelIndexStop.Clear();
      listAddIndexStop.Clear();

      if (Ds.Tables.Count > 0)
      {
        int iNum = 0;
        bool bExist = false;
        for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
        {
          try
          {
            iNum = Convert.ToInt32(Ds.Tables[0].Rows[i][0].ToString());
          }
          catch (Exception ex)
          {
            CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
            return false;
          }
          if (((enumAlarmStop)iNum).ToString().CompareTo(Ds.Tables[0].Rows[i][1].ToString()) != 0)
          {
            listDelIndexStop.Add(iNum);
          }
        }

        for (int i = 0; i < Enum.GetNames(typeof(enumAlarmStop)).Length; i++)
        {
          bExist = false;
          for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
          {
            iNum = 0;
            try
            {
              iNum = Convert.ToInt32(Ds.Tables[0].Rows[j][0].ToString());
            }
            catch (Exception ex)
            {
              CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
              return false;
            }
            if (iNum == i)
            {
              if (((enumAlarmStop)i).ToString().CompareTo(Ds.Tables[0].Rows[j][1].ToString()) == 0)
              {
                bExist = true;
                break;
              }
            }
          }
          if (bExist == false)
          {
            listAddIndexStop.Add(i);
          }
        }
      }


      System.Data.OleDb.OleDbConnection conn2 = new System.Data.OleDb.OleDbConnection();
      System.Data.OleDb.OleDbCommand connCmd2 = new System.Data.OleDb.OleDbCommand();
      System.Data.DataSet Ds2 = new System.Data.DataSet();
      System.Data.OleDb.OleDbDataAdapter pAdapter2 = new System.Data.OleDb.OleDbDataAdapter();
      string strSql2 = "SELECT Num, " + enumLanguageType.Default_Caption.ToString() + "_Name" + " FROM tbAlarmWarn;";
      try
      {
        conn2.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn2.Open();
        pAdapter2.SelectCommand = new System.Data.OleDb.OleDbCommand(strSql2, conn2);
        pAdapter2.Fill(Ds2);
        connCmd2.Connection = conn2;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }
      List<int> listDelIndexWarn = new List<int>();
      List<int> listAddIndexWarn = new List<int>();
      listDelIndexWarn.Clear();
      listAddIndexWarn.Clear();

      if (Ds2.Tables.Count > 0)
      {
        int iNum = 0;
        bool bExist = false;
        for (int i = 0; i < Ds2.Tables[0].Rows.Count; i++)
        {
          try
          {
            iNum = Convert.ToInt32(Ds2.Tables[0].Rows[i][0].ToString());
          }
          catch (Exception ex)
          {
            CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
            return false;
          }
          if (((enumAlarmWarn)iNum).ToString().CompareTo(Ds2.Tables[0].Rows[i][1].ToString()) != 0)
          {
            listDelIndexWarn.Add(iNum);
          }
        }

        for (int i = 0; i < Enum.GetNames(typeof(enumAlarmWarn)).Length; i++)
        {
          bExist = false;
          for (int j = 0; j < Ds2.Tables[0].Rows.Count; j++)
          {
            iNum = 0;
            try
            {
              iNum = Convert.ToInt32(Ds2.Tables[0].Rows[j][0].ToString());
            }
            catch (Exception ex)
            {
              CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
              return false;
            }
            if (iNum == i)
            {
              if (((enumAlarmWarn)i).ToString().CompareTo(Ds2.Tables[0].Rows[j][1].ToString()) == 0)
              {
                bExist = true;
                break;
              }
            }
          }
          if (bExist == false)
          {
            listAddIndexWarn.Add(i);
          }
        }
      }

      if (listDelIndexStop.Count < 0
       && listAddIndexStop.Count < 0
       && listDelIndexWarn.Count < 0
       && listAddIndexWarn.Count < 0)
      {
        return true;
      }

      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        connCmd.Connection = conn;

        for (int i = 0; i < listDelIndexStop.Count; i++)
        {
          connCmd.CommandText = string.Format("DELETE * FROM tbAlarmStop WHERE Num='{0}';", listDelIndexStop[i]);
          connCmd.ExecuteNonQuery();
        }
        for (int i = 0; i < listDelIndexWarn.Count; i++)
        {
          connCmd.CommandText = string.Format("DELETE * FROM tbAlarmWarn WHERE Num='{0}';", listDelIndexWarn[i]);
          connCmd.ExecuteNonQuery();
        }

        for (int i = 0; i < listAddIndexStop.Count; i++)
        {
          string strAddCmd = string.Format("INSERT INTO tbAlarmStop VALUES('{0}'", listAddIndexStop[i]);
          for (int j = 0; j < Enum.GetNames(typeof(enumLanguageType)).Length; j++)
          {
            strAddCmd += string.Format(",'{0}','{0}'", ((enumAlarmStop)listAddIndexStop[i]).ToString());
          }
          strAddCmd += ");";
          connCmd.CommandText = strAddCmd;
          connCmd.ExecuteNonQuery();
        }

        for (int i = 0; i < listAddIndexWarn.Count; i++)
        {
          string strAddCmd = string.Format("INSERT INTO tbAlarmWarn VALUES('{0}'", listAddIndexWarn[i]);
          for (int j = 0; j < Enum.GetNames(typeof(enumLanguageType)).Length; j++)
          {
            strAddCmd += string.Format(",'{0}','{0}'", ((enumAlarmWarn)listAddIndexWarn[i]).ToString());
          }
          strAddCmd += ");";
          connCmd.CommandText = strAddCmd;
          connCmd.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      return true;
    } //Organize Alarm DB
    public static bool Load_AlarmList(enumLanguageType eType)
    {
      string strDBPath = UI_PATH + UI_NAME_ALARM;
      bool bResult = true;
      if (!System.IO.Directory.Exists(UI_PATH))
      {
        System.IO.Directory.CreateDirectory(UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        return Create_Alarm();
      }

      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
      System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
      System.Data.DataSet Ds = new System.Data.DataSet();
      System.Data.OleDb.OleDbDataAdapter pAdapter = new System.Data.OleDb.OleDbDataAdapter();
      string strSql = string.Format("SELECT Num, {0}_Name, {0}_Info FROM tbAlarmStop;", eType.ToString());
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        pAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strSql, conn);
        pAdapter.Fill(Ds);
        connCmd.Connection = conn;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      if (Ds.Tables.Count <= 0)
      {
        return false;
      }

      for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
      {
        int iNum = 0;
        try
        {
          iNum = Convert.ToInt32(Ds.Tables[0].Rows[i][0].ToString());
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          return false;
        }
        if (arrAlarmStopName.Length > iNum)
        {
          arrAlarmStopName[iNum] = Ds.Tables[0].Rows[i][1].ToString();
          arrAlarmStopInfo[iNum] = Ds.Tables[0].Rows[i][2].ToString();
        }
      }

      strSql = string.Format("SELECT Num, {0}_Name, {0}_Info FROM tbAlarmWarn;", eType.ToString());
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        pAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strSql, conn);
        pAdapter.Fill(Ds);
        connCmd.Connection = conn;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      if (Ds.Tables.Count <= 0)
      {
        return false;
      }

      for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
      {
        int iNum = 0;
        try
        {
          iNum = Convert.ToInt32(Ds.Tables[0].Rows[i][0].ToString());
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          return false;
        }
        if (arrAlarmWarnName.Length > iNum)
        {
          arrAlarmWarnName[iNum] = Ds.Tables[0].Rows[i][1].ToString();
          arrAlarmWarnInfo[iNum] = Ds.Tables[0].Rows[i][2].ToString();
        }
      }

      return true;
    } //Load Alarm list from Alarm DB
    #endregion

    #region Message
    public static bool Create_Msg()
    {
      string strDBPath = UI_PATH + UI_NAME_MESSAGE;
      bool bResult = true;

      if (!System.IO.Directory.Exists(UI_PATH))
      {
        System.IO.Directory.CreateDirectory(UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        bool bCreated = false;
        try
        {
          string strNewDB =
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                        + strDBPath
                        + ";Jet OLEDB:Database Password="
                        + "";
          Type objClassType = Type.GetTypeFromProgID("ADOX.Catalog");
          if (objClassType != null)
          {
            object obj = Activator.CreateInstance(objClassType);
            // Create MDB file
            obj.GetType().InvokeMember("Create", System.Reflection.BindingFlags.InvokeMethod, null, obj, new object[] { "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strNewDB + ";" });
            bCreated = true;
            // Clean up
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        if (!bResult)
        {
          return false;
        }
        if (!bCreated)
        {
          return false;
        }

        System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
        System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
        try
        {
          conn.ConnectionString =
                        @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                        + strDBPath
                        + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                        + "";
          conn.Open();
          connCmd.Connection = conn;

          string strCaption = "Num text";
          for (int i = 0; i < Enum.GetNames(typeof(enumLanguageType)).Length; i++)
          {
            strCaption += string.Format(", {0}_Name text, {0}_Info text", ((enumLanguageType)i).ToString());
          }

          connCmd.CommandText = "CREATE TABLE "
                              + "tbMessage" + "("
                              + strCaption
                              + ")";
          connCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        finally
        {
          conn.Close();
        }
        if (!bResult)
        {
          return false;
        }

        try
        {
          conn.ConnectionString =
              @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
              + strDBPath
              + ";Mode=ReadWrite;Jet OLEDB:Database Password="
              + "";
          conn.Open();
          connCmd.Connection = conn;
          string strSql = "";
          for (int i = 0; i < Enum.GetNames(typeof(enumMsg)).Length; i++)
          {
            strSql = string.Format("INSERT INTO tbMessage VALUES('{0}'", i);
            for (int j = 0; j < Enum.GetNames(typeof(enumLanguageType)).Length; j++)
            {
              strSql += string.Format(",'{0}','{0}'", ((enumMsg)i).ToString());
            }
            strSql += ");";
            connCmd.CommandText = strSql;
            connCmd.ExecuteNonQuery();
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        finally
        {
          conn.Dispose();
          conn.Close();
        }
        if (!bResult)
        {
          return false;
        }

      }
      return true;
    } //Create Message DB
    public static bool Organize_Msg()
    {
      string strDBPath = UI_PATH + UI_NAME_MESSAGE;
      bool bResult = true;
      if (!System.IO.Directory.Exists(UI_PATH))
      {
        System.IO.Directory.CreateDirectory(UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        return Create_Msg();
      }

      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
      System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
      System.Data.DataSet Ds = new System.Data.DataSet();
      System.Data.OleDb.OleDbDataAdapter pAdapter = new System.Data.OleDb.OleDbDataAdapter();
      string strSql = "SELECT Num, " + enumLanguageType.Default_Caption.ToString() + "_Name" + " FROM tbMessage;";
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        pAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strSql, conn);
        pAdapter.Fill(Ds);
        connCmd.Connection = conn;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      List<int> listDelIndexMsg = new List<int>();
      List<int> listAddIndexMsg = new List<int>();
      listDelIndexMsg.Clear();
      listAddIndexMsg.Clear();

      if (Ds.Tables.Count > 0)
      {
        int iNum = 0;
        bool bExist = false;
        for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
        {
          try
          {
            iNum = Convert.ToInt32(Ds.Tables[0].Rows[i][0].ToString());
          }
          catch (Exception ex)
          {
            CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
            return false;
          }
          if (((enumMsg)iNum).ToString().CompareTo(Ds.Tables[0].Rows[i][1].ToString()) != 0)
          {
            listDelIndexMsg.Add(iNum);
          }
        }

        for (int i = 0; i < Enum.GetNames(typeof(enumMsg)).Length; i++)
        {
          bExist = false;
          for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
          {
            iNum = 0;
            try
            {
              iNum = Convert.ToInt32(Ds.Tables[0].Rows[j][0].ToString());
            }
            catch (Exception ex)
            {
              CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
              return false;
            }
            if (iNum == i)
            {
              if (((enumMsg)i).ToString().CompareTo(Ds.Tables[0].Rows[j][1].ToString()) == 0)
              {
                bExist = true;
                break;
              }
            }
          }
          if (bExist == false)
          {
            listAddIndexMsg.Add(i);
          }
        }
      }

      strSql = "SELECT Num, " + enumLanguageType.Default_Caption.ToString() + "_Name" + " FROM tbMessage;";
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        pAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strSql, conn);
        pAdapter.Fill(Ds);
        connCmd.Connection = conn;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      if (listDelIndexMsg.Count <= 0
       && listAddIndexMsg.Count <= 0)
      {
        return true;
      }

      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        connCmd.Connection = conn;

        for (int i = 0; i < listDelIndexMsg.Count; i++)
        {
          connCmd.CommandText = string.Format("DELETE * FROM tbMessage WHERE Num='{0}';", listDelIndexMsg[i]);
          connCmd.ExecuteNonQuery();
        }

        for (int i = 0; i < listAddIndexMsg.Count; i++)
        {
          string strAddCmd = string.Format("INSERT INTO tbMessage VALUES('{0}'", listAddIndexMsg[i]);
          for (int j = 0; j < Enum.GetNames(typeof(enumLanguageType)).Length; j++)
          {
            strAddCmd += string.Format(",'{0}','{0}'", ((enumMsg)listAddIndexMsg[i]).ToString());
          }
          strAddCmd += ");";
          connCmd.CommandText = strAddCmd;
          connCmd.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      return true;
    } //Organize Message DB
    public static bool Load_MsgList(enumLanguageType eType)
    {
      string strDBPath = UI_PATH + UI_NAME_MESSAGE;
      bool bResult = true;
      if (!System.IO.Directory.Exists(UI_PATH))
      {
        System.IO.Directory.CreateDirectory(UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        return Create_Msg();
      }

      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
      System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
      System.Data.DataSet Ds = new System.Data.DataSet();
      System.Data.OleDb.OleDbDataAdapter pAdapter = new System.Data.OleDb.OleDbDataAdapter();
      string strSql = string.Format("SELECT Num, {0}_Name, {0}_Info FROM tbMessage;", eType.ToString());
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        pAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strSql, conn);
        pAdapter.Fill(Ds);
        connCmd.Connection = conn;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      if (Ds.Tables.Count <= 0)
      {
        return false;
      }

      for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
      {
        int iNum = 0;
        try
        {
          iNum = Convert.ToInt32(Ds.Tables[0].Rows[i][0].ToString());
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          return false;
        }
        if (arrMsgName.Length > iNum)
        {
          arrMsgName[iNum] = Ds.Tables[0].Rows[i][1].ToString();
          arrMsgInfo[iNum] = Ds.Tables[0].Rows[i][2].ToString();
        }
      }

      return true;
    } //Load Message list from Message DB
    #endregion

    #region User
    public static bool Create_UserDB()
    {
      string strDBPath = UI_PATH + UI_NAME_USER;
      bool bResult = true;
      if (!System.IO.Directory.Exists(UI_PATH))
      {
        System.IO.Directory.CreateDirectory(UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        bool bCreated = false;
        try
        {
          string strNewDB =
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                        + strDBPath
                        + ";Jet OLEDB:Database Password="
                        + "";
          Type objClassType = Type.GetTypeFromProgID("ADOX.Catalog");
          if (objClassType != null)
          {
            object obj = Activator.CreateInstance(objClassType);
            // Create MDB file
            obj.GetType().InvokeMember("Create", System.Reflection.BindingFlags.InvokeMethod, null, obj, new object[] { "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strNewDB + ";" });
            bCreated = true;
            // Clean up
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        if (!bResult)
        {
          return false;
        }
        if (!bCreated)
        {
          return false;
        }

        System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
        System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
        try
        {
          conn.ConnectionString =
                        @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                        + strDBPath
                        + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                        + "";
          conn.Open();
          connCmd.Connection = conn;
          connCmd.CommandText = "CREATE TABLE "
          + "tbUser" + "("
          + "USER_ID" + " text,"
          + "USER_PW" + " text,"
          + "USER_INFO" + " text,"
          + "USER_LEVEL" + " text"
          + ")";
          connCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        finally
        {
          conn.Close();
        }
        if (!bResult)
        {
          return false;
        }
      }
      return true;
    }  //Create User DB
    public static bool Delete_User(string id)
    {
      string strDBPath = UI_PATH + UI_NAME_USER;
      bool bResult = true;
      if (!System.IO.Directory.Exists(UI_PATH))
      {
        System.IO.Directory.CreateDirectory(UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        Create_UserDB();
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        return false;
      }
      if (Check_ExistUser(id) == false)
      {
        return false;
      }
      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
      System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
      System.Data.DataSet Ds = new System.Data.DataSet();
      System.Data.OleDb.OleDbDataAdapter pAdapter = new System.Data.OleDb.OleDbDataAdapter();
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        connCmd.Connection = conn;
        connCmd.CommandText = string.Format("DELETE * FROM tbUser WHERE USER_ID='{0}';", id);
        connCmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }
      return true;
    } //Delete ID from User DB
    public static bool Create_User(string id, string pw, string info, enumUserLevel level)
    {
      string strDBPath = UI_PATH + UI_NAME_USER;
      bool bResult = true;
      if (!System.IO.Directory.Exists(UI_PATH))
      {
        System.IO.Directory.CreateDirectory(UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        Create_UserDB();
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        return false;
      }
      if (Check_ExistUser(id))
      {
        return false;
      }

      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
      System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
      System.Data.DataSet Ds = new System.Data.DataSet();
      System.Data.OleDb.OleDbDataAdapter pAdapter = new System.Data.OleDb.OleDbDataAdapter();
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        connCmd.Connection = conn;
        connCmd.CommandText = string.Format("INSERT INTO tbUser VALUES('{0}','{1}','{2}','{3}');"
          , id
          , pw
          , info
          , level.ToString()
          );
        connCmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      return true;
    } //Create ID User DB
    public static bool Modify_User(string id, string pw, string info, enumUserLevel level)
    {
      //????? 안써도 되나? 삭제후 재생성으로 할수도 잇슴 --> 현재 안씀
      return true;
    }
    public static bool Check_ExistUser(string id)
    {
      string strDBPath = UI_PATH + UI_NAME_USER;
      bool bResult = true;
      if (!System.IO.Directory.Exists(UI_PATH))
      {
        System.IO.Directory.CreateDirectory(UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        Create_UserDB();
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        return true;
      }

      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
      System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
      System.Data.DataSet Ds = new System.Data.DataSet();
      System.Data.OleDb.OleDbDataAdapter pAdapter = new System.Data.OleDb.OleDbDataAdapter();
      string strSql = string.Format("SELECT * FROM tbUser WHERE USER_ID='{0}';", id);
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        pAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strSql, conn);
        pAdapter.Fill(Ds);
        connCmd.Connection = conn;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return true;
      }

      if (Ds.Tables.Count <= 0)
      {
        return false;
      }

      if (Ds.Tables[0].Rows.Count <= 0)
      {
        return false;
      }

      bool bExist = false;
      for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
      {
        if (id.CompareTo(Ds.Tables[0].Rows[i][0].ToString()) == 0)
        {
          bExist = true;
          break;
        }
      }

      return bExist;
    } //Check ExistID from User DB(false:NoExist, true:Exist or Error)
    public static bool Load_User()
    {
      listUser.Clear();
      string strDBPath = UI_PATH + UI_NAME_USER;
      bool bResult = true;
      if (!System.IO.Directory.Exists(UI_PATH))
      {
        System.IO.Directory.CreateDirectory(UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        Create_UserDB();
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        return false;
      }
      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
      System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
      System.Data.DataSet Ds = new System.Data.DataSet();
      System.Data.OleDb.OleDbDataAdapter pAdapter = new System.Data.OleDb.OleDbDataAdapter();
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();

        pAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand(string.Format("SELECT * FROM tbUser;"), conn);
        pAdapter.Fill(Ds);
        connCmd.Connection = conn;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      if (Ds.Tables.Count <= 0)
      {
        return false;
      }
      StructUser sUser;
      enumUserLevel eLevel = 0;
      for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
      {
        sUser.strId = Ds.Tables[0].Rows[i][0].ToString();
        sUser.strPw = Ds.Tables[0].Rows[i][1].ToString();
        sUser.strInfo = Ds.Tables[0].Rows[i][2].ToString();
        for (int j = 0; j < Enum.GetNames(typeof(enumUserLevel)).Length; j++)
        {
          if (((enumUserLevel)j).ToString().CompareTo(Ds.Tables[0].Rows[i][3].ToString()) == 0)
          {
            eLevel = (enumUserLevel)j;
            break;
          }
        }
        sUser.eLevel = eLevel;
        listUser.Add(sUser);
      }

      return true;
    } //Refresh User from User DB
    public static bool Login(string id, string pw)
    {
      eCurrentUserLevel = enumUserLevel.Operator;

      if (id.CompareTo(SUPER_ID) == 0)
      {
        if (pw.CompareTo(SUPER_PW) == 0)
        {
          strCurrentUser = SUPER_ID;
          eCurrentUserLevel = enumUserLevel.Developer;
          //개발자 로그인
          return true;
        }
        else
        {
          CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginWrongPassword);
          strCurrentUser = "NONE";
          return false;
        }
      }

      Load_User();

      if (listUser.Count <= 0)
      {
        strCurrentUser = "NONE";
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginNoExistUserDBData);
        return false;
      }
      bool bExist = false;
      for (int i = 0; i < listUser.Count; i++)
      {
        if (listUser[i].strId.CompareTo(id) == 0)
        {
          bExist = true;
          break;
        }
      }
      if (bExist == false)
      {
        strCurrentUser = "NONE";
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginNoExistID);
        return false;
      }

      for (int i = 0; i < listUser.Count; i++)
      {
        if (listUser[i].strId.CompareTo(id) == 0)
        {
          if (listUser[i].strPw.CompareTo(pw) == 0)
          {
            for (int j = 0; j < Enum.GetNames(typeof(enumUserLevel)).Length; j++)
            {
              if (((enumUserLevel)j).ToString().CompareTo(listUser[i].eLevel.ToString()) == 0)
              {
                strCurrentUser = listUser[i].strId;
                eCurrentUserLevel = (enumUserLevel)j;
                //성공
                return true;
              }
            }
          }
          else
          {
            strCurrentUser = "NONE";
            CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginWrongPassword);
            return false;
          }
        }
      }


      return false;
    } //Login
    public static void Logout()
    {
      eCurrentUserLevel = enumUserLevel.Operator;
      strCurrentUser = "NONE";
    } //Logout
    #endregion
  }


}
