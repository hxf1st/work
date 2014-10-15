using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public class EnergyBalanceHandler : SystemDevice
    {
        /// <summary>
        /// ϵͳ���������������ܵ���WSR
        /// </summary>
        /// <param name="PSR">ϵͳ����/ϵͳ��Ȩ���ɣ����ʣ�PSR</param>
        /// <param name="TIME">����ʱ��</param>
        /// <returns></returns>
        public static double getWSR(double PSR, double TIME)
        {
            return PSR * TIME;
        }
        /// <summary>
        /// �������������WYJ
        /// </summary>
        /// <param name="PYJ">����/�豸�������PYJ</param>
        /// <param name="TIME">����ʱ��T</param>
        /// <returns></returns>
        public static double getWYJ(double PYJ, double TIME)
        {
            return PYJ * TIME;
        }
        /// <summary>
        /// 3.17.2	ϵͳ��ʧ������WS
        /// </summary>
        /// <param name="WSK">����װ���ڲ�����������ʧ��������WSK</param>
        /// <param name="WSD">�綯���ڲ�����������ʧ��������WSD</param>
        /// <param name="WSC">���������ڲ�����������ʧ��������WSC</param>
        /// <param name="WSS">����/�豸�ڲ��������������������WSS�����/��/��ѹ����</param>
        /// <param name="WSG">���͹�·�ڲ�����������ʧ��������WSG</param>
        /// <returns></returns>
        public static double getWS(double WSK, double WSD, double WSC, double WSS, double WSG)
        {
            return WSK + WSD + WSC + WSS + WSG;
        }
        /// <summary>
        ///ϵͳ���������WY 1
        /// </summary>
        /// <param name="PY">ϵͳ�������PY</param>
        /// <param name="TIME">����ʱ��T</param>
        /// <returns></returns>
        public static double getWY_1(double PY,double TIME) {
            return PY * TIME;
        }
        /// <summary>
        ///ϵͳ���������WY 2
        /// </summary>
        /// <param name="WYJ">�������������WYJ</param>
        /// <param name="NG">����Ч�ʦ�G</param>
        /// <returns></returns>
        public static double getWY_2(double WYJ, double NG)
        {
            return WYJ * NG;
        }
        /// <summary>
        /// ϵͳ���������WY 3
        /// </summary>
        /// <param name="WSR">ϵͳ���������������ܵ���WSR</param>
        /// <param name="N">ϵͳ����Ч�ʦ�</param>
        /// <returns></returns>
        public static double getWY_3(double WSR,double N) {
            return WSR * N;
        }
        /// <summary>
        ///�������������HJ 1
        /// </summary>
        /// <param name="WYJ">�������������WYJ</param>
        /// <param name="WSR">ϵͳ���������������ܵ���WSR</param>
        /// <returns></returns>
        public static double getHJ_1(double WYJ,double WSR) {
            return WYJ / WSR;
        }
        /// <summary>
        /// �������������HJ 2
        /// </summary>
        /// <param name="WSR">ϵͳ���������������ܵ���WSR</param>
        /// <param name="WSK">����װ���ڲ�����������ʧ��������WSK</param>
        /// <param name="WSD">�綯���ڲ�����������ʧ��������WSD</param>
        /// <param name="WSC">���������ڲ�����������ʧ��������WSC</param>
        /// <param name="WSS">����/�豸�ڲ��������������������WSS</param>
        /// <returns></returns>
        public static double getHJ_2(double WSR,double WSK,double WSD,double WSC,double WSS) {
            return 1 - (WSK + WSD + WSC + WSS) / WSR;
        }
        /// <summary>
        ///ϵͳ��Դ������HY_1
        /// </summary>
        /// <param name="WY">ϵͳ���������WY</param>
        /// <param name="WSR">ϵͳ���������������ܵ���WSR</param>
        /// <returns></returns>
        public static double getHY_1(double WY,double WSR) {

            return WY / WSR;
        }
        /// <summary>
        /// ϵͳ��Դ������HY_2
        /// </summary>
        /// <param name="WS">ϵͳ������������ʧ�ܵ���WS</param>
        /// <param name="WSR">ϵͳ���������������ܵ���WSR</param>
        /// <returns></returns>
        public static double getHY_2(double WS,double WSR) {

            return 1 - WS / WSR;
        }

    }
}
