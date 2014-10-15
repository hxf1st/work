using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public class ESourceHandler : SystemDevice
    {




        ///// <summary>
        ///// 系统输入功率PSR
        ///// </summary>
        ///// <param name="RearPower">后一组件功率</param>
        ///// <param name="CurrentEfficiency">当前组件功率</param>
        ///// <returns>系统输入功率PSR</returns>

        //public static double getInputPower(double RearPower, double CurrentEfficiency)
        //{


        //    return RearPower / CurrentEfficiency;

        //}

        /// <summary>
        /// 电源电压偏差ΔU
        /// </summary>
        /// <param name="U">电源电压U</param>
        /// <param name="UE">额定电源电压UE</param>
        /// <returns>电源电压偏差ΔU</returns>
        public static double getAU(double U, double UE)
        {

            double VoltageDeviation = U - UE;

            return VoltageDeviation;

        }
        /// <summary>
        /// 电源电压偏差ΔU 诊断结果
        /// </summary>
        /// <param name="U">电源电压U</param>
        /// <param name="UE">额定电源电压UE</param>
        /// <returns>电源电压偏差ΔU</returns>
        public static string getAU_Judge(double U, double UE)
        {

            double VoltageDeviation = U - UE;
            // Console.WriteLine(VoltageDeviation);
            Console.WriteLine("AU/UE :" + VoltageDeviation / UE);

            if (VoltageDeviation / UE >= -0.05 && VoltageDeviation / UE <= 0.05)
            {
                return "节能";
            }
            else if (VoltageDeviation / UE < -0.05 || VoltageDeviation / UE > 0.05)
            {
                return "不节能";
            }
            else
            {
                return "合理";
            }

        }

        /// <summary>
        /// 零序分量实部A0
        /// </summary>
        /// <param name="UA">A相电压的幅值UA</param>
        /// <param name="UB">B相电压的幅值UB</param>
        /// <param name="UC">C相电压的幅值UC</param>
        /// <param name="QA">A相电压的相位角ФA</param>
        /// <param name="QB">B相电压的相位角ФB</param>
        /// <param name="QC">C相电压的相位角ФC</param>
        /// <returns>零序分量实部A0</returns>
        public static double getA0(double UA, double UB, double UC, double QA, double QB, double QC)
        {
            double A0 = 1.0 / 3.0 * (UA * Math.Cos(Math.PI * QA / 180.0) +
                      UB * Math.Cos(Math.PI * QB / 180.0) +
                      UC * Math.Cos(Math.PI * QC / 180.0));
            return Math.Round(A0, 2, MidpointRounding.AwayFromZero);
        }


        /// <summary>
        /// 正序分量实部A1
        /// </summary>
        /// <param name="UA">A相电压的幅值UA</param>
        /// <param name="UB">B相电压的幅值UB</param>
        /// <param name="UC">C相电压的幅值UC</param>
        /// <param name="QA">A相电压的相位角ФA</param>
        /// <param name="QB">B相电压的相位角ФB</param>
        /// <param name="QC">C相电压的相位角ФC</param>
        /// <returns>正序分量实部A1</returns>
        /// 
        /// 
        public static double getA1(double UA, double UB, double UC, double QA, double QB, double QC)
        {

            double A1, a, b, c, d;
            a = 1.0 / 3.0;
            b = UA * Math.Cos(Math.PI * QA / 180.0);
            c = UB * ((-1.0 / 2.0) * Math.Cos(Math.PI * QB / 180.0) - (Math.Sqrt(3.0) / 2.0) * Math.Sin(Math.PI * QB / 180.0));
            d = UC * ((-1.0 / 2.0) * Math.Cos(Math.PI * QC / 180.0) + (Math.Sqrt(3.0) / 2.0) * Math.Sin(Math.PI * QC / 180.0));
            A1 = a * (b + c + d);
            return Math.Round(A1, 2, MidpointRounding.AwayFromZero);

        }
       

        /// <summary>
        /// 正序分量实部A2
        /// </summary>
        /// <param name="UA">A相电压的幅值UA</param>
        /// <param name="UB">B相电压的幅值UB</param>
        /// <param name="UC">C相电压的幅值UC</param>
        /// <param name="QA">A相电压的相位角ФA</param>
        /// <param name="QB">B相电压的相位角ФB</param>
        /// <param name="QC">C相电压的相位角ФC</param>
        /// <returns>正序分量实部A2</returns>
        /// 
        /// 
        public static double getA2(double UA, double UB, double UC, double QA, double QB, double QC)
        {

            double A2, a, b, c, d;
            a = 1.0 / 3.0;
            b = UA * Math.Cos(Math.PI * QA / 180.0);
            c = UB * ((-1.0 / 2.0) * Math.Cos(Math.PI * QB / 180.0) + (Math.Sqrt(3) / 2.0) * Math.Sin(Math.PI * QB / 180.0));
            d = UC * ((-1.0 / 2.0) * Math.Cos(Math.PI * QC / 180.0) - (Math.Sqrt(3) / 2.0) * Math.Sin(Math.PI * QC / 180.0));
            A2 = a * (b + c + d);
            return Math.Round(A2,2, MidpointRounding.AwayFromZero);

        }
        /// <summary>
        /// 零序分量虚部B0
        /// </summary>
        /// <param name="UA">A相电压的幅值UA</param>
        /// <param name="UB">B相电压的幅值UB</param>
        /// <param name="UC">C相电压的幅值UC</param>
        /// <param name="QA">A相电压的相位角ФA</param>
        /// <param name="QB">B相电压的相位角ФB</param>
        /// <param name="QC">C相电压的相位角ФC</param>
        /// <returns>零序分量虚部B0</returns>
        public static double getB0(double UA, double UB, double UC, double QA, double QB, double QC)
        {

            double B0 = 1.0 / 3.0 * (UA * Math.Sin(Math.PI * QA / 180.0) + (UB * Math.Sin(Math.PI * QB / 180.0)) + (UC * Math.Sin(Math.PI * QC / 180.0)));
            return Math.Round(B0, 2, MidpointRounding.AwayFromZero);
        }
        /// <summary>
        /// 正序分量虚部B1
        /// </summary>
        /// <param name="UA">A相电压的幅值UA</param>
        /// <param name="UB">B相电压的幅值UB</param>
        /// <param name="UC">C相电压的幅值UC</param>
        /// <param name="QA">A相电压的相位角ФA</param>
        /// <param name="QB">B相电压的相位角ФB</param>
        /// <param name="QC">C相电压的相位角ФC</param>
        /// <returns>正序分量虚部B1</returns>

        public static double getB1(double UA, double UB, double UC, double QA, double QB, double QC)
        {

            double B1, a, b, c, d;
            a = 1.0 / 3.0;
            a = 1.0 / 3.0;
            b = UA * Math.Sin((Math.PI * QA / 180.0));
            c = UB * ((-1.0 / 2.0) * Math.Sin(Math.PI * QB / 180.0) + (Math.Sqrt(3) / 2.0) * Math.Cos(Math.PI * QB / 180.0));
            d = UC * ((-1.0 / 2.0) * Math.Sin(Math.PI * QC / 180.0) - (Math.Sqrt(3) / 2.0) * Math.Cos(Math.PI * QC / 180.0));
            B1 = a * (b + c + d);
            return Math.Round(B1, 2, MidpointRounding.AwayFromZero);

        }
        /// <summary>
        /// 负序分量虚部B2
        /// </summary>
        /// <param name="UA">A相电压的幅值UA</param>
        /// <param name="UB">B相电压的幅值UB</param>
        /// <param name="UC">C相电压的幅值UC</param>
        /// <param name="QA">A相电压的相位角ФA</param>
        /// <param name="QB">B相电压的相位角ФB</param>
        /// <param name="QC">C相电压的相位角ФC</param>
        /// <returns>负序分量虚部B2</returns>

        public static double getB2(double UA, double UB, double UC, double QA, double QB, double QC)
        {

            double B2, a, b, c, d;
            a = 1.0 / 3.0;
            b = UA * Math.Sin((Math.PI * QA / 180.0));
            c = UB * ((1.0 / 2.0) * Math.Sin(Math.PI * QB / 180.0) + (Math.Sqrt(3) / 2.0) * Math.Cos(Math.PI * QB / 180.0));
            d = UC * ((-1.0 / 2.0) * Math.Sin(Math.PI * QC / 180.0) + (Math.Sqrt(3) / 2.0) * Math.Cos(Math.PI * QC / 180.0));

            B2 = a * (b - c + d);
            return Math.Round(B2, 2, MidpointRounding.AwayFromZero);

        }

        public static void test()
        {
            //Console.WriteLine(Math.Sqrt(3.0) / 2.0);

            double UA = 220, UB = 220, UC = 180, QA = 0, QB = -120, QC = -240;
            double B2, a, b, c, d;
            a = 1.0 / 3.0;
            b = UA * Math.Sin((Math.PI * QA / 180.0));
            c = UB * ((1.0 / 2.0) * Math.Sin(Math.PI * QB / 180.0) + (Math.Sqrt(3) / 2.0) * Math.Cos(Math.PI * QB / 180.0));
            d = UC * ((-1.0 / 2.0) * Math.Sin(Math.PI * QC / 180.0) + (Math.Sqrt(3) / 2.0) * Math.Cos(Math.PI * QC / 180.0));

            B2 = a * (b - c + d);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(B2);


        }


        /// <summary>
        /// 电压零序分量U0
        /// </summary>
        /// <param name="UA">A相电压的幅值UA</param>
        /// <param name="UB">B相电压的幅值UB</param>
        /// <param name="UC">C相电压的幅值UC</param>
        /// <param name="QA">A相电压的相位角ФA</param>
        /// <param name="QB">B相电压的相位角ФB</param>
        /// <param name="QC">C相电压的相位角ФC</param>
        /// <returns>电压零序分量U0</returns>
        public static double getU0(double UA, double UB, double UC, double QA, double QB, double QC)
        {
            double U0, A0, B0;
            A0 = getA0(UA, UB, UC, QA, QB, QC);
            B0 = getB0(UA, UB, UC, QA, QB, QC);
            U0 = Math.Sqrt(Math.Pow(A0, 2) + Math.Pow(B0, 2));

            return Math.Round(U0, 2, MidpointRounding.AwayFromZero);

        }
        /// <summary>
        /// 电压零序分量U0
        /// </summary>
        /// <param name="A0">零序分量实部A0</param>
        /// <param name="B0">零序分量虚部B0</param>
        /// <returns>电压零序分量U0</returns>
        public static double getU0(double A0, double B0)
        {
            double U0;

            U0 = Math.Sqrt(Math.Pow(A0, 2) + Math.Pow(B0, 2));

            return U0;

        }

        /// <summary>
        /// 电压正序分量U1
        /// </summary>
        /// <param name="UA">A相电压的幅值UA</param>
        /// <param name="UB">B相电压的幅值UB</param>
        /// <param name="UC">C相电压的幅值UC</param>
        /// <param name="QA">A相电压的相位角ФA</param>
        /// <param name="QB">B相电压的相位角ФB</param>
        /// <param name="QC">C相电压的相位角ФC</param>
        /// <returns>电压正序分量U1</returns>
        public static double getU1(double UA, double UB, double UC, double QA, double QB, double QC)
        {
            double U1, A1, B1;
            A1 = getA1(UA, UB, UC, QA, QB, QC);
            B1 = getB1(UA, UB, UC, QA, QB, QC);
            U1 = Math.Sqrt(Math.Pow(A1, 2) + Math.Pow(B1, 2));

            return Math.Round(U1, 2, MidpointRounding.AwayFromZero);

        }
        /// <summary>
        /// 电压正序分量U1
        /// </summary>
        /// <param name="A0">正序分量实部A1</param>
        /// <param name="B0">正序分量虚部B1</param>
        /// <returns>电压正序分量U0</returns>
        public static double getU1(double A1, double B1)
        {
            double U1;
            U1 = Math.Sqrt(Math.Pow(A1, 2) + Math.Pow(B1, 2));
            return U1;

        }


        /// <summary>
        /// 电压负序分量U2
        /// </summary>
        /// <param name="UA">A相电压的幅值UA</param>
        /// <param name="UB">B相电压的幅值UB</param>
        /// <param name="UC">C相电压的幅值UC</param>
        /// <param name="QA">A相电压的相位角ФA</param>
        /// <param name="QB">B相电压的相位角ФB</param>
        /// <param name="QC">C相电压的相位角ФC</param>
        /// <returns>电压负序分量U2</returns>
        public static double getU2(double UA, double UB, double UC, double QA, double QB, double QC)
        {
            double U2, A2, B2;
            A2 = getA2(UA, UB, UC, QA, QB, QC);
            B2 = getB2(UA, UB, UC, QA, QB, QC);
            U2 = Math.Sqrt(Math.Pow(A2, 2) + Math.Pow(B2, 2));

            return Math.Round(U2, 2, MidpointRounding.AwayFromZero);

        }
        /// <summary>
        /// 电压负序分量U2
        /// </summary>
        /// <param name="A0">负序分量实部A2</param>
        /// <param name="B0">负序分量虚部B2</param>
        /// <returns>电压负序分量U2</returns>
        public static double getU2(double A2, double B2)
        {
            double U2;
            U2 = Math.Sqrt(Math.Pow(A2, 2) + Math.Pow(B2, 2));
            return U2;

        }



        /// <summary>
        /// 电源三相不平衡度
        /// </summary>
        /// <param name="UA">A相电压的幅值UA</param>
        /// <param name="UB">B相电压的幅值UB</param>
        /// <param name="UC">C相电压的幅值UC</param>
        /// <param name="QA">A相电压的相位角ФA</param>
        /// <param name="QB">B相电压的相位角ФB</param>
        /// <param name="QC">C相电压的相位角ФC</param>
        /// <param name="UpTime">1－长期运行/2－短期运行(10分钟内)</param>
        /// <returns>节能/不节能</returns>


        public static String getThreephaseUnbalanced(double UA, double UB, double UC, double QA, double QB, double QC, int UpTime)
        {
            //if (UA == 0 || UB == 0 || UC == 0 || QA == 0 || QB == 0 || QC == 0)
            //{
            //    return "测算参数不足无法测算";
            //}

            double U0, U1, U2;
            U0 = getU0(UA, UB, UC, QA, QB, QC);
            U1 = getU1(UA, UB, UC, QA, QB, QC);
            U2 = getU2(UA, UB, UC, QA, QB, QC);
            Console.WriteLine(U2 / U1);
            Console.WriteLine(U0 / U1);

            if (UpTime == 1)
            {
                if ((U2 / U1) <= 0.01 && (U0 / U1) <= 0.01)
                {
                    return "节能";
                }
                else if ((U2 / U1) > 0.01 || (U0 / U1) > 0.01)
                {
                    return "不节能";

                }
                else
                {
                    return "测算错误，请检查参数";
                }
            }
            else if (UpTime == 2)
            {
                if ((U2 / U1) <= 0.015 && (U0 / U1) <= 0.01)
                {
                    return "节能";
                }
                else if ((U2 / U1) > 0.015 || (U0 / U1) > 0.01)
                {
                    return "不节能";

                }
                else
                {
                    return "测算错误，请检查参数";
                }
            }
            else
            {
                return "请选择正确的系统运行时长参数";
            }

        }

        public static double getPXC(double IXC, double UXC)
        {
            double PXC = IXC * UXC;
            return PXC;

        }

        /// <summary>
        /// 交流接触器吸持功率PXC 诊断项
        /// </summary>
        /// <param name="IXC">吸持电流IXC</param>
        /// <param name="UXC">吸持电压UXC</param>
        /// <param name="IE">吸持电压UXC</param>
        /// <returns>节能/合理/不节能</returns>

        public static string getPXC_Judge(double IXC, double UXC, int IE)
        {

            double PXC = getPXC(IXC, UXC);

            if (IE == 1)
            {
                if (PXC <= 5.0)
                {
                    return "节能";
                }
                else if (PXC > 5.0 && PXC <= 8.3)
                {
                    return "合理";
                }
                else
                {
                    return "不节能";
                }

            }
            else if (IE == 2)
            {
                if (PXC <= 5.1)
                {
                    return "节能";
                }
                else if (PXC > 5.1 && PXC <= 8.5)
                {
                    return "合理";
                }
                else
                {
                    return "不节能";
                }
            }
            else if (IE == 3)
            {
                if (PXC <= 8.3)
                {
                    return "节能";
                }
                else if (PXC > 8.3 && PXC <= 13.9)
                {
                    return "合理";
                }
                else
                {
                    return "不节能";
                }
            }
            else if (IE == 4)
            {
                if (PXC <= 11.4)
                {
                    return "节能";
                }
                else if (PXC > 11.4 && PXC <= 19.0)
                {
                    return "合理";
                }
                else
                {
                    return "不节能";
                }
            }
            else if (IE == 5)
            {
                if (PXC <= 34.2)
                {
                    return "节能";
                }
                else if (PXC > 34.2 && PXC <= 57.0)
                {
                    return "合理";
                }
                else
                {
                    return "不节能";
                }
            }
            else if (IE == 6)
            {
                if (PXC <= 36.6)
                {
                    return "节能";
                }
                else if (PXC > 36.6 && PXC <= 61.0)
                {
                    return "合理";
                }
                else
                {
                    return "不节能";
                }
            }
            else if (IE == 7)
            {
                if (PXC <= 51.3)
                {
                    return "节能";
                }
                else if (PXC > 51.3 && PXC <= 85.5)
                {
                    return "合理";
                }
                else
                {
                    return "不节能";
                }
            }
            else if (IE == 8)
            {
                if (PXC <= 91.2)
                {
                    return "节能";
                }
                else if (PXC > 91.2 && PXC <= 152.0)
                {
                    return "合理";
                }
                else
                {
                    return "不节能";
                }
            }
            else if (IE == 9)
            {
                if (PXC <= 150.0)
                {
                    return "节能";
                }
                else if (PXC > 150.0 && PXC <= 250.0)
                {
                    return "合理";
                }
                else
                {
                    return "不节能";
                }
            }
            else if (IE == 10)
            {
                if (PXC <= 150.0)
                {
                    return "节能";
                }
                else if (PXC > 150.0 && PXC <= 250.0)
                {
                    return "合理";
                }
                else
                {
                    return "不节能";
                }
            }
            else
            {
                return "参数有误，无法测算";
            }
        }
    }




}
