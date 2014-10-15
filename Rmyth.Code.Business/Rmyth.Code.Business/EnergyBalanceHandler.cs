using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public class EnergyBalanceHandler : SystemDevice
    {
        /// <summary>
        /// 系统测算周期内输入总电能WSR
        /// </summary>
        /// <param name="PSR">系统负荷/系统加权负荷（功率）PSR</param>
        /// <param name="TIME">测算时长</param>
        /// <returns></returns>
        public static double getWSR(double PSR, double TIME)
        {
            return PSR * TIME;
        }
        /// <summary>
        /// 机组总输出能量WYJ
        /// </summary>
        /// <param name="PYJ">机组/设备输出功率PYJ</param>
        /// <param name="TIME">测算时长T</param>
        /// <returns></returns>
        public static double getWYJ(double PYJ, double TIME)
        {
            return PYJ * TIME;
        }
        /// <summary>
        /// 3.17.2	系统损失总能量WS
        /// </summary>
        /// <param name="WSK">控制装置在测算周期内损失的总能量WSK</param>
        /// <param name="WSD">电动机在测算周期内损失的总能量WSD</param>
        /// <param name="WSC">传动机构在测算周期内损失的总能量WSC</param>
        /// <param name="WSS">机组/设备在测算周期内输出的总能量WSS（风机/泵/空压机）</param>
        /// <param name="WSG">输送管路在测算周期内损失的总能量WSG</param>
        /// <returns></returns>
        public static double getWS(double WSK, double WSD, double WSC, double WSS, double WSG)
        {
            return WSK + WSD + WSC + WSS + WSG;
        }
        /// <summary>
        ///系统总输出能量WY 1
        /// </summary>
        /// <param name="PY">系统输出功率PY</param>
        /// <param name="TIME">测算时长T</param>
        /// <returns></returns>
        public static double getWY_1(double PY,double TIME) {
            return PY * TIME;
        }
        /// <summary>
        ///系统总输出能量WY 2
        /// </summary>
        /// <param name="WYJ">机组总输出能量WYJ</param>
        /// <param name="NG">管网效率ηG</param>
        /// <returns></returns>
        public static double getWY_2(double WYJ, double NG)
        {
            return WYJ * NG;
        }
        /// <summary>
        /// 系统总输出能量WY 3
        /// </summary>
        /// <param name="WSR">系统测算周期内输入总电能WSR</param>
        /// <param name="N">系统运行效率η</param>
        /// <returns></returns>
        public static double getWY_3(double WSR,double N) {
            return WSR * N;
        }
        /// <summary>
        ///机组电能利用率HJ 1
        /// </summary>
        /// <param name="WYJ">机组总输出能量WYJ</param>
        /// <param name="WSR">系统测算周期内输入总电能WSR</param>
        /// <returns></returns>
        public static double getHJ_1(double WYJ,double WSR) {
            return WYJ / WSR;
        }
        /// <summary>
        /// 机组电能利用率HJ 2
        /// </summary>
        /// <param name="WSR">系统测算周期内输入总电能WSR</param>
        /// <param name="WSK">控制装置在测算周期内损失的总能量WSK</param>
        /// <param name="WSD">电动机在测算周期内损失的总能量WSD</param>
        /// <param name="WSC">传动机构在测算周期内损失的总能量WSC</param>
        /// <param name="WSS">机组/设备在测算周期内输出的总能量WSS</param>
        /// <returns></returns>
        public static double getHJ_2(double WSR,double WSK,double WSD,double WSC,double WSS) {
            return 1 - (WSK + WSD + WSC + WSS) / WSR;
        }
        /// <summary>
        ///系统能源利用率HY_1
        /// </summary>
        /// <param name="WY">系统总输出能量WY</param>
        /// <param name="WSR">系统测算周期内输入总电能WSR</param>
        /// <returns></returns>
        public static double getHY_1(double WY,double WSR) {

            return WY / WSR;
        }
        /// <summary>
        /// 系统能源利用率HY_2
        /// </summary>
        /// <param name="WS">系统测算周期内损失总电能WS</param>
        /// <param name="WSR">系统测算周期内输入总电能WSR</param>
        /// <returns></returns>
        public static double getHY_2(double WS,double WSR) {

            return 1 - WS / WSR;
        }

    }
}
