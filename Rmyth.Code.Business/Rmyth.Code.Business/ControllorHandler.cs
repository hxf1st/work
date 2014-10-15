using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public class ControllorHandler : SystemDevice
    {



        ///// <summary>
        ///// 控制装置输出功率PSCK
        ///// </summary>
        ///// <param name="FrontPower">前一组件功率</param>
        ///// <param name="FrontEfficiency">前一组件效率</param>
        ///// <returns></returns>
        //public static double getOutputPower_1(double FrontPower, double FrontEfficiency)
        //{
        //    return FrontPower * FrontEfficiency;
        //}
        ///// <summary>
        ///// 控制装置输出功率PSCK
        ///// </summary>
        ///// <param name="CurrentEfficiency">后一组件功率</param>
        ///// <param name="RearPower">当前组件效率</param>
        ///// <returns></returns>
        //public static double getOutputPower_2(double CurrentEfficiency, double RearPower)
        //{

        //    return RearPower / CurrentEfficiency;
        //}
        ///// <summary>
        ///// 效率
        ///// </summary>
        ///// <param name="CurrentOutputPower">当前组件输出功率</param>
        ///// <param name="FrontOutputPower">前一组件输出功率</param>
        ///// <returns></returns>
        //public static double getEfficiency(double CurrentOutputPower, double FrontOutputPower)
        //{

        //    return CurrentOutputPower / FrontOutputPower;
        //}
        /// <summary>
        /// 变频器运行效率比RK
        /// </summary>
        /// <param name="NK">运行效率ηK</param>
        /// <param name="NKE">额定效率ηKE</param>
        /// <returns>变频器运行效率比RK</returns>
        public static double getRK(double NK, double NKE)
        {
            return NK / NKE;
        }

        /// <summary>
        /// 变频器运行效率比RK
        /// </summary>
        /// <param name="NK">运行效率ηK</param>
        /// <param name="NKE">额定效率ηKE</param>
        /// <param name="RunState">运行状况</param>
        /// <returns>变频器运行效率比RK 1-低压。2－高压</returns>
        public static string getRK_Judge(double NK, double NKE, int RunState)
        {
            Double RK = getRK(NK , NKE);

            if (RunState == 1)
            {
                if (RK >= 0.95)
                {
                    return "节能";
                }
                else if (RK < 0.95)
                {
                    return "不节能";
                }
                else
                {
                    return "合理";
                }
            }
            else if (RunState == 2)
            {
                if (RK >= 0.96)
                {
                    return "节能";
                }
                else if (RK < 0.96)
                {
                    return "不节能";
                }
                else
                {
                    return "合理";
                }

            }
            else
            {
                return "请选择运行状况";
            }

        }
    }







}
