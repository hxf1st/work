using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public  class OutputHandler : SystemDevice
    {
        ///// <summary>
        ///// 系统输出功率PY
        ///// </summary>
        ///// <param name="FrontPower">前一组件功率</param>
        ///// <param name="FrontEfficiency">前一组件效率</param>
        ///// <returns></returns>
        //public static double getOutpurtPower_1(double FrontPower, double FrontEfficiency)
        //{
        //    return FrontPower * FrontEfficiency;
        //}

        /// <summary>
        /// 系统运行效率η
        /// </summary>
        /// <param name="PY">系统输出功率PY</param>
        /// <param name="PSR">系统负荷/系统加权负荷（功率）PSR（典型工况部分）</param>
        /// <returns></returns>
        public static double getN(double PY, double PSR)
        {
            return PY / PSR;
        }
      
       

        
          




        }
    }

