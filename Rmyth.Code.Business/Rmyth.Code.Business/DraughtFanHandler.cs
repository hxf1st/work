using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace JiDian.Business
{
    public class DraughtFanHandler : SystemDevice
    {
        #region handler 成员

        public void initialize(object obj)
        {

        }

        public object loadObject()
        {
            return null;
        }

        #endregion
        /// <summary>
        /// 风机输出功率PYF
        /// </summary>
        /// <param name="QFC">风机输出的风量QFC</param>
        /// <param name="PFC">风机出口气体密度ρFC</param>
        /// <param name="PFR">风机进口气体密度ρFR</param>
        /// <param name="PE1">风机进口静压pe1</param>
        /// <param name="PE2">风机出口静压pe2</param>
        /// <param name="V1">风机进口气体流速v1</param>
        /// <param name="V2">风机出口气体流速v2</param>
        /// <returns>PYF</returns>
        public static double getBlowerOutputPower(double QFC, double PFC, double PFR, double PE1, double PE2, double V1, double V2)
        {
            double PYF, a, b;

            a = PE2 + (PFC / 2) * Math.Pow(V2, 2);
            b = PE1 + (PFR / 2) * Math.Pow(V1, 2);
            PYF = QFC * (a - b) * Math.Pow(10, -3);
            return PYF;
        }


        /// <summary>
        /// 风机进口流速VGj1
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ1(double VGJ)
        {
            if (VGJ >= 7 && VGJ <= 15)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }

        /// <summary>
        /// 风机出口流速VGj2
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ2(double VGJ)
        {
            if (VGJ >= 10 && VGJ <= 30)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        /// 低速通风管道主管道（民用/工业）VGj3
        /// </summary>
        /// <param name="VGJ"></param>
        /// <param name="type">T-民用，F－工业</param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ3(double VGJ, bool type)
        {
            if (type)
            {
                if (VGJ >= 3.5 && VGJ <= 4.5)
                {
                    return "经济";
                }
                else
                {
                    return "非经济";
                }
            }
            else
            {
                if (VGJ >= 6 && VGJ <= 9)
                {
                    return "经济";
                }
                else
                {
                    return "非经济";
                }
            }

        }

        /// <summary>
        /// 低速通风管道分管道（民用/工业）VGj4
        /// </summary>
        /// <param name="VGJ"></param>
        /// <param name="type">T- 民用，F－工业</param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ4(double VGJ, bool type)
        {
            if (type)
            {
                if (VGJ <= 3)
                {
                    return "经济";
                }
                else
                {
                    return "非经济";
                }
            }
            else
            {
                if (VGJ >= 4 && VGJ <= 5)
                {
                    return "经济";
                }
                else
                {
                    return "非经济";
                }
            }

        }
        /// <summary>
        /// 低速通风管道上升管道（民用/工业）VGj5
        /// </summary>
        /// <param name="VGJ"></param>
        /// <param name="type">T- 民用，F－工业</param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ5(double VGJ, bool type)
        {
            if (type)
            {
                if (VGJ <= 2.5)
                {
                    return "经济";
                }
                else
                {
                    return "非经济";
                }
            }
            else
            {
                if (VGJ <= 4)
                {
                    return "经济";
                }
                else
                {
                    return "非经济";
                }
            }

        }

        /// <summary>
        ///低速通风管道大气进气口VGj6
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ6(double VGJ)
        {
            if (VGJ >= 20 && VGJ <= 30)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        ///高速通负管道主管道VGj7
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ7(double VGJ)
        {
            if (VGJ >= 20 && VGJ <= 30)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        ///风力输送谷物VGj8
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ8(double VGJ)
        {
            if (VGJ >= 15 && VGJ <= 30)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        ///风力输送煤粉VGj9
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ9(double VGJ)
        {
            if (VGJ >= 20 && VGJ <= 40)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }

        /// <summary>
        ///风力输送氧化铝VGj10
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ10(double VGJ)
        {
            if (VGJ >= 30 && VGJ <= 40)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        ///风力输送砂VGj11
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ11(double VGJ)
        {
            if (VGJ >= 30 && VGJ <= 40)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        ///风力输送橡胶粉VGj12
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ12(double VGJ)
        {
            if (VGJ <= 15)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        ///风力输送纱屑VGj13
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ13(double VGJ)
        {
            if (VGJ <= 7.5)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        ///风力输送金属屑VGj14
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ14(double VGJ)
        {
            if (VGJ <= 18)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        ///风力输送锯末VGj15
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ15(double VGJ)
        {
            if (VGJ <= 15)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        /// 风机管路泄漏率λlF
        /// </summary>
        /// <param name="QZ">输入管网的总容积流量QZ</param>
        /// <param name="QI">管网输出的总容积流量Qˊ</param>
        /// <returns></returns>
        public static double getLIF(double QZ, double QI)
        {
            return (QZ - QI) / QZ;
        }
        /// <summary>
        /// 风机管路泄漏率λlF 诊断
        /// </summary>
        /// <param name="QZ">输入管网的总容积流量QZ</param>
        /// <param name="QI">管网输出的总容积流量Qˊ</param>
        /// <returns></returns>
        public static string getLIF_Judge(double QZ, double QI)
        {
            double LIF;

            LIF = getLIF(QZ, QI);

            if (LIF < 0.05)
            {
                return "节能";
            }
            else if (LIF >= 0.05 && LIF < 0.1)
            {
                return "合理";
            }
            else if (LIF >= 0.1)
            {
                return "不节能";
            }
            else
            {
                return "参数有误无法诊断";
            }
        }




        /// <summary>
        /// 空气密度ρFC
        /// </summary>
        /// <param name="PA">绝对压力Pa</param>
        /// <param name="T">风机出口温度tW</param>
        /// <param name="QH">相对湿度ФH</param>
        /// <returns></returns>
        public static double getPFC(double PA, double T, double QH)
        {

            double pfc = 0.0, pwb = 0.0;
            pwb = getPWB(T);
            pfc = 1.293 * (273.0 / (273.0 + T)) * (PA - (0.378 * QH * pwb)) / 0.1013;
            return pfc;

        }
        /// <summary>
        /// 饱和空气中的水蒸汽分压Pwb取值
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public static double getPWB(double T)
        {
            double pwb = 0.0;
            Hashtable ht = StaticTable.getPWDTable();
            if (T != 0)
            {
                T = Math.Round(T, MidpointRounding.AwayFromZero);
            }
            if (T <= 50 && T >= -20)
            {
                pwb = (double)ht[T];

            }
            else if (T <= 100 && T >= 50)
            {
                for (int i = 50; i < 101; i = i + 5)
                {
                    if (i == T)
                    {
                        pwb = (double)ht[T];
                        break;

                    }
                    else if (i > T)
                    {

                        double a = (double)ht[(double)(i - 5)];
                        double b = (double)ht[(double)i];
                        double c = b - a;
                        double d = T % 5;
                        pwb = d * (c / 5) + a;
                        break;
                    }
                }
            }
            pwb = pwb * 0.0001;


            return pwb;
        }
        /// <summary>
        /// 风机系统能耗WSRF
        /// </summary>
        /// <param name="PTST">风机/泵/空压机轴功率PTSR</param>
        /// <param name="T">测算时长T</param>
        /// <returns></returns>
        public static double getWSRF(double PTST, double TIME)
        {
            return PTST * TIME;
        }


        /// <summary>
        /// 风机输送千吨能耗ew 
        /// </summary>
        /// <param name="WSRF">风机系统能耗WSRF</param>
        /// <param name="PFC">风机出口气体密度ρFC</param>
        /// <param name="g">重力加速度g</param>
        /// <param name="QV">风机系统输出流量qv</param>
        /// <param name="PFC">风机出口压力PFC</param>
        /// <param name="T">风机出口气体温度t</param>
        /// <returns></returns>
        public static double getEW(double WSRF, double PFC1, double PFC, double QV, double T)
        {
            return WSRF / (0.36 * PFC * 9.807 * QV * PFC1 * T); ;
        }
        /// <summary>
        /// 风机输送千吨能耗ew 诊断项
        /// </summary>
        /// <param name="WSRF">风机系统能耗WSRF</param>
        /// <param name="PFC">风机出口气体密度ρFC</param>
        /// <param name="g">重力加速度g</param>
        /// <param name="QV">风机系统输出流量qv</param>
        /// <param name="PFC">风机出口压力PFC</param>
        /// <param name="T">风机出口气体温度t</param>
        /// <returns></returns>
        public static string getEW_Judge(double WSRF, double PFC1, double PFC, double QV, double T)
        {
            double EW;
            EW = getEW(WSRF, PFC1, PFC, QV, T);

            if (EW <= 0.25)
            {
                return "节能";
            }
            else if (EW >= 0.25)
            {
                return "不节能";
            }
            else
            {
                return "合理";
            }

        }
        /// <summary>
        /// 机组额定效率ηJe
        /// </summary>
        /// <param name="PJE">机组额定输入功率Pje</param>
        /// <param name="PYE">机组额定输出功率Pye</param>
        /// <returns></returns>
        public static double getRJ(double PJE, double PYE, double NJ)
        {

            return NJ / (PYE / PJE);
        }
        /// <summary>
        /// 机组额定效率ηJe 诊断
        /// </summary>
        /// <param name="PJE">机组额定输入功率Pje</param>
        /// <param name="PYE">机组额定输出功率Pye</param>
        /// <returns></returns>
        public static string getRJ_Judge(double PJE, double PYE, double NJ)
        {
            double i = getRJ(PJE, PYE, NJ);
            Console.WriteLine(i);

            if (i > 0.85)
            {
                return "节能";
            }
            else if (i <= 0.85 && i >= 0.70)
            {
                return "合理";
            }
            else if (i < 0.70)
            {
                return "不节能";
            }
            else
            {
                return "无法测算";
            }
        }



    }






}
