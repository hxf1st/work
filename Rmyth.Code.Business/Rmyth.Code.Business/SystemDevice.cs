using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public  class SystemDevice
    {
        /// <summary>
        /// 输入功率
        /// </summary>
        /// <param name="OutputPower">输出功率</param>
        /// <param name="Efficiency">效率</param>
        /// <returns></returns>
        public static double getInputPower(double OutputPower,double Efficiency){
            return OutputPower / Efficiency;
        }
        /// <summary>
        /// 输出功率
        /// </summary>
        /// <param name="InputPower">输入功率</param>
        /// <param name="Efficiency">效率</param>
        /// <returns></returns>
        public static double getOutputPower(double InputPower, double Efficiency)
        {
            return InputPower * Efficiency;
        }
        /// <summary>
        /// 效率
        /// </summary>
        /// <param name="InputPower"></param>
        /// <param name="OutputPower"></param>
        /// <returns></returns>
        public static double getEfficiency(double InputPower, double OutputPower)
        {
            return OutputPower / InputPower;

        }

    }
}
