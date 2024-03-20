using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

using BASE.VO;

public enum enumBitInput // PLC -> PC Input
{
  B2000_EMO1Switch,
  B2001_EMO2Switch,
  B2002_EMO3Switch,
  B2003_EMO4Switch,
  B2004_,
  B2005_,
  B2006_,
  B2007_ResetSwitch,
  B2008_DoorLockSensor1_FrontRight,
  B2009_DoorLockSensor2_FrontCentral,
  B200A_DoorLockSensor3_FrontLeft,
  B200B_DoorLockSensor4_RearRight,
  B200C_DoorLockSensor5_RearCentral,
  B200D_DoorLockSensor6_RearLeft,
  B200E_MC_01_Trip_Signal,
  B200F_MC_02_Trip_Signal,
  B2010_CP_TripSignal_LE_UE1_UE2_UE3_UE4_AXISServoPowerTrip,
  B2011_CP_TripSignal_BCX_BCY_LP_UPY_AXISServoPowerTrip,
  B2012_CP_TripSignal_UPX_AXISServoPowerTrip,
  B2013_CP_TripSignal_Z1_Z2_AXISServoPowerTrip,
  B2014_CP_TripSignal_X1_AXISServoPowerTrip,
  B2015_CP_TripSignal_X2_AXISServoPowerTrip,
  B2016_CP_TripSignal_ALX_PR1_PR2_PR3_PR4_AXISServoPowerTrip,
  B2017_,
  B2018_ELCBTripSignal_FFUPowerTrip,
  B2019_ELCBTripSignal_ServoDriverControlPowerTrip,
  B201A_ELCBTripSignal_ServicePlugPower,
  B201B_ELCBTripSignal_ControllerPlugPower,
  B201C_LE_AXISIn_position_Signal,
  B201D_UE1_AXISIn_position_Signal,
  B201E_UE2_AXISIn_position_Signal,
  B201F_UE3_AXISIn_position_Signal,
  B2020_UE4_AXISIn_position_Signal,
  B2021_BC1_AXISIn_position_Signal,
  B2022_BC2_AXISIn_position_Signal,
  B2023_LP_AXISIn_position_Signal,
  B2024_UPX_AXISIn_position_Signal,
  B2025_UPY_AXISIn_position_Signal,
  B2026_Z1_AXISIn_position_Signal,
  B2027_Z2_AXISIn_position_Signal,
  B2028_ALX_AXISIn_position_Signal,
  B2029_ALY_AXISIn_position_Signal,
  B202A_X1_AXISIn_position_Signal,
  B202B_X2_AXISIn_position_Signal,
  B202C_PR1_AXISIn_position_Signal,
  B202D_PR2_AXISIn_position_Signal,
  B202E_PR3_AXISIn_position_Signal,
  B202F_PR4_AXISIn_position_Signal,
  B2030_Loading_Material_CheckSensor,
  B2031_,
  B2032_LoaderPicker_CylinderUp_Check_Sensor,
  B2033_LoaderPicker_CylinderDown_Check_Sensor,
  B2034_PR1_PR2collision_Check_Sensor,
  B2035_PR3_PR4collision_Check_Sensor,
  B2036_UnLoaderPicker_CylinderUp_Check_Sensor,
  B2037_UnLoaderPicker_CylinderDown_Check_Sensor,
  B2038_UnLoading1_Material_Check_Sensor,
  B2039_UnLoading1_Position_Check_Sensor,
  B203A_UnLoading2_Material_Check_Sensor,
  B203B_UnLoading2_Position_Check_Sensor,
  B203C_UnLoading3_Material_Check_Sensor,
  B203D_UnLoading3_Position_Check_Sensor,
  B203E_UnLoading4_Material_Check_Sensor,
  B203F_UnLoading4_Position_Check_Sensor,
  B2040_Probe_Stage1_Busy_Signal,
  B2041_Probe_Stage1_Ready_Signal,
  B2042_Probe_Stage1_NG_Signal,
  B2043_Probe_Stage1_OK_Signal,
  B2044_,
  B2045_,
  B2046_Align_Material_Check_Sensor,
  B2047_,
  B2048_,
  B2049_,
  B204A_,
  B204B_,
  B204C_,
  B204D_,
  B204E_,
  B204F_,
  B2050_Probe_Stage2_Busy_Signal,
  B2051_Probe_Stage2_Ready_Signal,
  B2052_Probe_Stage2_NG_Signal,
  B2053_Probe_Stage2_OK_Signal,
  B2054_,
  B2055_,
  B2056_,
  B2057_,
  B2058_,
  B2059_,
  B205A_,
  B205B_,
  B205C_,
  B205D_,
  B205E_,
  B205F_,
  B2060_,
  B2061_,
  B2062_,
  B2063_,
  B2064_,
  B2065_,
  B2066_,
  B2067_,
  B2068_,
  B2069_,
  B206A_,
  B206B_,
  B206C_,
  B206D_,
  B206E_,
  B206F_,
  B2070_,
  B2071_,
  B2072_,
  B2073_,
  B2074_,
  B2075_,
  B2076_,
  B2077_,
  B2078_,
  B2079_,
  B207A_,
  B207B_,
  B207C_,
  B207D_,
  B207E_,
  B207F_,
}
public enum enumFlagRunning // PLC - >PC
{
  B2080_LE_Homming,
  B2081_UE1_Homming,
  B2082_UE2_Homming,
  B2083_UE3_Homming,
  B2084_UE4_Homming,
  B2085_BCX_Homming,
  B2086_BCY_Homming,
  B2087_LP_Homming,
  B2088_UPX_Homming,
  B2089_UPY_Homming,
  B208A_Z1_Homming,
  B208B_Z2_Homming,
  B208C_ALX_Homming,
  B208D_ALY_Homming,
  B208E_X1_Homming,
  B208F_X2_Homming,
  B2090_PR1_Homming,
  B2091_PR2_Homming,
  B2092_PR3_Homming,
  B2093_PR4_Homming,
  B2094_,
  B2095_,
  B2096_,
  B2097_,
  B2098_,
  B2099_,
  B209A_,
  B209B_,
  B209C_Loading_Homming,
  B209D_Measure_Homming,
  B209E_Unloading_Homming,
  B209F_All_Homming,
  B20A0_LE_Teaching_Running,
  B20A1_UE1_Teaching_Running,
  B20A2_UE2_Teaching_Running,
  B20A3_UE3_Teaching_Running,
  B20A4_UE4_Teaching_Running,
  B20A5_BCX_Teaching_Running,
  B20A6_BCY_Teaching_Running,
  B20A7_LP_Teaching_Running,
  B20A8_UPX_Teaching_Running,
  B20A9_UPY_Teaching_Running,
  B20AA_Z1_Teaching_Running,
  B20AB_Z2_Teaching_Running,
  B20AC_ALX_Teaching_Running,
  B20AD_ALY_Teaching_Running,
  B20AE_X1_Teaching_Running,
  B20AF_X2_Teaching_Running,
  B20B0_PR1_Teaching_Running,
  B20B1_PR2_Teaching_Running,
  B20B2_PR3_Teaching_Running,
  B20B3_PR4_Teaching_Running,
  B20B4_,
  B20B5_,
  B20B6_,
  B20B7_,
  B20B8_,
  B20B9_,
  B20BA_,
  B20BB_,
  B20BC_,
  B20BD_,
  B20BE_,
  B20BF_,
  B20C0_LE_Align_Running,
  B20C1_LE_Cassette_Waiting,
  B20C2_UE1_Align_Running,
  B20C3_UE1_Cassette_Waiting,
  B20C4_UE2_Align_Running,
  B20C5_UE2_Cassette_Waiting,
  B20C6_UE3_Align_Running,
  B20C7_UE3_Cassette_Waiting,
  B20C8_UE4_Align_Running,
  B20C9_UE4_Cassette_Waiting,
  B20CA_LE_to_LP_Running,
  B20CB_LP_to_AL_Running,
  B20CC_AL_Running,
  B20CD_AL_to_LP_Running,
  B20CE_LP_to_Stage1_Running,
  B20CF_LP_to_Stage2_Running,
  B20D0_Stage1_Zero_Running,
  B20D1_Stage2_Zero_Running,
  B20D2_Stage1_Measure_Running,
  B20D3_Stage2_Measure_Running,
  B20D4_Stage1_to_UP_Running,
  B20D5_Stage2_to_UP_Running,
  B20D6_UP_to_UE_Running,
  B20D7_Stage1_Clean_Running,
  B20D8_Stage2_Clean_Running,
  B20D9_ProbeChange_Running,
  B20DA_,
  B20DB_,
  B20DC_,
  B20DD_,
  B20DE_,
  B20DF_,
}
public enum enumFlagComplete // PLC - >PC
{
  B20E0_LE_Home_Complete,
  B20E1_UE1_Home_Complete,
  B20E2_UE2_Home_Complete,
  B20E3_UE3_Home_Complete,
  B20E4_UE4_Home_Complete,
  B20E5_BCX_Home_Complete,
  B20E6_BCY_Home_Complete,
  B20E7_LP_Home_Complete,
  B20E8_UPX_Home_Complete,
  B20E9_UPY_Home_Complete,
  B20EA_Z1_Home_Complete,
  B20EB_Z2_Home_Complete,
  B20EC_ALX_Home_Complete,
  B20ED_ALY_Home_Complete,
  B20EE_X1_Home_Complete,
  B20EF_X2_Home_Complete,
  B20F0_PR1_Home_Complete,
  B20F1_PR2_Home_Complete,
  B20F2_PR3_Home_Complete,
  B20F3_PR4_Home_Complete,
  B20F4_,
  B20F5_,
  B20F6_,
  B20F7_,
  B20F8_,
  B20F9_,
  B20FA_,
  B20FB_,
  B20FC_Loading_Home_Complete,
  B20FD_Measure_Home_Complete,
  B20FE_Unloading_Home_Complete,
  B20FF_All_Home_Complete,
  B2100_LE_Teaching_Complete,
  B2101_UE1_Teaching_Complete,
  B2102_UE2_Teaching_Complete,
  B2103_UE3_Teaching_Complete,
  B2104_UE4_Teaching_Complete,
  B2105_BCX_Teaching_Complete,
  B2106_BCY_Teaching_Complete,
  B2107_LP_Teaching_Complete,
  B2108_UPX_Teaching_Complete,
  B2109_UPY_Teaching_Complete,
  B210A_Z1_Teaching_Complete,
  B210B_Z2_Teaching_Complete,
  B210C_ALX_Teaching_Complete,
  B210D_ALY_Teaching_Complete,
  B210E_X1_Teaching_Complete,
  B210F_X2_Teaching_Complete,
  B2110_PR1_Teaching_Complete,
  B2111_PR2_Teaching_Complete,
  B2112_PR3_Teaching_Complete,
  B2113_PR4_Teaching_Complete,
  B2114_,
  B2115_,
  B2116_,
  B2117_,
  B2118_,
  B2119_,
  B211A_,
  B211B_,
  B211C_,
  B211D_,
  B211E_,
  B211F_,
  B2120_LE_Align_Complete,
  B2121_LE_Cassette_Wait_Complete,
  B2122_UE1_Align_Complete,
  B2123_UE1_Cassette_Wait_Complete,
  B2124_UE2_Align_Complete,
  B2125_UE2_Cassette_Wait_Complete,
  B2126_UE3_Align_Complete,
  B2127_UE3_Cassette_Wait_Complete,
  B2128_UE4_Align_Complete,
  B2129_UE4_Cassette_Wait_Complete,
  B212A_LE_to_LP_Complete,
  B212B_LP_to_AL_Complete,
  B212C_AL_Complete,
  B212D_AL_to_LP_Complete,
  B212E_LP_to_Stage1_Complete,
  B212F_LP_to_Stage2_Complete,
  B2130_Stage1_Zero_Complete,
  B2131_Stage2_Zero_Complete,
  B2132_Stage1_Measure_Complete,
  B2133_Stage2_Measure_Complete,
  B2134_Stage1_to_UP_Complete,
  B2135_Stage2_to_UP_Complete,
  B2136_UP_to_UE_Complete,
  B2137_Stage1_Clean_Complete,
  B2138_Stage2_Clean_Complete,
  B2139_ProbeChange,
  B213A_LP_PCB_Exist,
  B213B_UP_PCB_Exist,
  B213C_X1_PCB_Exist,
  B213D_X2_PCB_Exist,
  B213E_LE_Lot_Complete,
  B213F_Barcode_Read_StandBy,
}

