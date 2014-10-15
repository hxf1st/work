using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public static class handlerFactory
    {

        public static handler createHandler(String deviceType)
        {

            //switch (deviceType) { 
            //    case "power":
            //        return new SystemESourceHandler();
            //    case"electricMotor":
            //        return new SystemEmotorHandler();
            //    case "controller":
            //        return new SystemControllorHandler();
            //    case "coupling":
            //        return new SystemCouplerHandler();
            //    case "transmission":
            //        return new transmissionHandler();
            //    case "blower":
            //        return new SystemDraughtFanHandler();
            //    case "pump":
            //        return new SystemPumpHandler();
            //    case "airCompressorHandler":
            //        return new airCompressorHandler();
            //    case "output":
            //        return new outpurHandler();
            //    default:
            return null;
            //}
        }
    }
}
