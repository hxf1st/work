using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public  class SystemDevice
    {
        /// <summary>
        /// ���빦��
        /// </summary>
        /// <param name="OutputPower">�������</param>
        /// <param name="Efficiency">Ч��</param>
        /// <returns></returns>
        public static double getInputPower(double OutputPower,double Efficiency){
            return OutputPower / Efficiency;
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="InputPower">���빦��</param>
        /// <param name="Efficiency">Ч��</param>
        /// <returns></returns>
        public static double getOutputPower(double InputPower, double Efficiency)
        {
            return InputPower * Efficiency;
        }
        /// <summary>
        /// Ч��
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
