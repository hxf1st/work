using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace JiDian.Business
{
    public class DraughtFanHandler : SystemDevice
    {
        #region handler ��Ա

        public void initialize(object obj)
        {

        }

        public object loadObject()
        {
            return null;
        }

        #endregion
        /// <summary>
        /// ����������PYF
        /// </summary>
        /// <param name="QFC">�������ķ���QFC</param>
        /// <param name="PFC">������������ܶȦ�FC</param>
        /// <param name="PFR">������������ܶȦ�FR</param>
        /// <param name="PE1">������ھ�ѹpe1</param>
        /// <param name="PE2">������ھ�ѹpe2</param>
        /// <param name="V1">���������������v1</param>
        /// <param name="V2">���������������v2</param>
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
        /// �����������VGj1
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ1(double VGJ)
        {
            if (VGJ >= 7 && VGJ <= 15)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }

        /// <summary>
        /// �����������VGj2
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ2(double VGJ)
        {
            if (VGJ >= 10 && VGJ <= 30)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        /// ����ͨ��ܵ����ܵ�������/��ҵ��VGj3
        /// </summary>
        /// <param name="VGJ"></param>
        /// <param name="type">T-���ã�F����ҵ</param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ3(double VGJ, bool type)
        {
            if (type)
            {
                if (VGJ >= 3.5 && VGJ <= 4.5)
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
                if (VGJ >= 6 && VGJ <= 9)
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
        /// ����ͨ��ܵ��ֹܵ�������/��ҵ��VGj4
        /// </summary>
        /// <param name="VGJ"></param>
        /// <param name="type">T- ���ã�F����ҵ</param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ4(double VGJ, bool type)
        {
            if (type)
            {
                if (VGJ <= 3)
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
                if (VGJ >= 4 && VGJ <= 5)
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
        /// ����ͨ��ܵ������ܵ�������/��ҵ��VGj5
        /// </summary>
        /// <param name="VGJ"></param>
        /// <param name="type">T- ���ã�F����ҵ</param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ5(double VGJ, bool type)
        {
            if (type)
            {
                if (VGJ <= 2.5)
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
                if (VGJ <= 4)
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
        ///����ͨ��ܵ�����������VGj6
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ6(double VGJ)
        {
            if (VGJ >= 20 && VGJ <= 30)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        ///����ͨ���ܵ����ܵ�VGj7
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ7(double VGJ)
        {
            if (VGJ >= 20 && VGJ <= 30)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        ///�������͹���VGj8
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ8(double VGJ)
        {
            if (VGJ >= 15 && VGJ <= 30)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        ///��������ú��VGj9
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ9(double VGJ)
        {
            if (VGJ >= 20 && VGJ <= 40)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }

        /// <summary>
        ///��������������VGj10
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ10(double VGJ)
        {
            if (VGJ >= 30 && VGJ <= 40)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        ///��������ɰVGj11
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ11(double VGJ)
        {
            if (VGJ >= 30 && VGJ <= 40)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        ///���������𽺷�VGj12
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ12(double VGJ)
        {
            if (VGJ <= 15)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        ///��������ɴмVGj13
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ13(double VGJ)
        {
            if (VGJ <= 7.5)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        ///�������ͽ���мVGj14
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ14(double VGJ)
        {
            if (VGJ <= 18)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        ///�������;�ĩVGj15
        /// </summary>
        /// <param name="VGJ"></param>
        /// <returns>����/�Ǿ���</returns>
        public static string getVGJ15(double VGJ)
        {
            if (VGJ <= 15)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }
        /// <summary>
        /// �����·й©�ʦ�lF
        /// </summary>
        /// <param name="QZ">������������ݻ�����QZ</param>
        /// <param name="QI">������������ݻ�����Q�@</param>
        /// <returns></returns>
        public static double getLIF(double QZ, double QI)
        {
            return (QZ - QI) / QZ;
        }
        /// <summary>
        /// �����·й©�ʦ�lF ���
        /// </summary>
        /// <param name="QZ">������������ݻ�����QZ</param>
        /// <param name="QI">������������ݻ�����Q�@</param>
        /// <returns></returns>
        public static string getLIF_Judge(double QZ, double QI)
        {
            double LIF;

            LIF = getLIF(QZ, QI);

            if (LIF < 0.05)
            {
                return "����";
            }
            else if (LIF >= 0.05 && LIF < 0.1)
            {
                return "����";
            }
            else if (LIF >= 0.1)
            {
                return "������";
            }
            else
            {
                return "���������޷����";
            }
        }




        /// <summary>
        /// �����ܶȦ�FC
        /// </summary>
        /// <param name="PA">����ѹ��Pa</param>
        /// <param name="T">��������¶�tW</param>
        /// <param name="QH">���ʪ�ȧ�H</param>
        /// <returns></returns>
        public static double getPFC(double PA, double T, double QH)
        {

            double pfc = 0.0, pwb = 0.0;
            pwb = getPWB(T);
            pfc = 1.293 * (273.0 / (273.0 + T)) * (PA - (0.378 * QH * pwb)) / 0.1013;
            return pfc;

        }
        /// <summary>
        /// ���Ϳ����е�ˮ������ѹPwbȡֵ
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
        /// ���ϵͳ�ܺ�WSRF
        /// </summary>
        /// <param name="PTST">���/��/��ѹ���Ṧ��PTSR</param>
        /// <param name="T">����ʱ��T</param>
        /// <returns></returns>
        public static double getWSRF(double PTST, double TIME)
        {
            return PTST * TIME;
        }


        /// <summary>
        /// �������ǧ���ܺ�ew 
        /// </summary>
        /// <param name="WSRF">���ϵͳ�ܺ�WSRF</param>
        /// <param name="PFC">������������ܶȦ�FC</param>
        /// <param name="g">�������ٶ�g</param>
        /// <param name="QV">���ϵͳ�������qv</param>
        /// <param name="PFC">�������ѹ��PFC</param>
        /// <param name="T">������������¶�t</param>
        /// <returns></returns>
        public static double getEW(double WSRF, double PFC1, double PFC, double QV, double T)
        {
            return WSRF / (0.36 * PFC * 9.807 * QV * PFC1 * T); ;
        }
        /// <summary>
        /// �������ǧ���ܺ�ew �����
        /// </summary>
        /// <param name="WSRF">���ϵͳ�ܺ�WSRF</param>
        /// <param name="PFC">������������ܶȦ�FC</param>
        /// <param name="g">�������ٶ�g</param>
        /// <param name="QV">���ϵͳ�������qv</param>
        /// <param name="PFC">�������ѹ��PFC</param>
        /// <param name="T">������������¶�t</param>
        /// <returns></returns>
        public static string getEW_Judge(double WSRF, double PFC1, double PFC, double QV, double T)
        {
            double EW;
            EW = getEW(WSRF, PFC1, PFC, QV, T);

            if (EW <= 0.25)
            {
                return "����";
            }
            else if (EW >= 0.25)
            {
                return "������";
            }
            else
            {
                return "����";
            }

        }
        /// <summary>
        /// ����Ч�ʦ�Je
        /// </summary>
        /// <param name="PJE">�������빦��Pje</param>
        /// <param name="PYE">�����������Pye</param>
        /// <returns></returns>
        public static double getRJ(double PJE, double PYE, double NJ)
        {

            return NJ / (PYE / PJE);
        }
        /// <summary>
        /// ����Ч�ʦ�Je ���
        /// </summary>
        /// <param name="PJE">�������빦��Pje</param>
        /// <param name="PYE">�����������Pye</param>
        /// <returns></returns>
        public static string getRJ_Judge(double PJE, double PYE, double NJ)
        {
            double i = getRJ(PJE, PYE, NJ);
            Console.WriteLine(i);

            if (i > 0.85)
            {
                return "����";
            }
            else if (i <= 0.85 && i >= 0.70)
            {
                return "����";
            }
            else if (i < 0.70)
            {
                return "������";
            }
            else
            {
                return "�޷�����";
            }
        }



    }






}
