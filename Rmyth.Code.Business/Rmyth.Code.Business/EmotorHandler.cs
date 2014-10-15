using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public class EmotorHandler : SystemDevice
    {


        ///// <summary>
        ///// 电动机输入功率PDR
        ///// </summary>
        ///// <param name="FrontPower">前一组件输出功率(PSCK)</param>
        ///// <returns></returns>
        //public static double getInpurtPower(double FrontPower)
        //{
        //    return FrontPower;
        //}



        ///// <summary>
        ///// 电动机输出功率PYD
        ///// </summary>
        ///// <param name="FrontPower">前一组件功率</param>
        ///// <param name="FrontEfficiency">前一组件效率</param>
        ///// <returns></returns>
        //public static double getOutpurtPower_1(double FrontPower, double FrontEfficiency)
        //{
        //    return FrontPower * FrontEfficiency;
        //}


        ///// <summary>
        ///// 电动机输出功率PYD
        ///// </summary>
        ///// <param name="CurrentEfficiency">当前组件效率</param>
        ///// <param name="RearPower">后一组件功率</param>
        ///// <returns></returns>
        //public static double getOutputPower_2(double CurrentEfficiency, double RearPower)
        //{
        //    return RearPower / CurrentEfficiency;
        //}
        ///// <summary>
        ///// 效率
        ///// </summary>
        ///// <param name="CurrentOutputPower">当前组件输出功率</param>
        ///// <param name="FrontOutputPower">前一组件输出功率</param>
        ///// <returns></returns>
        //public static double getEfficiency(double CurrentOutputPower, double FrontOutputPower)
        //{

        //    return CurrentOutputPower / FrontOutputPower;
        //}

        /// <summary>
        /// 电动机额定负载时的无功功率QN
        /// </summary>
        /// <param name="PN">电动机额定功率PN</param>
        /// <param name="NN">电动机额定效率ηN</param>
        /// <param name="QN">额定运行时输入电动机相电流滞后于相电压的相角φN</param>
        /// <returns></returns>
        public static double getQN(double PN, double NN, double QN_A)
        {

            return (PN / NN) * Math.Tan((Math.PI * QN_A / 180.0));
        }



        /// <summary>
        /// 电动机空载无功功率Q0
        /// </summary>
        /// <param name="u">电源电压U</param>
        /// <param name="I0">电动机额定电流I0</param>
        /// <param name="P0">电动机空载有功损耗P0</param>
        /// <returns></returns>
        public static double getQ0(double U, double I0, double P0)
        {
            double Q0, a, b;
            a = 3.0 * Math.Pow(U, 2) * Math.Pow(I0, 2) * Math.Pow(10, -6);
            b = a - Math.Pow(P0, 2);
            Q0 = Math.Sqrt(b);
            return Q0;
        }


        /// <summary>
        /// 电动机额定负载有功损耗ΔPN
        /// </summary>
        /// <param name="NN"></param>
        /// <param name="PN"></param>
        /// <returns></returns>
        public static double getAPN(double NN, double PN)
        {

            return (1.0 / NN - 1.0) * PN;
        }

        /// <summary>
        /// 电动机运行负载系数β
        /// </summary>
        /// <param name="AP0">电动机空载时有功损耗△P0</param>
        /// <param name="APN">电动机额定负载有功损耗ΔPN</param>
        /// <param name="PN">电动机额定功率PN</param>
        /// <param name="PDR">电动机输入功率PDR</param>
        /// <returns></returns>
        public static double getB(double AP0, double APN, double PN, double PDR)
        {
            double B, a, b, c, d;

            a = (-PN / 2.0);
            b = (Math.Pow(PN, 2) / 4.0) + (APN - AP0) * (PDR - AP0);
            c = a + Math.Sqrt(b);
            d = APN - AP0;
            B = c / d;
            return B;
        }


        /// <summary>
        /// 电动机额定综合功率损耗ΔPC
        /// </summary>
        /// <param name="AP0">电动机空载时有功损耗△P0</param>
        /// <param name="APN">电动机额定负载有功损耗ΔPN</param>
        /// <param name="KQ">电动机无功经济当量KQ</param>
        /// <param name="QN">电动机空载有功损耗QN</param>
        /// <param name="Q0">电动机空载无功功率Q0</param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double getAPC(double AP0, double APN, double KQ, double QN, double Q0, double B)
        {
            double APC, a, b;
            a = AP0 + (Math.Pow(B, 2) * (APN - AP0));
            b = KQ * (Q0 + (Math.Pow(B, 2) * (QN - QN)));
            APC = a + b;
            return APC;

        }
        /// <summary>
        /// 电动机额定综合功率损耗ΔPCN
        /// </summary>
        /// <param name="KQ">电动机无功经济当量KQ</param>
        /// <param name="QN">电动机空载有功损耗QN</param>
        /// <param name="APN">电动机额定负载有功损耗ΔPN</param>
        /// <returns></returns>
        public static double getAPCN(double KQ, double QN, double APN)
        {
            return APN + KQ * QN;
        }
        /// <summary>
        /// 电动机综合效率ηCD
        /// </summary>
        /// <param name="APC">电动机额定综合功率损耗ΔPC</param>
        /// <param name="PN">电动机额定功率PN</param>
        /// <param name="B">电动机运行负载系数β</param>
        /// <returns></returns>

        public static double getNCD(double APC, double PN, double B)
        {

            return (B * PN) / (B * PN + APC);
        }

        /// <summary>
        /// 电动机额定综合效率ηCN
        /// </summary>
        /// <param name="PN">电动机额定功率PN</param>
        /// <param name="APCN">电动机额定综合功率损耗ΔPCN</param>
        /// <returns></returns>
        public static double getNCN(double PN, double APCN)
        {

            return PN / (PN + APCN);
        }

        /// <summary>
        /// 电动机综合效率比
        /// </summary>
        /// <param name="NCD">电动机综合效率ηCD</param>
        /// <param name="NCN">电动机额定综合效率ηCN</param>
        /// <returns></returns>
        public static double getMER(double NCD, double NCN)
        {
            double MER = NCN / NCD;
            return MER;
        }


        /// <summary>
        /// 电动机综合效率比诊断项
        /// </summary>
        /// <param name="NCD">电动机综合效率ηCD</param>
        /// <param name="NCN">电动机额定综合效率ηCN</param>
        /// <returns></returns>
        public static string getMER_Judge(double NCD, double NCN)
        {

            double flag = getMER(NCD, NCN);
            //Console.WriteLine(flag);
            if (flag >= 1)
            {
                return "节能";
            }
            else if (flag >= 0.6)
            {
                return "合理";
            }
            else if (flag < 0.6)
            {
                return "不节能";
            }
            else {
                return "";
            }
        }
        /// <summary>
        /// 电动机功率因数
        /// </summary>
        /// <param name="COSQ">电动机功率因数COSφ</param>
        /// <returns></returns>
        public static string getMEF_Judge(double COSQ)
        {
            if (COSQ >= 0.9)
            {
                return "节能";
            }
            else if (COSQ < 0.9)
            {
                return "不节能";
            }
            else
            {
                return "合理";
            }

        }

    }
}
