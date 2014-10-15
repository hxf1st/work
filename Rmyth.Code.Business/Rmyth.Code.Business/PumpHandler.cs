using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace JiDian.Business
{
    public class PumpHandler : SystemDevice
    {

        /// <summary>
        /// Һ���ܶȦ�B
        /// </summary>
        /// <param name="PA">����ѹ��Pa</param>
        /// <param name="T">�¶�t</param>
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
        /// ���������PYB
        /// </summary>
        /// <param name="PB">������Һ���ܶȦ�B</param>
        /// <param name="g">�������ٶ�g</param>
        /// <param name="QV">���������Qv</param>
        /// <param name="H">�����H</param>
        /// <returns></returns>
        public static double getPumpOutputpower(double PB, double QV, double H)
        {
            return PB * 9.807 * QV * H * (Math.Pow(10, -3));
        }

        ///// <summary>
        ///// �豸/����������PYJ
        ///// </summary>
        ///// <param name="FrontPower">ǰһ�������</param>
        ///// <param name="FrontEfficiency">ǰһ���Ч��</param>
        ///// <returns></returns>
        //public static double getOutpurtPower_1(double FrontPower, double FrontEfficiency)
        //{
        //    return FrontPower * FrontEfficiency;
        //}


        ///// <summary>
        ///// �豸/����������PYJ
        ///// </summary>
        ///// <param name="CurrentEfficiency">��ǰ���Ч��</param>
        ///// <param name="RearPower">��һ�������</param>
        ///// <returns></returns>
        //public static double getOutputPower_2(double CurrentEfficiency, double RearPower)
        //{
        //    return RearPower / CurrentEfficiency;
        //}
        ///// <summary>
        ///// ���/��������Ч�ʦ�B
        ///// </summary>
        ///// <param name="CurrentOutputPower">��ǰ����������</param>
        ///// <param name="FrontOutputPower">ǰһ����������</param>
        ///// <returns></returns>
        //public static double getEfficiency(double CurrentOutputPower, double FrontOutputPower)
        //{

        //    return CurrentOutputPower / FrontOutputPower;
        //}


        /// <summary>
        /// Һ�����͹�·��������Vgj
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ1(double VGJ)
        {
            if (VGJ <= 2)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }

        /// <summary>
        /// Һ�����͹�·��������Vgj
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ2(double VGJ)
        {
            if (VGJ >= 2 && VGJ <= 3)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }

        /// <summary>
        /// ����ˮѹ����С�ھ���300mmֱ�����£�����Vgj3
        /// ����ˮѹ����С�ھ���300mmֱ�����ϣ�����Vgj3
        /// </summary>
        /// <param name="VGJ"></param>
        /// <param name="type">T-300���ϡ�F-300����</param>
        /// <returns></returns>
        public static string getVGJ3(double VGJ, bool type)
        {
            if (type)
            {
                if (VGJ >= 1.5 && VGJ <= 3)
                {
                    return "����";
                }
                else
                {
                    return "�Ǿ���";
                }

            }
            else
            {
                if (VGJ >= 1 && VGJ <= 2)
                {
                    return "����";
                }
                else
                {
                    return "�Ǿ���";
                }
            }

        }

        /// <summary>
        /// ���ͺ�ȼ�͹�����Vgj4
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ4(double VGJ)
        {
            if (VGJ >= 0.2 && VGJ <= 1.2)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        /// ���ͻ�����ȼ�͹�����Vgj5
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ5(double VGJ)
        {
            if (VGJ >= 1 && VGJ <= 3)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        /// ��Һ�����͹�·й©�ʦ�lF
        /// </summary>
        /// <param name="QZ">��Һ�����͹�·���ݻ�����QZ</param>
        /// <param name="QI">��Һ�����͹�·���ݻ�����Q�@</param>
        /// <returns></returns>
        public static double getLIF(double QZ, double QI)
        {
            return (QZ - QI) / QZ;
        }
        /// <summary>
        /// ��Һ�����͹�·й©�ʦ�lF �����
        /// </summary>
        /// <param name="QZ">��Һ�����͹�·���ݻ�����QZ</param>
        /// <param name="QI">��Һ�����͹�·���ݻ�����Q�@</param>
        /// <returns></returns>
        public static string getLIF_Judge(double QZ, double QI)
        {
            double LIF = getLIF(QZ, QI);
            if (LIF < 0.5)
            {
                return "����";
            }
            else if (LIF >= 0.5 && LIF < 1)
            {
                return "����";
            }
            else if (LIF >= 0.1)
            {
                return "������";
            }
            else
            {
                return "���������޷�����";
            }
        }
        /// <summary>
        /// ��ϵͳ�ܺ�WSRB
        /// </summary>
        /// <param name="PRB">�����빦��PRB</param>
        /// <param name="TIME">����ʱ��T</param>
        /// <returns></returns>
        public static double getWSRB(double PRB, double TIME)
        {
            return PRB * TIME;
        }
        /// <summary>
        /// ������ǧ���ܺ�Eb
        /// </summary>
        /// <param name="WSRB">��ϵͳ�ܺ�WSRB</param>
        /// <param name="PB">Һ���ܶȦ�B</param>
        /// <param name="QV">���������Qv</param>
        /// <param name="H">����H��</param>
        /// <param name="Time">����ʱ��T</param>
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
        /// ������ǧ���ܺ�Eb �����
        /// </summary>
        /// <param name="WSRB">��ϵͳ�ܺ�WSRB</param>
        /// <param name="PB">Һ���ܶȦ�B</param>
        /// <param name="QV">���������Qv</param>
        /// <param name="H">����H��</param>
        /// <param name="Time">����ʱ��T</param>
        /// <returns></returns>
        public static String getEB_Judge(double WSRB, double PB, double QV, double H, double Time)
        {
            decimal EB;
            EB = getEB(WSRB, PB, QV, H, Time);
            // Console.WriteLine(EB);

            if ((double)EB < 0.28)
            {
                return "����";
            }
            else if ((double)EB >= 0.28)
            {
                return "������";

            }
            else
            {
                return "����";
            }
            return "";
        }

        /// <summary>
        /// �û�������Ч�ʱ�RJ
        /// </summary>
        /// <param name="NJ">�û�������Ч�ʦ�J����B��</param>
        /// <param name="PYE">�ã����飩��������PYe</param>
        /// <param name="PJE">�ã����飩����빦��PJe</param>
        /// <returns></returns>
        public static double getRJ(double NB, double PYE, double PJE)
        {

            return NB / (PYE / PJE);
        }
        /// <summary>
        /// �û�������Ч�ʱ�RJ
        /// </summary>
        /// <param name="NJ">�û�������Ч�ʦ�J����B��</param>
        /// <param name="PYE">�ã����飩��������PYe</param>
        /// <param name="PJE">�ã����飩����빦��PJe</param>
        /// <returns></returns>
        public static string getRJ_Judge(double NB, double PYE, double PJE)
        {
            double RJ;

            RJ = getRJ(NB, PYE, PJE);
            //Console.WriteLine(RJ);
            if (RJ > 0.85)
            {
                return "����";
            }
            else if (RJ <= 0.85 && RJ >= 0.70)
            {
                return "����";

            }
            else if (RJ < 0.70)
            {
                return "������";
            }

            else
            {
                return "�������";
            }
        }
    }
}
