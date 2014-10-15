using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public class EmotorHandler : SystemDevice
    {


        ///// <summary>
        ///// �綯�����빦��PDR
        ///// </summary>
        ///// <param name="FrontPower">ǰһ����������(PSCK)</param>
        ///// <returns></returns>
        //public static double getInpurtPower(double FrontPower)
        //{
        //    return FrontPower;
        //}



        ///// <summary>
        ///// �綯���������PYD
        ///// </summary>
        ///// <param name="FrontPower">ǰһ�������</param>
        ///// <param name="FrontEfficiency">ǰһ���Ч��</param>
        ///// <returns></returns>
        //public static double getOutpurtPower_1(double FrontPower, double FrontEfficiency)
        //{
        //    return FrontPower * FrontEfficiency;
        //}


        ///// <summary>
        ///// �綯���������PYD
        ///// </summary>
        ///// <param name="CurrentEfficiency">��ǰ���Ч��</param>
        ///// <param name="RearPower">��һ�������</param>
        ///// <returns></returns>
        //public static double getOutputPower_2(double CurrentEfficiency, double RearPower)
        //{
        //    return RearPower / CurrentEfficiency;
        //}
        ///// <summary>
        ///// Ч��
        ///// </summary>
        ///// <param name="CurrentOutputPower">��ǰ����������</param>
        ///// <param name="FrontOutputPower">ǰһ����������</param>
        ///// <returns></returns>
        //public static double getEfficiency(double CurrentOutputPower, double FrontOutputPower)
        //{

        //    return CurrentOutputPower / FrontOutputPower;
        //}

        /// <summary>
        /// �綯�������ʱ���޹�����QN
        /// </summary>
        /// <param name="PN">�綯�������PN</param>
        /// <param name="NN">�綯���Ч�ʦ�N</param>
        /// <param name="QN">�����ʱ����綯��������ͺ������ѹ����Ǧ�N</param>
        /// <returns></returns>
        public static double getQN(double PN, double NN, double QN_A)
        {

            return (PN / NN) * Math.Tan((Math.PI * QN_A / 180.0));
        }



        /// <summary>
        /// �綯�������޹�����Q0
        /// </summary>
        /// <param name="u">��Դ��ѹU</param>
        /// <param name="I0">�綯�������I0</param>
        /// <param name="P0">�綯�������й����P0</param>
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
        /// �綯��������й���Ħ�PN
        /// </summary>
        /// <param name="NN"></param>
        /// <param name="PN"></param>
        /// <returns></returns>
        public static double getAPN(double NN, double PN)
        {

            return (1.0 / NN - 1.0) * PN;
        }

        /// <summary>
        /// �綯�����и���ϵ����
        /// </summary>
        /// <param name="AP0">�綯������ʱ�й���ġ�P0</param>
        /// <param name="APN">�綯��������й���Ħ�PN</param>
        /// <param name="PN">�綯�������PN</param>
        /// <param name="PDR">�綯�����빦��PDR</param>
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
        /// �綯����ۺϹ�����Ħ�PC
        /// </summary>
        /// <param name="AP0">�綯������ʱ�й���ġ�P0</param>
        /// <param name="APN">�綯��������й���Ħ�PN</param>
        /// <param name="KQ">�綯���޹����õ���KQ</param>
        /// <param name="QN">�綯�������й����QN</param>
        /// <param name="Q0">�綯�������޹�����Q0</param>
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
        /// �綯����ۺϹ�����Ħ�PCN
        /// </summary>
        /// <param name="KQ">�綯���޹����õ���KQ</param>
        /// <param name="QN">�綯�������й����QN</param>
        /// <param name="APN">�綯��������й���Ħ�PN</param>
        /// <returns></returns>
        public static double getAPCN(double KQ, double QN, double APN)
        {
            return APN + KQ * QN;
        }
        /// <summary>
        /// �綯���ۺ�Ч�ʦ�CD
        /// </summary>
        /// <param name="APC">�綯����ۺϹ�����Ħ�PC</param>
        /// <param name="PN">�綯�������PN</param>
        /// <param name="B">�綯�����и���ϵ����</param>
        /// <returns></returns>

        public static double getNCD(double APC, double PN, double B)
        {

            return (B * PN) / (B * PN + APC);
        }

        /// <summary>
        /// �綯����ۺ�Ч�ʦ�CN
        /// </summary>
        /// <param name="PN">�綯�������PN</param>
        /// <param name="APCN">�綯����ۺϹ�����Ħ�PCN</param>
        /// <returns></returns>
        public static double getNCN(double PN, double APCN)
        {

            return PN / (PN + APCN);
        }

        /// <summary>
        /// �綯���ۺ�Ч�ʱ�
        /// </summary>
        /// <param name="NCD">�綯���ۺ�Ч�ʦ�CD</param>
        /// <param name="NCN">�綯����ۺ�Ч�ʦ�CN</param>
        /// <returns></returns>
        public static double getMER(double NCD, double NCN)
        {
            double MER = NCN / NCD;
            return MER;
        }


        /// <summary>
        /// �綯���ۺ�Ч�ʱ������
        /// </summary>
        /// <param name="NCD">�綯���ۺ�Ч�ʦ�CD</param>
        /// <param name="NCN">�綯����ۺ�Ч�ʦ�CN</param>
        /// <returns></returns>
        public static string getMER_Judge(double NCD, double NCN)
        {

            double flag = getMER(NCD, NCN);
            //Console.WriteLine(flag);
            if (flag >= 1)
            {
                return "����";
            }
            else if (flag >= 0.6)
            {
                return "����";
            }
            else if (flag < 0.6)
            {
                return "������";
            }
            else {
                return "";
            }
        }
        /// <summary>
        /// �綯����������
        /// </summary>
        /// <param name="COSQ">�綯����������COS��</param>
        /// <returns></returns>
        public static string getMEF_Judge(double COSQ)
        {
            if (COSQ >= 0.9)
            {
                return "����";
            }
            else if (COSQ < 0.9)
            {
                return "������";
            }
            else
            {
                return "����";
            }

        }

    }
}