public enum enumError // AW: Always BH: Beforehand OB: Obtain
{
  B2140_AW_LE_Ready_Error,
  B2141_AW_LE_Motor_Error,
  B2142_AW_LE_Limit_Error,
  B2143_AW_LE_PLC_Error,
  B2144_AW_UE1_Ready_Error,
  B2145_AW_UE1_Motor_Error,
  B2146_AW_UE1_Limit_Error,
  B2147_AW_UE1_PLC_Error,
  B2148_AW_UE2_Ready_Error,
  B2149_AW_UE2_Motor_Error,
  B214A_AW_UE2_Limit_Error,
  B214B_AW_UE2_PLC_Error,
  B214C_AW_UE3_Ready_Error,
  B214D_AW_UE3_Motor_Error,
  B214E_AW_UE3_Limit_Error,
  B214F_AW_UE3_PLC_Error,
  B2150_AW_UE4_Ready_Error,
  B2151_AW_UE4_Motor_Error,
  B2152_AW_UE4_Limit_Error,
  B2153_AW_UE4_PLC_Error,
  B2154_AW_BCX_Ready_Error,
  B2155_AW_BCX_Motor_Error,
  B2156_AW_BCX_Limit_Error,
  B2157_AW_BCX_PLC_Error,
  B2158_AW_BCY_Ready_Error,
  B2159_AW_BCY_Motor_Error,
  B215A_AW_BCY_Limit_Error,
  B215B_AW_BCY_PLC_Error,
  B215C_AW_LP_Ready_Error,
  B215D_AW_LP_Motor_Error,
  B215E_AW_LP_Limit_Error,
  B215F_AW_LP_PLC_Error,
  B2160_AW_UPX_Ready_Error,
  B2161_AW_UPX_Motor_Error,
  B2162_AW_UPX_Limit_Error,
  B2163_AW_UPX_PLC_Error,
  B2164_AW_UPY_Ready_Error,
  B2165_AW_UPY_Motor_Error,
  B2166_AW_UPY_Limit_Error,
  B2167_AW_UPY_PLC_Error,
  B2168_AW_Z1_Ready_Error,
  B2169_AW_Z1_Motor_Error,
  B216A_AW_Z1_Limit_Error,
  B216B_AW_Z1_PLC_Error,
  B216C_AW_Z2_Ready_Error,
  B216D_AW_Z2_Motor_Error,
  B216E_AW_Z2_Limit_Error,
  B216F_AW_Z2_PLC_Error,
  B2170_AW_ALX_Ready_Error,
  B2171_AW_ALX_Motor_Error,
  B2172_AW_ALX_Limit_Error,
  B2173_AW_ALX_PLC_Error,
  B2174_AW_ALY_Ready_Error,
  B2175_AW_ALY_Motor_Error,
  B2176_AW_ALY_Limit_Error,
  B2177_AW_ALY_PLC_Error,
  B2178_AW_X1_Ready_Error,
  B2179_AW_X1_Motor_Error,
  B217A_AW_X1_Limit_Error,
  B217B_AW_X1_PLC_Error,
  B217C_AW_X2_Ready_Error,
  B217D_AW_X2_Motor_Error,
  B217E_AW_X2_Limit_Error,
  B217F_AW_X2_PLC_Error,
  B2180_AW_PR1_Ready_Error,
  B2181_AW_PR1_Motor_Error,
  B2182_AW_PR1_Limit_Error,
  B2183_AW_PR1_PLC_Error,
  B2184_AW_PR2_Ready_Error,
  B2185_AW_PR2_Motor_Error,
  B2186_AW_PR2_Limit_Error,
  B2187_AW_PR2_PLC_Error,
  B2188_AW_PR3_Ready_Error,
  B2189_AW_PR3_Motor_Error,
  B218A_AW_PR3_Limit_Error,
  B218B_AW_PR3_PLC_Error,
  B218C_AW_PR4_Ready_Error,
  B218D_AW_PR4_Motor_Error,
  B218E_AW_PR4_Limit_Error,
  B218F_AW_PR4_PLC_Error,
  B2190_,
  B2191_,
  B2192_,
  B2193_,
  B2194_,
  B2195_,
  B2196_,
  B2197_,
  B2198_,
  B2199_,
  B219A_,
  B219B_,
  B219C_,
  B219D_,
  B219E_,
  B219F_,
  B21A0_,
  B21A1_,
  B21A2_,
  B21A3_,
  B21A4_,
  B21A5_,
  B21A6_,
  B21A7_,
  B21A8_,
  B21A9_,
  B21AA_,
  B21AB_,
  B21AC_,
  B21AD_,
  B21AE_,
  B21AF_,
  B21B0_,
  B21B1_,
  B21B2_,
  B21B3_,
  B21B4_,
  B21B5_,
  B21B6_,
  B21B7_,
  B21B8_,
  B21B9_,
  B21BA_,
  B21BB_,
  B21BC_,
  B21BD_,
  B21BE_,
  B21BF_,
  B21C0_AW_LE_Position_Data_Error,
  B21C1_AW_UE1_Position_Data_Error,
  B21C2_AW_UE2_Position_Data_Error,
  B21C3_AW_UE3_Position_Data_Error,
  B21C4_AW_UE4_Position_Data_Error,
  B21C5_AW_BCX_Position_Data_Error,
  B21C6_AW_BCY_Position_Data_Error,
  B21C7_AW_LP_Position_Data_Error,
  B21C8_AW_UPX_Position_Data_Error,
  B21C9_AW_UPY_Position_Data_Error,
  B21CA_AW_Z1_Position_Data_Error,
  B21CB_AW_Z2_Position_Data_Error,
  B21CC_AW_ALX_Position_Data_Error,
  B21CD_AW_ALY_Position_Data_Error,
  B21CE_AW_X1_Position_Data_Error,
  B21CF_AW_X2_Position_Data_Error,
  B21D0_AW_PR1_Position_Data_Error,
  B21D1_AW_PR2_Position_Data_Error,
  B21D2_AW_PR3_Position_Data_Error,
  B21D3_AW_PR4_Position_Data_Error,
  B21D4_,
  B21D5_,
  B21D6_,
  B21D7_,
  B21D8_,
  B21D9_,
  B21DA_,
  B21DB_,
  B21DC_,
  B21DD_,
  B21DE_,
  B21DF_,
  B21E0_,
  B21E1_,
  B21E2_,
  B21E3_,
  B21E4_,
  B21E5_,
  B21E6_,
  B21E7_,
  B21E8_,
  B21E9_,
  B21EA_,
  B21EB_,
  B21EC_,
  B21ED_,
  B21EE_,
  B21EF_,
  B21F0_,
  B21F1_,
  B21F2_,
  B21F3_,
  B21F4_,
  B21F5_,
  B21F6_,
  B21F7_,
  B21F8_,
  B21F9_,
  B21FA_,
  B21FB_,
  B21FC_,
  B21FD_,
  B21FE_,
  B21FF_,
  B2200_AW_Front_EMO_Error,
  B2201_AW_Left_EMO_Error,
  B2202_AW_Back_EMO_Error,
  B2203_AW_Right_EMO_Error,
  B2204_AW_Main_Air_Low_Pressure_Error,
  B2205_AW_CP_ELCB_TRIP_Error,
  B2206_AW_Stage1_Probe_Collision_Error,
  B2207_AW_Stage2_Probe_Collision_Error,
  B2208_,
  B2209_,
  B220A_,
  B220B_,
  B220C_,
  B220D_,
  B220E_AW_Power_Switch_Off_Error,
  B220F_AW_Servo_Off_Error,
  B2210_,
  B2211_,
  B2212_,
  B2213_,
  B2214_,
  B2215_,
  B2216_,
  B2217_,
  B2218_,
  B2219_,
  B221A_,
  B221B_,
  B221C_,
  B221D_,
  B221E_,
  B221F_,
  B2220_BH_Door_Open_Error_Home,
  B2221_,
  B2222_BH_Moving_Error_Home,
  B2223_BH_Home_Not_Complete_Error_Home,
  B2224_BH_LP_Up_Sensor_Off_Error_Home,
  B2225_BH_UP_Up_Sensor_Off_Error_Home,
  B2226_,
  B2227_,
  B2228_,
  B2229_BH_Z1_Over_Ready_Position_Error_Home,
  B222A_BH_Z2_Over_Ready_Position_Error_Home,
  B222B_BH_LE_ZeroPos_Over_Error_Home,
  B222C_,
  B222D_,
  B222E_,
  B222F_,
  B2230_OB_Door_Open_Error_Home,
  B2231_OB_LP_Up_Sensor_Off_Error_Home,
  B2232_OB_UP_Up_Sensor_Off_Error_Home,
  B2233_,
  B2234_,
  B2235_,
  B2236_,
  B2237_,
  B2238_,
  B2239_,
  B223A_,
  B223B_,
  B223C_,
  B223D_,
  B223E_,
  B223F_,
  B2240_BH_Door_Open_Error_Teaching,
  B2241_BH_No_Speed_Error_Teaching,
  B2242_BH_Moving_Error_Teaching,
  B2243_BH_Home_Not_Complete_Error_Teaching,
  B2244_BH_LP_Up_Sensor_Off_Error_Teaching,
  B2245_BH_UP_Up_Sensor_Off_Error_Teaching,
  B2246_BH_Stage1_Probe_Collision_Error_Teaching,
  B2247_BH_Stage2_Probe_Collision_Error_Teaching,
  B2248_,
  B2249_BH_Z1_Over_Ready_Position_Error_Teaching,
  B224A_BH_Z2_Over_Ready_Position_Error_Teaching,
  B224B_BH_LE_ZeroPos_Over_Error_Teaching,
  B224C_BH_LP_Collision_Error,
  B224D_BH_BCX_ZeroPos_Over_Error,
  B224E_,
  B224F_,
  B2250_OB_Door_Open_Error_Teaching,
  B2251_OB_Stage1_Probe_Collision_Error_Teaching,
  B2252_OB_Stage2_Probe_Collision_Error_Teaching,
  B2253_,
  B2254_,
  B2255_,
  B2256_,
  B2257_,
  B2258_,
  B2259_,
  B225A_,
  B225B_,
  B225C_,
  B225D_,
  B225E_,
  B225F_,
  B2260_BH_Door_Open_Error_LEAlignReady,
  B2261_BH_No_Speed_Error_LEAlignReady,
  B2262_BH_Moving_Error_LEAlignReady,
  B2263_BH_Home_Not_Complete_Error_LEAlignReady,
  B2264_BH_LE_No_Product_Error_LEAlignReady,
  B2265_,
  B2266_,
  B2267_,
  B2268_,
  B2269_,
  B226A_,
  B226B_,
  B226C_,
  B226D_,
  B226E_,
  B226F_,
  B2270_OB_LE_Align_Fail_Error_LEAlignReady,
  B2271_OB_LE_Lot_Complete_LEAlignReady,
  B2272_OB_Max_Limit_Over_Error_LEAlignReady,
  B2273_,
  B2274_,
  B2275_,
  B2276_,
  B2277_,
  B2278_,
  B2279_,
  B227A_,
  B227B_,
  B227C_,
  B227D_,
  B227E_,
  B227F_,
  B2280_BH_Door_Open_Error_UE1AlignReady,
  B2281_BH_No_Speed_Error_UE1AlignReady,
  B2282_BH_Moving_Error_UE1AlignReady,
  B2283_BH_Home_Not_Complete_Error_UE1AlignReady,
  B2284_,
  B2285_,
  B2286_,
  B2287_,
  B2288_,
  B2289_,
  B228A_,
  B228B_,
  B228C_,
  B228D_,
  B228E_,
  B228F_,
  B2290_OB_UE1_Align_Fail_Error_UE1AlignReady,
  B2291_,
  B2292_,
  B2293_,
  B2294_,
  B2295_,
  B2296_,
  B2297_,
  B2298_,
  B2299_,
  B229A_,
  B229B_,
  B229C_,
  B229D_,
  B229E_,
  B229F_,
  B22A0_BH_Door_Open_Error_UE2AlignReady,
  B22A1_BH_No_Speed_Error_UE2AlignReady,
  B22A2_BH_Moving_Error_UE2AlignReady,
  B22A3_BH_Home_Not_Complete_Error_UE2AlignReady,
  B22A4_,
  B22A5_,
  B22A6_,
  B22A7_,
  B22A8_,
  B22A9_,
  B22AA_,
  B22AB_,
  B22AC_,
  B22AD_,
  B22AE_,
  B22AF_,
  B22B0_OB_UE2_Align_Fail_Error_UE2AlignReady,
  B22B1_,
  B22B2_,
  B22B3_,
  B22B4_,
  B22B5_,
  B22B6_,
  B22B7_,
  B22B8_,
  B22B9_,
  B22BA_,
  B22BB_,
  B22BC_,
  B22BD_,
  B22BE_,
  B22BF_,
  B22C0_BH_Door_Open_Error_UE3AlignReady,
  B22C1_BH_No_Speed_Error_UE3AlignReady,
  B22C2_BH_Moving_Error_UE3AlignReady,
  B22C3_BH_Home_Not_Complete_Error_UE3AlignReady,
  B22C4_,
  B22C5_,
  B22C6_,
  B22C7_,
  B22C8_,
  B22C9_,
  B22CA_,
  B22CB_,
  B22CC_,
  B22CD_,
  B22CE_,
  B22CF_,
  B22D0_OB_UE3_Align_Fail_Error_UE3AlignReady,
  B22D1_,
  B22D2_,
  B22D3_,
  B22D4_,
  B22D5_,
  B22D6_,
  B22D7_,
  B22D8_,
  B22D9_,
  B22DA_,
  B22DB_,
  B22DC_,
  B22DD_,
  B22DE_,
  B22DF_,
  B22E0_BH_Door_Open_Error_UE4AlignReady,
  B22E1_BH_No_Speed_Error_UE4AlignReady,
  B22E2_BH_Moving_Error_UE4AlignReady,
  B22E3_BH_Home_Not_Complete_Error_UE4AlignReady,
  B22E4_,
  B22E5_,
  B22E6_,
  B22E7_,
  B22E8_,
  B22E9_,
  B22EA_,
  B22EB_,
  B22EC_,
  B22ED_,
  B22EE_,
  B22EF_,
  B22F0_OB_UE4_Align_Fail_Error_UE4AlignReady,
  B22F1_,
  B22F2_,
  B22F3_,
  B22F4_,
  B22F5_,
  B22F6_,
  B22F7_,
  B22F8_,
  B22F9_,
  B22FA_,
  B22FB_,
  B22FC_,
  B22FD_,
  B22FE_,
  B22FF_,
  B2300_BH_Door_Open_Error_LEtoLP,
  B2301_BH_No_Speed_Error_LEtoLP,
  B2302_BH_Moving_Error_LEtoLP,
  B2303_BH_Home_Not_Complete_Error_LEtoLP,
  B2304_BH_LP_Up_Sensor_Off_Error_LEtoLP,
  B2305_,
  B2306_,
  B2307_BH_LP_Air_On_Error_LEtoLP,
  B2308_,
  B2309_BH_Barcode_ReadFail_Error_LEtoLP,
  B230A_BH_LE_PCB_Not_Exist_Error_LEtoLP,
  B230B_,
  B230C_,
  B230D_,
  B230E_,
  B230F_,
  B2310_OB_LP_Up_Sensor_Off_Error_LEtoLP,
  B2311_OB_LP_Down_Sensor_Off_Error_LEtoLP,
  B2312_OB_LP_Air_Error_LEtoLP,
  B2313_,
  B2314_,
  B2315_,
  B2316_,
  B2317_,
  B2318_,
  B2319_,
  B231A_,
  B231B_,
  B231C_,
  B231D_,
  B231E_,
  B231F_,
  B2320_BH_Door_Open_Error_LPtoAL,
  B2321_BH_No_Speed_Error_LPtoAL,
  B2322_BH_Moving_Error_LPtoAL,
  B2323_BH_Home_Not_Complete_Error_LPtoAL,
  B2324_,
  B2325_,
  B2326_,
  B2327_BH_LP_Air_Error_LPtoAL,
  B2328_,
  B2329_BH_AL_PCB_Exist_Error_LPtoAL,
  B232A_,
  B232B_,
  B232C_,
  B232D_,
  B232E_,
  B232F_,
  B2330_OB_LP_Up_Sensor_Off_Error_LPtoAL,
  B2331_OB_LP_Down_Sensor_Off_Error_LPtoAL,
  B2332_OB_LP_Air_Error_LPtoAL,
  B2333_OB_Align_No_PCB_Error_LPtoAL,
  B2334_,
  B2335_OB_LP_PCB_Drop_Error_LPtoAL,
  B2336_,
  B2337_,
  B2338_,
  B2339_,
  B233A_,
  B233B_,
  B233C_,
  B233D_,
  B233E_,
  B233F_,
  B2340_BH_Door_Open_Error_AL,
  B2341_BH_No_Speed_Error_AL,
  B2342_BH_Moving_Error_AL,
  B2343_BH_Home_Not_Complete_Error_AL,
  B2344_BH_LP_Up_Sensor_Off_Error_AL,
  B2345_,
  B2346_,
  B2347_,
  B2348_,
  B2349_BH_Align_No_PCB_Error_AL,
  B234A_BH_ALX_ReadyPos_Over_Error_AL,
  B234B_BH_ALY_ReadyPos_Over_Error_AL,
  B234C_BH_ALX_Align_BackOffset_Over_Error_AL,
  B234D_BH_ALY_Align_BackOffset_Over_Error_AL,
  B234E_,
  B234F_,
  B2350_,
  B2351_,
  B2352_,
  B2353_,
  B2354_,
  B2355_,
  B2356_,
  B2357_,
  B2358_,
  B2359_,
  B235A_,
  B235B_,
  B235C_,
  B235D_,
  B235E_,
  B235F_,
  B2360_BH_Door_Open_Error_ALtoLP,
  B2361_BH_No_Speed_Error_ALtoLP,
  B2362_BH_Moving_Error_ALtoLP,
  B2363_BH_Home_Not_Complete_Error_ALtoLP,
  B2364_BH_LP_Up_Sensor_Off_Error_ALtoLP,
  B2365_,
  B2366_,
  B2367_BH_LP_Air_On_Error_ALtoLP,
  B2368_,
  B2369_,
  B236A_,
  B236B_,
  B236C_,
  B236D_,
  B236E_,
  B236F_,
  B2370_OH_LP_Up_Sensor_Off_Error_ALtoLP,
  B2371_OH_LP_Down_Sensor_Off_Error_ALtoLP,
  B2372_OH_LP_Air_Error_ALtoLP,
  B2373_OH_AL_PCB_Exist_Error_ALtoLP,
  B2374_,
  B2375_,
  B2376_,
  B2377_,
  B2378_,
  B2379_,
  B237A_,
  B237B_,
  B237C_,
  B237D_,
  B237E_,
  B237F_,
  B2380_BH_Door_Open_Error_LPtoStage1,
  B2381_BH_No_Speed_Error_LPtoStage1,
  B2382_BH_Moving_Error_LPtoStage1,
  B2383_BH_Home_Not_Complete_Error_LPtoStage1,
  B2384_BH_LP_Up_Sensor_Off_Error_LPtoStage1,
  B2385_,
  B2386_BH_Stage1_Air_On_Error_LPtoStage1,
  B2387_BH_LP_Air_Off_Error_LPtoStage1,
  B2388_,
  B2389_,
  B238A_BH_Z1_Reade_Position_Error_LPtoStage1,
  B238B_,
  B238C_,
  B238D_,
  B238E_,
  B238F_,
  B2390_OB_LP_Up_Sensor_Off_Error_LPtoStage1,
  B2391_OB_LP_Down_Sensor_Off_Error_LPtoStage1,
  B2392_OB_LP_Air_Error_LPtoStage1,
  B2393_OB_Stage1_Air_Error_LPtoStage1,
  B2394_,
  B2395_OB_LP_PCB_Drop_Error_LPtoStage1,
  B2396_,
  B2397_,
  B2398_,
  B2399_,
  B239A_,
  B239B_,
  B239C_,
  B239D_,
  B239E_,
  B239F_,
  B23A0_BH_Door_Open_Error_LPtoStage2,
  B23A1_BH_No_Speed_Error_LPtoStage2,
  B23A2_BH_Moving_Error_LPtoStage2,
  B23A3_BH_Home_Not_Complete_Error_LPtoStage2,
  B23A4_BH_LP_Up_Sensor_Off_Error_LPtoStage2,
  B23A5_,
  B23A6_BH_Stage2_Air_On_Error_LPtoStage2,
  B23A7_BH_LP_Air_Off_Error_LPtoStage2,
  B23A8_,
  B23A9_,
  B23AA_BH_Z2_Reade_Position_Error_LPtoStage2,
  B23AB_,
  B23AC_,
  B23AD_,
  B23AE_,
  B23AF_,
  B23B0_OB_LP_Up_Sensor_Off_Error_LPtoStage2,
  B23B1_OB_LP_Down_Sensor_Off_Error_LPtoStage2,
  B23B2_OB_LP_Air_Error_LPtoStage2,
  B23B3_OB_Stage2_Air_Error_LPtoStage2,
  B23B4_,
  B23B5_OB_LP_PCB_Drop_Error_LPtoStage2,
  B23B6_,
  B23B7_,
  B23B8_,
  B23B9_,
  B23BA_,
  B23BB_,
  B23BC_,
  B23BD_,
  B23BE_,
  B23BF_,
  B23C0_BH_Door_Open_Error_Stage1Zero,
  B23C1_BH_No_Speed_Error_Stage1Zero,
  B23C2_BH_Moving_Error_Stage1Zero,
  B23C3_BH_Home_Not_Complete_Error_Stage1Zero,
  B23C4_,
  B23C5_,
  B23C6_BH_Stage1_Air_On_Error_Stage1Zero,
  B23C7_,
  B23C8_,
  B23C9_,
  B23CA_BH_Z1_Safty_Pos_Over_Error_Stage1Zero,
  B23CB_,
  B23CC_,
  B23CD_,
  B23CE_,
  B23CF_,
  B23D0_,
  B23D1_,
  B23D2_,
  B23D3_OB_Stage1_Air_Error_Stage1Zero,
  B23D4_OB_Stage1_Probe_Collision_Error_Stage1Zero,
  B23D5_,
  B23D6_,
  B23D7_,
  B23D8_,
  B23D9_,
  B23DA_,
  B23DB_,
  B23DC_,
  B23DD_,
  B23DE_,
  B23DF_,
  B23E0_BH_Door_Open_Error_Stage2Zero,
  B23E1_BH_No_Speed_Error_Stage2Zero,
  B23E2_BH_Moving_Error_Stage2Zero,
  B23E3_BH_Home_Not_Complete_Error_Stage2Zero,
  B23E4_,
  B23E5_,
  B23E6_BH_Stage2_Air_On_Error_Stage2Zero,
  B23E7_,
  B23E8_,
  B23E9_,
  B23EA_BH_Z2_Safty_Pos_Over_Error_Stage2Zero,
  B23EB_,
  B23EC_,
  B23ED_,
  B23EE_,
  B23EF_,
  B23F0_,
  B23F1_,
  B23F2_,
  B23F3_OB_Stage2_Air_Error_Stage2Zero,
  B23F4_OB_Stage2_Probe_Collision_Error_Stage2Zero,
  B23F5_,
  B23F6_,
  B23F7_,
  B23F8_,
  B23F9_,
  B23FA_,
  B23FB_,
  B23FC_,
  B23FD_,
  B23FE_,
  B23FF_,
  B2400_BH_Door_Open_Error_Stage1Measure,
  B2401_BH_No_Speed_Error_Stage1Measure,
  B2402_BH_Moving_Error_Stage1Measure,
  B2403_BH_Home_Not_Complete_Error_Stage1Measure,
  B2404_,
  B2405_,
  B2406_BH_Stage1_Air_Off_Error_Stage1Measure,
  B2407_,
  B2408_,
  B2409_,
  B240A_,
  B240B_,
  B240C_,
  B240D_,
  B240E_,
  B240F_,
  B2410_,
  B2411_,
  B2412_,
  B2413_OB_Stage1_Air_Error_Stage1Measure,
  B2414_OB_Stage1_Probe_Collision_Error_Stage1Measure,
  B2415_,
  B2416_,
  B2417_,
  B2418_,
  B2419_,
  B241A_,
  B241B_,
  B241C_,
  B241D_,
  B241E_,
  B241F_,
  B2420_BH_Door_Open_Error_Stage2Measure,
  B2421_BH_No_Speed_Error_Stage2Measure,
  B2422_BH_Moving_Error_Stage2Measure,
  B2423_BH_Home_Not_Complete_Error_Stage2Measure,
  B2424_,
  B2425_,
  B2426_BH_Stage2_Air_Off_Error_Stage2Measure,
  B2427_,
  B2428_,
  B2429_,
  B242A_,
  B242B_,
  B242C_,
  B242D_,
  B242E_,
  B242F_,
  B2430_,
  B2431_,
  B2432_,
  B2433_OB_Stage2_Air_Error_Stage2Measure,
  B2434_OB_Stage2_Probe_Collision_Error_Stage2Measure,
  B2435_,
  B2436_,
  B2437_,
  B2438_,
  B2439_,
  B243A_,
  B243B_,
  B243C_,
  B243D_,
  B243E_,
  B243F_,
  B2440_BH_Door_Open_Error_Stage1toUP,
  B2441_BH_No_Speed_Error_Stage1toUP,
  B2442_BH_Moving_Error_Stage1toUP,
  B2443_BH_Home_Not_Complete_Error_Stage1toUP,
  B2444_,
  B2445_BH_UP_Up_Sensor_Off_Error_Stage1toUP,
  B2446_BH_Stage1_Air_Error_Stage1toUP,
  B2447_,
  B2448_BH_UP_Air_On_Error_Stage1toUP,
  B2449_,
  B244A_,
  B244B_,
  B244C_,
  B244D_,
  B244E_,
  B244F_,
  B2450_OB_UP_Up_Sensor_Off_Error_Stage1toUP,
  B2451_OB_UP_Down_Sensor_Off_Error_Stage1toUP,
  B2452_OB_UP_Air_Error_Stage1toUP,
  B2453_OB_Stage1_Air_Error_Stage1toUP,
  B2454_,
  B2455_,
  B2456_,
  B2457_,
  B2458_,
  B2459_,
  B245A_,
  B245B_,
  B245C_,
  B245D_,
  B245E_,
  B245F_,
  B2460_BH_Door_Open_Error_Stage2toUP,
  B2461_BH_No_Speed_Error_Stage2toUP,
  B2462_BH_Moving_Error_Stage2toUP,
  B2463_BH_Home_Not_Complete_Error_Stage2toUP,
  B2464_,
  B2465_BH_UP_Up_Sensor_Off_Error_Stage2toUP,
  B2466_BH_Stage2_Air_On_Error_Stage2toUP,
  B2467_,
  B2468_BH_UP_Air_On_Error_Stage2toUP,
  B2469_,
  B246A_,
  B246B_,
  B246C_,
  B246D_,
  B246E_,
  B246F_,
  B2470_OB_UP_Up_Sensor_Off_Error_Stage2toUP,
  B2471_OB_UP_Down_Sensor_Off_Error_Stage2toUP,
  B2472_OB_UP_Air_Error_Stage2toUP,
  B2473_OB_Stage1_Air_Error_Stage2toUP,
  B2474_,
  B2475_,
  B2476_,
  B2477_,
  B2478_,
  B2479_,
  B247A_,
  B247B_,
  B247C_,
  B247D_,
  B247E_,
  B247F_,
  B2480_BH_Door_Open_Error_UPtoUE,
  B2481_BH_No_Speed_Error_UPtoUE,
  B2482_BH_Moving_Error_UPtoUE,
  B2483_BH_Home_Not_Complete_Error_UPtoUE,
  B2484_,
  B2485_BH_UP_Up_Sensor_Off_Error_UPtoUE,
  B2486_,
  B2487_,
  B2488_BH_UP_Air_Off_Error_UPtoUE,
  B2489_,
  B248A_,
  B248B_,
  B248C_,
  B248D_,
  B248E_,
  B248F_,
  B2490_OB_UP_Up_Sensor_Off_Error_UPtoUE,
  B2491_OB_UP_Down_Sensor_Off_Error_UPtoUE,
  B2492_OB_UP_Air_Error_UPtoUE,
  B2493_,
  B2494_,
  B2495_OB_UP_PCB_Drop_Error_UPtoUE,
  B2496_,
  B2497_,
  B2498_,
  B2499_,
  B249A_,
  B249B_,
  B249C_,
  B249D_,
  B249E_,
  B249F_,
  B24A0_BH_Door_Open_Error_Stage1Clean,
  B24A1_BH_No_Speed_Error_Stage1Clean,
  B24A2_BH_Moving_Error_Stage1Clean,
  B24A3_BH_Home_Not_Complete_Error_Stage1Clean,
  B24A4_BH_LP_Up_Sensor_Off_Error_Stage1Clean,
  B24A5_BH_UP_Up_Sensor_Off_Error_Stage1Clean,
  B24A6_BH_Stage1_Air_Error_Stage1Clean,
  B24A7_,
  B24A8_,
  B24A9_,
  B24AA_,
  B24AB_,
  B24AC_,
  B24AD_,
  B24AE_,
  B24AF_,
  B24B0_,
  B24B1_,
  B24B2_,
  B24B3_,
  B24B4_OB_Stage1_Probe_Collision_Error_Stage1Clean,
  B24B5_,
  B24B6_,
  B24B7_,
  B24B8_,
  B24B9_,
  B24BA_,
  B24BB_,
  B24BC_,
  B24BD_,
  B24BE_,
  B24BF_,
  B24C0_BH_Door_Open_Error_Stage2Clean,
  B24C1_BH_No_Speed_Error_Stage2Clean,
  B24C2_BH_Moving_Error_Stage2Clean,
  B24C3_BH_Home_Not_Complete_Error_Stage2Clean,
  B24C4_BH_LP_Up_Sensor_Off_Error_Stage2Clean,
  B24C5_BH_UP_Up_Sensor_Off_Error_Stage2Clean,
  B24C6_BH_Stage2_Air_Error_Stage2Clean,
  B24C7_,
  B24C8_,
  B24C9_,
  B24CA_,
  B24CB_,
  B24CC_,
  B24CD_,
  B24CE_,
  B24CF_,
  B24D0_,
  B24D1_,
  B24D2_,
  B24D3_,
  B24D4_OB_Stage2_Probe_Collision_Error_Stage2Clean,
  B24D5_,
  B24D6_,
  B24D7_,
  B24D8_,
  B24D9_,
  B24DA_,
  B24DB_,
  B24DC_,
  B24DD_,
  B24DE_,
  B24DF_,
  B24E0_BH_Door_Open_Error_ProbeChange,
  B24E1_BH_No_Speed_Error_ProbeChange,
  B24E2_BH_Moving_Error_ProbeChange,
  B24E3_BH_Home_Not_Complete_Error_ProbeChange,
  B24E4_BH_LP_Up_Sensor_Off_Error_ProbeChange,
  B24E5_BH_UP_Up_Sensor_Off_Error_ProbeChange,
  B24E6_,
  B24E7_,
  B24E8_,
  B24E9_,
  B24EA_,
  B24EB_,
  B24EC_,
  B24ED_,
  B24EE_,
  B24EF_,
  B24F0_,
  B24F1_,
  B24F2_,
  B24F3_,
  B24F4_OB_Stage1_Probe_Collision_Error_ProbeChange,
  B24F5_OB_Stage2_Probe_Collision_Error_ProbeChange,
  B24F6_,
  B24F7_,
  B24F8_,
  B24F9_,
  B24FA_,
  B24FB_,
  B24FC_,
  B24FD_,
  B24FE_,
  B24FF_,
}

