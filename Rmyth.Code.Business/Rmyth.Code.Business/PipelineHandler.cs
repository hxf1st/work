using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public  class PipelineHandler : SystemDevice
    {
        ///// <summary>
        ///// 管网效率ηG
        ///// </summary>
        ///// <param name="RearEfficiency">后一功率 PY</param>
        ///// <param name="FrontEfficiency">前一功率 PYJ</param>
        ///// <returns></returns>
        //public static double getNG_1(double RearPower, double FrontPower)
        //{

        //    return RearPower / FrontPower;
        //}
        /// <summary>
        /// 风机输出功率PYF
        /// </summary>
        /// <param name="QV">风机系统输出流量qv</param>
        /// <param name="PFC">风机出口气体密度ρFC</param>
        /// <param name="PFG">风机管路出口气体密度ρFG</param>
        /// <param name="P3">风机系统管路出口静压p3</param>
        /// <param name="P2">风机出口静压p2</param>
        /// <param name="V3">风机管路出口气体流速v3</param>
        /// <param name="V2">风机出口气体流速v2</param>
        /// <returns></returns>
        public static double getPYF(double QV, double PFC, double PFG, double P3, double P2, double V3, double V2)
        {

            double a,b,c,d,PYF;
           // PYF = QV * ((P3 + PFG / 2.0 * Math.Pow(V3, 2)) - (P2 + PFG / 2.0 * Math.Pow(V2, 2))) * Math.Pow(10, -3);
            a=QV;
            b = P2 +( PFC / 2.0) * Math.Pow(V2, 2);
            c = P3 + (PFG / 2.0 )* Math.Pow(V3, 2);
            d = Math.Pow(10, -3);
            PYF = a * (b - c) * d;

            return PYF;
        }
        /// <summary>
        /// 管网效率ηG
        /// </summary>
        /// <param name="H">泵扬程H</param>
        /// <param name="HG">液体输送长度Hg</param>
        /// <returns></returns>
        public static double getNG(double H, double HG, double HC, double HA)
        {

            double Q = 1.08, NG;


            Q = getQ(HC, HA);

            Console.WriteLine(Q);

            NG = Q * HG / H;

            return NG;
        }

        /// <summary>
        /// 倾斜管路的折算系数θ
        /// </summary>
        /// <param name="HC">管路长度Hc</param>
        /// <param name="HA">倾斜角度</param>
        /// <returns></returns>
        public static double getQ(double HC, double HA)
        {
            double Q = 0.0;
            double[,] table = StaticTable.getOutputTable();



            int i1, i2 = 0;
            i1 = -1;
            for (int i = 10; i < 61; i = i + 5)
            {
                i1++;
                i2 = i1 + 1;
                // Console.WriteLine("i=" + i);
                if (HA == i)
                {
                    i2 = i1;
                    break;
                }
                else if (HA < i)
                {
                    break;
                }

            }

            int j1, j2 = 0;
            j1 = -1;
            for (int j = 100; j < 601; j = j + 100)
            {
                // Console.WriteLine("j="+j);
                j1++;
                j2 = j1 + 1;
                if (HC == j)
                {
                    j2 = j1;
                    break;
                }
                else if (HC < j)
                {
                    break;
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

            Q = (table[j1, i1] + table[j1, i2] + table[j2, i1] + table[j2, i2]) / 4;
            //Console.WriteLine(Q);


            return Q;

        }
        /// <summary>
        /// 管网效率ηG 第二种算法
        /// </summary>
        /// <param name="PC">循环泵系统回水末端或出口余压PC</param>
        /// <param name="PY">循环泵系统出口压力PY</param>
        /// <returns></returns>
        public static double getNG_A(double PC, double PY) { 
        
             return (PY-PC)/PY;
        }


    }
}
