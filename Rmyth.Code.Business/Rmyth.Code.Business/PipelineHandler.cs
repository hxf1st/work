using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public  class PipelineHandler : SystemDevice
    {
        ///// <summary>
        ///// ����Ч�ʦ�G
        ///// </summary>
        ///// <param name="RearEfficiency">��һ���� PY</param>
        ///// <param name="FrontEfficiency">ǰһ���� PYJ</param>
        ///// <returns></returns>
        //public static double getNG_1(double RearPower, double FrontPower)
        //{

        //    return RearPower / FrontPower;
        //}
        /// <summary>
        /// ����������PYF
        /// </summary>
        /// <param name="QV">���ϵͳ�������qv</param>
        /// <param name="PFC">������������ܶȦ�FC</param>
        /// <param name="PFG">�����·���������ܶȦ�FG</param>
        /// <param name="P3">���ϵͳ��·���ھ�ѹp3</param>
        /// <param name="P2">������ھ�ѹp2</param>
        /// <param name="V3">�����·������������v3</param>
        /// <param name="V2">���������������v2</param>
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
        /// ����Ч�ʦ�G
        /// </summary>
        /// <param name="H">�����H</param>
        /// <param name="HG">Һ�����ͳ���Hg</param>
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
        /// ��б��·������ϵ����
        /// </summary>
        /// <param name="HC">��·����Hc</param>
        /// <param name="HA">��б�Ƕ�</param>
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
        /// ����Ч�ʦ�G �ڶ����㷨
        /// </summary>
        /// <param name="PC">ѭ����ϵͳ��ˮĩ�˻������ѹPC</param>
        /// <param name="PY">ѭ����ϵͳ����ѹ��PY</param>
        /// <returns></returns>
        public static double getNG_A(double PC, double PY) { 
        
             return (PY-PC)/PY;
        }


    }
}