public enum enumFlagOut // PC -> PLC Flag
{
  B1000_LE_Home_Start,
  B1001_UE1_Home_Start,
  B1002_UE2_Home_Start,
  B1003_UE3_Home_Start,
  B1004_UE4_Home_Start,
  B1005_BCX_Home_Start,
  B1006_BCY_Home_Start,
  B1007_LP_Home_Start,
  B1008_UPX_Home_Start,
  B1009_UPY_Home_Start,
  B100A_Z1_Home_Start,
  B100B_Z2_Home_Start,
  B100C_ALX_Home_Start,
  B100D_ALY_Home_Start,
  B100E_X1_Home_Start,
  B100F_X2_Home_Start,
  B1010_PR1_Home_Start,
  B1011_PR2_Home_Start,
  B1012_PR3_Home_Start,
  B1013_PR4_Home_Start,
  B1014_,
  B1015_,
  B1016_,
  B1017_,
  B1018_,
  B1019_,
  B101A_,
  B101B_,
  B101C_Loading_Home_Start,
  B101D_Measurement_Home_Start,
  B101E_Unloding_Home_Start,
  B101F_All_Home_Start,
  B1020_LE_Teaching_Start,
  B1021_UE1_Teaching_Start,
  B1022_UE2_Teaching_Start,
  B1023_UE3_Teaching_Start,
  B1024_UE4_Teaching_Start,
  B1025_BCX_Teaching_Start,
  B1026_BCY_Teaching_Start,
  B1027_LP_Teaching_Start,
  B1028_UPX_Teaching_Start,
  B1029_UPY_Teaching_Start,
  B102A_Z1_Teaching_Start,
  B102B_Z2_Teaching_Start,
  B102C_ALX_Teaching_Start,
  B102D_ALY_Teaching_Start,
  B102E_X1_Teaching_Start,
  B102F_X2_Teaching_Start,
  B1030_PR1_Teaching_Start,
  B1031_PR2_Teaching_Start,
  B1032_PR3_Teaching_Start,
  B1033_PR4_Teaching_Start,
  B1034_,
  B1035_,
  B1036_,
  B1037_,
  B1038_,
  B1039_,
  B103A_,
  B103B_,
  B103C_,
  B103D_,
  B103E_,
  B103F_,
  B1040_LE_Align_Start,
  B1041_LE_Cassette_Wait_Start,
  B1042_UE1_Align_Start,
  B1043_UE1_Cassette_Wait_Start,
  B1044_UE2_Align_Start,
  B1045_UE2_Cassette_Wait_Start,
  B1046_UE3_Align_Start,
  B1047_UE3_Cassette_Wait_Start,
  B1048_UE4_Align_Start,
  B1049_UE4_Cassette_Wait_Start,
  B104A_LE_to_LP_Start,
  B104B_LP_to_AL_Start,
  B104C_Align_Start,
  B104D_AL_to_LP_Start,
  B104E_LP_to_Stage1_Start,
  B104F_LP_to_Stage2_Start,
  B1050_Stage1_Zero_Start,
  B1051_Stage2_Zero_Start,
  B1052_Stage1_Measure_Start,
  B1053_Stage2_Measure_Start,
  B1054_Stage1_to_UP_Start,
  B1055_Stage2_to_UP_Start,
  B1056_UP_to_UE_Start,
  B1057_Stage1_Clean_Start,
  B1058_Stage2_Clean_Start,
  B1059_Probe_Change_Start,
  B105A_,
  B105B_,
  B105C_,
  B105D_,
  B105E_,
  B105F_,
  B1060_LE_Cw_Jog_Signal,
  B1061_LE_Ccw_Jog_Signal,
  B1062_UE1_Cw_Jog_Signal,
  B1063_UE1_Ccw_Jog_Signal,
  B1064_UE2_Cw_Jog_Signal,
  B1065_UE2_Ccw_Jog_Signal,
  B1066_UE3_Cw_Jog_Signal,
  B1067_UE3_Ccw_Jog_Signal,
  B1068_UE4_Cw_Jog_Signal,
  B1069_UE4_Ccw_Jog_Signal,
  B106A_BCX_Cw_Jog_Signal,
  B106B_BCX_Ccw_Jog_Signal,
  B106C_BCY_Cw_Jog_Signal,
  B106D_BCY_Ccw_Jog_Signal,
  B106E_LP_Cw_Jog_Signal,
  B106F_LP_Ccw_Jog_Signal,
  B1070_UPX_Cw_Jog_Signal,
  B1071_UPX_Ccw_Jog_Signal,
  B1072_UPY_Cw_Jog_Signal,
  B1073_UPY_Ccw_Jog_Signal,
  B1074_Z1_Cw_Jog_Signal,
  B1075_Z1_Ccw_Jog_Signal,
  B1076_Z2_Cw_Jog_Signal,
  B1077_Z2_Ccw_Jog_Signal,
  B1078_ALX_Cw_Jog_Signal,
  B1079_ALX_Ccw_Jog_Signal,
  B107A_ALY_Cw_Jog_Signal,
  B107B_ALY_Ccw_Jog_Signal,
  B107C_X1_Cw_Jog_Signal,
  B107D_X1_Ccw_Jog_Signal,
  B107E_X2_Cw_Jog_Signal,
  B107F_X2_Ccw_Jog_Signal,
  B1080_PR1_Cw_Jog_Signal,
  B1081_PR1_Ccw_Jog_Signal,
  B1082_PR2_Cw_Jog_Signal,
  B1083_PR2_Ccw_Jog_Signal,
  B1084_PR3_Cw_Jog_Signal,
  B1085_PR3_Ccw_Jog_Signal,
  B1086_PR4_Cw_Jog_Signal,
  B1087_PR4_Ccw_Jog_Signal,
  B1088_,
  B1089_,
  B108A_,
  B108B_,
  B108C_,
  B108D_,
  B108E_,
  B108F_,
  B1090_,
  B1091_,
  B1092_,
  B1093_,
  B1094_,
  B1095_,
  B1096_,
  B1097_,
  B1098_,
  B1099_,
  B109A_,
  B109B_,
  B109C_,
  B109D_,
  B109E_,
  B109F_,
  B10A0_PC_Complete_Reset_Signal,
  B10A1_PC_Error_Signal,
  B10A2_PC_Error_Reset_Signal,
  B10A3_PC_Auto_Pause_Signal,
  B10A4_PC_Auto_Running_Signal,
  B10A5_PC_Auto_Complete_Signal,
  B10A6_PC_Touch_Lock_Signal,
  B10A7_PC_Buzz_Stop_Signal,
  B10A8_,
  B10A9_,
  B10AA_,
  B10AB_,
  B10AC_,
  B10AD_,
  B10AE_,
  B10AF_,
  B10B0_,
  B10B1_,
  B10B2_,
  B10B3_,
  B10B4_,
  B10B5_,
  B10B6_,
  B10B7_,
  B10B8_,
  B10B9_,
  B10BA_,
  B10BB_,
  B10BC_,
  B10BD_,
  B10BE_,
  B10BF_,
  B10C0_Teaching_Cancel,
  B10C1_All_Stop,
  B10C2_LE_Align_Cancel,
  B10C3_LE_Cassette_Wait_Cancel,
  B10C4_UE1_Align_Cancel,
  B10C5_UE1_Cassette_Wait_Cancel,
  B10C6_UE2_Align_Cancel,
  B10C7_UE2_Cassette_Wait_Cancel,
  B10C8_UE3_Align_Cancel,
  B10C9_UE3_Cassette_Wait_Cancel,
  B10CA_UE4_Align_Cancel,
  B10CB_UE4_Cassette_Wait_Cancel,
  B10CC_LE_to_LP_Cancel,
  B10CD_LP_to_AL_Cancel,
  B10CE_Align_Cancel,
  B10CF_AL_to_LP_Cancel,
  B10D0_LP_to_X1_Cancel,
  B10D1_LP_to_X2_Cancel,
  B10D2_Stage1_Zero_Cancel,
  B10D3_Stage2_Zero_Cancel,
  B10D4_Stage1_Measure_Cancel,
  B10D5_Stage2_Measure_Cancel,
  B10D6_Stage1_to_UP_Cancel,
  B10D7_Stage2_to_UP_Cancel,
  B10D8_UP_to_UE_Cancel,
  B10D9_Stage1_Clean_Cancel,
  B10DA_Stage2_Clean_Cancel,
  B10DB_Probe_Change_Cancel,
  B10DC_,
  B10DD_,
  B10DE_,
  B10DF_,
  B10E0_Barcode_Trigger_OK,
  B10E1_Barcode_Trigger_NG,
  B10E2_Barcode_Trigger_Error,
  B10E3_,
  B10E4_,
  B10E5_,
  B10E6_,
  B10E7_,
  B10E8_,
  B10E9_,
  B10EA_,
  B10EB_,
  B10EC_,
  B10ED_,
  B10EE_,
  B10EF_,
  B10F0_,
  B10F1_,
  B10F2_,
  B10F3_,
  B10F4_,
  B10F5_,
  B10F6_,
  B10F7_,
  B10F8_,
  B10F9_,
  B10FA_,
  B10FB_,
  B10FC_,
  B10FD_,
  B10FE_,
  B10FF_,
}
public enum enumBitOutput // PC -> PLC Output
{
  B1100_PCPowerSwitchLED_Green,
  B1101_ResetSwitchLED_Blue,
  B1102_TowerLampLED_Red,
  B1103_TowerLampLED_Yellow,
  B1104_TowerLampLED_Green,
  B1105_TowerLampBuzzer_Error,
  B1106_TowerLampBuzzer_End,
  B1107_,
  B1108_DoorLockSignal1,
  B1109_DoorLockSignal2,
  B110A_DoorLockSignal3,
  B110B_DoorLockSignal4,
  B110C_DoorLockSignal5,
  B110D_DoorLockSignal6,
  B110E_,
  B110F_,
  B1110_FFUPowerOnSignal,
  B1111_,
  B1112_,
  B1113_LoadingAirBlowSol,
  B1114_LoadingPickerUpSol,
  B1115_LoadingPickerDownSol,
  B1116_Chuck1AirBlow_Rear,
  B1117_Chuck2AirBlow_Front,
  B1118_ProbeAirBlowSol1_Rear,
  B1119_ProbeAirBlowSol2_Front,
  B111A_UnloadingPickerUpSol,
  B111B_UnloadingPickerDownSol,
  B111C_,
  B111D_,
  B111E_,
  B111F_,
  B1120_LoadingPickerVacuumSol,
  B1121_UnLoadingPickerVacuumSol,
  B1122_Chuck1VacuumSol_Rear,
  B1123_Chuck2VacuumSol_Front,
  B1124_LoadingPickerBackVacuumSol,
  B1125_UnLoadingPickerBackVacuumSol,
  B1126_Chuck1BackVacuumSol,
  B1127_Chuck2BackVacuumSol,
  B1128_,
  B1129_,
  B112A_,
  B112B_,
  B112C_,
  B112D_,
  B112E_,
  B112F_,
  B1130_Probe_Stage1_Zero_Signal,
  B1131_Probe_Stage1_Start_Signal,
  B1132_Probe_Stage2_Zero_Signal,
  B1133_Probe_Stage2_Start_Signal,
  B1134_,
  B1135_,
  B1136_,
  B1137_,
  B1138_,
  B1139_,
  B113A_,
  B113B_,
  B113C_,
  B113D_,
  B113E_ServoOnSig,
  B113F_AlarmResetSig,
  B1140_,
  B1141_,
  B1142_,
  B1143_,
  B1144_,
  B1145_,
  B1146_,
  B1147_,
  B1148_,
  B1149_,
  B114A_,
  B114B_,
  B114C_,
  B114D_,
  B114E_,
  B114F_,
  B1150_,
  B1151_,
  B1152_,
  B1153_,
  B1154_,
  B1155_,
  B1156_,
  B1157_,
  B1158_,
  B1159_,
  B115A_,
  B115B_,
  B115C_,
  B115D_,
  B115E_,
  B115F_,
  B1160_,
  B1161_,
  B1162_,
  B1163_,
  B1164_,
  B1165_,
  B1166_,
  B1167_,
  B1168_,
  B1169_,
  B116A_,
  B116B_,
  B116C_,
  B116D_,
  B116E_,
  B116F_,
  B1170_,
  B1171_,
  B1172_,
  B1173_,
  B1174_,
  B1175_,
  B1176_,
  B1177_,
  B1178_,
  B1179_,
  B117A_,
  B117B_,
  B117C_,
  B117D_,
  B117E_,
  B117F_,
}

