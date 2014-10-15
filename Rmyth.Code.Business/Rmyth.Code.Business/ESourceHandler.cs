using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public class ESourceHandler : SystemDevice
    {




        ///// <summary>
        ///// ϵͳ���빦��PSR
        ///// </summary>
        ///// <param name="RearPower">��һ�������</param>
        ///// <param name="CurrentEfficiency">��ǰ�������</param>
        ///// <returns>ϵͳ���빦��PSR</returns>

        //public static double getInputPower(double RearPower, double CurrentEfficiency)
        //{


        //    return RearPower / CurrentEfficiency;

        //}

        /// <summary>
        /// ��Դ��ѹƫ�U
        /// </summary>
        /// <param name="U">��Դ��ѹU</param>
        /// <param name="UE">���Դ��ѹUE</param>
        /// <returns>��Դ��ѹƫ�U</returns>
        public static double getAU(double U, double UE)
        {

            double VoltageDeviation = U - UE;

            return VoltageDeviation;

        }
        /// <summary>
        /// ��Դ��ѹƫ�U ��Ͻ��
        /// </summary>
        /// <param name="U">��Դ��ѹU</param>
        /// <param name="UE">���Դ��ѹUE</param>
        /// <returns>��Դ��ѹƫ�U</returns>
        public static string getAU_Judge(double U, double UE)
        {

            double VoltageDeviation = U - UE;
            // Console.WriteLine(VoltageDeviation);
            Console.WriteLine("AU/UE :" + VoltageDeviation / UE);

            if (VoltageDeviation / UE >= -0.05 && VoltageDeviation / UE <= 0.05)
            {
                return "����";
            }
            else if (VoltageDeviation / UE < -0.05 || VoltageDeviation / UE > 0.05)
            {
                return "������";
            }
            else
            {
                return "����";
            }

        }

        /// <summary>
        /// �������ʵ��A0
        /// </summary>
        /// <param name="UA">A���ѹ�ķ�ֵUA</param>
        /// <param name="UB">B���ѹ�ķ�ֵUB</param>
        /// <param name="UC">C���ѹ�ķ�ֵUC</param>
        /// <param name="QA">A���ѹ����λ�ǧ�A</param>
        /// <param name="QB">B���ѹ����λ�ǧ�B</param>
        /// <param name="QC">C���ѹ����λ�ǧ�C</param>
        /// <returns>�������ʵ��A0</returns>
        public static double getA0(double UA, double UB, double UC, double QA, double QB, double QC)
        {
            double A0 = 1.0 / 3.0 * (UA * Math.Cos(Math.PI * QA / 180.0) +
                      UB * Math.Cos(Math.PI * QB / 180.0) +
                      UC * Math.Cos(Math.PI * QC / 180.0));
            return Math.Round(A0, 2, MidpointRounding.AwayFromZero);
        }


        /// <summary>
        /// �������ʵ��A1
        /// </summary>
        /// <param name="UA">A���ѹ�ķ�ֵUA</param>
        /// <param name="UB">B���ѹ�ķ�ֵUB</param>
        /// <param name="UC">C���ѹ�ķ�ֵUC</param>
        /// <param name="QA">A���ѹ����λ�ǧ�A</param>
        /// <param name="QB">B���ѹ����λ�ǧ�B</param>
        /// <param name="QC">C���ѹ����λ�ǧ�C</param>
        /// <returns>�������ʵ��A1</returns>
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
        /// �������ʵ��A2
        /// </summary>
        /// <param name="UA">A���ѹ�ķ�ֵUA</param>
        /// <param name="UB">B���ѹ�ķ�ֵUB</param>
        /// <param name="UC">C���ѹ�ķ�ֵUC</param>
        /// <param name="QA">A���ѹ����λ�ǧ�A</param>
        /// <param name="QB">B���ѹ����λ�ǧ�B</param>
        /// <param name="QC">C���ѹ����λ�ǧ�C</param>
        /// <returns>�������ʵ��A2</returns>
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
        /// ��������鲿B0
        /// </summary>
        /// <param name="UA">A���ѹ�ķ�ֵUA</param>
        /// <param name="UB">B���ѹ�ķ�ֵUB</param>
        /// <param name="UC">C���ѹ�ķ�ֵUC</param>
        /// <param name="QA">A���ѹ����λ�ǧ�A</param>
        /// <param name="QB">B���ѹ����λ�ǧ�B</param>
        /// <param name="QC">C���ѹ����λ�ǧ�C</param>
        /// <returns>��������鲿B0</returns>
        public static double getB0(double UA, double UB, double UC, double QA, double QB, double QC)
        {

            double B0 = 1.0 / 3.0 * (UA * Math.Sin(Math.PI * QA / 180.0) + (UB * Math.Sin(Math.PI * QB / 180.0)) + (UC * Math.Sin(Math.PI * QC / 180.0)));
            return Math.Round(B0, 2, MidpointRounding.AwayFromZero);
        }
        /// <summary>
        /// ��������鲿B1
        /// </summary>
        /// <param name="UA">A���ѹ�ķ�ֵUA</param>
        /// <param name="UB">B���ѹ�ķ�ֵUB</param>
        /// <param name="UC">C���ѹ�ķ�ֵUC</param>
        /// <param name="QA">A���ѹ����λ�ǧ�A</param>
        /// <param name="QB">B���ѹ����λ�ǧ�B</param>
        /// <param name="QC">C���ѹ����λ�ǧ�C</param>
        /// <returns>��������鲿B1</returns>

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
        /// ��������鲿B2
        /// </summary>
        /// <param name="UA">A���ѹ�ķ�ֵUA</param>
        /// <param name="UB">B���ѹ�ķ�ֵUB</param>
        /// <param name="UC">C���ѹ�ķ�ֵUC</param>
        /// <param name="QA">A���ѹ����λ�ǧ�A</param>
        /// <param name="QB">B���ѹ����λ�ǧ�B</param>
        /// <param name="QC">C���ѹ����λ�ǧ�C</param>
        /// <returns>��������鲿B2</returns>

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
        /// ��ѹ�������U0
        /// </summary>
        /// <param name="UA">A���ѹ�ķ�ֵUA</param>
        /// <param name="UB">B���ѹ�ķ�ֵUB</param>
        /// <param name="UC">C���ѹ�ķ�ֵUC</param>
        /// <param name="QA">A���ѹ����λ�ǧ�A</param>
        /// <param name="QB">B���ѹ����λ�ǧ�B</param>
        /// <param name="QC">C���ѹ����λ�ǧ�C</param>
        /// <returns>��ѹ�������U0</returns>
        public static double getU0(double UA, double UB, double UC, double QA, double QB, double QC)
        {
            double U0, A0, B0;
            A0 = getA0(UA, UB, UC, QA, QB, QC);
            B0 = getB0(UA, UB, UC, QA, QB, QC);
            U0 = Math.Sqrt(Math.Pow(A0, 2) + Math.Pow(B0, 2));

            return Math.Round(U0, 2, MidpointRounding.AwayFromZero);

        }
        /// <summary>
        /// ��ѹ�������U0
        /// </summary>
        /// <param name="A0">�������ʵ��A0</param>
        /// <param name="B0">��������鲿B0</param>
        /// <returns>��ѹ�������U0</returns>
        public static double getU0(double A0, double B0)
        {
            double U0;

            U0 = Math.Sqrt(Math.Pow(A0, 2) + Math.Pow(B0, 2));

            return U0;

        }

        /// <summary>
        /// ��ѹ�������U1
        /// </summary>
        /// <param name="UA">A���ѹ�ķ�ֵUA</param>
        /// <param name="UB">B���ѹ�ķ�ֵUB</param>
        /// <param name="UC">C���ѹ�ķ�ֵUC</param>
        /// <param name="QA">A���ѹ����λ�ǧ�A</param>
        /// <param name="QB">B���ѹ����λ�ǧ�B</param>
        /// <param name="QC">C���ѹ����λ�ǧ�C</param>
        /// <returns>��ѹ�������U1</returns>
        public static double getU1(double UA, double UB, double UC, double QA, double QB, double QC)
        {
            double U1, A1, B1;
            A1 = getA1(UA, UB, UC, QA, QB, QC);
            B1 = getB1(UA, UB, UC, QA, QB, QC);
            U1 = Math.Sqrt(Math.Pow(A1, 2) + Math.Pow(B1, 2));

            return Math.Round(U1, 2, MidpointRounding.AwayFromZero);

        }
        /// <summary>
        /// ��ѹ�������U1
        /// </summary>
        /// <param name="A0">�������ʵ��A1</param>
        /// <param name="B0">��������鲿B1</param>
        /// <returns>��ѹ�������U0</returns>
        public static double getU1(double A1, double B1)
        {
            double U1;
            U1 = Math.Sqrt(Math.Pow(A1, 2) + Math.Pow(B1, 2));
            return U1;

        }


        /// <summary>
        /// ��ѹ�������U2
        /// </summary>
        /// <param name="UA">A���ѹ�ķ�ֵUA</param>
        /// <param name="UB">B���ѹ�ķ�ֵUB</param>
        /// <param name="UC">C���ѹ�ķ�ֵUC</param>
        /// <param name="QA">A���ѹ����λ�ǧ�A</param>
        /// <param name="QB">B���ѹ����λ�ǧ�B</param>
        /// <param name="QC">C���ѹ����λ�ǧ�C</param>
        /// <returns>��ѹ�������U2</returns>
        public static double getU2(double UA, double UB, double UC, double QA, double QB, double QC)
        {
            double U2, A2, B2;
            A2 = getA2(UA, UB, UC, QA, QB, QC);
            B2 = getB2(UA, UB, UC, QA, QB, QC);
            U2 = Math.Sqrt(Math.Pow(A2, 2) + Math.Pow(B2, 2));

            return Math.Round(U2, 2, MidpointRounding.AwayFromZero);

        }
        /// <summary>
        /// ��ѹ�������U2
        /// </summary>
        /// <param name="A0">�������ʵ��A2</param>
        /// <param name="B0">��������鲿B2</param>
        /// <returns>��ѹ�������U2</returns>
        public static double getU2(double A2, double B2)
        {
            double U2;
            U2 = Math.Sqrt(Math.Pow(A2, 2) + Math.Pow(B2, 2));
            return U2;

        }



        /// <summary>
        /// ��Դ���಻ƽ���
        /// </summary>
        /// <param name="UA">A���ѹ�ķ�ֵUA</param>
        /// <param name="UB">B���ѹ�ķ�ֵUB</param>
        /// <param name="UC">C���ѹ�ķ�ֵUC</param>
        /// <param name="QA">A���ѹ����λ�ǧ�A</param>
        /// <param name="QB">B���ѹ����λ�ǧ�B</param>
        /// <param name="QC">C���ѹ����λ�ǧ�C</param>
        /// <param name="UpTime">1����������/2����������(10������)</param>
        /// <returns>����/������</returns>


        public static String getThreephaseUnbalanced(double UA, double UB, double UC, double QA, double QB, double QC, int UpTime)
        {
            //if (UA == 0 || UB == 0 || UC == 0 || QA == 0 || QB == 0 || QC == 0)
            //{
            //    return "������������޷�����";
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
                    return "����";
                }
                else if ((U2 / U1) > 0.01 || (U0 / U1) > 0.01)
                {
                    return "������";

                }
                else
                {
                    return "��������������";
                }
            }
            else if (UpTime == 2)
            {
                if ((U2 / U1) <= 0.015 && (U0 / U1) <= 0.01)
                {
                    return "����";
                }
                else if ((U2 / U1) > 0.015 || (U0 / U1) > 0.01)
                {
                    return "������";

                }
                else
                {
                    return "��������������";
                }
            }
            else
            {
                return "��ѡ����ȷ��ϵͳ����ʱ������";
            }

        }

        public static double getPXC(double IXC, double UXC)
        {
            double PXC = IXC * UXC;
            return PXC;

        }

        /// <summary>
        /// �����Ӵ������ֹ���PXC �����
        /// </summary>
        /// <param name="IXC">���ֵ���IXC</param>
        /// <param name="UXC">���ֵ�ѹUXC</param>
        /// <param name="IE">���ֵ�ѹUXC</param>
        /// <returns>����/����/������</returns>

        public static string getPXC_Judge(double IXC, double UXC, int IE)
        {

            double PXC = getPXC(IXC, UXC);

            if (IE == 1)
            {
                if (PXC <= 5.0)
                {
                    return "����";
                }
                else if (PXC > 5.0 && PXC <= 8.3)
                {
                    return "����";
                }
                else
                {
                    return "������";
                }

            }
            else if (IE == 2)
            {
                if (PXC <= 5.1)
                {
                    return "����";
                }
                else if (PXC > 5.1 && PXC <= 8.5)
                {
                    return "����";
                }
                else
                {
                    return "������";
                }
            }
            else if (IE == 3)
            {
                if (PXC <= 8.3)
                {
                    return "����";
                }
                else if (PXC > 8.3 && PXC <= 13.9)
                {
                    return "����";
                }
                else
                {
                    return "������";
                }
            }
            else if (IE == 4)
            {
                if (PXC <= 11.4)
                {
                    return "����";
                }
                else if (PXC > 11.4 && PXC <= 19.0)
                {
                    return "����";
                }
                else
                {
                    return "������";
                }
            }
            else if (IE == 5)
            {
                if (PXC <= 34.2)
                {
                    return "����";
                }
                else if (PXC > 34.2 && PXC <= 57.0)
                {
                    return "����";
                }
                else
                {
                    return "������";
                }
            }
            else if (IE == 6)
            {
                if (PXC <= 36.6)
                {
                    return "����";
                }
                else if (PXC > 36.6 && PXC <= 61.0)
                {
                    return "����";
                }
                else
                {
                    return "������";
                }
            }
            else if (IE == 7)
            {
                if (PXC <= 51.3)
                {
                    return "����";
                }
                else if (PXC > 51.3 && PXC <= 85.5)
                {
                    return "����";
                }
                else
                {
                    return "������";
                }
            }
            else if (IE == 8)
            {
                if (PXC <= 91.2)
                {
                    return "����";
                }
                else if (PXC > 91.2 && PXC <= 152.0)
                {
                    return "����";
                }
                else
                {
                    return "������";
                }
            }
            else if (IE == 9)
            {
                if (PXC <= 150.0)
                {
                    return "����";
                }
                else if (PXC > 150.0 && PXC <= 250.0)
                {
                    return "����";
                }
                else
                {
                    return "������";
                }
            }
            else if (IE == 10)
            {
                if (PXC <= 150.0)
                {
                    return "����";
                }
                else if (PXC > 150.0 && PXC <= 250.0)
                {
                    return "����";
                }
                else
                {
                    return "������";
                }
            }
            else
            {
                return "���������޷�����";
            }
        }
    }




}
