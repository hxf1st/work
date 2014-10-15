using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace JiDian.Business
{
    public class AirCompressorHandler : SystemDevice
    {




        /// <summary>
        /// 从机组出口到主分配管路最远点的压降Vg
        /// </summary>
        /// <param name="PP">空压机排气压力（绝对）PP</param>
        /// <param name="PM">空压机主分配管路末端压力PM</param>
        /// <returns></returns>
        public static double getVGJ(double PP, double PM)
        {

            return (PP - PM) / PP;
        }


        /// <summary>
        /// 从机组出口到主分配管路最远点的压降Vg 诊断项
        /// </summary>
        /// <param name="PP">空压机排气压力（绝对）PP</param>
        /// <param name="PM">空压机主分配管路末端压力PM</param>
        /// <returns></returns>
        public static string getVGJ_Judge(double PP, double PM)
        {


            double VG = getVGJ(PP, PM);

            if (VG <= 0.1)
            {
                return "节能";
            }
            else if (VG > 0.1)
            {
                return "不节能";
            }
            else
            {
                return "合理";
            }
        }
        /// <summary>
        /// 站内的主管路流速Vg1
        /// </summary>
        /// <param name="VG"></param>
        /// <returns></returns>
        public static string getVGJ1(double VG)
        {
            if (VG <= 5)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }

        }
        /// <summary>
        /// 站外主分配管路流速Vg2
        /// </summary>
        /// <param name="VG"></param>
        /// <returns></returns>
        public static string getVGJ2(double VG)
        {
            if (VG <= 10)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }

        }
        /// <summary>
        /// 主分配管路到使用点前流速Vg3
        /// </summary>
        /// <param name="VG"></param>
        /// <returns></returns>
        public static string getVGJ3(double VG)
        {
            if (VG <= 15)
            {
                return "经济";
            }
            else
            {
                return "非经济";
            }
        }

        /// <summary>
        /// 空压机管路泄漏率λlC
        /// </summary>
        /// <param name="QZ">空压机输送管路总容积流量QZ</param>
        /// <param name="QI">空压机输送管路总容积流量Qˊ</param>
        /// <returns></returns>
        public static double getLIC(double QZ, double QI)
        {
            return (QZ - QI) / QZ;



        }

        /// <summary>
        /// 空压机管路泄漏率λlC
        /// </summary>
        /// <param name="QZ">空压机输送管路总容积流量QZ</param>
        /// <param name="QI">空压机输送管路总容积流量Qˊ</param>
        /// <returns></returns>
        public static string getLIC_Judge(double QZ, double QI)
        {
            double LIC = getLIC(QZ, QI);

            if (LIC <= 0.05)
            {
                return "节能";
            }
            else if (LIC > 0.10)
            {
                return "不节能";
            }
            else
            {
                return "合理";
            }

        }
        /// <summary>
        /// 空压机进气量QX
        /// </summary>
        /// <param name="QP">空压机排气端气量QP</param>
        /// <param name="TX">空压机吸气温度TX</param>
        /// <param name="TP">空压机排气温度TP</param>
        /// <param name="PP">空压机排气压力（绝对）PP</param>
        /// <param name="PX">空压机吸气压力（绝对）PX</param>
        /// <returns></returns>
        public static double getQX(double QP, double TX, double TP, double PP, double PX)
        {
            double QX;
            QX = QP * (PP * (TX + 273.0)) / (PX * (TP + 273.0));
            return QX;
        }
        /// <summary>
        /// 空压机组输入电能ERc
        /// </summary>
        /// <param name="PR">空压机机组输入功率PR（电动机输入功率）</param>
        /// <param name="TIME">测算时长T</param>
        /// <returns></returns>
        public static double getERC(double PR, double TIME)
        {
            return PR * TIME;
        }
        /// <summary>
        /// 压力修正系数K2
        /// </summary>
        /// <param name="PP"></param>
        /// <param name="PX"></param>
        /// <param name="poles">T-单级/F-两极/两级（水冷）</param>
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
        /// 空压机单耗Wa（WG）
        /// </summary>
        /// <param name="CC">空压机驱动电动机容量CC</param>
        /// <param name="ERC">空压机组输入电能ERc</param>
        /// <param name="QX">空压机进气量QX</param>
        /// <param name="K1">冷却水修正系数K1</param>
        /// <param name="K2">压力修正系数K2</param>
        /// <returns></returns>
        public static double getWG(double ERC, double QX, double K1, double K2)
        {
            return ERC * K1 * K2 / QX;
        }
        /// <summary>
        /// 空压机单耗Wa（WG）
        /// </summary>
        /// <param name="CC">空压机驱动电动机容量CC</param>
        /// <param name="ERC">空压机组输入电能ERc</param>
        /// <param name="QX">空压机进气量QX</param>
        /// <param name="K1">冷却水修正系数K1</param>
        /// <param name="K2">压力修正系数K2</param>
        /// <returns></returns>
        public static string getWG_Judge(double CC, double ERC, double QX, double K1, double K2)
        {
            double WA;
            WA = getWG(ERC, QX, K1, K2);
            if (CC <= 45 && WA <= 0.129)
            {
                return "节能";
            }
            else if (CC >= 55 && CC <= 160 && WA <= 0.115)
            {
                return "节能";
            }
            else if (CC >= 200 && WA <= 0.112)
            {
                return "节能";
            }
            else
            {
                return "不节能";
            }
        }
        /// <summary>
        /// 空压机机组运行比功率PB
        /// </summary>
        /// <param name="PR">空压机机组输入功率PR</param>
        /// <param name="QP">空压机排气端气量QP</param>
        /// <param name="type">类型</param>
        /// <param name="poles">级数</param>
        /// <param name="inputPower">功率</param>
        /// <param name="force">压力</param>
        /// <returns></returns>

        public static double getPB(double PR, double QP) { 
         return PR /QP;
        }
        /// <summary>
        /// 空压机机组运行比功率PB 诊断项
        /// </summary>
        /// <param name="PR">空压机机组输入功率PR</param>
        /// <param name="QP">空压机排气端气量QP</param>
        /// <param name="type">类型</param>
        /// <param name="poles">级数</param>
        /// <param name="inputPower">功率</param>
        /// <param name="force">压力</param>
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
                return "节能";
            }
            else if (PB <= EEL)
            {
                return "合理";
            }
            else
            {
                return "不节能";
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