public enum enumWR_AD_Data
{
  W1500_Main_Air_Value,
  W1502_Vaccum_Air_Value,
  W1504_LP_Air_Value,
  W1506_UP_Air_Value,
  W1508_Stage1_Air_Value,
  W150A_Stage2_Air_Value,
  W150C_,
  W150E_,
  W1510_,
  W1512_,
  W1514_,
  W1516_,
  W1518_,
  W151A_,
  W151C_,
  W151E_,
  W1520_,
  W1522_,
  W1524_,
  W1526_,
  W1528_,
  W152A_,
  W152C_,
  W152E_,
  W1530_,
  W1532_,
  W1534_,
  W1536_,
  W1538_,
  W153A_,
  W153C_,
  W153E_,
  W1540_,
  W1542_,
  W1544_,
  W1546_,
  W1548_,
  W154A_,
  W154C_,
  W154E_,
  W1550_,
  W1552_,
  W1554_,
  W1556_,
  W1558_,
  W155A_,
  W155C_,
  W155E_,
}
public enum enumWR_CurPos
{
  W1560_LE_Cur_Pos,
  W1562_UE1_Cur_Pos,
  W1564_UE2_Cur_Pos,
  W1566_UE3_Cur_Pos,
  W1568_UE4_Cur_Pos,
  W156A_BCX_Cur_Pos,
  W156C_BCY_Cur_Pos,
  W156E_LP_Cur_Pos,
  W1570_UPX_Cur_Pos,
  W1572_UPY_Cur_Pos,
  W1574_Z1_Cur_Pos,
  W1576_Z2_Cur_Pos,
  W1578_ALX_Cur_Pos,
  W157A_ALY_Cur_Pos,
  W157C_X1_Cur_Pos,
  W157E_X2_Cur_Pos,
  W1580_PR1_Cur_Pos,
  W1582_PR2_Cur_Pos,
  W1584_PR3_Cur_Pos,
  W1586_PR4_Cur_Pos,
  W1588_,
  W158A_,
  W158C_,
  W158E_,
  W1590_,
  W1592_,
  W1594_,
  W1596_,
  W1598_,
  W159A_,
  W159C_,
  W159E_,
}
public enum enumWR_CurSpd
{
  W15A0_LE_Cur_Spd,
  W15A2_UE1_Cur_Spd,
  W15A4_UE2_Cur_Spd,
  W15A6_UE3_Cur_Spd,
  W15A8_UE4_Cur_Spd,
  W15AA_BCX_Cur_Spd,
  W15AC_BCY_Cur_Spd,
  W15AE_LP_Cur_Spd,
  W15B0_UPX_Cur_Spd,
  W15B2_UPY_Cur_Spd,
  W15B4_Z1_Cur_Spd,
  W15B6_Z2_Cur_Spd,
  W15B8_ALX_Cur_Spd,
  W15BA_ALY_Cur_Spd,
  W15BC_X1_Cur_Spd,
  W15BE_X2_Cur_Spd,
  W15C0_PR1_Cur_Spd,
  W15C2_PR2_Cur_Spd,
  W15C4_PR3_Cur_Spd,
  W15C6_PR4_Cur_Spd,
  W15C8_,
  W15CA_,
  W15CC_,
  W15CE_,
  W15D0_,
  W15D2_,
  W15D4_,
  W15D6_,
  W15D8_,
  W15DA_,
  W15DC_,
  W15DE_,
}
public enum enumWR_AlarmCode
{
  W15E0_LE_Alarm_Code,
  W15E2_UE1_Alarm_Code,
  W15E4_UE2_Alarm_Code,
  W15E6_UE3_Alarm_Code,
  W15E8_UE4_Alarm_Code,
  W15EA_BCX_Alarm_Code,
  W15EC_BCY_Alarm_Code,
  W15EE_LP_Alarm_Code,
  W15F0_UPX_Alarm_Code,
  W15F2_UPY_Alarm_Code,
  W15F4_Z1_Alarm_Code,
  W15F6_Z2_Alarm_Code,
  W15F8_ALX_Alarm_Code,
  W15FA_ALY_Alarm_Code,
  W15FC_X1_Alarm_Code,
  W15FE_X2_Alarm_Code,
  W1600_PR1_Alarm_Code,
  W1602_PR2_Alarm_Code,
  W1604_PR3_Alarm_Code,
  W1606_PR4_Alarm_Code,
  W1608_,
  W160A_,
  W160C_,
  W160E_,
  W1610_,
  W1612_,
  W1614_,
  W1616_,
  W1618_,
  W161A_,
  W161C_,
  W161E_,
}
public enum enumWR_Counter
{
  W1620_LE_Align_Counter,
  W1622_LE_Cassette_Wait_Counter,
  W1624_UE1_Align_Counter,
  W1626_UE1_Cassette_Wait_Counter,
  W1628_UE2_Align_Counter,
  W162A_UE2_Cassette_Wait_Counter,
  W162C_UE3_Align_Counter,
  W162E_UE3_Cassette_Wait_Counter,
  W1630_UE4_Align_Counter,
  W1632_UE4_Cassette_Wait_Counter,
  W1634_LE_to_LP_Counter,
  W1636_LP_to_AL_Counter,
  W1638_Align_Counter,
  W163A_AL_to_LP_Counter,
  W163C_LP_to_X1_Counter,
  W163E_LP_to_X2_Counter,
  W1640_Stage1_Zero_Counter,
  W1642_Stage2_Zero_Counter,
  W1644_Stage1_Measure_Counter,
  W1646_Stage2_Measure_Counter,
  W1648_X1_to_UP_Counter,
  W164A_X2_to_UP_Counter,
  W164C_UP_to_UE_Counter,
  W164E_Stage1_Clean_Counter,
  W1650_Stage2_Clean_Counter,
  W1652_Probe_Change_Counter,
  W1654_,
  W1656_,
  W1658_,
  W165A_,
  W165C_,
  W165E_,
}
public enum enumWR_Etc
{
  W1660_Command_Reject_Alarm_Number,
  W1662_PLC_Version,
  W1664_,
  W1666_,
  W1668_,
  W166A_,
  W166C_,
  W166E_,
  W1670_,
  W1672_,
  W1674_,
  W1676_,
  W1678_,
  W167A_,
  W167C_,
  W167E_,
  W1680_,
  W1682_,
  W1684_,
  W1686_,
  W1688_,
  W168A_,
  W168C_,
  W168E_,
  W1690_,
  W1692_,
  W1694_,
  W1696_,
  W1698_,
  W169A_,
  W169C_,
  W169E_,
  W16A0_,
  W16A2_,
  W16A4_,
  W16A6_,
  W16A8_,
  W16AA_,
  W16AC_,
  W16AE_,
  W16B0_,
  W16B2_,
  W16B4_,
  W16B6_,
  W16B8_,
  W16BA_,
  W16BC_,
  W16BE_,
  W16C0_,
  W16C2_,
  W16C4_,
  W16C6_,
  W16C8_,
  W16CA_,
  W16CC_,
  W16CE_,
  W16D0_,
  W16D2_,
  W16D4_,
  W16D6_,
  W16D8_,
  W16DA_,
  W16DC_,
  W16DE_,
}

