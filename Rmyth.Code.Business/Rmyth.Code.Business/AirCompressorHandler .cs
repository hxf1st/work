using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace JiDian.Business
{
    public class AirCompressorHandler : SystemDevice
    {




        /// <summary>
        /// �ӻ�����ڵ��������·��Զ���ѹ��Vg
        /// </summary>
        /// <param name="PP">��ѹ������ѹ�������ԣ�PP</param>
        /// <param name="PM">��ѹ���������·ĩ��ѹ��PM</param>
        /// <returns></returns>
        public static double getVGJ(double PP, double PM)
        {

            return (PP - PM) / PP;
        }


        /// <summary>
        /// �ӻ�����ڵ��������·��Զ���ѹ��Vg �����
        /// </summary>
        /// <param name="PP">��ѹ������ѹ�������ԣ�PP</param>
        /// <param name="PM">��ѹ���������·ĩ��ѹ��PM</param>
        /// <returns></returns>
        public static string getVGJ_Judge(double PP, double PM)
        {


            double VG = getVGJ(PP, PM);

            if (VG <= 0.1)
            {
                return "����";
            }
            else if (VG > 0.1)
            {
                return "������";
            }
            else
            {
                return "����";
            }
        }
        /// <summary>
        /// վ�ڵ�����·����Vg1
        /// </summary>
        /// <param name="VG"></param>
        /// <returns></returns>
        public static string getVGJ1(double VG)
        {
            if (VG <= 5)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }

        }
        /// <summary>
        /// վ���������·����Vg2
        /// </summary>
        /// <param name="VG"></param>
        /// <returns></returns>
        public static string getVGJ2(double VG)
        {
            if (VG <= 10)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }

        }
        /// <summary>
        /// �������·��ʹ�õ�ǰ����Vg3
        /// </summary>
        /// <param name="VG"></param>
        /// <returns></returns>
        public static string getVGJ3(double VG)
        {
            if (VG <= 15)
            {
                return "����";
            }
            else
            {
                return "�Ǿ���";
            }
        }

        /// <summary>
        /// ��ѹ����·й©�ʦ�lC
        /// </summary>
        /// <param name="QZ">��ѹ�����͹�·���ݻ�����QZ</param>
        /// <param name="QI">��ѹ�����͹�·���ݻ�����Q�@</param>
        /// <returns></returns>
        public static double getLIC(double QZ, double QI)
        {
            return (QZ - QI) / QZ;



        }

        /// <summary>
        /// ��ѹ����·й©�ʦ�lC
        /// </summary>
        /// <param name="QZ">��ѹ�����͹�·���ݻ�����QZ</param>
        /// <param name="QI">��ѹ�����͹�·���ݻ�����Q�@</param>
        /// <returns></returns>
        public static string getLIC_Judge(double QZ, double QI)
        {
            double LIC = getLIC(QZ, QI);

            if (LIC <= 0.05)
            {
                return "����";
            }
            else if (LIC > 0.10)
            {
                return "������";
            }
            else
            {
                return "����";
            }

        }
        /// <summary>
        /// ��ѹ��������QX
        /// </summary>
        /// <param name="QP">��ѹ������������QP</param>
        /// <param name="TX">��ѹ�������¶�TX</param>
        /// <param name="TP">��ѹ�������¶�TP</param>
        /// <param name="PP">��ѹ������ѹ�������ԣ�PP</param>
        /// <param name="PX">��ѹ������ѹ�������ԣ�PX</param>
        /// <returns></returns>
        public static double getQX(double QP, double TX, double TP, double PP, double PX)
        {
            double QX;
            QX = QP * (PP * (TX + 273.0)) / (PX * (TP + 273.0));
            return QX;
        }
        /// <summary>
        /// ��ѹ�����������ERc
        /// </summary>
        /// <param name="PR">��ѹ���������빦��PR���綯�����빦�ʣ�</param>
        /// <param name="TIME">����ʱ��T</param>
        /// <returns></returns>
        public static double getERC(double PR, double TIME)
        {
            return PR * TIME;
        }
        /// <summary>
        /// ѹ������ϵ��K2
        /// </summary>
        /// <param name="PP"></param>
        /// <param name="PX"></param>
        /// <param name="poles">T-����/F-����/������ˮ�䣩</param>
        /// <returns></returns>

        public static double getK2(double PP, double PX, int poles)
        {
            double K2 = 0.0;
            if (poles == 1)
            {
                K2 = 0.8114 / (Math.Pow((PP / PX), 0.2857) - 1.0);
            }
            else
            {
                K2 = 0.3459 / (Math.Pow((PP / PX), 0.1429) - 1.0);
            }
            return K2;
        }
        /// <summary>
        /// ��ѹ������Wa��WG��
        /// </summary>
        /// <param name="CC">��ѹ�������綯������CC</param>
        /// <param name="ERC">��ѹ�����������ERc</param>
        /// <param name="QX">��ѹ��������QX</param>
        /// <param name="K1">��ȴˮ����ϵ��K1</param>
        /// <param name="K2">ѹ������ϵ��K2</param>
        /// <returns></returns>
        public static double getWG(double ERC, double QX, double K1, double K2)
        {
            return ERC * K1 * K2 / QX;
        }
        /// <summary>
        /// ��ѹ������Wa��WG��
        /// </summary>
        /// <param name="CC">��ѹ�������綯������CC</param>
        /// <param name="ERC">��ѹ�����������ERc</param>
        /// <param name="QX">��ѹ��������QX</param>
        /// <param name="K1">��ȴˮ����ϵ��K1</param>
        /// <param name="K2">ѹ������ϵ��K2</param>
        /// <returns></returns>
        public static string getWG_Judge(double CC, double ERC, double QX, double K1, double K2)
        {
            double WA;
            WA = getWG(ERC, QX, K1, K2);
            if (CC <= 45 && WA <= 0.129)
            {
                return "����";
            }
            else if (CC >= 55 && CC <= 160 && WA <= 0.115)
            {
                return "����";
            }
            else if (CC >= 200 && WA <= 0.112)
            {
                return "����";
            }
            else
            {
                return "������";
            }
        }
        /// <summary>
        /// ��ѹ���������бȹ���PB
        /// </summary>
        /// <param name="PR">��ѹ���������빦��PR</param>
        /// <param name="QP">��ѹ������������QP</param>
        /// <param name="type">����</param>
        /// <param name="poles">����</param>
        /// <param name="inputPower">����</param>
        /// <param name="force">ѹ��</param>
        /// <returns></returns>

        public static double getPB(double PR, double QP) { 
         return PR /QP;
        }
        /// <summary>
        /// ��ѹ���������бȹ���PB �����
        /// </summary>
        /// <param name="PR">��ѹ���������빦��PR</param>
        /// <param name="QP">��ѹ������������QP</param>
        /// <param name="type">����</param>
        /// <param name="poles">����</param>
        /// <param name="inputPower">����</param>
        /// <param name="force">ѹ��</param>
        /// <returns></returns>

        public static string getPB_Judge(double PR, double QP, int type, int poles, int inputPower, int force)
        {
            double PB, EVEC, EEL;
            double[] rs = new double[2];
            PB = getPB(PR,QP);
            rs = getEF(type, poles, inputPower, force);
            EVEC = rs[1];
            EEL = rs[0];
            //Console.WriteLine("EEL" + EEL);
            //Console.WriteLine("EVEC" + EVEC);
            if (PB <= EVEC)
            {
                return "����";
            }
            else if (PB <= EEL)
            {
                return "����";
            }
            else
            {
                return "������";
            }
        }

        public static double[] getEF(int type, int poles, int inputPower, int force)
        {
            double[] rs = new double[2];
            String src1 = "";
            String src2 = "";

            Hashtable ht = StaticTable.getEvaluateValue(type);
            if (type < 5)
            {
                src1 = type + "," + poles + "," + inputPower + "," + force + ",1";
                //  Console.WriteLine("src1=" + src1);
                src2 = type + "," + poles + "," + inputPower + "," + force + ",2";
                //  Console.WriteLine("src2=" + src2);
            }
            else if (type > 5 && type < 14)
            {
                src1 = type + "," + inputPower + "," + force + ",1";
                // Console.WriteLine("src1=" + src1);
                src2 = type + "," + inputPower + "," + force + ",2";
                //  Console.WriteLine("src2=" + src2);
            }
            Object obj1 = ht[src1];

            if (obj1 != null)
            {
                rs[0] = (double)obj1;

            }
            else
            {
                rs[0] = 0.0;
            }

            Object obj2 = ht[src2];

            if (obj2 != null)
            {
                rs[1] = (double)obj2;
            }
            else
            {
                rs[1] = 0.0;
            }

            return rs;
        }

      
    }
}
