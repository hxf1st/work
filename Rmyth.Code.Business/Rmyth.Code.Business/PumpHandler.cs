using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace JiDian.Business
{
    public class PumpHandler : SystemDevice
    {

        /// <summary>
        /// 液体密度ρB
        /// </summary>
        /// <param name="PA">绝对压力Pa</param>
        /// <param name="T">温度t</param>
        /// <returns></returns>
        public static double getPB(double PA, double T)
        {

            double PB = 1001.3;

            //int i, j, i1, i2, j1, j2;

            double[,] table = StaticTable.getPumpTable();

            try
            {


                int i1, i2 = 0;
                i1 = -1;
                for (int i = 0; i < 41; i++)
                {
                    i1++;
                    i2 = i1 + 1;
                    //Console.WriteLine("i=" + i);
                    if (T == i)
                    {
                        i2 = i1;
                        break;
                    }
                    else if (T < i)
                    {
                        break;
                    }

                }

                int j1, j2 = 0;
                j1 = -1;
                for (int j = 0; j < 151; j = j + 10)
                {
                    // Console.WriteLine("j="+j);
                    j1++;
                    j2 = j1 + 1;
                    if (j == 0)
                    {
                        if (PA == j + 1)
                        {
                            j2 = j1;
                            break;
                        }
                        else if (PA < j)
                        {
                            break;
                        }

                    }
                    else
                    {
                        if (PA == j)
                        {
                            j2 = j1;
                            break;
                        }
                        else if (PA < j)
                        {
                            break;
                        }
                    }
                }
                //Console.WriteLine(table[j1, i1]);
                //Console.WriteLine(table[j1, i2]);
                //Console.WriteLine(table[j2, i1]);
                //Console.WriteLine(table[j2, i2]);

                //Console.WriteLine("i1=" + i1);
                //Console.WriteLine("i2=" + i2);
                //Console.WriteLine("j1=" + j1);
                //Console.WriteLine("j2=" + j2);

                PB = (table[j1, i1] + table[j1, i2] + table[j2, i1] + table[j2, i2]) / 4;
                //Console.WriteLine("PB=" + PB);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return PB;
        }

        /// <summary>
        /// 泵输出功率PYB
        /// </summary>
        /// <param name="PB">泵输送液体密度ρB</param>
        /// <param name="g">重力加速度g</param>
        /// <param name="QV">泵输出流量Qv</param>
        /// <param name="H">泵扬程H</param>
        /// <returns></returns>
        public static double getPumpOutputpower(double PB, double QV, double H)
        {
            return PB * 9.807 * QV * H * (Math.Pow(10, -3));
        }

        ///// <summary>
        ///// 设备/组件输出功率PYJ
        ///// </summary>
        ///// <param name="FrontPower">前一组件功率</param>
        ///// <param name="FrontEfficiency">前一组件效率</param>
        ///// <returns></returns>
        //public static double getOutpurtPower_1(double FrontPower, double FrontEfficiency)
        //{
        //    return FrontPower * FrontEfficiency;
        //}


        ///// <summary>
        ///// 设备/组件输出功率PYJ
        ///// </summary>
        ///// <param name="CurrentEfficiency">当前组件效率</param>
        ///// <param name="RearPower">后一组件功率</param>
        ///// <returns></returns>
        //public static double getOutputPower_2(double CurrentEfficiency, double RearPower)
        //{
        //    return RearPower / CurrentEfficiency;
        //}
        ///// <summary>
        ///// 风机/机组运行效率ηB
        ///// </summary>
        ///// <param name="CurrentOutputPower">当前组件输出功率</param>
        ///// <param name="FrontOutputPower">前一组件输出功率</param>
        ///// <returns></returns>
        //public static double getEfficiency(double CurrentOutputPower, double FrontOutputPower)
        //{

        //    return CurrentOutputPower / FrontOutputPower;
        //}


        /// <summary>
        /// 液体输送管路进口流速Vgj
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ1(double VGJ)
        {
            if (VGJ <= 2)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }

        /// <summary>
        /// 液体输送管路出口流速Vgj
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ2(double VGJ)
        {
            if (VGJ >= 2 && VGJ <= 3)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }

        /// <summary>
        /// 长输水压力管小口径（300mm直径以下）流速Vgj3
        /// 长输水压力管小口径（300mm直径以上）流速Vgj3
        /// </summary>
        /// <param name="VGJ"></param>
        /// <param name="type">T-300以上　F-300以下</param>
        /// <returns></returns>
        public static string getVGJ3(double VGJ, bool type)
        {
            if (type)
            {
                if (VGJ >= 1.5 && VGJ <= 3)
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
                if (VGJ >= 1 && VGJ <= 2)
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
        /// 机油和燃油管流速Vgj4
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ4(double VGJ)
        {
            if (VGJ >= 0.2 && VGJ <= 1.2)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        /// 汽油或其他燃油管流速Vgj5
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>经济/非经济</returns>
        public static string getVGJ5(double VGJ)
        {
            if (VGJ >= 1 && VGJ <= 3)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }
        /// <summary>
        /// 泵液体输送管路泄漏率λlF
        /// </summary>
        /// <param name="QZ">泵液体输送管路总容积流量QZ</param>
        /// <param name="QI">泵液体输送管路总容积流量Qˊ</param>
        /// <returns></returns>
        public static double getLIF(double QZ, double QI)
        {
            return (QZ - QI) / QZ;
        }
        /// <summary>
        /// 泵液体输送管路泄漏率λlF 诊断项
        /// </summary>
        /// <param name="QZ">泵液体输送管路总容积流量QZ</param>
        /// <param name="QI">泵液体输送管路总容积流量Qˊ</param>
        /// <returns></returns>
        public static string getLIF_Judge(double QZ, double QI)
        {
            double LIF = getLIF(QZ, QI);
            if (LIF < 0.5)
            {
                return "节能";
            }
            else if (LIF >= 0.5 && LIF < 1)
            {
                return "合理";
            }
            else if (LIF >= 0.1)
            {
                return "不节能";
            }
            else
            {
                return "参数有误，无法测算";
            }
        }
        /// <summary>
        /// 泵系统能耗WSRB
        /// </summary>
        /// <param name="PRB">泵输入功率PRB</param>
        /// <param name="TIME">测算时长T</param>
        /// <returns></returns>
        public static double getWSRB(double PRB, double TIME)
        {
            return PRB * TIME;
        }
        /// <summary>
        /// 泵输送千吨能耗Eb
        /// </summary>
        /// <param name="WSRB">泵系统能耗WSRB</param>
        /// <param name="PB">液体密度ρB</param>
        /// <param name="QV">泵输出流量Qv</param>
        /// <param name="H">泵扬H程</param>
        /// <param name="Time">测算时长T</param>
        /// <returns></returns>
        public static decimal getEB(double WSRB, double PB, double QV, double H, double Time)

        {
            double eb = (1000.0 * WSRB) / (3.6 * PB * 9.807 * QV * H * Time);
            decimal ea = (decimal)eb;
            //String str = ea.ToString("0.00000000");
            //Console.WriteLine(str);
            //Console.WriteLine(ea);
            return ea;
            //return Math.Round(eb,4,MidpointRounding.AwayFromZero);
        }
        /// <summary>
        /// 泵输送千吨能耗Eb 诊断项
        /// </summary>
        /// <param name="WSRB">泵系统能耗WSRB</param>
        /// <param name="PB">液体密度ρB</param>
        /// <param name="QV">泵输出流量Qv</param>
        /// <param name="H">泵扬H程</param>
        /// <param name="Time">测算时长T</param>
        /// <returns></returns>
        public static String getEB_Judge(double WSRB, double PB, double QV, double H, double Time)
        {
            decimal EB;
            EB = getEB(WSRB, PB, QV, H, Time);
            // Console.WriteLine(EB);

            if ((double)EB < 0.28)
            {
                return "节能";
            }
            else if ((double)EB >= 0.28)
            {
                return "不节能";

            }
            else
            {
                return "合理";
            }
            return "";
        }

        /// <summary>
        /// 泵机组运行效率比RJ
        /// </summary>
        /// <param name="NJ">泵机组运行效率ηJ（ηB）</param>
        /// <param name="PYE">泵（机组）额定输出功率PYe</param>
        /// <param name="PJE">泵（机组）额定输入功率PJe</param>
        /// <returns></returns>
        public static double getRJ(double NB, double PYE, double PJE)
        {

            return NB / (PYE / PJE);
        }
        /// <summary>
        /// 泵机组运行效率比RJ
        /// </summary>
        /// <param name="NJ">泵机组运行效率ηJ（ηB）</param>
        /// <param name="PYE">泵（机组）额定输出功率PYe</param>
        /// <param name="PJE">泵（机组）额定输入功率PJe</param>
        /// <returns></returns>
        public static string getRJ_Judge(double NB, double PYE, double PJE)
        {
            double RJ;

            RJ = getRJ(NB, PYE, PJE);
            //Console.WriteLine(RJ);
            if (RJ > 0.85)
            {
                return "节能";
            }
            else if (RJ <= 0.85 && RJ >= 0.70)
            {
                return "合理";

            }
            else if (RJ < 0.70)
            {
                return "不节能";
            }

            else
            {
                return "测算错误";
            }
        }
    }
}