public enum enumWW_Teaching_Jog_Data
{
  W1000_LE_Teaching_Spd,
  W1002_LE_Teaching_Pos,
  W1004_UE1_Teaching_Spd,
  W1006_UE1_Teaching_Pos,
  W1008_UE2_Teaching_Spd,
  W100A_UE2_Teaching_Pos,
  W100C_UE3_Teaching_Spd,
  W100E_UE3_Teaching_Pos,
  W1010_UE4_Teaching_Spd,
  W1012_UE4_Teaching_Pos,
  W1014_BCX_Teaching_Spd,
  W1016_BCX_Teaching_Pos,
  W1018_BCY_Teaching_Spd,
  W101A_BCY_Teaching_Pos,
  W101C_LP_Teaching_Spd,
  W101E_LP_Teaching_Pos,
  W1020_UPX_Teaching_Spd,
  W1022_UPX_Teaching_Pos,
  W1024_UPY_Teaching_Spd,
  W1026_UPY_Teaching_Pos,
  W1028_Z1_Teaching_Spd,
  W102A_Z1_Teaching_Pos,
  W102C_Z2_Teaching_Spd,
  W102E_Z2_Teaching_Pos,
  W1030_ALX_Teaching_Spd,
  W1032_ALX_Teaching_Pos,
  W1034_ALY_Teaching_Spd,
  W1036_ALY_Teaching_Pos,
  W1038_X1_Teaching_Spd,
  W103A_X1_Teaching_Pos,
  W103C_X2_Teaching_Spd,
  W103E_X2_Teaching_Pos,
  W1040_PR1_Teaching_Spd,
  W1042_PR1_Teaching_Pos,
  W1044_PR2_Teaching_Spd,
  W1046_PR2_Teaching_Pos,
  W1048_PR3_Teaching_Spd,
  W104A_PR3_Teaching_Pos,
  W104C_PR4_Teaching_Spd,
  W104E_PR4_Teaching_Pos,
  W1050_,
  W1052_,
  W1054_,
  W1056_,
  W1058_,
  W105A_,
  W105C_,
  W105E_,
  W1060_,
  W1062_,
  W1064_,
  W1066_,
  W1068_,
  W106A_,
  W106C_,
  W106E_,
  W1070_,
  W1072_,
  W1074_,
  W1076_,
  W1078_,
  W107A_,
  W107C_,
  W107E_,
  W1080_LE_Jog_Spd,
  W1082_UE1_Jog_Spd,
  W1084_UE2_Jog_Spd,
  W1086_UE3_Jog_Spd,
  W1088_UE4_Jog_Spd,
  W108A_BCX_Jog_Spd,
  W108C_BCY_Jog_Spd,
  W108E_LP_Jog_Spd,
  W1090_UPX_Jog_Spd,
  W1092_UPY_Jog_Spd,
  W1094_Z1_Jog_Spd,
  W1096_Z2_Jog_Spd,
  W1098_ALX_Jog_Spd,
  W109A_ALY_Jog_Spd,
  W109C_X1_Jog_Spd,
  W109E_X2_Jog_Spd,
  W10A0_PR1_Jog_Spd,
  W10A2_PR2_Jog_Spd,
  W10A4_PR3_Jog_Spd,
  W10A6_PR4_Jog_Spd,
  W10A8_,
  W10AA_,
  W10AC_,
  W10AE_,
  W10B0_,
  W10B2_,
  W10B4_,
  W10B6_,
  W10B8_,
  W10BA_,
  W10BC_,
  W10BE_,
}
public enum enumWW_LE_Align_Ready
{
  W10C0_LE_Scan_Start_Pos,
  W10C2_LE_Scan_Complete_Pos,
  W10C4_LE_Cassette_Wait_Pos,
  W10C6_BCX_Ready_Pos,
  W10C8_BCY_Ready_Pos,
  W10CA_BCX_Read_Pos,
  W10CC_BCY_Read_Pos,
  W10CE_LP_ReadyPos,
  W10D0_,
  W10D2_,
  W10D4_,
  W10D6_,
  W10D8_LE_Spd,
  W10DA_LE_Scan_Spd,
  W10DC_BCX_Spd,
  W10DE_BCY_Spd,
}
public enum enumWW_UE1_Align_Ready
{
  W10E0_UE1_Scan_Start_Pos,
  W10E2_UE1_Scan_Complete_Pos,
  W10E4_UE1_Cassete_Wait_Pos,
  W10E6_,
  W10E8_,
  W10EA_,
  W10EC_,
  W10EE_,
  W10F0_,
  W10F2_,
  W10F4_,
  W10F6_,
  W10F8_UE1_Spd,
  W10FA_UE1_Scan_Spd,
  W10FC_,
  W10FE_,
}
public enum enumWW_UE2_Align_Ready
{
  W1100_UE2_Scan_Start_Pos,
  W1102_UE2_Scan_Complete_Pos,
  W1104_UE2_Cassete_Wait_Pos,
  W1106_,
  W1108_,
  W110A_,
  W110C_,
  W110E_,
  W1110_,
  W1112_,
  W1114_,
  W1116_,
  W1118_UE2_Spd,
  W111A_UE2_Scan_Spd,
  W111C_,
  W111E_,
}
public enum enumWW_UE3_Align_Ready
{
  W1120_UE3_Scan_Start_Pos,
  W1122_UE3_Scan_Complete_Pos,
  W1124_UE3_Cassete_Wait_Pos,
  W1126_,
  W1128_,
  W112A_,
  W112C_,
  W112E_,
  W1130_,
  W1132_,
  W1134_,
  W1136_,
  W1138_UE3_Spd,
  W113A_UE3_Scan_Spd,
  W113C_,
  W113E_,
}
public enum enumWW_UE4_Align_Ready
{
  W1140_UE4_Scan_Start_Pos,
  W1142_UE4_Scan_Complete_Pos,
  W1144_UE4_Cassete_Wait_Pos,
  W1146_,
  W1148_,
  W114A_,
  W114C_,
  W114E_,
  W1150_,
  W1152_,
  W1154_,
  W1156_,
  W1158_UE4_Spd,
  W115A_UE4_Scan_Spd,
  W115C_,
  W115E_,
}
public enum enumWW_LE_to_LP
{
  W1160_LP_LE_Pos,
  W1162_,
  W1164_BCX_Ready_Pos,
  W1166_BCY_Ready_Pos,
  W1168_,
  W116A_,
  W116C_LE_Down_Offset_Rel,
  W116E_,
  W1170_,
  W1172_LP_Shake_Count,
  W1174_,
  W1176_,
  W1178_LP_Spd,
  W117A_,
  W117C_,
  W117E_,
}
public enum enumWW_LP_to_AL
{
  W1180_LP_AL_Loading_Pos,
  W1182_ALX_Ready_Pos,
  W1184_ALY_Ready_Pos,
  W1186_,
  W1188_,
  W118A_,
  W118C_,
  W118E_,
  W1190_,
  W1192_,
  W1194_,
  W1196_,
  W1198_,
  W119A_,
  W119C_,
  W119E_,
}
public enum enumWW_Align
{
  W11A0_ALX_Befor_Pos,
  W11A2_ALY_Befor_Pos,
  W11A4_ALX_Align_Pos,
  W11A6_ALY_Align_Pos,
  W11A8_ALX_Back_Offset,
  W11AA_ALY_Back_Offset,
  W11AC_,
  W11AE_,
  W11B0_,
  W11B2_,
  W11B4_,
  W11B6_,
  W11B8_ALX_Low_Spd,
  W11BA_ALY_Low_Spd,
  W11BC_ALX_Spd,
  W11BE_ALY_Spd,

}
public enum enumWW_AL_to_LP
{
  W11C0_LP_Align_Unload_Pos,
  W11C2_ALX_Ready_Pos,
  W11C4_ALY_Ready_Pos,
  W11C6_,
  W11C8_,
  W11CA_,
  W11CC_,
  W11CE_,
  W11D0_,
  W11D2_,
  W11D4_,
  W11D6_,
  W11D8_,
  W11DA_,
  W11DC_,
  W11DE_,
}
public enum enumWW_LP_to_Stage1
{
  W11E0_LP_Stage1_Pos,
  W11E2_Z1_Ready_Pos,
  W11E4_Z1_Loading_Pos,
  W11E6_X1_Loading_Pos,
  W11E8_,
  W11EA_,
  W11EC_,
  W11EE_,
  W11F0_,
  W11F2_,
  W11F4_,
  W11F6_,
  W11F8_Z1_Low_Spd,
  W11FA_Z1_Spd,
  W11FC_X1_Spd,
  W11FE_,
}
public enum enumWW_LP_to_Stage2
{
  W1200_LP_Stage2_Pos,
  W1202_Z2_Ready_Pos,
  W1204_Z2_Loading_Pos,
  W1206_X2_Loading_Pos,
  W1208_,
  W120A_,
  W120C_,
  W120E_,
  W1210_,
  W1212_,
  W1214_,
  W1216_,
  W1218_Z2_Low_Spd,
  W121A_Z2_Spd,
  W121C_X2_Spd,
  W121E_,
}
public enum enumWW_Stage1_Zero
{
  W1220_Z1_Zero_Pos,
  W1222_X1_Zero_Pos,
  W1224_PR1_Zero_Pos,
  W1226_PR2_Zero_Pos,
  W1228_,
  W122A_,
  W122C_,
  W122E_,
  W1230_Z1_Safety_Pos,
  W1232_,
  W1234_,
  W1236_,
  W1238_PR1_Spd,
  W123A_PR2_Spd,
  W123C_,
  W123E_,
}
public enum enumWW_Stage2_Zero
{
  W1240_Z2_Zero_Pos,
  W1242_X2_Zero_Pos,
  W1244_PR3_Zero_Pos,
  W1246_PR4_Zero_Pos,
  W1248_,
  W124A_,
  W124C_,
  W124E_,
  W1250_Z2_Safety_Pos,
  W1252_,
  W1254_,
  W1256_,
  W1258_PR3_Spd,
  W125A_PR4_Spd,
  W125C_,
  W125E_,
}
public enum enumWW_Stage1_Measure
{
  W1260_Z1_Measure_Pos,
  W1262_X1_Measure_Pos,
  W1264_PR1_Measure_Pos,
  W1266_PR2_Measure_Pos,
  W1268_,
  W126A_,
  W126C_,
  W126E_,
  W1270_,
  W1272_,
  W1274_,
  W1276_,
  W1278_,
  W127A_,
  W127C_,
  W127E_,
}
public enum enumWW_Stage2_Measure
{
  W1280_Z2_Measure_Pos,
  W1282_X2_Measure_Pos,
  W1284_PR3_Measure_Pos,
  W1286_PR4_Measure_Pos,
  W1288_,
  W128A_,
  W128C_,
  W128E_,
  W1290_,
  W1292_,
  W1294_,
  W1296_,
  W1298_,
  W129A_,
  W129C_,
  W129E_,
}
public enum enumWW_Stage1_to_UL
{
  W12A0_UPX_Stage1_Pos,
  W12A2_UPY_Stage1_Pos,
  W12A4_Z1_Unload_Pos,
  W12A6_X1_Unload_Pos,
  W12A8_,
  W12AA_,
  W12AC_,
  W12AE_,
  W12B0_,
  W12B2_,
  W12B4_,
  W12B6_,
  W12B8_UPX_Spd,
  W12BA_UPY_Spd,
  W12BC_,
  W12BE_,
}
public enum enumWW_Stage2_to_UL
{
  W12C0_UPX_Stage2_Pos,
  W12C2_UPY_Stage2_Pos,
  W12C4_Z2_Unload_Pos,
  W12C6_X2_Unload_Pos,
  W12C8_,
  W12CA_,
  W12CC_,
  W12CE_,
  W12D0_,
  W12D2_,
  W12D4_,
  W12D6_,
  W12D8_UPX_Spd,
  W12DA_UPY_Spd,
  W12DC_,
  W12DE_,
}
public enum enumWW_UL_to_UE
{
  W12E0_UPX_UE1_Unload_Pos,
  W12E2_UPX_UE2_Unload_Pos,
  W12E4_UPX_UE3_Unload_Pos,
  W12E6_UPX_UE4_Unload_Pos,
  W12E8_UPY_UE1_Unload_Pos,
  W12EA_UPY_UE2_Unload_Pos,
  W12EC_UPY_UE3_Unload_Pos,
  W12EE_UPY_UE4_Unload_Pos,
  W12F0_UPX_Ready_Pos,
  W12F2_UPY_Ready_Pos,
  W12F4_,
  W12F6_,
  W12F8_UP_Unload_Pos_Number,
  W12FA_,
  W12FC_,
  W12FE_,
}
public enum enumWW_Stage1_Clean
{
  W1300_Z1_Clean_Pos,
  W1302_X1_Clean_Start_Pos,
  W1304_X1_Clean_End_Pos,
  W1306_X1_Probe_Clean_Pos,
  W1308_PR1_Clean_Pos,
  W130A_PR2_Clean_Pos,
  W130C_,
  W130E_,
  W1310_,
  W1312_,
  W1314_,
  W1316_PCB_Exist, // (0: Empty 1:Exist)
  W1318_CleanMode,
  W131A_CleanCount,
  W131C_X1_Low_Spd,
  W131E_,
}
public enum enumWW_Stage2_Clean
{
  W1320_Z2_Clean_Pos,
  W1322_X2_Clean_Start_Pos,
  W1324_X2_Clean_End_Pos,
  W1326_X2_Probe_Clean_Pos,
  W1328_PR3_Clean_Pos,
  W132A_PR4_Clean_Pos,
  W132C_,
  W132E_,
  W1330_,
  W1332_,
  W1334_,
  W1336_PCB_Exist, // (0: Empty 1:Exist)
  W1338_CleanMode,
  W133A_CleanCount,
  W133C_X2_Low_Spd,
  W133E_,
}
public enum enumWW_Etc
{
  W1340_,
  W1342_,
  W1344_,
  W1346_,
  W1348_,
  W134A_,
  W134C_,
  W134E_,
  W1350_,
  W1352_,
  W1354_,
  W1356_,
  W1358_,
  W135A_,
  W135C_,
  W135E_,
}
public enum enumWW_ErrorValue_Allow_Data
{
  W1360_MainAir_Min_Error_Value,
  W1362_MainAir_Vaccum_Min_Error_Value,
  W1364_LP_Air_Max_Error_Value,
  W1366_LP_Air_Min_Error_Value,
  W1368_UP_Air_Max_Error_Value,
  W136A_UP_Air_Min_Error_Value,
  W136C_STAGE1_Air_Max_Error_Value,
  W136E_STAGE1_Air_Min_Error_Value,
  W1370_STAGE2_Air_Max_Error_Value,
  W1372_STAGE2_Air_Min_Error_Value,
  W1374_,
  W1376_,
  W1378_,
  W137A_,
  W137C_,
  W137E_,
  W1380_,
  W1382_,
  W1384_,
  W1386_,
  W1388_,
  W138A_,
  W138C_,
  W138E_,
  W1390_,
  W1392_,
  W1394_,
  W1396_,
  W1398_,
  W139A_,
  W139C_,
  W139E_,
  W13A0_LE_Cw_Max_Pos,
  W13A2_LE_Ccw_Max_Pos,
  W13A4_UE1_Cw_Max_Pos,
  W13A6_UE1_Ccw_Max_Pos,
  W13A8_UE2_Cw_Max_Pos,
  W13AA_UE2_Ccw_Max_Pos,
  W13AC_UE3_Cw_Max_Pos,
  W13AE_UE3_Ccw_Max_Pos,
  W13B0_UE4_Cw_Max_Pos,
  W13B2_UE4_Ccw_Max_Pos,
  W13B4_BCX_Cw_Max_Pos,
  W13B6_BCX_Ccw_Max_Pos,
  W13B8_BCY_Cw_Max_Pos,
  W13BA_BCY_Ccw_Max_Pos,
  W13BC_LP_Cw_Max_Pos,
  W13BE_LP_Ccw_Max_Pos,
  W13C0_UPX_Cw_Max_Pos,
  W13C2_UPX_Ccw_Max_Pos,
  W13C4_UPY_Cw_Max_Pos,
  W13C6_UPY_Ccw_Max_Pos,
  W13C8_Z1_Cw_Max_Pos,
  W13CA_Z1_Ccw_Max_Pos,
  W13CC_Z2_Cw_Max_Pos,
  W13CE_Z2_Ccw_Max_Pos,
  W13D0_ALX_Cw_Max_Pos,
  W13D2_ALX_Ccw_Max_Pos,
  W13D4_ALY_Cw_Max_Pos,
  W13D6_ALY_Ccw_Max_Pos,
  W13D8_X1_Cw_Max_Pos,
  W13DA_X1_Ccw_Max_Pos,
  W13DC_X2_Cw_Max_Pos,
  W13DE_X2_Ccw_Max_Pos,
  W13E0_PR1_Cw_Max_Pos,
  W13E2_PR1_Ccw_Max_Pos,
  W13E4_PR2_Cw_Max_Pos,
  W13E6_PR2_Ccw_Max_Pos,
  W13E8_PR3_Cw_Max_Pos,
  W13EA_PR3_Ccw_Max_Pos,
  W13EC_PR4_Cw_Max_Pos,
  W13EE_PR4_Ccw_Max_Pos,
  W13F0_,
  W13F2_,
  W13F4_,
  W13F6_,
  W13F8_,
  W13FA_,
  W13FC_,
  W13FE_,
  W1400_PR1_Interlock_pos,
  W1402_PR2_Interlock_pos,
  W1404_PR3_Interlock_pos,
  W1406_PR4_Interlock_pos,
  W1408_,
  W140A_,
  W140C_,
  W140E_,
  W1410_,
  W1412_,
  W1414_,
  W1416_,
  W1418_,
  W141A_,
  W141C_,
  W141E_,
}
public enum enumWW_Select_Section
{
  W1420_Setup_Mode,
  W1422_Teaching_Mode,
  W1424_LE_Air_Mode,
  W1426_LP_Shaking_Mode,
  W1428_,
  W142A_,
  W142C_,
  W142E_,
  W1430_,
  W1432_,
  W1434_,
  W1436_,
  W1438_,
  W143A_,
  W143C_,
  W143E_,
  W1440_Cylinder_Error_Time,
  W1442_LP_Air_Error_Time,
  W1444_UP_Air_Error_Time,
  W1446_Stage1_Air_Error_Time,
  W1448_Stage2_Air_Error_Time,
  W144A_,
  W144C_,
  W144E_,
  W1450_Cylinder_Check_Time,
  W1452_LP_Air_Check_Time,
  W1454_UP_Air_Check_Time,
  W1456_Stage1_Air_Check_Time,
  W1458_Stage2_Air_Check_Time,
  W145A_,
  W145C_,
  W145E_Run_TimiOut_Error_Time,
  W1460_Measure_Delay_Time,
  W1462_Align_Delay_Time,
  W1464_LE_Air_Blow_Time,
  W1466_,
  W1468_,
  W146A_,
  W146C_,
  W146E_,
  W1470_,
  W1472_,
  W1474_,
  W1476_,
  W1478_,
  W147A_,
  W147C_,
  W147E_,
}

