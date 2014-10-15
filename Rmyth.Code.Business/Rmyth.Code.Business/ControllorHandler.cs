using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public class ControllorHandler : SystemDevice
    {



        ///// <summary>
        ///// ����װ���������PSCK
        ///// </summary>
        ///// <param name="FrontPower">ǰһ�������</param>
        ///// <param name="FrontEfficiency">ǰһ���Ч��</param>
        ///// <returns></returns>
        //public static double getOutputPower_1(double FrontPower, double FrontEfficiency)
        //{
        //    return FrontPower * FrontEfficiency;
        //}
        ///// <summary>
        ///// ����װ���������PSCK
        ///// </summary>
        ///// <param name="CurrentEfficiency">��һ�������</param>
        ///// <param name="RearPower">��ǰ���Ч��</param>
        ///// <returns></returns>
        //public static double getOutputPower_2(double CurrentEfficiency, double RearPower)
        //{

        //    return RearPower / CurrentEfficiency;
        //}
        ///// <summary>
        ///// Ч��
        ///// </summary>
        ///// <param name="CurrentOutputPower">��ǰ����������</param>
        ///// <param name="FrontOutputPower">ǰһ����������</param>
        ///// <returns></returns>
        //public static double getEfficiency(double CurrentOutputPower, double FrontOutputPower)
        //{

        //    return CurrentOutputPower / FrontOutputPower;
        //}
        /// <summary>
        /// ��Ƶ������Ч�ʱ�RK
        /// </summary>
        /// <param name="NK">����Ч�ʦ�K</param>
        /// <param name="NKE">�Ч�ʦ�KE</param>
        /// <returns>��Ƶ������Ч�ʱ�RK</returns>
        public static double getRK(double NK, double NKE)
        {
            return NK / NKE;
        }

        /// <summary>
        /// ��Ƶ������Ч�ʱ�RK
        /// </summary>
        /// <param name="NK">����Ч�ʦ�K</param>
        /// <param name="NKE">�Ч�ʦ�KE</param>
        /// <param name="RunState">����״��</param>
        /// <returns>��Ƶ������Ч�ʱ�RK 1-��ѹ��2����ѹ</returns>
        public static string getRK_Judge(double NK, double NKE, int RunState)
        {
            Double RK = getRK(NK , NKE);

            if (RunState == 1)
            {
                if (RK >= 0.95)
                {
                    return "����";
                }
                else if (RK < 0.95)
                {
                    return "������";
                }
                else
                {
                    return "����";
                }
            }
            else if (RunState == 2)
            {
                if (RK >= 0.96)
                {
                    return "����";
                }
                else if (RK < 0.96)
                {
                    return "������";
                }
                else
                {
                    return "����";
                }

            }
            else
            {
                return "��ѡ������״��";
            }

        }
    }







}
