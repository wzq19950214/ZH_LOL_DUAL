using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GTR;

namespace GTR
{
    class Program
    {
        public static int AppRunTime = 0;

        public static bool bRelease = false;//�Ƿ�Ϊ���ϰ�
        private static Thread Fun1Proc;
        public static uint pid = User32API.GetCurrentProcessId();

        public static void Fun1()
        {

            while (true)
            {
                AppRunTime++;
                Thread.Sleep(1000);
                if (AppRunTime > 0 && AppRunTime % 20 == 0)
                {
                    if (AppRunTime > 300)
                        break;
                    LOL.udpdd.theUDPSend(18, "���������У����Ե�...", LOL.OrdNo);
                    Console.WriteLine(AppRunTime.ToString());
                }
            }
        }
        /// <summary>
        /// Ӧ�ó��������ڵ㡣
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Fun1Proc = new Thread(new ThreadStart(Fun1));
            // C#���̱߳��ʱ��Thread�����и�IsBackground���ԣ�����Ϊtrue���ɣ������̹߳ر�ʱ�����߳���֮�ر�
            Fun1Proc.IsBackground = true;

            Fun1Proc.Start();

            LOL.udpdd = new udpSockets();
            LOL.the_nRC2Port = 0;//����
            if (args.Length > 0)
            {
                bRelease = true;
                LOL.OrdNo = args[0];
                LOL.the_nRC2Port = Convert.ToInt32(args[2]);
                Console.WriteLine("����");
                Console.WriteLine(args.Length);//3
                Console.WriteLine(args[0]);//������
                Console.WriteLine(args[1]);//0
                Console.WriteLine(args[2]);//�˿ں�
            }
            LOL.udpdd.udpInit("127.0.0.1", LOL.the_nRC2Port);
            LOL.m_UDPPORT = LOL.udpdd.localPort;
            LOL lol = new LOL();
            try
            {
                lol.StartToWork();
            }
            catch (Exception e)
            {
                System.Environment.Exit(-1);//�˳�����̨
            }
            Fun1Proc.Abort();//��ֹ�߳�
            LOL.udpdd.Close();//�ر�UDP ��������������̨ ��ΪUDP�Ƚ�����
            System.Environment.Exit(0);//�˳�����̨
        }
    }
}
