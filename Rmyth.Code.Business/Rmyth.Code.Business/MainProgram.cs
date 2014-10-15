using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    class MainProgram
    {
        static void Main(string[] args)
        {

            // string handlerName = ConfigurationSettings.AppSettings["handlerName"];


            // public static double getNG(double H, double HG,double HC,double HA);
            //double q=SystemOutputHandler.getQ(200,10);
            // SystemOutputHandler.getQ(300, 10);
            //    SystemOutputHandler.getQ(200, 15);
            //    SystemOutputHandler.getQ(150, 13);
            //SystemPumpHandler.getPB(10,0);
            //SystemPumpHandler.getPB(55, 4);
            //SystemPumpHandler.getPB(30, 2);
            //SystemPumpHandler.getPB(30, 2);


            //Console.WriteLine(q);
            //SystemOutputHandler.test(150,10);
            //4	1	1	5	2
            //SystemAirCompressorHandler.getPB(1.0,2.0,13,1,5,2);
            //角度
            //Console.WriteLine(Math.Sin(30));
            //弧度
            //Console.WriteLine(Math.Sin(Math.PI * 30 / 180.0));

            //Console.WriteLine(-1.0/2.0);


            //// 电源测试


            //double U = 391, UE = 380;
            //double U = 399, UE = 380;
            //double U = 354, UE = 380;
            //double U = 411, UE = 380;


            //double AU = SystemESourceHandler.getAU(U, UE);
            //Console.WriteLine("AU :" + AU);
            //String AU_str = SystemESourceHandler.getAU_Judge(U, UE);
            //Console.WriteLine("AU_str :" + AU_str);


            //220	220	180	0	-120	-240
					
            //220	220	180	0	-118	-252
					
            //380	380	380	0	-120	-240
            					
            //367	409	388	2	-123	-242
            					
            //380	384	381	1	-120	-241


            //SystemESourceHandler.test();

            //double UA = 220, UB = 220, UC = 180, QA = 0, QB = -120, QC = -240;
            //int upTime = 1;

            //double UA = 220, UB = 220, UC = 180, QA = 0, QB = -118, QC = -252;

            //double UA = 380, UB = 380, UC = 380, QA = 0, QB = -120, QC = -240;

            ////double UA = 367, UB = 409, UC = 388, QA = 2, QB = -123, QC = -242;

            ////double UA = 380, UB = 384, UC = 381, QA = 1, QB = -120, QC = -241;
            //int upTime = 2;

            //double A0 = SystemESourceHandler.getA0(UA, UB, UC, QA, QB, QC);
            //double A1 = SystemESourceHandler.getA1(UA, UB, UC, QA, QB, QC);
            //double A2 = SystemESourceHandler.getA2(UA, UB, UC, QA, QB, QC);
            //double B0 = SystemESourceHandler.getB0(UA, UB, UC, QA, QB, QC);
            //double B1 = SystemESourceHandler.getB1(UA, UB, UC, QA, QB, QC);
            //double B2 = SystemESourceHandler.getB2(UA, UB, UC, QA, QB, QC);
            //double U0 = SystemESourceHandler.getU0(UA, UB, UC, QA, QB, QC);
            //double U1 = SystemESourceHandler.getU1(UA, UB, UC, QA, QB, QC);
            //double U2 = SystemESourceHandler.getU2(UA, UB, UC, QA, QB, QC);


            //Console.WriteLine(A0);
            //Console.WriteLine(A1);
            //Console.WriteLine(A2);
            //Console.WriteLine(B0);
            //Console.WriteLine(B1);
            //Console.WriteLine(B2);
            //Console.WriteLine(U0);
            //Console.WriteLine(U1);
            //Console.WriteLine(U2);

            //Console.WriteLine("A0 :" + A0);
            //Console.WriteLine("A1 :" + A1);
            //Console.WriteLine("A2 :" + A2);
            //Console.WriteLine("B0 :" + B0);
            //Console.WriteLine("B1 :" + B1);
            //Console.WriteLine("B2 :" + B2);
            //Console.WriteLine("U0 :" + U0);
            //Console.WriteLine("U1 :" + U1);
            //Console.WriteLine("U2 :" + U2);

            //Console.WriteLine(SystemESourceHandler.getThreephaseUnbalanced(UA, UB, UC, QA, QB, QC, upTime));


            //交流接触器

            //double IXC = 0.034, UXC = 380, IE = 30;
            //double IXC = 0.286, UXC = 220, IE = 70;
            //double IXC = 0.0013, UXC = 380, IE = 40;



            //double PXC = SystemACContactorHandler.getPXC(IXC, UXC);
            //Console.WriteLine(PXC);

            //string PXC_Judge = SystemACContactorHandler.getPXC_Judge(IXC, UXC, IE);
            //Console.WriteLine(PXC_Judge);


            //控制装置测试
            //double NK = 0.975, NKE = 0.989;
            //double NK = 0.922, NKE = 0.989;
            //int RunState = 1;

            //double RK = SystemControllorHandler.getRK(NK, NKE);
            //Console.WriteLine(RK);
            //string RK_Judge = SystemControllorHandler.getRK_Judge (NK, NKE, RunState);
            //Console.WriteLine(RK_Judge);

            //电动机测试


            //double PN = 9.543, NN = 0.9456, QN_A = 6;
            //double PN = 9.543, NN = 0.9456, QN_A = 4;

            //double QN = SystemEmotorHandler.getQN(PN, NN, QN_A);
            //Console.WriteLine(QN);

            //double U = 380, I0 = 8.7896, P0 = 3.34;

            //double Q0 = SystemEmotorHandler.getQ0(U, I0, P0);
            //Console.WriteLine(Q0);


            //double PN = 9.543, NN = 0.9456;

            //double APN = SystemEmotorHandler.getAPN(NN, PN);
            //Console.WriteLine(APN);


            //double AP0 = 3.34, APN = 0.549005076142132, PN = 9.543, PDR = 9.736;
            //double AP0 = 3.34, APN = 0.549005076142132, PN = 9.543, PDR = 6.8152;
            //double AP0 = 3.34, APN = 0.549005076142132, PN = 9.543, PDR = 10.2228;

            //double B = SystemEmotorHandler.getB(AP0, APN, PN, PDR);
            //Console.WriteLine(B);

            //double AP0 = 3.34, APN = 0.549005076142132, KQ = 0.09, QN = 1.0607, Q0 = 4.72, B = 0.915190695653342;
            //double AP0 = 3.34, APN = 0.549005076142132, KQ = 0.09, QN = 0.88294, Q0 = 4.72, B = 0.414382155986869;
            //double AP0 = 3.34, APN = 0.549005076142132, KQ = 0.09, QN = 0.705701741092343, Q0 = 4.72, B = 1.033826861;

            //double APC = SystemEmotorHandler.getAPC(AP0, APN, KQ, QN, Q0, B);
            //Console.WriteLine(APC);

            //double KQ = 0.09, QN = 1.06071247582524, APN = 0.549005076142132;
            //double KQ = 0.09, QN = 0.88294, APN = 0.549005076142132;
            //double APCN = SystemEmotorHandler.getAPCN(KQ, QN, APN);
            //Console.WriteLine(APCN);

            //double APC = 1.15, PN = 9.543, B = 0.915190696;
            //double APC = 3.23, PN = 9.543, B = 0.414382156;
            //double APC = 0.4, PN = 9.543, B = 1.03382686051491;

            //double NCD = SystemEmotorHandler.getNCD(APC, PN, B);
            //Console.WriteLine(NCD);

            //double PN = 9.543, APCN = 0.644469198966404;

            //double NCN = SystemEmotorHandler.getNCN(PN, APCN);
            //Console.WriteLine(NCN);

            //double NCD = 0.8835, NCN = 0.936739028469231;
            //double NCD = 0.5507, NCN = 0.936739028469231;
            //double NCD = 0.9615, NCN = 0.936739028469231;

            //double MER = SystemEmotorHandler.getMER(NCD, NCN);
            //Console.WriteLine(MER);

            //string MER_Judge = SystemEmotorHandler.getMER_Judge(NCD, NCN);
            //Console.WriteLine(MER_Judge);

            //double COSQ = 0.92;
            //double COSQ = 0.88;
            //String MEF_Judge = SystemEmotorHandler.getMEF_Judge (COSQ);
            //Console.WriteLine(MEF_Judge);


            //传动机构无计算算法


            ////藕合器测试



            ////风机测试



            //string VGJ_src;


            //double QFC = 31.2, PFC = 1.32, PFR = 1.29, PE1 = -170.7, PE2 = 36.6, V1 = 9.2258, V2 = 12.401;
            //double QFC = 26.2, PFC = 1.32, PFR = 1.29, PE1 = -170.7, PE2 = 36.6, V1 = 9.2258, V2 = 12.401;

            //double PYF = SystemDraughtFanHandler.getBlowerOutputPower(QFC, PFC, PFR, PE1, PE2, V1, V2);
            //Console.WriteLine(PYF);


            //PFC = SystemDraughtFanHandler.getPFC(T, PB, Q, P, AIR);
            //Console.WriteLine(PFC);

            //double QZ = 33.6, QI = 31.2;
            //double QZ = 27.1, QI = 26.2;
            //double QZ = 36.7, QI = 31.2;

            //double LIF = SystemDraughtFanHandler.getLIF(QZ, QI);
            //Console.WriteLine(LIF);

            //string LIF_Judge = SystemDraughtFanHandler.getLIF_Judge(QZ, QI);
            //Console.WriteLine(LIF_Judge);


            //double PTSR = 8.834,TIME = 6;
            //double PTSR = 7.834, TIME = 15;
            //double PTSR = 7.834, TIME = 132;

            //double WSRF = SystemDraughtFanHandler.getWSRF(PTSR, TIME);
            //Console.WriteLine(WSRF);

            //double WSRF = 70.2, PFC = 1.32, QV = 31.2, PFC1 = 137, T = 6;
            ////double WSRF = 189, PFC = 1.32, QV = 26.2, PFC1 = 137, T = 15;


            //double EW = SystemDraughtFanHandler.getEW(WSRF, PFC1, PFC, QV, T);
            //Console.WriteLine(EW);

            //string EW_Judge = SystemDraughtFanHandler.getEW_Judge(WSRF, PFC1, PFC, QV, T);
            //Console.WriteLine(EW_Judge);


            //double NJ = 7.922 / 9.99; double PJE = 9.99, PYE = 8.5;
            //double NJ = 6.652 / 9.63; double PJE = 9.99, PYE = 8.4;
            //double NJ = 5.8 / 10; double PJE = 10, PYE = 8.5;


            //double RJ = SystemDraughtFanHandler.getRJ(PJE, PYE,NJ);
            //Console.WriteLine(RJ);

            //string RJ_Judge = SystemDraughtFanHandler.getRJ_Judge(PJE, PYE, NJ);
            //Console.WriteLine(RJ_Judge);


            //VGJ_src = SystemDraughtFanHandler.getVGJ1(VGJ1);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ2(VGJ2);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ3(VGJ3,true);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ4(VGJ4,false);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ5(VGJ5,true);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ6(VGJ6);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ7(VGJ7);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ8(VGJ8);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ9(VGJ9);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ10(VGJ10);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ11(VGJ11);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ12(VGJ12);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ13(VGJ13);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ14(VGJ14);
            //Console.WriteLine(VGJ_src);
            //VGJ_src = SystemDraughtFanHandler.getVGJ15(VGJ15);
            //Console.WriteLine(VGJ_src);




            ////泵测试



            //string vgj_src;

            //double PB = 1000, QV = 0.005186, H = 160.54;
            //double PB = 1000, QV = 0.003978, H = 160.8;
            //double PB = 1000, QV = 0.006047, H = 159.8;

            //double PYB = SystemPumpHandler.getPumpOutputpower(PB,QV,H);
            //Console.WriteLine(PYB);

            //double PB = SystemPumpHandler.getPB(PA, T);
            //Console.WriteLine(PB);

            //vgj_src = SystemPumpHandler.getVGJ1(VGJ1);
            //Console.WriteLine(vgj_src);


            //vgj_src = SystemPumpHandler.getVGJ2(VGJ2);
            //Console.WriteLine(vgj_src);

            //vgj_src = SystemPumpHandler.getVGJ3(VGJ3, false);
            //Console.WriteLine(vgj_src);

            //vgj_src = SystemPumpHandler.getVGJ4(VGJ4);
            //Console.WriteLine(vgj_src);

            //vgj_src = SystemPumpHandler.getVGJ5(VGJ5);
            //Console.WriteLine(vgj_src);

            //double QZ = 2.63, QI = 2.58;
            //double QZ = 3.96, QI = 3.95;
            //double QZ = 4.56, QI = 4.53;

            //double LIF = SystemPumpHandler.getLIF(QZ, QI);
            //Console.WriteLine(LIF);

            //string LIF_Judge = SystemPumpHandler.getLIF_Judge(QZ, QI);
            //Console.WriteLine(LIF_Judge);

            //double PRB = 8.834, TIME = 6;
            //double PRB = 8.834, TIME = 15;
            //double PRB = 8.834, TIME = 132;



            //double WSRB = SystemPumpHandler.getWSRB(PRB, TIME);
            //Console.WriteLine(WSRB);



            double WSRB = 53.00, PB = 1000, QV = 18.67, H = 160.54, TIME = 6;
            //double WSRB = 132.51, PB = 1000, QV = 14.32, H = 160.8, TIME = 15;
            //double WSRB = 1166.09, PB = 1000, QV = 21.77, H = 159.8, TIME = 132;



            decimal EB = PumpHandler.getEB(WSRB, PB, QV, H, TIME);
            Console.WriteLine(EB);

            //string EB_Judge = SystemPumpHandler.getEB_Judge(WSRB, PB, QV, H, TIME);
            //Console.WriteLine(EB_Judge);

            //double N = 8.15 / 10.98, PYE = 10.23, PJE = 12.89;
            //double N = 9.75 / 13.29, PYE = 13.32, PJE = 15.23;
            //double N = 7.47 / 13.84, PYE = 12.12, PJE = 14.97;

            //double RJ = SystemPumpHandler.getRJ(N,PYE,PJE);
            //Console.WriteLine(RJ);

            //string RJ_Judge = SystemPumpHandler.getRJ_Judge(N, PYE, PJE);
            //Console.WriteLine(RJ_Judge);

            ////空压机测试

            //double P = 3.739897075, N = 0.7226,PP = 1.6,PM = 0.7,VG1 = 4.5,VG2 = 7.3,VG3 = 16,
            //QZ = 2.3,QI = 2.0,QP = 30,TX = 20,TP = 24,PX = 0.8,PR = 2.2,K1 = 0.88,CC = 1500,TIME=10.0;
            //int type=4,poles=1,force=2,inputPower=2;

            //double PA, T, QH;
            ////PA = 0.1013; T = 0; QH = 0;
            ////PA = 0.1013; T = 0; QH = 0.5;
            ////PA = 0.1013; T = 25; QH = 1;
            ////PA = 0.1013; T = 30; QH = 1;
            //PA = 0.1013; T = 30; QH = 0.75;


            //double pfc = SystemDraughtFanHandler.getPFC(PA, T, QH);
            //Console.WriteLine(pfc);

            //double T=59;
            //double pwb = SystemDraughtFanHandler.getPWB(T);
            //Console.WriteLine(pwb);

            //double PP = 0.8, PM = 0.68;
            //double PP = 0.8, PM = 0.73;

            //double VG = SystemAirCompressorHandler.getVGJ(PP, PM);
            //Console.WriteLine(VG);

            //string VG_Judge = SystemAirCompressorHandler.getVGJ_Judge(PP, PM);
            //Console.WriteLine(VG_Judge);

            //String VG1_A = SystemAirCompressorHandler.getVGJ1(VG1);
            //Console.WriteLine(VG1_A);

            //String VG2_A = SystemAirCompressorHandler.getVGJ2(VG2);
            //Console.WriteLine(VG2_A);

            //String VG3_A = SystemAirCompressorHandler.getVGJ3(VG3);
            //Console.WriteLine(VG3_A);


            //double QZ = 6.5, QI = 5.4;
            //double QZ = 8.4, QI = 8.0;
            //double QZ = 11.9, QI = 10.9;


            //double LIC = SystemAirCompressorHandler.getLIC(QZ, QI);
            //Console.WriteLine(LIC);

            //string LIC_Judge = SystemAirCompressorHandler.getLIC_Judge(QZ, QI);
            //Console.WriteLine(LIC_Judge);

            //double QP = 324, TX = 10, TP = 20, PP = 0.8, PX = 0.1013;
            //double QP = 480, TX = 10, TP = 20, PP = 0.8, PX = 0.1013;
            //double QP = 654, TX = 10, TP = 20, PP = 0.8, PX = 0.1013;

            //double QX = SystemAirCompressorHandler.getQX(QP, TX, TP, PP, PX);
            //Console.WriteLine(QX);

            //double PR = 45, TIME = 6; 
            //double PR = 63, TIME = 12;


            //double ERC = SystemAirCompressorHandler.getERC(PR, TIME);
            //Console.WriteLine(ERC);


            //double PP = 0.8, PX = 0.1013;
            //int poles = 1;
            ////int poles = 2;

            //double K2 = SystemAirCompressorHandler.getK2(PP, PX, poles);
            //Console.WriteLine(K2);
            //double CC = 45, ERC = 270, QX = 1944, K2 = 1.095, K1 = 1;
            //double CC = 63, ERC = 756, QX = 5760, K2 = 1.007, K1 = 0.88;
            //double CC = 75, ERC = 900, QX = 7848, K2 = 1.007, K1 = 0.88;

            //double WG = SystemAirCompressorHandler.getWG(ERC, QX, K1, K2);
            //Console.WriteLine(WG);

            //string WG_Judge = SystemAirCompressorHandler.getWG_Judge(CC, ERC, QX, K1, K2);
            //Console.WriteLine(WG_Judge);

             //8，1,5,21
             // 9，1,5,23
             // 9，1,5,24
            //double QP = 5.4, PR = 45;
            //int type = 8, poles = 1, force = 5, inputPower = 21;

            //double QP = 8, PR = 63;
            //int type = 9, poles = 1, force = 5, inputPower = 23;

            //double QP = 10.9, PR = 75;
            //int type = 9, poles = 1, force = 5, inputPower = 24;

            //double PB = SystemAirCompressorHandler.getPB(PR,QP);
            //Console.WriteLine(PB);

            //string PB_Judge = SystemAirCompressorHandler.getPB_Judge(PR, QP, type, poles, inputPower, force);
            //Console.WriteLine(PB_Judge);

            ////输送管路测试

            //double H = 74.77, HG = 200, HA = 30, HC = 200, PC = 0.03, PY = 1.36,
            //    QV = 10, PFC = 2.4, PFG = 1.200683122, P3 = 1.3, P2 = 1.5, V3 = 30, V2 = 25,
            //    RearPower = 3.216311485,FrontPower = 3.739897075;



            //double NG_1 = SystemPipelineHandler.getNG_1(RearPower, FrontPower);
            //Console.WriteLine(NG_1);

            //double H = 165.54, HG = 128, HC = 200, HA = 10;
            //double H = 160.8, HG = 132, HC = 200, HA = 15;

            //double NG = SystemPipelineHandler.getNG(H, HG, HC, HA);
            //Console.WriteLine(NG);


            //double QV = 31.2, PFC = 1.36, PFG = 1.32, P3 = 32.3, P2 = 36.6, V3 = 12.6, V2 = 12.7;
            //double QV = 26.2, PFC = 1.42, PFG = 1.37, P3 = 33.5, P2 = 36.6, V3 = 12.9, V2 = 13.4;

            //double PYF = SystemPipelineHandler.getPYF(QV, PFC, PFG, P3, P2, V3, V2);
            //Console.WriteLine(PYF);

            //double PC = 0.0089, PY = 0.1013;
            //double PC = 0.0004, PY = 0.1013;

            //double NG_A = SystemPipelineHandler.getNG_A(PC, PY);
            //Console.WriteLine(NG_A);

            ////系统输出测试
            //double P = 3.216311485, PSR = 5.624;

            //double N = SystemOutputHandler.getN(P, PSR);
            //Console.WriteLine(N);

            ////能量平衡测试

            //double WSK = 0.1, WSD = 0.2, WSC = 0.2, WSS = 0.2, WSG = 0.1, PYJ = 3.739897075,
            //       PY = 3.216311485, TIME = 10, NG = 0.86, N = 0.571890378, PSR = 5.624;


            //double WSR = SystemEnergyBalanceHandler.getWSR(PSR, TIME);
            //Console.WriteLine(WSR);

            //double WYJ = SystemEnergyBalanceHandler.getWYJ(PYJ, TIME);
            //Console.WriteLine(WYJ);


            //double WS = SystemEnergyBalanceHandler.getWS(WSK, WSD, WSC, WSS, WSG);
            //Console.WriteLine(WS);


            //double WY = SystemEnergyBalanceHandler.getWY_1(PY, TIME);
            //Console.WriteLine(WY);
            //WY = SystemEnergyBalanceHandler.getWY_2(WYJ, NG);
            //Console.WriteLine(WY);
            //WY = SystemEnergyBalanceHandler.getWY_3(WSR, N);
            //Console.WriteLine(WY);

            //double HJ = SystemEnergyBalanceHandler.getHJ_1(WYJ, WSR);
            //Console.WriteLine(HJ);
            //HJ = SystemEnergyBalanceHandler.getHJ_2(WSR, WSR, WSD, WSC, WSS);
            //Console.WriteLine(HJ + "  此公式有问题！！！");


            //double HY = SystemEnergyBalanceHandler.getHY_1(WY, WSR);
            //Console.WriteLine(HY);
            //HY = SystemEnergyBalanceHandler.getHY_2(WS, WSR);
            //Console.WriteLine(HY);


        }

    }
}