namespace BASE.MODULE.PLC
{
  public class ClassMxComponent
  {
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    private static bool bOpen = false;
    //private static ActUtlTypeLib.ActUtlType _ActUtlType = null;

    private static ClassMxComponent cInstatnce;
    private static object syncLock = new object();

    protected ClassMxComponent()
    {

    }

    public static ClassMxComponent Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassMxComponent();
          }
        }
      }
      return cInstatnce;
    }

    #region PLC Communication Function

    public bool IsOpen()
    {
      return bOpen;
    }
    public bool Open()
    {
      //if (_ActUtlType != null)
      //{
      //  _ActUtlType.Close();
      //  _ActUtlType = null;
      //}
      //bOpen = false;
      //_ActUtlType = new ActUtlTypeLib.ActUtlType();
      //_ActUtlType.ActLogicalStationNumber = 0;
      //if (_ActUtlType.Open() == 0)
      //{
      //  bOpen = true;
      //}
      //return bOpen;
      return true;
    }

    public void Close()
    {
      //if (_ActUtlType != null)
      //{
      //  _ActUtlType.Close();
      //  _ActUtlType = null;
      //}
      bOpen = false;
    }
    #endregion

    #region Direct Read/Write
    public bool Set_Address_Bit(string add, bool on)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iData = on ? 1 : 0;
      //int iResult = _ActUtlType.SetDevice(add, iData);
      //if (iResult != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_Address_Word(string add, ref int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      //int iResult = _ActUtlType.WriteDeviceBlock(add, 1, data);
      //if (iResult != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Get_Address_Bit(string add)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iData = 0;
      //int iResult = _ActUtlType.GetDevice(add, out iData);
      //if (iResult != 0)
      //{
      //  return false;
      //}
      return (iData == 1);
    }
    #endregion

    #region Memory Communicate Onece

    public bool Set_WA_Teaching_Jog_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1000;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_LE_Align_Ready_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x10C0;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_UE1_Align_Ready_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x10E0;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_UE2_Align_Ready_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1100;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_UE3_Align_Ready_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1120;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_UE4_Align_Ready_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1140;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_LE_to_LP_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1160;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_LP_to_AL_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1180;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_Align_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x11A0;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_AL_to_LP_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x11C0;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_LP_to_Stage1_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x11E0;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_LP_to_Stage2_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1200;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_Stage1_Zero_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1220;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_Stage2_Zero_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1240;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_Stage1_Measure_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1260;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_Stage2_Measure_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1280;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_Stage1_to_UL_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x12A0;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_Stage2_to_UL_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x12C0;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_UL_to_UE_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x12E0;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_Stage1_Clean_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1300;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_Stage2_Clean_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1320;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_Etc_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 16)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1340;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_ErrorValue_Allow_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 96)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1360;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_WA_Select_Section_Data(int[] data)
    {
      if (bOpen == false)
      {
        return false;
      }
      if (data.Length != 48)
      {
        return false;
      }
      int[] temp = new int[16 * 2];
      for (int i = 0; i < data.Length; i++)
      {
        temp[i * 2] = (data[i] & 65535);
        temp[i * 2 + 1] = ((data[i] >> 16) & 65535);
      }
      int iAdd = 0x1420;
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, temp.Length, ref temp[0]);
      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }

    #endregion

    #region Memory
    public bool Set_W_OutFlag(enumFlagOut number, bool on)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iAdd = 0x1000 + (int)number;
      int iData = on ? 1 : 0;
      string strAdd = string.Format("B{0}", iAdd.ToString("X4"));

      //int iRet = _ActUtlType.SetDevice(strAdd, iData);
      //if (iRet != 0)
      //{
      //  return false;
      //}

      return true;
    }
    public bool Set_W_OutBit(enumBitOutput number, bool on)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iAdd = 0x1000 + (int)number + Enum.GetNames(typeof(enumFlagOut)).Length;
      int iData = on ? 1 : 0;
      string strAdd = string.Format("B{0}", iAdd.ToString("X4"));

      //int iRet = _ActUtlType.SetDevice(strAdd, iData);
      //if (iRet != 0)
      //{
      //  return false;
      //}

      return true;
    }

    public bool Set_W_Teaching_Jog_Data(enumWW_Teaching_Jog_Data number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Teaching_Jog_Data)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1000 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);


      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_LE_Align_Ready_Data(enumWW_LE_Align_Ready number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_LE_Align_Ready)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x10C0 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_UE1_Align_Ready_Data(enumWW_UE1_Align_Ready number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_UE1_Align_Ready)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x10E0 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_UE2_Align_Ready_Data(enumWW_UE2_Align_Ready number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_UE2_Align_Ready)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1100 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_UE3_Align_Ready_Data(enumWW_UE3_Align_Ready number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_UE3_Align_Ready)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1120 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_UE4_Align_Ready_Data(enumWW_UE4_Align_Ready number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_UE4_Align_Ready)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1140 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_LE_to_LP_Data(enumWW_LE_to_LP number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_LE_to_LP)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1160 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_LP_to_AL_Data(enumWW_LP_to_AL number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_LP_to_AL)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1180 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_Align_Data(enumWW_Align number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Align)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x11A0 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_AL_to_LP_Data(enumWW_AL_to_LP number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_AL_to_LP)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x11C0 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_LP_to_Stage1_Data(enumWW_LP_to_Stage1 number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_LP_to_Stage1)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x11E0 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_LP_to_Stage2_Data(enumWW_LP_to_Stage2 number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_LP_to_Stage2)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1200 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_Stage1_Zero_Data(enumWW_Stage1_Zero number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Stage1_Zero)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1220 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_Stage2_Zero_Data(enumWW_Stage2_Zero number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Stage2_Zero)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1240 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_Stage1_Measure_Data(enumWW_Stage1_Measure number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Stage1_Measure)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1260 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_Stage2_Measure_Data(enumWW_Stage2_Measure number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Stage2_Measure)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1280 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_Stage1_to_UL_Data(enumWW_Stage1_to_UL number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Stage1_to_UL)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x12A0 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_Stage2_to_UL_Data(enumWW_Stage2_to_UL number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Stage2_to_UL)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x12C0 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_UL_to_UE_Data(enumWW_UL_to_UE number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_UL_to_UE)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x12E0 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_Stage1_Clean_Data(enumWW_Stage1_Clean number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Stage1_Clean)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1300 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_Stage2_Clean_Data(enumWW_Stage2_Clean number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Stage2_Clean)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1320 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_Etc_Data(enumWW_Etc number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Etc)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1340 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_ErrorValue_Allow_Data(enumWW_ErrorValue_Allow_Data number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_ErrorValue_Allow_Data)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1360 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }
    public bool Set_W_Select_Section_Data(enumWW_Select_Section number, int data)
    {
      if (bOpen == false)
      {
        return false;
      }
      int iLength = Enum.GetNames(typeof(enumWW_Select_Section)).Length;
      int iWordSize = 16;
      int iWordCount = 2;
      int iAllCount = iWordCount;

      int iAdd = 0x1420 + ((int)number * 2);
      string strMemoryAdd = string.Format("W{0}", iAdd.ToString("X4"));
      int[] iTemp = new int[iWordCount];
      iTemp[0] = (data & 65535);
      iTemp[1] = ((data >> iWordSize) & 65535);

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }

    #endregion

    #region Read Function
    public bool Read_Every_MachineData()
    {
      if (bOpen == false)
      {
        return false;
      }
      int iWordSize = 16;
      string strMemoryAdd = "W1000";
      int iStartAdd = 0x1000;
      int iAllCount = (0x1800 - 0x1000);
      int[] iTemp = new int[iAllCount];
      //int iResurt = _ActUtlType.ReadDeviceBlock(strMemoryAdd, iAllCount, out iTemp[0]);
      //if (iResurt != 0)
      //{
      //  return false;
      //}

      #region Write W Data
      int iCount_1 = Enum.GetNames(typeof(enumWW_Teaching_Jog_Data)).Length;            //enumWW_Teaching_Jog_Data                  
      int iCount_2 = Enum.GetNames(typeof(enumWW_LE_Align_Ready)).Length;               //enumWW_LE_Align_Ready
      int iCount_3 = Enum.GetNames(typeof(enumWW_UE1_Align_Ready)).Length;              //enumWW_UE1_Align_Ready
      int iCount_4 = Enum.GetNames(typeof(enumWW_UE2_Align_Ready)).Length;              //enumWW_UE2_Align_Ready
      int iCount_5 = Enum.GetNames(typeof(enumWW_UE3_Align_Ready)).Length;              //enumWW_UE3_Align_Ready
      int iCount_6 = Enum.GetNames(typeof(enumWW_UE4_Align_Ready)).Length;              //enumWW_UE4_Align_Ready
      int iCount_7 = Enum.GetNames(typeof(enumWW_LE_to_LP)).Length;                     //enumWW_LE_to_LP
      int iCount_8 = Enum.GetNames(typeof(enumWW_LP_to_AL)).Length;                     //enumWW_LP_to_AL
      int iCount_9 = Enum.GetNames(typeof(enumWW_Align)).Length;                       //enumWW_Align
      int iCount_10 = Enum.GetNames(typeof(enumWW_AL_to_LP)).Length;                    //enumWW_AL_to_LP
      int iCount_11 = Enum.GetNames(typeof(enumWW_LP_to_Stage1)).Length;                //enumWW_LP_to_Stage1
      int iCount_12 = Enum.GetNames(typeof(enumWW_LP_to_Stage2)).Length;                //enumWW_LP_to_Stage2
      int iCount_13 = Enum.GetNames(typeof(enumWW_Stage1_Zero)).Length;                 //enumWW_Stage1_Zero
      int iCount_14 = Enum.GetNames(typeof(enumWW_Stage2_Zero)).Length;                 //enumWW_Stage2_Zero
      int iCount_15 = Enum.GetNames(typeof(enumWW_Stage1_Measure)).Length;              //enumWW_Stage1_Measure
      int iCount_16 = Enum.GetNames(typeof(enumWW_Stage2_Measure)).Length;              //enumWW_Stage2_Measure
      int iCount_17 = Enum.GetNames(typeof(enumWW_Stage1_to_UL)).Length;                //enumWW_Stage1_to_UL
      int iCount_18 = Enum.GetNames(typeof(enumWW_Stage2_to_UL)).Length;                //enumWW_Stage2_to_UL
      int iCount_19 = Enum.GetNames(typeof(enumWW_UL_to_UE)).Length;                    //enumWW_UL_to_UE
      int iCount_20 = Enum.GetNames(typeof(enumWW_Stage1_Clean)).Length;                 //enumWW_Stage1_Clean
      int iCount_21 = Enum.GetNames(typeof(enumWW_Stage2_Clean)).Length;                 //enumWW_Stage2_Clean
      int iCount_22 = Enum.GetNames(typeof(enumWW_Etc)).Length;                         //enumWW_Etc
      int iCount_23 = Enum.GetNames(typeof(enumWW_ErrorValue_Allow_Data)).Length;       //enumWW_ErrorValue_Allow_Data
      int iCount_24 = Enum.GetNames(typeof(enumWW_Select_Section)).Length;              //enumWW_Select_Section

      int iIndexStart = 0;
      int iIndexEnd = 0;

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_1;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiTeaching_Jog_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_2;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiLE_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_3;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiUE1_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_4;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiUE2_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_5;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiUE3_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_6;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiUE4_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_7;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiLE_to_LP_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_8;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiLP_to_AL_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_9;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiAlign_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_10;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiAL_to_LP_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_11;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiLP_to_Stage1_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_12;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiLP_to_Stage2_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_13;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage1_Zero_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_14;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage2_Zero_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_15;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage1_Measure_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_16;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage2_Measure_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_17;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage1_to_UL_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_18;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage2_to_UL_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_19;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiUL_to_UE_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_20;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage1_Clean_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_21;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage2_Clean_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_22;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiEtc_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_23;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiErrorValue_Allow_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_24;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiSelect_Section_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }
      #endregion

      #region Read W Data
      iCount_1 = Enum.GetNames(typeof(enumWR_AD_Data)).Length;
      iCount_2 = Enum.GetNames(typeof(enumWR_CurPos)).Length;
      iCount_3 = Enum.GetNames(typeof(enumWR_CurSpd)).Length;
      iCount_4 = Enum.GetNames(typeof(enumWR_AlarmCode)).Length;
      iCount_5 = Enum.GetNames(typeof(enumWR_Counter)).Length;
      iCount_6 = Enum.GetNames(typeof(enumWR_Etc)).Length;

      int iCurrentAdd = 0x1500;
      for (int i = 0; i < iCount_1; i++)
      {
        CIoVo.aiAD_Data[i] = ((iTemp[(iCurrentAdd - iStartAdd) + (i * 2 + 1)] << iWordSize) & -65536) | (iTemp[(iCurrentAdd - iStartAdd) + (i * 2)] & 65535);
      }

      iCurrentAdd = 0x1560;
      for (int i = 0; i < iCount_2; i++)
      {
        CIoVo.aiCurPos[i] = ((iTemp[(iCurrentAdd - iStartAdd) + (i * 2 + 1)] << iWordSize) & -65536) | (iTemp[(iCurrentAdd - iStartAdd) + (i * 2)] & 65535);
      }

      iCurrentAdd = 0x15A0;
      for (int i = 0; i < iCount_3; i++)
      {
        CIoVo.aiCurSpd[i] = ((iTemp[(iCurrentAdd - iStartAdd) + (i * 2 + 1)] << iWordSize) & -65536) | (iTemp[(iCurrentAdd - iStartAdd) + (i * 2)] & 65535);
      }

      iCurrentAdd = 0x15E0;
      for (int i = 0; i < iCount_4; i++)
      {
        CIoVo.aiAlarmCode[i] = ((iTemp[(iCurrentAdd - iStartAdd) + (i * 2 + 1)] << iWordSize) & -65536) | (iTemp[(iCurrentAdd - iStartAdd) + (i * 2)] & 65535);
      }

      iCurrentAdd = 0x1620;
      for (int i = 0; i < iCount_5; i++)
      {
        CIoVo.aiCounter[i] = ((iTemp[(iCurrentAdd - iStartAdd) + (i * 2 + 1)] << iWordSize) & -65536) | (iTemp[(iCurrentAdd - iStartAdd) + (i * 2)] & 65535);
      }

      iCurrentAdd = 0x1660;
      for (int i = 0; i < iCount_6; i++)
      {
        CIoVo.aiEtc[i] = ((iTemp[(iCurrentAdd - iStartAdd) + (i * 2 + 1)] << iWordSize) & -65536) | (iTemp[(iCurrentAdd - iStartAdd) + (i * 2)] & 65535);
      }
      #endregion

      #region Write B Bit
      iCount_1 = Enum.GetNames(typeof(enumFlagOut)).Length / iWordSize;
      iCount_2 = Enum.GetNames(typeof(enumBitOutput)).Length / iWordSize;

      iIndexStart = (0x1700 - 0x1000);
      iIndexEnd = (0x1700 - 0x1000);

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_1;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.abFlag_Out[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
        }
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_2;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.sOutput[((i * iWordSize) - (iIndexStart * iWordSize)) + j].bOriginSignal = bTemp[j];
        }
      }
      #endregion

      #region Read B Bit
      iCount_1 = Enum.GetNames(typeof(enumBitInput)).Length / iWordSize;
      iCount_2 = Enum.GetNames(typeof(enumFlagRunning)).Length / iWordSize;
      iCount_3 = Enum.GetNames(typeof(enumFlagComplete)).Length / iWordSize;
      iCount_4 = Enum.GetNames(typeof(enumError)).Length / iWordSize;

      iIndexStart = (0x1718 - 0x1000);
      iIndexEnd = (0x1718 - 0x1000);

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_1;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.sInput[((i * iWordSize) - (iIndexStart * iWordSize)) + j].bOriginSignal = bTemp[j];
        }
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_2;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.abFlag_Running[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
        }
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_3;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.abFlag_Complete[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
        }
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_4;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.abError[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
        }
      }
      #endregion
      return true;
    }
    public bool Read_Bit() // Read Bit
    {
      if (bOpen == false)
      {
        return false;
      }
      string strMemoryAdd = "B2000";

      int iWordSize = 16;

      int iCount_1 = Enum.GetNames(typeof(enumBitInput)).Length / iWordSize;
      int iCount_2 = Enum.GetNames(typeof(enumFlagRunning)).Length / iWordSize;
      int iCount_3 = Enum.GetNames(typeof(enumFlagComplete)).Length / iWordSize;
      int iCount_4 = Enum.GetNames(typeof(enumError)).Length / iWordSize;

      int iAllCount =
          iCount_1
        + iCount_2
        + iCount_3
        + iCount_4;

      int iIndexStart = 0;
      int iIndexEnd = 0;


      int[] iTemp = new int[iAllCount];
      //int iResurt = _ActUtlType.ReadDeviceBlock(strMemoryAdd, iAllCount, out iTemp[0]);

      //if (iResurt != 0)
      //{
      //  return false;
      //}

      iIndexStart = iIndexEnd;
      iIndexEnd = iCount_1;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.sInput[((i * iWordSize) - (iIndexStart * iWordSize)) + j].bOriginSignal = bTemp[j];
          //abInput[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
        }
      }

      iIndexStart = iIndexEnd;
      iIndexEnd = iCount_1 + iCount_2;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.abFlag_Running[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
          //abFlag_Running[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
        }
      }

      iIndexStart = iIndexEnd;
      iIndexEnd = iCount_1 + iCount_2 + iCount_3;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.abFlag_Complete[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
          //abFlag_Complete[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
        }
      }

      iIndexStart = iIndexEnd;
      iIndexEnd = iCount_1 + iCount_2 + iCount_3 + iCount_4;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.abError[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
          //abError[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
        }
      }
      return true;
    }
    public bool Read_Data() // Read Data
    {
      if (bOpen == false)
      {
        return false;
      }
      string strMemoryAdd = "W1500";

      int iWordSize = 16;
      int iWordCount = 2;

      int iCount_1 = Enum.GetNames(typeof(enumWR_AD_Data)).Length;
      int iCount_2 = Enum.GetNames(typeof(enumWR_CurPos)).Length;
      int iCount_3 = Enum.GetNames(typeof(enumWR_CurSpd)).Length;
      int iCount_4 = Enum.GetNames(typeof(enumWR_AlarmCode)).Length;
      int iCount_5 = Enum.GetNames(typeof(enumWR_Counter)).Length;
      int iCount_6 = Enum.GetNames(typeof(enumWR_Etc)).Length;

      int iAllCount =
         (iCount_1
        + iCount_2
        + iCount_3
        + iCount_4
        + iCount_5
        + iCount_6
        )
        * iWordCount;

      int iIndexStart = 0;
      int iIndexEnd = 0;

      int[] iTemp = new int[iAllCount];
      //int iResurt = _ActUtlType.ReadDeviceBlock(strMemoryAdd, iAllCount, out iTemp[0]);

      //if (iResurt != 0)
      //{
      //  return false;
      //}

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_1;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiAD_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiAD_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_2;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiCurPos[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiCurPos[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_3;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiCurSpd[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiCurSpd[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_4;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiAlarmCode[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiAlarmCode[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_5;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiCounter[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiCounter[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_6;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiEtc[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiEtc[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      return true;
    }
    public bool Read_W_Bit() // Write Bit
    {
      if (bOpen == false)
      {
        return false;
      }
      string strMemoryAdd = "B1000";
      int iWordSize = 16;

      int iCount_1 = Enum.GetNames(typeof(enumFlagOut)).Length / iWordSize;
      int iCount_2 = Enum.GetNames(typeof(enumBitOutput)).Length / iWordSize;

      int iAllCount =
          iCount_1
        + iCount_2;

      int[] iTemp = new int[iAllCount];
      //int iResurt = _ActUtlType.ReadDeviceBlock(strMemoryAdd, iAllCount, out iTemp[0]);

      //if (iResurt != 0)
      //{
      //  return false;
      //}

      int iIndexStart = 0;
      int iIndexEnd = 0;

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_1;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.abFlag_Out[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
          //abFlag_Out[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
        }
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_2;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        bool[] bTemp = new bool[iWordSize];
        for (int j = 0; j < iWordSize; j++)
        {
          bTemp[j] = false;
        }
        var array = Convert.ToString(iTemp[i], 2).PadLeft(8, '0').ToArray();
        Array.Reverse(array);
        for (int j = 0; j < array.Length; j++)
        {
          bTemp[j] = (array.GetValue(j).ToString().CompareTo("0") == 0) ? false : true;
        }
        for (int j = 0; j < iWordSize; j++)
        {
          CIoVo.sOutput[((i * iWordSize) - (iIndexStart * iWordSize)) + j].bOriginSignal = bTemp[j];
          //abOutput[((i * iWordSize) - (iIndexStart * iWordSize)) + j] = bTemp[j];
        }
      }

      return true;
    }
    public bool Read_W_Data() // Write Data
    {
      if (bOpen == false)
      {
        return false;
      }
      string strMemoryAdd = "W1000";

      int iWordSize = 16;
      int iWordCount = 2;

      int iCount_1 = Enum.GetNames(typeof(enumWW_Teaching_Jog_Data)).Length;            //enumWW_Teaching_Jog_Data                  
      int iCount_2 = Enum.GetNames(typeof(enumWW_LE_Align_Ready)).Length;               //enumWW_LE_Align_Ready
      int iCount_3 = Enum.GetNames(typeof(enumWW_UE1_Align_Ready)).Length;              //enumWW_UE1_Align_Ready
      int iCount_4 = Enum.GetNames(typeof(enumWW_UE2_Align_Ready)).Length;              //enumWW_UE2_Align_Ready
      int iCount_5 = Enum.GetNames(typeof(enumWW_UE3_Align_Ready)).Length;              //enumWW_UE3_Align_Ready
      int iCount_6 = Enum.GetNames(typeof(enumWW_UE4_Align_Ready)).Length;              //enumWW_UE4_Align_Ready
      int iCount_7 = Enum.GetNames(typeof(enumWW_LE_to_LP)).Length;                     //enumWW_LE_to_LP
      int iCount_8 = Enum.GetNames(typeof(enumWW_LP_to_AL)).Length;                     //enumWW_LP_to_AL
      int iCount_9 = Enum.GetNames(typeof(enumWW_Align)).Length;                       //enumWW_Align
      int iCount_10 = Enum.GetNames(typeof(enumWW_AL_to_LP)).Length;                    //enumWW_AL_to_LP
      int iCount_11 = Enum.GetNames(typeof(enumWW_LP_to_Stage1)).Length;                //enumWW_LP_to_Stage1
      int iCount_12 = Enum.GetNames(typeof(enumWW_LP_to_Stage2)).Length;                //enumWW_LP_to_Stage2
      int iCount_13 = Enum.GetNames(typeof(enumWW_Stage1_Zero)).Length;                 //enumWW_Stage1_Zero
      int iCount_14 = Enum.GetNames(typeof(enumWW_Stage2_Zero)).Length;                 //enumWW_Stage2_Zero
      int iCount_15 = Enum.GetNames(typeof(enumWW_Stage1_Measure)).Length;              //enumWW_Stage1_Measure
      int iCount_16 = Enum.GetNames(typeof(enumWW_Stage2_Measure)).Length;              //enumWW_Stage2_Measure
      int iCount_17 = Enum.GetNames(typeof(enumWW_Stage1_to_UL)).Length;                //enumWW_Stage1_to_UL
      int iCount_18 = Enum.GetNames(typeof(enumWW_Stage2_to_UL)).Length;                //enumWW_Stage2_to_UL
      int iCount_19 = Enum.GetNames(typeof(enumWW_UL_to_UE)).Length;                    //enumWW_UL_to_UE
      int iCount_20 = Enum.GetNames(typeof(enumWW_Stage1_Clean)).Length;                 //enumWW_Stage1_Clean
      int iCount_21 = Enum.GetNames(typeof(enumWW_Stage2_Clean)).Length;                 //enumWW_Stage2_Clean
      int iCount_22 = Enum.GetNames(typeof(enumWW_Etc)).Length;                         //enumWW_Etc
      int iCount_23 = Enum.GetNames(typeof(enumWW_ErrorValue_Allow_Data)).Length;       //enumWW_ErrorValue_Allow_Data
      int iCount_24 = Enum.GetNames(typeof(enumWW_Select_Section)).Length;              //enumWW_Select_Section

      int iAllCount =
        (iCount_1
        + iCount_2
        + iCount_3
        + iCount_4
        + iCount_5
        + iCount_6
        + iCount_7
        + iCount_8
        + iCount_9
        + iCount_10
        + iCount_11
        + iCount_12
        + iCount_13
        + iCount_14
        + iCount_15
        + iCount_16
        + iCount_17
        + iCount_18
        + iCount_19
        + iCount_20
        + iCount_21
        + iCount_22
        + iCount_23
        + iCount_24
        )
        * iWordCount;

      int iIndexStart = 0;
      int iIndexEnd = 0;

      int[] iTemp = new int[iAllCount];
      //int iResurt = _ActUtlType.ReadDeviceBlock(strMemoryAdd, iAllCount, out iTemp[0]);

      //if (iResurt != 0)
      //{
      //  return false;
      //}


      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_1;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiTeaching_Jog_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiTeaching_Jog_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_2;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiLE_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiLE_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_3;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiUE1_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiUE1_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_4;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiUE2_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiUE2_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_5;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiUE3_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiUE3_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_6;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiUE4_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiUE4_Align_Ready_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_7;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiLE_to_LP_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiLE_to_LP_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_8;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiLP_to_AL_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiLP_to_AL_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_9;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiAlign_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiAlign_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_10;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiAL_to_LP_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiAL_to_LP_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_11;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiLP_to_Stage1_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiLP_to_Stage1_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_12;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiLP_to_Stage2_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiLP_to_Stage2_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_13;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage1_Zero_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiStage1_Zero_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_14;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage2_Zero_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //iStage2_Zero_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_15;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage1_Measure_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiStage1_Measure_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_16;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage2_Measure_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiStage2_Measure_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_17;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage1_to_UL_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiStage1_to_UL_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_18;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage2_to_UL_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiStage2_to_UL_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_19;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiUL_to_UE_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiUL_to_UE_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_20;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage1_Clean_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiStage1_Clean_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_21;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiStage2_Clean_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiStage2_Clean_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_22;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiEtc_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiEtc_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_23;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiErrorValue_Allow_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiErrorValue_Allow_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      iIndexStart = iIndexEnd;
      iIndexEnd += iCount_24;
      for (int i = iIndexStart; i < iIndexEnd; i++)
      {
        CIoVo.aiSelect_Section_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
        //aiSelect_Section_Data[i - iIndexStart] = ((iTemp[i * 2 + 1] << iWordSize) & -65536) | (iTemp[i * 2] & 65535);
      }

      //int iRet = _ActUtlType.WriteDeviceBlock(strMemoryAdd, iAllCount, ref iTemp[0]);

      //if (iRet != 0)
      //{
      //  return false;
      //}
      return true;
    }

    #endregion

  }
}
