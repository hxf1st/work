using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public  class OutputHandler : SystemDevice
    {
        ///// <summary>
        ///// ϵͳ�������PY
        ///// </summary>
        ///// <param name="FrontPower">ǰһ�������</param>
        ///// <param name="FrontEfficiency">ǰһ���Ч��</param>
        ///// <returns></returns>
        //public static double getOutpurtPower_1(double FrontPower, double FrontEfficiency)
        //{
        //    return FrontPower * FrontEfficiency;
        //}

        /// <summary>
        /// ϵͳ����Ч�ʦ�
        /// </summary>
        /// <param name="PY">ϵͳ�������PY</param>
        /// <param name="PSR">ϵͳ����/ϵͳ��Ȩ���ɣ����ʣ�PSR�����͹������֣�</param>
        /// <returns></returns>
        public static double getN(double PY, double PSR)
        {
            return PY / PSR;
        }
      
       

        
          




        }
    }

