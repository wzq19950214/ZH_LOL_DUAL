using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging; //ImageFormat.Jpeg
using System.Web;
using System.Web.Security;
using System.Net;
using System.Net.Sockets;
using System.Management;
using System.Text.RegularExpressions;//����
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Pipes;
using System.Security.Principal;
using System.Linq;
using System.Runtime.InteropServices;
using RC_ZH_LOL;
//using System.Threading.Tasks;
namespace GTR
{
    class LOL
    {
        #region ��ʼ��ͨ�ű���
        //��������
        public static string m_strOrderData;
        //udpsockets
        public static udpSockets udpdd;
        //��֤�뷵��
        public static string mouseP = "";
        //��֤��ش����
        public int yzmTimes = 0;
        //�ű��˿�
        public static int m_UDPPORT = 6801;
        //RC����˿�
        public static int the_nRC2Port = 1;
        //��������-���׵�/������
        public static string m_strOrderType;
        //������
        public static string OrdNo = "���Զ���"; //"MZH-160607000000001";
        //����״̬
        public int Status;
        public int IsStop = 1;
        public static IntPtr ChangerHWND;

        #endregion

        #region ��ʼ���������

        int IsCallPone = 1;
        string m_mobible = "";
        int WeGametime = 0;
        bool noDel = false;
        bool IsGetZie = false;
        bool IsSucess = false;
        bool IsOpen = false;
        bool ClosePipe = false;
        public string IsNeedRecognition;
        //��ͼĬ�ϳߴ�
        public const int Lwidth = 1280;
        public const int Lheight = 1200;
        public const int nZHPicWidth = 880;
        //ƴͼ�Ƿ�����
        public bool bPicFull = false;
        public Point ptBigPic;
        //�Ƿ�����¹���
        bool isTest = false;
        //װ����ͼ�ߴ�
        public Point ptMAX;
        static int PicNum = 1;
        static string strLastPicID = "";
        string m_strLastName;
        int m_nPicNum;
        static int picNum = 0;
        public int time = 0;
        public int QWE = 0;
        //ƴͼ�Ҳ���ͼƬ����
        int C = 0;
        //ӵ�з���ҳ��
        public int RenusNum;
        //ӵ�е�Ӣ������
        public Int64 intHero = 0;
        //ӵ�е�Ƥ������
        public Int64 intSkin = 0;
        //ӵ�еĽ��
        public Int32 intCoin = 0;
        public Int32 intLevel = 0;
        //��ȯ
        public Int32 djc = 0;
        public bool IsNewGame = false;
        //�����ͼĿ¼
        public bool IsSendCapPath = false;
        //Ƥ����ͼ�Ƿ��Ѿ����
        public bool IsCapSkin = false;
        //��λ
        public string Level = "��ǰ������";
        //�ȼ�
        public string grade = "";
        //QQ��������
        string FriendNumber = "";
        //���֤��
        string IDNumber = "";
        //QQ�ȼ�
        string QQLevel = "";
        string emailband = "";
        //���ֻ�����
        string BoundMobilePhoneNumber = "";
        string FriendN = "";
        bool zzb = true;

        //�������ļ�������
        string[] FileArr;
        bool isGoTGP = true;
        string wwPath = m_strPicPath + "ww\\";
        int writetime = 0;

        struct CoinStruct
        {
            public int x;
            public String no;
        }
        //�����־
        public static bool IsAnswer;
        //�ʼı�־
        public static bool IsAskMail;
        //�ƽ���־
        public static bool bYiJiao = false;
        //������Ϸ��־
        public static bool IfEnter = false;
        //Mվ�㶩����־
        public static bool MZH = false;
        string QQstuctd;
        //��֤�루jpg��
        string mousea;
        //���ھ��
        public static IntPtr m_hGameWnd;
        public static IntPtr HwndWnd;
        public static IntPtr m_hGameWndTGP;
        //��������·��
        private string m_strProgPath = System.Windows.Forms.Application.StartupPath;
        //ƥ��ͼƬ·��
        public static string m_strPicPath = System.Windows.Forms.Application.StartupPath + @"\Ӣ������\";
        //�쳣��ͼ����·��
        public static string LocalPicPath = "E:\\ƴͼ\\";
        public static string ReadPath = System.Windows.Forms.Application.StartupPath;
        public static string StartPath = System.Windows.Forms.Application.StartupPath;
        //[WebMethod]
        //public string Project(string paramaters)
        //{

        //    return paramaters;

        //}
        //������ϸ����
        public string m_strVirtualIP;
        public string m_strLocalIP;
        public string m_GameTitle;
        public string m_strGamePath;
        public string m_strAccount = "";
        public string m_strPassword;
        public string m_strGameName;
        public string m_strArea;
        public string m_strServer;
        public string m_strSellerRole;
        public string m_strSecondPwd;
        public string m_strGameStartFile;
        public string m_strMbkID;
        public string m_strMbkImage;
        public string m_strMbkString;
        public string m_strCapturePath = "";
        public string m_GameId;
        public string GameID;
        public static StringBuilder strb = new StringBuilder();
        #endregion
        //���������
        public void StartToWork()
        {
            #region ������ж� IP��ȡ �쳣��ͼĿ¼����
            //��ȡ�����ű�����·�����ַ�����һλ
            string ss = StartPath.Substring(0, 1);
            StringBuilder strBuildera = new StringBuilder(512);
            StringBuilder strBuilderb = new StringBuilder(512);

            if (ss == "C")
            {
                WriteToFile("�û�Ϊ�����");
                User32API.GetPrivateProfileString("�����·����Ϣ", "��ͼ·��", "", strBuildera, 512, ReadPath + "\\CaptruePath.ini");
                User32API.GetPrivateProfileString("�����·����Ϣ", "�쳣��ͼ·��", "", strBuilderb, 512, ReadPath + "\\CaptruePath.ini");
                m_strCapturePath = strBuildera.ToString();
                LocalPicPath = strBuilderb.ToString();
                m_strLocalIP = FileRW.ReadFile("Z:\\jiaoben\\IP.txt");
                if (m_strLocalIP == "")
                {
                    WriteToFile("ʵ���IPδ����");
                }
                string tmp1 = string.Format("�����IP:{0},ʵ���IP:{1}", Game.GetLocalIp(), m_strLocalIP);
                WriteToFile(tmp1);
                WriteToFile(m_strCapturePath);
                //WriteToFile("��ͼ·��{0},���ؽ�ͼ·��{1}", m_strCapturePath, LocalPicPath);
                if (m_strCapturePath == "")
                {
                    WriteToFile("�Ҳ�����ͼ��š��쳣·������Ҫ�ڸ�����������F��");
                    Status = 2260;
                }
            }
            if (ss == "E")
            {
                WriteToFile("�û�Ϊ������");
                User32API.GetPrivateProfileString("������·����Ϣ", "��ͼ·��", "", strBuildera, 512, ReadPath + "\\CaptruePath.ini");
                User32API.GetPrivateProfileString("������·����Ϣ", "�쳣��ͼ·��", "", strBuilderb, 512, ReadPath + "\\CaptruePath.ini");
                m_strCapturePath = strBuildera.ToString();
                LocalPicPath = strBuilderb.ToString();
                if (m_strCapturePath == "")
                {
                    WriteToFile("�Ҳ�����ͼ��š��쳣·����");
                }
                WriteToFile(m_strCapturePath);
                User32API.WinExec("rasphone -h �������", 2); //��
                Sleep(1000);
                User32API.WinExec("rasphone -d �������", 2); //��
                for (int i = 0; i < 8; i++)
                {
                    if (User32API.FindWindow(null, "�������ӵ� �������...") != IntPtr.Zero)
                    {
                        Sleep(3000);
                        WriteToFile("���������...");
                    }
                    if (User32API.FindWindow(null, "���ӵ� ������� ʱ����") != IntPtr.Zero)
                    {
                        WriteToFile("���󲦺�ʧ�ܲ����в���");
                        Game.tskill("rasphone");
                        Sleep(500);
                        if (User32API.FindWindow(null, "���ӵ� ������� ʱ����") == IntPtr.Zero)
                            break;
                    }
                    if (User32API.FindWindow(null, "��������") != IntPtr.Zero)
                    {
                        WriteToFile("����ʧ�ܲ����в���");
                        Game.tskill("rasphone");
                        if (User32API.FindWindow(null, "��������") == IntPtr.Zero)
                            break;
                    }
                }
            }
            ss = string.Format("�����ű��ļ�����·��������ĸ��{0}", ss);
            WriteToFile(ss);
            #endregion
            m_hGameWnd = User32API.GetDesktopWindow();
            try
            {
                DeleteFolder(LocalPicPath, 7);
                Status = GameProc();

                if (Status > 1000)
                {
                    Point pt = new Point();
                    CaptureJpg("����ʧ��");
                }
            }
            catch (System.Exception ex)
            {
                WriteToFile(ex.ToString());
                Status = 2120;
            }
            CloseGames();
            if (MZH && Status != 1000)
            {
                if (Status > 2000 && Status < 3000)
                    Status += 2000;
            }
            string tmp = "";
            string IPoneList = "";
            IPoneList = FileRW.ReadFile("ipone.txt");
            if (Status == 1000)
            {
                tmp = string.Format("��ͼ�ɹ�,��{0}��\r\n", picNum);
                WriteToFile(tmp);
            }

            if (Status > 1000)
            {
                FileRW.DeleteTmpFiles(m_strCapturePath + OrdNo);
            }
            if ((Status == 3000 || Status == 3333) && m_mobible != "" && m_strOrderType == "������" && !OrdNo.Contains("M") && !IPoneList.Contains(m_mobible))
            {
                //-------�绰����---------
                if (IsCallPone == 0)
                {
                    string PostData = string.Format("gameId={0}&OrdNo={1}&Status={2}", "60", OrdNo, Status);
                    string strHTML = PostUrlData(" http://172.16.74.147:8010/WebService.asmx/SetPhoneData", PostData);
                    WriteToFile(strHTML);
                    Status = 3333;
                    tmp = string.Format("�ƽ�״̬={0}\r\n", Status);
                    WriteToFile(tmp);
                    tmp = string.Format("FStatus={0}\r\n", Status);
                }
                if (IsCallPone == 1 && Status == 3333)
                {
                    string PostData = string.Format("Method=CallSellerMobFB&OrderNO={0}&SellerMob={1}&GameName=Ӣ������", OrdNo, m_mobible);
                    string strHTML = PostUrlData("http://192.168.36.8/OrderAid.aspx", PostData);


                    WriteToFile("�Ѳ�������" + m_mobible.ToString() + "�绰");

                    //�ӿ�2,������

                    string SendData = string.Format("��5173����{0}�ڽ�ͼ��֤�г���������,�뽫�����޸�Ϊԭ�����0,�޸���ɺ�ظ���xmm��Ϊ�����½�ͼ��", m_strAccount);
                    PostData = string.Format("Method=SendM&SendContent={0}&SendMob={1}&OrderNO={2}", SendData, m_mobible, OrdNo);
                    string strHTML2 = PostUrlData("http://192.168.36.8/OrderAid.aspx", PostData);

                    WriteToFile("�ѷ��Ͷ���");

                    PostData = string.Format("gameId={0}&OrdNo={1}&Status=0", "60", OrdNo);
                    string strHTML3 = PostUrlData(" http://172.16.74.147:8010/WebService.asmx/SetPhoneData", PostData);
                    WriteToFile(strHTML3);


                    DateTime CurrentTime = System.DateTime.Now.AddHours(1);
                    string strYMD = CurrentTime.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    tmp = string.Format("�ƽ�״̬={0}\r\nFPlanTime={1}\r\n", 0, strYMD);
                    WriteToFile(tmp);
                    WriteToFile("�´�ִ��ʱ��" + strYMD);
                }

                if (IsCallPone == 1 && Status == 3000)
                {
                    tmp = string.Format("�ƽ�״̬={0}\r\n", Status);
                    WriteToFile(tmp);
                    tmp = string.Format("FStatus={0}\r\n", Status);
                }
                //-----------------------
            }
            else
            {
                if (IPoneList.Contains(m_mobible) && Status==3333)
                    WriteToFile("�������Ѻ��Դ�绰");
                tmp = string.Format("�ƽ�״̬={0}\r\n", Status);
                WriteToFile(tmp);
                tmp = string.Format("FStatus={0}\r\n", Status);
            }

            #region//�ټ�¼������� ������ʧ��5���������ԣ�Ƶ���������¶�����ʱ��
            StringBuilder retVal = new StringBuilder(256);
            User32API.GetPrivateProfileString("��¼����", "ADSL��������", "", retVal, 256, m_strProgPath + "\\adsl.ini");
            int num = 0;
            if (retVal.ToString() != "")
                num = int.Parse(retVal.ToString());
            if (num > 100)
            {
                User32API.WritePrivateProfileString("��¼����", "ADSL��������", "0", m_strProgPath + "\\adsl.ini");
                Sleep(2500);
            }
            else
            {
                if ((Status > 1000 && Status < 3000) || Status > 4000)
                {
                    string strNum = string.Format("{0}", num + 20);
                    User32API.WritePrivateProfileString("��¼����", "ADSL��������", strNum, m_strProgPath + "\\adsl.ini");
                }
            }


            StringBuilder retVal1 = new StringBuilder(256);
            User32API.GetPrivateProfileString("��¼����", "����ʧ��", "", retVal1, 255, m_strProgPath + "\\adsl.ini");
            int num1 = int.Parse(retVal1.ToString());
            if ((Status > 1000 && Status < 3000 && Status != 3333) || (Status > 4000 && Status != 4050))
            {
                if (num1 == 5)
                {
                    User32API.WritePrivateProfileString("��¼����", "����ʧ��", "0", m_strProgPath + "\\adsl.ini");
                    RestartPC();//��������
                }
                else
                {
                    string strNum1 = string.Format("{0}", num1 + 1);
                    User32API.WritePrivateProfileString("��¼����", "����ʧ��", strNum1, m_strProgPath + "\\adsl.ini");

                }
            }
            #endregion

            if (the_nRC2Port != 0)
            {
                for (int j = 0; j < 2; j++)
                {
                    try
                    {
                        udpdd.theUDPSend((int)TRANSTYPE.TRANS_ORDER_END, tmp, OrdNo);//����UDP
                    }
                    catch (Exception ex)
                    {
                        WriteToFile(ex.ToString());
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        if (bYiJiao)
                        {
                            WriteToFile("�ƽ��ɹ�");

                            break;
                        }
                        Sleep(100);
                    }
                    if (bYiJiao)
                    {
                        break;
                    }
                    if (j == 1)
                        WriteToFile("�ƽ�ʧ��");
                }
            }
            else
            {
                WriteToFile("�˿�Ϊ0");
            }
            return;
        }
        /// ������
        /// <returns>����״̬</returns>
        public int GameProc()
        {
            #region �����������
            if (!KeyMouse.InitKeyMouse())
            {
                WriteToFile("��������ʧ��");
                return 2260;
            }
            #endregion

            #region �ж϶����������󶩵���Ϣ
            if (OrdNo.IndexOf("MZH") == 0)
                MZH = true;
            int n = OrdNo.IndexOf("-");
            if (n > 0 || OrdNo == "���Զ���" || MZH)
                m_strOrderType = "������";
            else
                m_strOrderType = "���׵�";
            if (!RequestOrderData())
                return 2260;
            if (!ReadOrderDetail())
                return 2260;
            #endregion

            #region �˺��������
            if (Regex.IsMatch(m_strAccount, @"[\u4e00-\u9fa5]"))
            {
                WriteToFile("�˺ź�������");
                WriteToFile(m_strAccount);
                return 3000;
            }
            if (Regex.IsMatch(m_strPassword, @"[\u4e00-\u9fa5]"))
            {
                WriteToFile("���뺬������");
                WriteToFile(m_strPassword);
                return 3000;
            }
            #endregion

            #region ��ȡ�˺��Ƿ����绰

            //-----------��������-----------
            //m_mobible = "18672290630";
            //string IPoneList = FileRW.ReadFile("ipone.txt");
            //if (!IPoneList.Contains(m_mobible)) {
            //    Sleep(1000);
            //}
            
            //OrdNo = "DB088-20171025-34361693";
            //Status = 3000;
            //-----------------------------
            if (m_mobible != "" && OrdNo.Contains("-") && !OrdNo.Contains("MZH"))
            {
                string postData = string.Format("PublishNO={0}", OrdNo);
                string strHTML = PostUrlData("http://gtr.5173.com:7080/RobotCallback.asmx/MobileResult", postData);
                IsCallPone = Convert.ToInt32(MyStr.FindStr(strHTML, "/\">", "</string>"));
                if (IsCallPone == 0)
                {
                    WriteToFile("��ҳ��ȡֵΪ��" + IsCallPone.ToString() + ",�Ѿ���������ҵ绰");
                    m_strPassword += "0";
                    WriteToFile("����ԭ�����ϼ�0");
                }
                else
                {
                    WriteToFile("��ҳ��ȡֵΪ��" + IsCallPone.ToString() + ",δ��������ҵ绰");
                }
            }
            else
                WriteToFile("����û����д�ֻ��Ż�����վ������");
            #endregion

            AppInit();//IP��ַ �汾��
#if DEBUG
            
            m_hGameWnd = User32API.FindWindow(null, "��Ѷ��Ϸƽ̨");
            if (m_hGameWnd != IntPtr.Zero)
            {
            }
#else
#endif
            for (int i = 0; i < 3; i++)
            {

                #region �رս���
                CloseGames();
                m_hGameWnd = User32API.GetDesktopWindow();
                for (int j = 0; j < 40; j++)
                {
                    int a = 5;
                    a = a * j;
                    Sleep(30);
                    KeyMouse.MouseMove(m_hGameWnd, 926 + a, 1007);
                }
                #endregion

                #region ��ҳ������֤
                if (MZH && i == 0)
                {
                    try
                    {
                        int a = ReadQQ();
                        if (a == 3000 || a == 3333)
                        {
                            return a;
                        }

                    }
                    catch (Exception e)
                    {
                        WriteToFile(e.ToString());
                    }

                    if (!zzb)
                        return 3301;
                }
                #endregion

                #region TGP Э���ȡ����
                Status = GetHeroAndSkin();
                if (Status <= 1000)
                {
                    try
                    {
                        LOLRead(m_strProgPath + @"\RoleInfo.txt");//��ȡ�˺���Ϣ
                        if (Status == 3010)
                            return Status;
                    }
                    catch (Exception ex)
                    {
                        WriteToFile(ex.ToString());
                    }
                    if (Status != 1000)
                        return 2120;
                    if (intHero > 0)
                        Status = ReplaceTGP(true, m_strProgPath + @"\Hero\");//Ӣ��ƴͼ
                    if (intSkin > 0 && Status <= 1000)
                        Status = ReplaceTGP(false, m_strProgPath + @"\Skin\");//Ƥ��ƴͼ 

                }
                #endregion

                #region TGP��¼��֤�˺� �Ƿ������ ������֤
                if (Status > 1000 && i < 1 && Status != 3333)
                {
                    CloseGames();
                    Status = RunGame();//����TGP
                    if (Status > 1000)
                    {
                        IsSucess = true;
                        continue;
                    }
                    Status = EnterAccPwd();
                    if (Status == 2120)
                        continue;
                }
                #endregion

                #region TGP��֤��¼�ɹ� Э���ȡʧ�� ��ҳ���߷���
                if ((IsSucess && (Status == 3000 || Status == 3700)) || Status == 2260)
                {
                    if (true)
                    {
                        WriteToFile("TGP��¼�ɹ������쳣,ʹ��LOL��ҳ����");
                        IsGetZie = true;
                        GetLOLInfo();
                        try
                        {
                            LOLRead2(m_strProgPath + @"\RoleInfo.txt");
                        }
                        catch (Exception ex)
                        {
                            WriteToFile("��ҳ��ȡʧ��");
                        }
                        if (intHero > 0)
                            Status = ReplaceTGP(true, m_strProgPath + @"\Hero\");//Ӣ��ƴͼ
                        if (intSkin > 0 && Status <= 1000)
                            Status = ReplaceTGP(false, m_strProgPath + @"\Skin\");//Ƥ��ƴͼ 
                    }

                }
                #endregion

                #region ����������ͻ�ȡ������
                if (Status == 1000 && MZH)
                {
                    WriteToFile("������������ʺ���Ϣ");
                    try
                    {
                        AutoVerifya();
                    }
                    catch (Exception ex)
                    {
                        WriteToFile(ex.ToString());
                        WriteToFile("������������ʺ���Ϣ�쳣");
                    }

                }
                #endregion

                CloseGames();
                break;
            }
            return Status;
        }
        // ����TGP
        public int RunGame()
        {

            bool NoPlayWeGame = false;

            Point pc = new Point(0, 0);
            Point pd = new Point(0, 0);
            Point pt = new Point(0, 0);
            Point pa = new Point(-1, -2);
            Point pb = new Point(-1, -2);
            RECT ra = new RECT();
            //Ѱ��TGP����
            for (int i = 0; i < 20; i++)
            {
                m_GameTitle = "��Ѷ��Ϸƽ̨";
                m_hGameWnd = User32API.FindWindow(null, m_GameTitle);
                if (m_hGameWnd == IntPtr.Zero)
                    m_hGameWnd = User32API.FindWindow(null, "WeGame");
                //���Ϊ�գ�����ָ��·������Ϸ
                if (m_hGameWnd == IntPtr.Zero)
                {
                    //Game.StartProcess(m_strGameStartFile, "start");
                    myapp.RunBat(m_strGameStartFile);
                    WriteToFile(m_strGameStartFile);
                    //�ж�TGP����Ƿ����
                    m_GameTitle = "��Ѷ��Ϸƽ̨";
                    m_hGameWnd = User32API.FindWindow(null, m_GameTitle);
                    if (m_hGameWnd == IntPtr.Zero)
                        m_hGameWnd = User32API.FindWindow(null, "WeGame");
                    Sleep(1000);

                    //Ѱ���˺ŵ�¼����
                    for (int y = 0; y < 60; y++)
                    {
                        Sleep(1000);
                        m_hGameWnd = User32API.FindWindow(null, m_GameTitle);
                        if (m_hGameWnd == IntPtr.Zero)
                            m_hGameWnd = User32API.FindWindow(null, "WeGame");
                        if (m_hGameWnd == IntPtr.Zero)
                            continue;

                        pa = ImageTool.fPic(m_strPicPath + "TGP��¼.bmp", 0, 0, 0, 0);
                        pt = ImageTool.fPic(m_strPicPath + "�˺ŵ�¼����.bmp", 0, 0, 0, 0);
                        pb = ImageTool.fPic(m_strPicPath + "TGP��¼2.bmp", 0, 0, 0, 0);
                        pc = ImageTool.fPic(m_strPicPath + "TGP��¼3.bmp", 0, 0, 0, 0);
                        pd = ImageTool.fPic(m_strPicPath + "WeGame��¼.bmp", 838, 423, 1069, 713);
                        if (pt.X > 0 || pa.X > 0 || pb.X > 0 || pc.X > 0 || pd.X > 0)
                        {
                            WriteToFile("����WeGame�˺��������");
                            return 1;
                        }
                        if (y % 3 == 0 || y > 0)
                        {
                            pa = ImageTool.fPic(m_strPicPath + "��¼����.bmp", 0, 0, 0, 0);
                            if (pa.X > 0)
                            {
                                WriteToFile("WeGameֹͣ����");
                                KeyMouse.MouseClick(pa.X + 5, pa.Y + 5, 1, 1, 1000);
                                Game.RunCmd("taskkill /im  tgp_daemon.exe /F");
                                Game.RunCmd("taskkill /im  werfault.exe /F");//�ر�
                                break;
                            }
                            pa = ImageTool.fPic(m_strPicPath + "��Ϸ����.bmp", 0, 0, 0, 0);
                            if (pa.X > 0)
                            {
                                KeyMouse.MouseClick(pa.X + 5, pa.Y + 5, 1, 1, 1000);
                            }
                        }
                        if (y % 6 == 0)
                        {
                            WriteToFile("�ȴ�TGP����");
                        }
                        Sleep(2000);
                    }
                }
                else
                {
                    //����ָ������
                    User32API.SwitchToThisWindow(m_hGameWnd, true);
                    User32API.SetForegroundWindow(m_hGameWnd);
                }

            }
            WriteToFile("WeGame����������ʮ��");
            return 2260;
        }
        //�����ʺ�����      
        public int EnterAccPwd()
        {
            //--------------------------------------------------
            //WriteToFile("TGP��¼�ɹ�");
            //IsSucess = true;
            //return 2120;
            // -------------------------------------------------
            #region ��ʼ������
            Point pa = new Point(-1, -2);
            Point pb = new Point(-1, -2);
            Point pt = new Point(-1, -2);
            Point at = new Point(-1, -2);
            Point pc = new Point(-1, -2);
            Point pd = new Point(-1, -2);
            Point pf = new Point(-1, -2);
            Point ae = new Point(-1, -2);
            Point po = new Point(-1, -2);
            Point pw = new Point(-1, -2);
            Point pl = new Point(-1, -2);
            Point paa = new Point(-1, -2);
            Point pbb = new Point(-1, -2);
            Point st = new Point(-1, -2);
            RECT rt = new RECT(0, 0, 1024, 768);
            //��֤��
            string Yzm = "";
            //�����������
            int k = 0;
            //�˺��������
            int l = 0;
            m_GameTitle = "��Ѷ��Ϸƽ̨";
            m_hGameWnd = User32API.FindWindow(null, m_GameTitle);
            if (m_hGameWnd == IntPtr.Zero)
                m_hGameWnd = User32API.FindWindow(null, "WeGame");
            #endregion
            //�ô���ʼ������ǰ��������������߳�ӵ�нϸ߷���Ȩ����������ת�����߳�
            User32API.SetForegroundWindow(m_hGameWnd);
            for (int q = 0; q < 6; q++)
            {
                Sleep(3000);

                #region �ɰ�TGP
                pt = ImageTool.fPic(m_strPicPath + "�˺ŵ�¼����.bmp", 0, 0, 0, 0);
                pa = ImageTool.fPic(m_strPicPath + "TGP��¼.bmp", 0, 0, 0, 0);
                if (pt.X > 0 || pa.X > 0)
                {
                    #region �����˺����벢��½
                    //����˺������
                    KeyMouse.MouseClick(m_hGameWnd, 425, 75, 1, 2, 1000);
                    //ģ���������Backspace
                    for (int a = 0; a < 2; a++)
                    {
                        KeyMouse.SendBackSpaceKey(2);
                        Sleep(500);
                    }
                    WriteToFile("�����˺�");
                    //�����˺�
                    KeyMouse.SendKeys(m_strAccount, 200);
                    Thread.Sleep(1000);
                    KeyMouse.MouseClick(m_hGameWnd, 425, 120, 1, 2, 1000);
                    //��������
                    WriteToFile("��������");
                    KeyMouse.SendKeys(m_strPassword, 300);
                    CaptureJpg("�˺�����");
                    //CaptureJpg();
                    string accountPassword = "�����˺ţ�[" + m_strAccount + "]" + "����[" + m_strPassword.Length.ToString() + "]λ���";
                    //��־��ʾ�����˺���Ϣ������λ��
                    WriteToFile(accountPassword);
                    Sleep(1000);
                    for (int z = 0; z < 3; z++)
                    {
                        Sleep(500);
                        pt = ImageTool.fPic(m_strPicPath + "�˺ŵ�¼����.bmp", 0, 0, 0, 0);
                        pa = ImageTool.fPic(m_strPicPath + "TGP��¼.bmp", 0, 0, 0, 0);
                        if (pt.X > 0 || pa.X > 0)
                        {
                            if (pt.X <= 0)
                                pt = pa;
                            KeyMouse.MouseClick(m_hGameWnd, pt.X + 80, pt.Y + 20, 1, 1, 500);//�����¼
                        }

                    }
                    #endregion

                    #region �ж��Ƿ������֤��
                    for (int p = 0; p < 10; p++)
                    {
                        Sleep(1000);
                        //�ж��Ƿ������֤�봰��
                        pb = ImageTool.fPic(m_strPicPath + "��֤��.bmp", 325, 50, 365, 70, 50);
                        pa = ImageTool.fPic(m_strPicPath + "�˺Ű�ȫ.bmp", 170, 45, 235, 75, 50);
                        pc = ImageTool.fPic(m_strPicPath + "��һ��.bmp", 377, 90, 425, 115, 50);
                        pd = ImageTool.fPic(m_strPicPath + "�鿴��¼��.bmp", 295, 155, 380, 180, 50);
                        pw = ImageTool.fPic(m_strPicPath + "��֤��1.bmp", 325, 50, 365, 70, 50);
                        po = ImageTool.fPic(m_strPicPath + "�˺Ű�ȫ1.bmp", 170, 45, 235, 75, 50);
                        pl = ImageTool.fPic(m_strPicPath + "��һ��1.bmp", 377, 90, 425, 115, 50);
                        paa = ImageTool.fPic(m_strPicPath + "�鿴��¼��1.bmp", 295, 155, 380, 180, 50);
                        if (pa.X > 0 || pb.X > 0 || pc.X > 0 || pd.X > 0 || pw.X > 0 || po.X > 0 || pl.X > 0 || paa.X > 0)
                        {
                            //��֤�����
                            Status = verificationCode();
                            if (Status == 3000)
                                return Status;
                            if (QWE == 1)
                                return 2230;
                            break;
                        }
                        if (p == 9)
                        {
                            WriteToFile("δ��⵽��֤�봰�ڣ�������һ������");
                        }
                        if (p % 4 == 0)
                        {
                            WriteToFile("����Ƿ�����֤�봰��");
                        }
                    #endregion

                        #region �ж�������TGP�Ƿ���֣�������������
                        pa = ImageTool.fPic(m_strPicPath + "QTδ��Ӧ.bmp", 0, 0, 0, 0);
                        if (pa.X > 0)
                        {
                            WriteToFile("�ر�QT����");
                            KeyMouse.MouseClick(m_hGameWnd, pa.X + 54, pa.Y + 99, 1, 1, 1000);
                        }
                        HwndWnd = User32API.FindWindow("TWINCONTROL", "�״�����");
                        if (HwndWnd != IntPtr.Zero)
                            break;
                        pa = ImageTool.fPic(m_strPicPath + "�°汾1.bmp", 0, 0, 0, 0);
                        if (pa.X > 0)
                            break;
                        //�ж��Ƿ�ΪTGP�°汾���棨2��
                        pa = ImageTool.fPic(m_strPicPath + "�°汾2.bmp", 0, 0, 0, 0);
                        if (pa.X > 0)
                            break;
                        pa = ImageTool.fPic(m_strPicPath + "�°汾3.bmp", 0, 0, 0, 0);
                        if (pa.X > 0)
                            break;
                        pa = ImageTool.fPic(m_strPicPath + "LOLͼ��.bmp", 0, 0, 0, 0);
                        if (pa.X > 0)
                            break;
                        pa = ImageTool.fPic(m_strPicPath + "LOLͼ��2.bmp", 0, 0, 0, 0);
                        if (pa.X > 0)
                            break;
                        pa = ImageTool.fPic(m_strPicPath + "TGP-�����־.bmp", 0, 0, 0, 0);
                        if (pa.X > 0)
                            break;
                    }
                        #endregion

                    #region �ж��Ƿ�������� ��ص�¼
                    //�ж��Ƿ��������
                    ae = ImageTool.fPic(m_strPicPath + "���벻��ȷ1.bmp", 0, 0, 0, 0);
                    at = ImageTool.fPic(m_strPicPath + "���벻��ȷ.bmp", 0, 0, 0, 0);
                    pa = ImageTool.fPic(m_strPicPath + "�������1.bmp", 0, 0, 0, 0);
                    st = ImageTool.fPic(m_strPicPath + "���벻��ȷ3.bmp", 0, 0, 0, 0);
                    if (at.X > 0 || ae.X > 0 || pa.X > 0 || st.X > 0)
                    {
                        k = k + 1;
                        string ss = string.Format("��{0}���˺��������", k);
                        WriteToFile(ss);
                        if (k == 3)
                        {
                            CaptureJpg("�����3��");
                            return 3000;
                        }
                        KeyMouse.MouseClick(m_hGameWnd, 325, 230, 1, 1, 1000);
                    }
                    //�ж��Ƿ������������

                    //�ж��˺��Ƿ����
                    ae = ImageTool.fPic(m_strPicPath + "�˺Ų�����.bmp", 0, 0, 0, 0);
                    if (ae.X > 0)
                    {
                        l = l + 1;
                        string ss = string.Format("��{0}���˺��������", l);
                        KeyMouse.MouseClick(m_hGameWnd, ae.X + 145, ae.Y + 150, 1, 1, 1000);
                        WriteToFile(ss);
                    }
                    pa = ImageTool.fPic(m_strPicPath + "QTδ��Ӧ.bmp", 0, 0, 0, 0);
                    if (pa.X > 0)
                    {
                        WriteToFile("�ر�QT����");
                        KeyMouse.MouseClick(m_hGameWnd, pa.X + 54, pa.Y + 99, 1, 1, 1000);
                    }
                    //�ж��˺��Ƿ��������
                    if (l == 2)
                    {
                        CaptureJpg("�˺Ų�����");
                        return 3000;
                    }
                    pa = ImageTool.fPic(m_strPicPath + "�ָ�����.bmp", 0, 0, 0, 0);
                    pc = ImageTool.fPic(m_strPicPath + "�޷���¼2.bmp", 0, 0, 0, 0);
                    pd = ImageTool.fPic(m_strPicPath + "�ָ�����2.bmp", 0, 0, 0, 0);
                    if (pa.X > 0 || pb.X > 0 || pc.X > 0 || pd.X > 0)
                    {
                        WriteToFile("��ص�½�����޷���½");
                        CaptureJpg();
                        return 3333;
                    }
                    ae = ImageTool.fPic(m_strPicPath + "��¼�쳣.bmp", 0, 0, 0, 0);
                    if (ae.X > 0)
                    {
                        KeyMouse.MouseClick(m_hGameWnd, ae.X + 5, ae.Y + 5, 1, 1, 1000);
                    }
                    #endregion

                }
                #endregion

                #region �°�TGP
                pb = ImageTool.fPic(m_strPicPath + "TGP��¼2.bmp", 0, 0, 0, 0);
                pc = ImageTool.fPic(m_strPicPath + "TGP��¼3.bmp", 0, 0, 0, 0);
                if (pb.X > 0 || pc.X > 0)
                {
                    if (pb.X < 0)
                        pb = pc;

                    #region �����˺����벢��½
                    //����˺������
                    KeyMouse.MouseClick(m_hGameWnd, pb.X + 15, pb.Y - 132, 1, 2, 1000);
                    //ģ���������Backspace
                    for (int a = 0; a < 2; a++)
                    {
                        KeyMouse.SendBackSpaceKey(2);
                        Sleep(500);
                    }
                    WriteToFile("�����˺�");
                    //�����˺�
                    KeyMouse.SendKeys(m_strAccount, 200);
                    Thread.Sleep(1000);
                    KeyMouse.MouseClick(m_hGameWnd, pb.X + 15, pb.Y - 92, 1, 2, 1000);
                    //��������
                    WriteToFile("��������");
                    KeyMouse.SendKeys(m_strPassword, 300);
                    CaptureJpg("�˺�����");
                    //CaptureJpg();
                    string accountPassword = "�����˺ţ�[" + m_strAccount + "]" + "����[" + m_strPassword.Length.ToString() + "]λ���";
                    //��־��ʾ�����˺���Ϣ������λ��
                    WriteToFile(accountPassword);
                    Sleep(1000);
                    for (int z = 0; z < 3; z++)
                    {
                        Sleep(500);
                        pb = ImageTool.fPic(m_strPicPath + "TGP��¼2.bmp", 0, 0, 0, 0);
                        pc = ImageTool.fPic(m_strPicPath + "TGP��¼3.bmp", 0, 0, 0, 0);
                        if (pb.X > 0 || pc.X > 0)
                        {
                            if (pb.X < 0)
                                pb = pc;
                            KeyMouse.MouseClick(m_hGameWnd, pb.X + 10, pb.Y + 10, 1, 1, 500);//�����¼
                        }

                    }
                    #endregion

                    #region �ж��Ƿ������֤��
                    for (int p = 0; p < 10; p++)
                    {
                        Sleep(1000);
                        //�ж��Ƿ������֤�봰��
                        pb = ImageTool.fPic(m_strPicPath + "TGP��֤��.bmp", 646 + 210, 256 + 248, 760 + 210, 298 + 248, 50);
                        pa = ImageTool.fPic(m_strPicPath + "TGP��֤��1.bmp", 786 + 210, 198 + 248, 849 + 210, 251 + 248, 50);
                        pc = ImageTool.fPic(m_strPicPath + "TGP��֤��2.bmp", 641 + 210, 85 + 248, 858 + 210, 155 + 248, 50);

                        if (pa.X > 0 || pb.X > 0 || pc.X > 0)
                        {
                            //��֤�����
                            Status = verificationCode1();
                            if (Status > 1000)
                                return Status;
                            break;
                        }
                        if (p == 9)
                        {
                            WriteToFile("δ��⵽��֤�봰�ڣ�������һ������");
                        }
                        if (p % 4 == 0)
                        {
                            WriteToFile("����Ƿ�����֤�봰��");
                        }

                    }
                    #endregion

                    #region �ж��Ƿ�������� ��ص�¼
                    //�ж��Ƿ��������
                    ae = ImageTool.fPic(m_strPicPath + "TGP�����.bmp", 638 + 210, 157 + 248, 861 + 210, 294 + 248);
                    at = ImageTool.fPic(m_strPicPath + "���벻��ȷ.bmp", 638 + 210, 157 + 248, 861 + 210, 294 + 248);
                    pa = ImageTool.fPic(m_strPicPath + "�������1.bmp", 638 + 210, 157 + 248, 861 + 210, 294 + 248);
                    st = ImageTool.fPic(m_strPicPath + "���벻��ȷ3.bmp", 638 + 210, 157 + 248, 861 + 210, 294 + 248);
                    if (at.X > 0 || ae.X > 0 || pa.X > 0 || st.X > 0)
                    {
                        k++;
                        WriteToFile("��" + k.ToString() + "���˺��������");
                        if (k == 3)
                        {
                            CaptureJpg("�����3��");
                            return 3000;
                        }
                        KeyMouse.MouseClick(m_hGameWnd, 697 + 210, 331 + 248, 1, 1, 1000);
                        continue;
                    }

                    //�ж��˺��Ƿ����
                    ae = ImageTool.fPic(m_strPicPath + "TGP�˺Ų�����.bmp", 638 + 210, 157 + 248, 861 + 210, 294 + 248);
                    if (ae.X > 0)
                    {
                        l++;
                        WriteToFile("��" + l.ToString() + "���˺Ų�����");
                        if (l == 2)
                        {
                            CaptureJpg("�˺Ų�����");
                            return 3000;
                        }
                        KeyMouse.MouseClick(m_hGameWnd, 697 + 210, 331 + 248, 1, 1, 1000);
                        continue;
                    }

                    //�ж���ص�¼
                    pa = ImageTool.fPic(m_strPicPath + "�ָ�����.bmp", 638 + 210, 157 + 248, 861 + 210, 294 + 248);
                    pb = ImageTool.fPic(m_strPicPath + "�޷���¼.bmp", 638 + 210, 157 + 248, 861 + 210, 294 + 248);
                    pc = ImageTool.fPic(m_strPicPath + "�޷���¼2.bmp", 638 + 210, 157 + 248, 861 + 210, 294 + 248);
                    pd = ImageTool.fPic(m_strPicPath + "�ָ�����2.bmp", 638 + 210, 157 + 248, 861 + 210, 294 + 248);
                    if (pa.X > 0 || pb.X > 0 || pc.X > 0 || pd.X > 0)
                    {
                        WriteToFile("��ص�½�����޷���½");
                        CaptureJpg();
                        return 3333;
                    }
                    ae = ImageTool.fPic(m_strPicPath + "TGP��¼�쳣.bmp", 636 + 210, 304 + 248, 851 + 210, 375 + 248);
                    if (ae.X > 0)
                    {
                        KeyMouse.MouseClick(m_hGameWnd, ae.X + 5, ae.Y + 5, 1, 1, 1000);
                        WriteToFile("δʶ������ⴰ��");
                        CaptureJpg("δ�жϵ����ⴰ��");
                    }
                    #endregion

                }
                #endregion

                #region WeGame
                pd = ImageTool.fPic(m_strPicPath + "WeGame��¼.bmp", 838, 423, 1069, 713);
                if (pd.X > 0)
                {
                    #region �����˺����벢��½
                    //����˺������
                    KeyMouse.MouseClick(m_hGameWnd, pd.X + 68, pd.Y - 133, 1, 2, 1000);
                    //ģ���������Backspace
                    for (int a = 0; a < 2; a++)
                    {
                        KeyMouse.SendBackSpaceKey(2);
                        Sleep(500);
                    }
                    WriteToFile("�����˺�");
                    //�����˺�
                    KeyMouse.SendKeys(m_strAccount, 200);
                    Thread.Sleep(1000);
                    KeyMouse.MouseClick(m_hGameWnd, pd.X + 18, pd.Y - 92, 1, 2, 1000);
                    //��������
                    WriteToFile("��������");
                    KeyMouse.SendKeys(m_strPassword, 300);
                    CaptureJpg("�˺�����");
                    //CaptureJpg();
                    string accountPassword = "�����˺ţ�[" + m_strAccount + "]" + "����[" + m_strPassword.Length.ToString() + "]λ���";
                    //��־��ʾ�����˺���Ϣ������λ��
                    WriteToFile(accountPassword);
                    Sleep(1000);
                    for (int z = 0; z < 3; z++)
                    {
                        Sleep(500);
                        pd = ImageTool.fPic(m_strPicPath + "WeGame��¼.bmp", 838, 423, 1069, 713);
                        //pc = ImageTool.fPic(m_strPicPath + "TGP��¼3.bmp", 0, 0, 0, 0);
                        if (pd.X > 0)
                        {
                            KeyMouse.MouseClick(m_hGameWnd, pd.X + 10, pd.Y + 10, 1, 1, 500);//�����¼
                        }
                    }
                    #endregion

                    #region �ж��Ƿ������֤��
                    for (int p = 0; p < 10; p++)
                    {
                        Sleep(1000);
                        //�ж��Ƿ������֤�봰��
                        pb = ImageTool.fPic(m_strPicPath + "We��֤��.bmp", 853, 356, 1063, 657, 50);
                        pa = ImageTool.fPic(m_strPicPath + "We��֤��1.bmp", 853, 356, 1063, 657, 50);
                        pc = ImageTool.fPic(m_strPicPath + "We��֤��2.bmp", 853, 356, 1063, 657, 50);

                        if (pa.X > 0 || pb.X > 0 || pc.X > 0)
                        {
                            //��֤�����
                            Status = verificationCode1();
                            if (Status > 1000)
                                return Status;
                            break;
                        }
                        if (p == 9)
                        {
                            WriteToFile("δ��⵽��֤�봰�ڣ�������һ������");
                        }
                        if (p % 4 == 0)
                        {
                            WriteToFile("����Ƿ�����֤�봰��");
                        }

                    }
                    #endregion

                    #region �ж��Ƿ�������� ��ص�¼
                    //�ж��Ƿ��������
                    at = ImageTool.fPic(m_strPicPath + "We���벻��ȷ.bmp", 838, 377, 1069, 713);

                    if (at.X > 0)
                    {
                        k++;
                        WriteToFile("��" + k.ToString() + "���˺��������");
                        if (k == 3)
                        {
                            CaptureJpg("�����3��");
                            return 3000;
                        }
                        KeyMouse.MouseClick(m_hGameWnd, 908, 582, 1, 1, 1000);
                        continue;
                    }
                    //�ж���ص�¼
                    pa = ImageTool.fPic(m_strPicPath + "We��ص�¼.bmp", 848, 405, 1071, 542);

                    if (pa.X > 0)
                    {
                        WriteToFile("��ص�½�����޷���½");
                        CaptureJpg();
                        return 3333;
                    }

                    //�ж���ص�¼
                    pa = ImageTool.fPic(m_strPicPath + "We�޸�����.bmp", 848, 405, 1071, 542);

                    if (pa.X > 0)
                    {
                        WriteToFile("���ʺ����޸�����");
                        CaptureJpg();
                        return 2120;
                    }
                    ae = ImageTool.fPic(m_strPicPath + "We��¼ʧ��.bmp", 636 + 210, 304 + 248, 851 + 210, 375 + 248);

                    if (ae.X > 0)
                    {
                        KeyMouse.MouseClick(m_hGameWnd, ae.X + 5, ae.Y + 5, 1, 1, 1000);
                        WriteToFile("δʶ������ⴰ��");
                        CaptureJpg("δ�жϵ����ⴰ��");
                    }
                    #endregion
                }
                #endregion

                #region �ж��˺�ҳ���Ƿ���ʧ
                KeyMouse.MouseMove(0, 0);
                pt = ImageTool.fPic(m_strPicPath + "�˺ŵ�¼����.bmp", 0, 0, 0, 0);
                pa = ImageTool.fPic(m_strPicPath + "TGP��¼.bmp", 0, 0, 0, 0);
                pb = ImageTool.fPic(m_strPicPath + "TGP��¼2.bmp", 0, 0, 0, 0);
                pc = ImageTool.fPic(m_strPicPath + "TGP��¼3.bmp", 0, 0, 0, 0);
                pd = ImageTool.fPic(m_strPicPath + "WeGame��¼.bmp", 838, 423, 1069, 713);
                if (pt.X < 0 && pa.X < 0 && pb.X < 0 && pc.X < 0 && pd.X < 0)
                {
                    WriteToFile("�˺�����ҳ����ʧ�������ʺ�����׶����");
                    break;
                }

                if (q == 5)
                {
                    WriteToFile("δ֪ԭ���¼ʧ�ܣ��Ա����ͼ");
                    return 2120;
                }

                #endregion
            }

            #region //�˺������� �ҵ�TGP�����־����
            for (int y = 0; y < 3; y++)
            {
                WriteToFile("����Ƿ������ⴰ�ڳ���");
                Sleep(3000);

                #region �ж�������־�Ƿ����
                pa = ImageTool.fPic(m_strPicPath + "LOLͼ��.bmp", 0, 0, 0, 0);
                pb = ImageTool.fPic(m_strPicPath + "LOLͼ��2.bmp", 0, 0, 0, 0);
                if (pa.X > 0 || pb.X > 0)
                    break;
                //TGP�°�
                pa = ImageTool.fPic(m_strPicPath + "�°汾1.bmp", 0, 0, 0, 0);
                pb = ImageTool.fPic(m_strPicPath + "�°汾2.bmp", 0, 0, 0, 0);
                pc = ImageTool.fPic(m_strPicPath + "�°汾3.bmp", 0, 0, 0, 0);
                if (pa.X > 0 || pb.X > 0 || pc.X > 0)
                    break;
                //WeGame
                pa = ImageTool.fPic(m_strPicPath + "We�̵����.bmp", 613, 85, 666, 126);
                if (pa.X > 0)
                    break;
                #endregion

                //�ж��Ƿ�ΪQQ����δ����״̬
                at = ImageTool.fPic(m_strPicPath + "QQ����.bmp", 0, 0, 0, 0);
                if (at.X > 0)
                {
                    WriteToFile("QQ����δ����");
                    CaptureJpg();
                    return 3040;
                }

                //�ж��˺��Ƿ�����쳣�������ᣩ
                pb = ImageTool.fPic(m_strPicPath + "�޷���¼.bmp", 838, 423, 1069, 713);
                pa = ImageTool.fPic(m_strPicPath + "�ָ�����.bmp", 838, 423, 1069, 713);
                pc = ImageTool.fPic(m_strPicPath + "�޷���¼2.bmp", 838, 423, 1069, 713);
                pd = ImageTool.fPic(m_strPicPath + "�ָ�����2.bmp", 838, 423, 1069, 713);
                pt = ImageTool.fPic(m_strPicPath + "We��ص�¼.bmp", 838, 423, 1069, 713);

                if (pa.X > 0 || pb.X > 0 || pc.X > 0 || pd.X > 0 || pt.X > 0)
                {
                    WriteToFile("��ص�½�����޷���½");
                    CaptureJpg();
                    return 3333;
                }

                //�ж��˺��Ƿ񱻻���
                pa = ImageTool.fPic(m_strPicPath + "����.bmp", 0, 0, 0, 0);
                if (pa.X > 0)
                {
                    WriteToFile("�˺��ѱ�����");
                    CaptureJpg();
                    return 3300;
                }

                //�ж��˺��Ƿ����޸�����
                pa = ImageTool.fPic(m_strPicPath + "�޸�����.bmp", 838, 423, 1069, 713);
                pb = ImageTool.fPic(m_strPicPath + "We�޸�����.bmp", 838, 423, 1069, 713);
                pt = ImageTool.fPic(m_strPicPath + "�޸�����1.bmp", 838, 423, 1069, 713);
                if (pa.X > 0)
                {
                    WriteToFile("���ʺ����޸�����");
                    CaptureJpg();
                    return 2120;
                }

                //�жϸ��ʺ��Ƿ����ʺ���
                pt = ImageTool.fPic(m_strPicPath + "�˺���.bmp", 0, 0, 0, 0);
                if (pt.X > 0)
                {
                    WriteToFile("���˺����˺���");
                    CaptureJpg();
                    return 3370;
                }

            }
            #endregion

            WriteToFile("TGP��¼�ɹ�");
            IsSucess = true;
            return 2120;
        }
        //QQ���϶�ȡ
        public int ReadQQ()
        {
            //������ҳ��֤
            CheckAccount();
            StringBuilder strBuilder = new StringBuilder(512);
            StringBuilder strBuilder1 = new StringBuilder(512);
            StringBuilder strBuilder2 = new StringBuilder(512);
            StringBuilder strBuilder3 = new StringBuilder(512);
            StringBuilder strBuilder4 = new StringBuilder(512);
            StringBuilder strBuilderMax = new StringBuilder(512);
            //��ȡ�����ļ���Ϣ
            User32API.GetPrivateProfileString("�˺���Ϣ", "ִ��״̬", "", strBuilderMax, 512, m_strProgPath + "\\roleInfo.ini");
            User32API.GetPrivateProfileString("�˺���Ϣ", "֤������", "", strBuilder, 512, m_strProgPath + "\\roleInfo.ini");
            User32API.GetPrivateProfileString("�˺���Ϣ", "�ܱ��ֻ�", "", strBuilder1, 512, m_strProgPath + "\\roleInfo.ini");
            User32API.GetPrivateProfileString("�˺���Ϣ", "QQ�ȼ�", "", strBuilder2, 512, m_strProgPath + "\\roleInfo.ini");
            User32API.GetPrivateProfileString("�˺���Ϣ", "QQ����", "", strBuilder3, 512, m_strProgPath + "\\roleInfo.ini");
            User32API.GetPrivateProfileString("�˺���Ϣ", "����", "", strBuilder4, 512, m_strProgPath + "\\roleInfo.ini");

            QQstuctd = strBuilderMax.ToString();
            if (QQstuctd == "2000")
            {
                WriteToFile("�˺��������");
                return 3000;
            }
            if (QQstuctd == "2300")
            {
                WriteToFile("�˺ű�����");
                return 3333;
            }
            //����ʵ���е����ַ�����ֵת��ΪSystem.string
            FriendNumber = strBuilder3.ToString();
            IDNumber = strBuilder.ToString();
            if (IDNumber.Equals("������"))
            {
                IDNumber = "���֤������";
            }
            if (IDNumber.Equals("δ����"))
                IDNumber = "���֤δ����";
            QQLevel = strBuilder2.ToString();
            BoundMobilePhoneNumber = strBuilder1.ToString();
            emailband = strBuilder4.ToString();

            if (emailband == "������")
                emailband = "�Ѱ�����";
            if (emailband == "δ����")
                emailband = "δ������";
            //if (BoundMobilePhoneNumber="")
            if (BoundMobilePhoneNumber != "")
                BoundMobilePhoneNumber = "�ֻ����Ѱ�";
            else
                BoundMobilePhoneNumber = "�ֻ���δ��";
            WriteToFile("QQ����������" + FriendNumber);
            WriteToFile("���֤��״̬��" + IDNumber);
            WriteToFile("QQ�ȼ���" + QQLevel);
            WriteToFile("�ܱ��ֻ���" + BoundMobilePhoneNumber);
            return 1;
        }
        //��֤������°�
        public int verificationCode1()
        {
            Point pa = new Point(-1, -2);
            Point pb = new Point(-1, -2);
            Point pc = new Point(-1, -2);
            Point pa1 = new Point(-1, -2);
            Point pb1 = new Point(-1, -2);
            Point pc1 = new Point(-1, -2);
            //��֤��
            string Yzm = "";
            m_GameTitle = "��Ѷ��Ϸƽ̨";
            m_hGameWnd = User32API.FindWindow(null, m_GameTitle);
            if (m_hGameWnd == IntPtr.Zero)
                m_hGameWnd = User32API.FindWindow(null, "WeGame");
            for (int i = 0; i < 11; i++)
            {
                WriteToFile("������֤��");
                //��Ҫʶ�����֤��ͼƬ��ȡ����
                CaptureBmpInRect("��֤��", m_strProgPath, 861, 444, 989, 496);
                Sleep(100);
                WriteToFile("������֤��");
                KeyMouse.SendBackSpaceKey(5);
                //�Զ�����
                if (i > 7)
                {
                    if (i == 8)
                        WriteToFile("ת���˹�����");
                    jpgResize(m_strProgPath + "��֤��.bmp", m_strProgPath + "��֤��1.jpg", 125, 52);
                    //�˹����ⷵ�ص���֤��
                    Yzm = RequestSafeCardInfo(1, m_strProgPath + "��֤��1.jpg", "", 180);
                }
                else
                    Yzm = AutoVerify(m_strProgPath + "��֤��.bmp", 60);
                if (Yzm.Length >= 4)
                    Yzm = Yzm.Substring(0, 4);
                Sleep(500);
                KeyMouse.SendKeys(Yzm, 200);
                WriteToFile(Yzm);
                KeyMouse.MouseClick(m_hGameWnd, 696 + 210, 383 + 248, 1, 1, 1000);
                User32API.SetForegroundWindow(m_hGameWnd);
                Sleep(2000);
                //�ж�����Ƿ��Ѿ��޸�����
                pa = ImageTool.fPic(m_strPicPath + "�޸�����.bmp", 0, 0, 0, 0);
                if (pa.X > 0)
                {
                    WriteToFile("������޸�����");
                    CaptureJpg();
                    return 3000;
                }
                //�ж���֤���Ƿ���ʧ
                pb = ImageTool.fPic(m_strPicPath + "TGP��֤��.bmp", 646 + 210, 256 + 248, 760 + 210, 298 + 248, 50);
                pa = ImageTool.fPic(m_strPicPath + "TGP��֤��1.bmp", 786 + 210, 198 + 248, 849 + 210, 251 + 248, 50);
                pc = ImageTool.fPic(m_strPicPath + "TGP��֤��2.bmp", 641 + 210, 85 + 248, 858 + 210, 155 + 248, 50);

                pb1 = ImageTool.fPic(m_strPicPath + "We��֤��.bmp", 853, 356, 1063, 657, 50);
                pa1 = ImageTool.fPic(m_strPicPath + "We��֤��1.bmp", 853, 356, 1063, 657, 50);
                pc1 = ImageTool.fPic(m_strPicPath + "We��֤��2.bmp", 853, 356, 1063, 657, 50);

                if (pa.X <= 0 && pb.X <= 0 && pc.X <= 0 && pa1.X <= 0 && pb1.X <= 0 && pc1.X <= 0)
                {
                    WriteToFile("��֤�ɹ�");
                    //���TGP�����Ƿ���ʧ
                    m_hGameWnd = User32API.FindWindow(null, m_GameTitle);
                    if (m_hGameWnd == IntPtr.Zero)
                    {
                        m_hGameWnd = User32API.FindWindow(null, "WeGame");
                        if (m_hGameWnd == IntPtr.Zero)
                        {
                            WriteToFile("TGP������ʧ");
                            return 2120;
                        }
                    }
                    return 1;
                }

            }
            WriteToFile("�˹�����ʧ��");
            return 2230;

        }
        //��֤�����
        public int verificationCode()
        {
            Point pa = new Point(-1, -2);
            Point pb = new Point(-1, -2);
            Point pc = new Point(-1, -2);
            Point pd = new Point(-1, -2);
            Point pw = new Point(-1, -2);
            Point po = new Point(-1, -2);
            Point pl = new Point(-1, -2);
            Point paa = new Point(-1, -2);
            Point pbb = new Point(-1, -2);
            //��֤��
            string Yzm = "";
            m_GameTitle = "��Ѷ��Ϸƽ̨";
            m_hGameWnd = User32API.FindWindow(null, m_GameTitle);
            if (m_hGameWnd == IntPtr.Zero)
                m_hGameWnd = User32API.FindWindow(null, "WeGame");
            //��վ����
            if (m_GameId == "60")
                for (int i = 0; i < 8; i++)
                {
                    WriteToFile("������֤��");
                    //�����֤�������
                    KeyMouse.MouseClick(m_hGameWnd, 190, 90, 1, 2, 1000);
                    //��Ҫʶ�����֤��ͼƬ��ȡ����
                    CaptureBmpInRect("��֤��", m_strProgPath, 245, 74, 372, 126);
                    Sleep(100);
                    WriteToFile("������֤��");
                    KeyMouse.SendBackSpaceKey(5);
                    //�Զ�����
                    Yzm = AutoVerify(m_strProgPath + "��֤��.bmp", 60);
                    int Yzmlength;
                    Yzmlength = Yzm.Length;
                    if (Yzmlength >= 4)
                        //��ȡ�Զ�������֤���ǰ��λ
                        Yzm = Yzm.Substring(0, 4);
                    //������֤��
                    Sleep(500);
                    KeyMouse.SendKeys(Yzm, 200);
                    WriteToFile(Yzm);
                    KeyMouse.MouseClick(m_hGameWnd, 185, 210, 1, 1, 1000);
                    User32API.SetForegroundWindow(m_hGameWnd);
                    Sleep(2000);
                    //�ж�����Ƿ��Ѿ��޸�����
                    pa = ImageTool.fPic(m_strPicPath + "�޸�����.bmp", 0, 0, 0, 0);
                    if (pa.X > 0)
                    {
                        WriteToFile("������޸�����");
                        CaptureJpg();
                        return 3000;
                    }
                    //�ж���֤���Ƿ���ʧ
                    pb = ImageTool.fPic(m_strPicPath + "��֤��.bmp", 325, 50, 365, 70, 50);
                    Sleep(1000);
                    pa = ImageTool.fPic(m_strPicPath + "�˺Ű�ȫ.bmp", 170, 45, 235, 75, 50);
                    Sleep(1000);
                    pc = ImageTool.fPic(m_strPicPath + "��һ��.bmp", 377, 90, 425, 115, 50);
                    Sleep(1000);
                    pd = ImageTool.fPic(m_strPicPath + "�鿴��¼��.bmp", 295, 155, 380, 180, 50);
                    Sleep(1000);
                    pw = ImageTool.fPic(m_strPicPath + "��֤��1.bmp", 325, 50, 365, 70, 50);
                    Sleep(1000);
                    po = ImageTool.fPic(m_strPicPath + "�˺Ű�ȫ1.bmp", 170, 45, 235, 75, 50);
                    Sleep(1000);
                    pl = ImageTool.fPic(m_strPicPath + "��һ��1.bmp", 377, 90, 425, 115, 50);
                    Sleep(1000);
                    paa = ImageTool.fPic(m_strPicPath + "�鿴��¼��1.bmp", 295, 155, 380, 180, 50);
                    if (pa.X <= 0 && pb.X <= 0 && pc.X <= 0 && pd.X <= 0 && pw.X <= 0 && po.X <= 0 && pl.X <= 0 && paa.X <= 0)
                    {
                        WriteToFile("��֤�ɹ�");
                        //���TGP�����Ƿ���ʧ
                        m_hGameWnd = User32API.FindWindow(null, m_GameTitle);
                        if (m_hGameWnd == IntPtr.Zero)
                        {
                            m_hGameWnd = User32API.FindWindow(null, "WeGame");
                            if (m_hGameWnd == IntPtr.Zero)
                            {
                                WriteToFile("TGP������ʧ");
                                return 2120;
                            }
                        }
                        return 1;
                    }
                    if (i == 7)
                    {

                        WriteToFile("�Զ�ʶ����֤�����涨������ת�˹�����");
                        for (int u = 0; u < 3; u++)
                        {
                            pa = ImageTool.fPic(m_strPicPath + "�޸�����.bmp", 0, 0, 0, 0);
                            if (pa.X > 0)
                            {
                                WriteToFile("������޸�����");
                                CaptureJpg();
                                return 3000;
                            }
                            CaptureBmpInRect("��֤��", m_strProgPath, 245, 74, 372, 126);
                            //����ȡ��������֤��ͼƬת��ΪJpg��ʽ
                            jpgResize(m_strProgPath + "��֤��.bmp", m_strProgPath + "��֤��1.jpg", 125, 52);
                            //�˹����ⷵ�ص���֤��
                            mouseP = RequestSafeCardInfo(1, m_strProgPath + "��֤��1.jpg", "", 180);
                            int Msplength;
                            //�жϻ�ȡ��֤���ַ����ĳ���
                            Msplength = mouseP.Length;
                            //��ȡ��֤��ǰ��λ
                            if (Msplength >= 4)
                                mouseP = mouseP.Substring(0, 4);
                            //������֤�룬���д���
                            KeyMouse.MouseClick(m_hGameWnd, 190, 90, 1, 2, 1000);
                            KeyMouse.SendBackSpaceKey(5);
                            Sleep(100);
                            KeyMouse.SendKeys(mouseP, 40);
                            Sleep(100);
                            KeyMouse.MouseClick(m_hGameWnd, 185, 210, 1, 1, 1000);
                            Sleep(1000);
                            //�ж��˹������Ƿ�ɹ�
                            pb = ImageTool.fPic(m_strPicPath + "��֤��.bmp", 325, 50, 365, 70, 50);
                            Sleep(1000);
                            pa = ImageTool.fPic(m_strPicPath + "�˺Ű�ȫ.bmp", 170, 45, 235, 75, 50);
                            Sleep(1000);
                            pc = ImageTool.fPic(m_strPicPath + "��һ��.bmp", 377, 90, 425, 115, 50);
                            Sleep(1000);
                            pd = ImageTool.fPic(m_strPicPath + "�鿴��¼��.bmp", 295, 155, 380, 180, 50);
                            Sleep(1000);
                            pw = ImageTool.fPic(m_strPicPath + "��֤��1.bmp", 325, 50, 365, 70, 50);
                            Sleep(1000);
                            po = ImageTool.fPic(m_strPicPath + "�˺Ű�ȫ1.bmp", 170, 45, 235, 75, 50);
                            Sleep(1000);
                            pl = ImageTool.fPic(m_strPicPath + "��һ��1.bmp", 377, 90, 425, 115, 50);
                            Sleep(1000);
                            paa = ImageTool.fPic(m_strPicPath + "�鿴��¼��1.bmp", 295, 155, 380, 180, 50);
                            if (pa.X <= 0 && pb.X <= 0 && pc.X <= 0 && pd.X <= 0 && pw.X <= 0 && po.X <= 0 && pl.X <= 0 && paa.X <= 0)
                            {
                                WriteToFile("�˹�����ɹ�");
                                return 1;
                            }
                            if (u == 2)
                            {
                                WriteToFile("�˹�����ʧ��");
                                CaptureJpg("��֤��");
                                QWE = 1;
                            }
                        }
                    }
                }
            //Mվ����
            if (m_GameId == "100")
            {
                for (int a = 0; a < 8; a++)
                {
                    pa = ImageTool.fPic(m_strPicPath + "�޸�����.bmp", 0, 0, 0, 0);
                    if (pa.X > 0)
                    {
                        WriteToFile("������޸�����");
                        CaptureJpg();
                        return 3000;
                    }
                    WriteToFile("������֤��");
                    KeyMouse.MouseClick(m_hGameWnd, 190, 90, 1, 2, 1000);
                    CaptureBmpInRect("��֤��", 245, 74, 372, 126);
                    Sleep(100);
                    WriteToFile("������֤��");
                    KeyMouse.SendBackSpaceKey(5);
                    //�Զ�����
                    Yzm = AutoVerify(m_strCapturePath + "��֤��.bmp", 100);
                    int Yzmlength;
                    //�жϻ�ȡ��֤���ַ����ĳ���
                    Yzmlength = Yzm.Length;
                    if (Yzmlength >= 4)
                        //��ȡ�Զ�������֤���ǰ��λ
                        Yzm = Yzm.Substring(0, 4);
                    KeyMouse.SendKeys(Yzm, 40);
                    WriteToFile(Yzm);
                    KeyMouse.MouseClick(m_hGameWnd, 185, 210, 1, 1, 1000);
                    User32API.SetForegroundWindow(m_hGameWnd);
                    Sleep(1000);
                    pa = ImageTool.fPic(m_strPicPath + "�޸�����.bmp", 0, 0, 0, 0);
                    if (pa.X > 0)
                    {
                        WriteToFile("������޸�����");
                        CaptureJpg();
                        return 3000;
                    }
                    //�ж���֤���Ƿ���ʧ
                    pb = ImageTool.fPic(m_strPicPath + "��֤��.bmp", 325, 50, 365, 70, 50);
                    Sleep(1000);
                    pa = ImageTool.fPic(m_strPicPath + "�˺Ű�ȫ.bmp", 170, 45, 235, 75, 50);
                    Sleep(1000);
                    pc = ImageTool.fPic(m_strPicPath + "��һ��.bmp", 377, 90, 425, 115, 50);
                    Sleep(1000);
                    pd = ImageTool.fPic(m_strPicPath + "�鿴��¼��.bmp", 295, 155, 380, 180, 50);
                    Sleep(1000);
                    pw = ImageTool.fPic(m_strPicPath + "��֤��1.bmp", 325, 50, 365, 70, 50);
                    Sleep(1000);
                    po = ImageTool.fPic(m_strPicPath + "�˺Ű�ȫ1.bmp", 170, 45, 235, 75, 50);
                    Sleep(1000);
                    pl = ImageTool.fPic(m_strPicPath + "��һ��1.bmp", 377, 90, 425, 115, 50);
                    Sleep(1000);
                    paa = ImageTool.fPic(m_strPicPath + "�鿴��¼��1.bmp", 295, 155, 380, 180, 50);
                    if (pa.X <= 0 && pb.X <= 0 && pc.X <= 0 && pd.X <= 0 && pw.X <= 0 && po.X <= 0 && pl.X <= 0 && paa.X <= 0)
                    {
                        WriteToFile("��֤�ɹ�");
                        m_GameTitle = "��Ѷ��Ϸƽ̨";
                        m_hGameWnd = User32API.FindWindow(null, m_GameTitle);
                        if (m_hGameWnd == IntPtr.Zero)
                        {
                            WriteToFile("TGP������ʧ");
                            CaptureJpg();
                            return 2120;
                        }
                        return 1;
                    }
                    if (a == 7)
                    {
                        //�Զ�ʶ����֤����󳬹��ߴΣ�ת�˹�����
                        WriteToFile("�Զ�ʶ����֤�����涨������ת�˹�����");
                        for (int u = 0; u < 3; u++)
                        {

                            pa = ImageTool.fPic(m_strPicPath + "�޸�����.bmp", 0, 0, 0, 0);
                            if (pa.X > 0)
                            {
                                WriteToFile("������޸�����");
                                CaptureJpg();
                                return 3000;
                            }
                            //��֤���ͼ�����룬ȷ��
                            CaptureJpg();
                            CaptureBmpInRect("��֤��", 245, 74, 372, 126);
                            jpgResize(m_strCapturePath + "��֤��.bmp", m_strCapturePath + "��֤��1.jpg", 125, 52);
                            mouseP = RequestSafeCardInfo(1, m_strCapturePath + "��֤��1.jpg", "", 90);
                            int Msplength;
                            //�жϻ�ȡ��֤���ַ����ĳ���
                            Msplength = mouseP.Length;
                            if (Msplength >= 4)
                                //��ȡ��֤��ǰ��λ
                                mouseP = mouseP.Substring(0, 4);
                            KeyMouse.MouseClick(m_hGameWnd, 190, 90, 1, 2, 1000);
                            KeyMouse.SendBackSpaceKey(5);
                            Sleep(100);
                            KeyMouse.SendKeys(mouseP, 40);
                            Sleep(100);
                            KeyMouse.MouseClick(m_hGameWnd, 185, 210, 1, 1, 1000);
                            Sleep(3000);
                            //�ж���֤���Ƿ���ʧ
                            pb = ImageTool.fPic(m_strPicPath + "��֤��.bmp", 325, 50, 365, 70, 50);
                            Sleep(1000);
                            pa = ImageTool.fPic(m_strPicPath + "�˺Ű�ȫ.bmp", 170, 45, 235, 75, 50);
                            Sleep(1000);
                            pc = ImageTool.fPic(m_strPicPath + "��һ��.bmp", 377, 90, 425, 115, 50);
                            Sleep(1000);
                            pd = ImageTool.fPic(m_strPicPath + "�鿴��¼��.bmp", 295, 155, 380, 180, 50);
                            Sleep(1000);
                            pw = ImageTool.fPic(m_strPicPath + "��֤��1.bmp", 325, 50, 365, 70, 50);
                            Sleep(1000);
                            po = ImageTool.fPic(m_strPicPath + "�˺Ű�ȫ1.bmp", 170, 45, 235, 75, 50);
                            Sleep(1000);
                            pl = ImageTool.fPic(m_strPicPath + "��һ��1.bmp", 377, 90, 425, 115, 50);
                            Sleep(1000);
                            paa = ImageTool.fPic(m_strPicPath + "�鿴��¼��1.bmp", 295, 155, 380, 180, 50);
                            if (pa.X <= 0 && pb.X <= 0 && pc.X <= 0 && pd.X <= 0 && pw.X <= 0 && po.X <= 0 && pl.X <= 0 && paa.X <= 0)
                            {
                                WriteToFile("�˹�����ɹ�");
                                return 1;
                            }
                            if (u == 2)
                            {
                                WriteToFile("�˹�����ʧ��");
                                CaptureJpg();
                                QWE = 1;
                            }
                        }
                    }
                }
            }
            return 1;
        }
        public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                User32API.GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }
        /// <summary>
        /// �ر���Ϸ
        /// </summary>
        public void CloseGames()
        {
            Game.RunCmd("taskkill /im  tgp_daemon.exe /F");
            Game.RunCmd("taskkill /im  LOL.exe /F");
            Game.RunCmd("taskkill /im  TGP.exe /F");
        }
        /// <summary>
        /// ���󶩵�����
        /// </summary>
        /// <returns></returns>
        public static bool RequestOrderData()
        {
            if (the_nRC2Port == 0)
            {//������
                m_strOrderData = FileRW.ReadFile("info.txt");
            }
            else
            { //��������ȡ
                m_strOrderData = "";
                string tmp = string.Format("FExeProcID={0}\r\nFRobotPort={1}\r\n", Program.pid, m_UDPPORT);
                udpdd.theUDPSend((int)TRANSTYPE.TRANS_REQUEST_ORDER, tmp, OrdNo);
                for (int i = 0; i < 30; i++)
                {
                    if (m_strOrderData != "")
                    {
                        tmp = string.Format("�˿ں�{0}������{1}���̺�{2}", the_nRC2Port, OrdNo, Program.pid);
                        WriteToFile(tmp);
                        Thread.Sleep(100);
                        return true;
                    }
                    Thread.Sleep(100);
                }
                WriteToFile("��������ʧ��\r\n");
                return false;
            }
            return true;
        }
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        public bool ReadOrderDetail()
        {
            if (m_strOrderData == "")
            {
                WriteToFile(("==========> ��������Ϊ�� <==========\n"));
                return false;
            }
            string m_RegInfos = MyStr.FindStr(m_strOrderData, "<RegInfos>", "</RegInfos>");
            string strItem = MyStr.FindStr(m_RegInfos, "<Name>��Ϸ�˺�</Name>", "</RegInfoItem>");
            m_strAccount = MyStr.FindStr(strItem, "<Value>", "</Value>");
            if (m_strAccount == "")
            {
                strItem = MyStr.FindStr(m_RegInfos, "<Name>��Ϸ�ʺ�</Name>", "</RegInfoItem>");
                m_strAccount = MyStr.FindStr(strItem, "<Value>", "</Value>");
            }
            strItem = MyStr.FindStr(m_RegInfos, "<Name>��Ϸ����</Name>", "</RegInfoItem>");
            m_strPassword = MyStr.FindStr(strItem, "<Value>", "</Value>");
            strItem = MyStr.FindStr2(m_RegInfos, "<Name>��Ϸ��ɫ��</Name>", "</RegInfoItem>");
            m_strSellerRole = MyStr.FindStr(strItem, "<Value>", "</Value>");
            strItem = MyStr.FindStr(m_RegInfos, "<Name>�ֿ�����</Name>", "</RegInfoItem>");
            m_strSecondPwd = MyStr.FindStr(strItem, "<Value>", "</Value>");
            strItem = MyStr.FindStr(m_RegInfos, "<Name>�û����</Name>", "</RegInfoItem>");
            strItem = MyStr.FindStr(m_RegInfos, "<Name>IsNeedRecognition</Name>", "</RegInfoItem>");
            IsNeedRecognition = MyStr.FindStr(strItem, "<Value>", "</Value>");
            m_mobible = MyStr.FindStr(m_strOrderData, "<SellerMobile>", "</SellerMobile>");
            WriteToFile("�Ƿ���Ҫ��ȡQQ��Ϣ��" + IsNeedRecognition);
            if (m_strAccount == "")
            {
                WriteToFile("�ʺ�Ϊ��");
                try
                {
                    WriteToFile(m_RegInfos);
                }
                catch { WriteToFile("�����������ʧ��"); }
                return false;
            }
            if (m_strPassword == "")
            {
                WriteToFile("����Ϊ��");
                return false;
            }
            char[] acc = m_strAccount.ToCharArray();
            for (int i = 0; i < acc.Length; i++)
            {
                if (char.IsControl(acc[i]))
                {
                    WriteToFile("�˺ź��в��ɼ���ת���ַ�");
                    return false;
                }
            }
            char[] pwd = m_strPassword.ToCharArray();
            for (int i = 0; i < pwd.Length; i++)
            {
                if (char.IsControl(pwd[i]))
                {
                    WriteToFile("���뺬�в��ɼ���ת���ַ�");
                    return false;
                }
            }
            m_strGameName = MyStr.FindStr(m_strOrderData, "<GameName>", "</GameName>");
            m_strArea = MyStr.FindStr(m_strOrderData, "<GameArea>", "</GameArea>");
            m_strServer = MyStr.FindStr(m_strOrderData, "<GameServer>", "</GameServer>");
            m_strGameStartFile = MyStr.FindStr(m_strOrderData, "<GamePath>", "</GamePath>");
            m_GameId = MyStr.FindStr(m_strOrderData, "<GameId>", "</GameId>");
            m_strGameStartFile.LastIndexOf('\\');
            m_strGamePath = m_strGameStartFile.Substring(0, m_strGameStartFile.Substring(0, m_strGameStartFile.LastIndexOf('\\')).LastIndexOf('\\') + 1);
            m_strMbkID = MyStr.FindStr(m_strOrderData, "<Passpod_Id>", "</Passpod_Id>");
            m_strMbkImage = MyStr.FindStr(m_strOrderData, "<SafeCardPath>", "</SafeCardPath>");
            m_strMbkString = MyStr.FindStr(m_strOrderData, "<Passpod_Content>", "</Passpod_Content>");
            m_strCapturePath = MyStr.FindStr(m_strOrderData, "<CapturePath>", "</CapturePath>");
            string strlog = string.Format("��Ϸ��[{0}]", m_strGameName);
            WriteToFile(strlog);
            int tt = m_strCapturePath.LastIndexOf("\\");
            if (m_strCapturePath == "")
                m_strCapturePath = "C:\\ƴͼ\\";
            else if (tt > 0)
                m_strCapturePath += "\\";
            return true;
        }
        public void AppInit()
        {
            string tmp;
            Version ApplicationVersion = new Version(Application.ProductVersion);
            tmp = string.Format("IP:{0},�汾��:{1},�ű��˿�{2}", Game.GetLocalIp(), ApplicationVersion.ToString(), m_UDPPORT);
            WriteToFile(tmp);
            return;
        }
        /// <summary>
        ///�߳���ͣ
        /// </summary>
        public static void Sleep(int time)
        {
            Thread.Sleep(time);
            return;
        }
        /// <summary>
        ///��־���
        /// </summary>
        /// <param name="tmp">��־����</param>
        public static void WriteToFile(string tmp)
        {

            Program.AppRunTime = 0;
            if (Program.bRelease)
            {
                udpdd.theUDPSend(18, tmp, OrdNo);
                FileRW.WriteToFile(tmp);
            }
            else
            {
                FileRW.WriteToFile(tmp);
                Console.WriteLine(tmp);
            }
            return;
        }
        /// <summary>
        /// ��������
        /// </summary>
        public void RestartPC()
        {
#if DEBUG
#else
            System.Diagnostics.Process.Start("shutdown", @"/r");
#endif
            return;
        }
        /// <summary>
        /// �����˹�����
        /// </summary>
        /// <param name="CodeType">���ݸ�ʽ</param>
        /// <param name="ImagePath">ͼƬ·��</param>
        /// <param name="Explain"></param>
        /// <param name="time">���ⳬʱʱ�䣺��λ��</param>
        /// <returns>������</returns>
        public string RequestSafeCardInfo(int CodeType, string ImagePath, string Explain, int time)
        {
            #region ˵��
            //���󶩵����� & ���ն������� & ����ȷ��
            //	TRANS_REQ_IDCODE_RESULT  = 30,    //����������GTR������֤��               ( ROBOT -> RC2 ) 
            //TRANS_RES_IDCODE_RESULT  = 31,    //���ʹ��������֤��ĵ������˳���      ( RC2 -> ROBOT ) 
            //TRANS_IDCODE_INPUT_RESULT = 32,   //������������֤���Ľ�����͸��ͻ���  ( ROBOT -> RC2 )
            // 
            //30 ���ݸ�ʽ:
            //FCodeType=  ��������(����Ϊ��)
            //1. ������֤��.
            //2. �ܱ���֤��.
            //3. ������֤��.
            //FImageName= ��֤��ͼƬ�ļ���ȫ·��(����Ϊ��)
            //FQuestion=  һЩ˵���ı�(��Ϊ��) 
            //FTimeout=   ��ʱֵ(��λ��)
            //FSmsMobile=%s\r\n
            //FSmsValue=%s\r\n
            //FSmsAddress=%s\r\n
            #endregion
            if (OrdNo == "���Զ���")
            {
                Console.Write("�������ܱ���");
                return Console.ReadLine();
            }
            IsAnswer = false;
            string strSendData;
            WriteToFile("������֤��...");
            m_strOrderData = "";
            strSendData = string.Format("FCodeType={0}\r\nFImageName={1}\r\nFQuestion={2}\r\nFTimeout={3}\r\n", CodeType, ImagePath, Explain, time);
            udpdd.theUDPSend(30, strSendData, OrdNo);
            Sleep(1000);
            for (int i = 0; i < time; i++)
            {
                if ("" != m_strOrderData)
                {
                    yzmTimes++;
                    IsAnswer = true;
                    string tmp;
                    tmp = string.Format("���ⷵ��:{0}", m_strOrderData);
                    WriteToFile(tmp);
                    return m_strOrderData;
                }
                Sleep(1000);
                if (i % 20 == 15)
                    WriteToFile("�ȴ���֤��...");
            }
            WriteToFile("�ȴ���֤�볬ʱ...");
            return "";
        }
        public string AutoVerify(string ImagePath, int GameId)
        {
            System.IO.MemoryStream m = new System.IO.MemoryStream();
            System.Drawing.Bitmap bp = new System.Drawing.Bitmap(ImagePath);
            bp.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] b = m.ToArray();
            string base64string = Convert.ToBase64String(b);
            bp.Dispose();
            string strHTML = "";
            String postData = string.Format("orderNo={0}&GameId={1}&JpgBase64={2}", OrdNo, GameId, HttpUtility.UrlEncode(base64string));
            try
            {
                strHTML = PostUrlData("http://192.168.36.245/autotalk/service.asmx/UploadJpgBase64", postData);
                strHTML = MyStr.FindStr(strHTML, "\">", "<");
                return strHTML;
            }
            catch (Exception e)
            {
                WriteToFile(e.Message);
                return "";
            }
            //string code = MyStr.FindStr(strHTML, "\">", "<");
            //WriteToFile("�Զ����ⷵ��:" + code);
        }
        //��ȡ���ݣ����ͷ�����(M)
        public string AutoVerifya()
        {
            //�����͵����ݷָ��JSON��ʽ��
            string qq = ",\"gtr_eleven\":";
            string ee = ",\"gtr_ten\":";
            string ww = "{\"gtr_eighteen\":";
            string rr = ",\"gtr_six\":";
            string yy = ",\"dan_name\":";
            string uu = ",\"hero_num\":";
            string ii = ",\"skin_num\":";
            string oo = ",\"gtr_seven\":";
            string pp = ",\"gtr_eight\":";
            string aa = ",\"gtr_bind_mobile\":";
            string bb = ",\"id\":";
            string cc = "}";
            string ida = "\"";
            string zz = "\"property_values\":";
            //��ȡ��֮ǰ��ȡ���������ݲ������ǽ��и�ʽ��
            string IDn = string.Format("{0}", IDNumber);
            string BMPN = string.Format("{0}", BoundMobilePhoneNumber);

            string Grade = string.Empty;
            int qa = 0;
            try
            {
                if (string.IsNullOrEmpty(QQLevel))
                    QQLevel = "0";
                qa = int.Parse(QQLevel);
            }
            catch (Exception err)
            {
                WriteToFile(err.ToString());
                WriteToFile("QQ�ȼ���ȡ�쳣��");
            }
            if (qa == 0)
                Grade = "QQ�ȼ�0��";
            if (0 < qa && qa <= 10)
                Grade = "QQ�ȼ�1-10��";
            if (10 < qa && qa <= 20)
                Grade = "QQ�ȼ�11-20��";
            if (20 < qa && qa <= 40)
                Grade = "QQ�ȼ�21-40��";
            if (qa > 40)
                Grade = "QQ�ȼ�40������";

            if (FriendNumber.Equals("0"))
                FriendN = "��QQ����";
            else if (FriendNumber == "")
                FriendN = "";
            else
                FriendN = "��QQ����";
            // string FriendN = string.Format("{0}", FriendNumber);
            string LEVEL = string.Format("{0}", Level);
            string intskin = string.Format("{0}��Ƥ��", intSkin);
            string intrenus = string.Format("{0}", RenusNum);
            if (RenusNum == 0)
                intrenus = "";
            string inthero = string.Format("{0}��Ӣ��", intHero);
            string Glevel = string.Format("{0}��", grade);
            string intcoin = string.Empty;
            //if (intCoin <= 1000)
            //    intcoin = "1ǧ���½��";
            //if (intCoin > 1000 && intCoin <= 2000)
            //    intcoin = "1000-2000���";
            //if (intCoin > 2000 && intCoin <= 5000)
            //    intcoin = "2000-5000���";
            //if (intCoin > 5000 && intCoin <= 10000)
            //    intcoin = "5000-10000���";
            //if (intCoin > 10000)
            //    intcoin = "1�����Ͻ��";
            intcoin = intCoin.ToString();
            string strdjc = string.Format("{0}��ȯ", djc);
            string ordNo = OrdNo;
            ordNo = ordNo.Replace("-", "");



            String property_values = "[{\"���֤\":\"" + IDn + "\",\"QQ�ȼ�\":\"" + Grade + "\",\"QQ����\":\"" + FriendN + "\",\"�ȼ�\":\"" + Glevel + "\",\"Ӣ��\":\"" + inthero + "\",\"Ƥ��\":\"" + intskin + "\",\"��˫�Ŷ�λ\":\"" + Level + "\"}]";

            //ƴ��������JSON��ʽ�ı�
            // String strData = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}{18}{19}{20}{21}{22}{23}{24}{25}{26}{27}{28}{29}{30}{31}{32}{33}{34}{35}{36}{37}{38}{39}{40}{41}{42}{43}{44}{45}", ww, ida, IDn, ida, ee, ida, FriendN, ida, qq, ida, Grade, ida, rr, ida, Glevel, ida, yy, ida, LEVEL, ida, uu, ida, inthero, ida, ii, ida, intskin, ida, oo, ida, intrenus, ida, pp, ida, intcoin, ida, aa, ida, BMPN, ida, bb, ida, ordNo, zz, property_values,cc);
            //������ƴ�õ�����ǰ����4$_Y&wqz$#9!ck_data={0}


            // string strData = "{\"property\":[{\"QQ����\":\"" + FriendN + "\",\"id\":136},{\"���֤\":\"" + IDn + "\",\"id\":138},{\"�ȼ�\":\"" + Glevel + "\",\"id\":139},{\"QQ�ȼ�\":\"" + Grade + "\",\"id\":137},{\"�ֻ�����\":\"" + BMPN + "\",\"id\":140},{\"����\":\"" + emailband + "\",\"id\":141},{\"Ӣ��\":\"" + inthero + "\",\"id\":132},{\"Ƥ��\":\"" + intskin + "\",\"id\":133},{\"��˫�Ŷ�λ\":\"" + LEVEL + "\",\"id\":135},{\"�������\":\"" + intcoin + "\",\"id\":143}],\"id\":\"" + ordNo + "\",\"property_values\":" + property_values + "}";


            //FriendN = "��QQ����";
            //IDn = "���֤������";
            //Glevel = "30";
            //Grade = "QQ�ȼ�40������";
            //BMPN = "";
            //emailband = "";
            //inthero = "100";
            //intskin = "99";
            //LEVEL = "��ǿ����";
            //intcoin = "";
            //ordNo = "MZH170802000000018";

            string strData = "{\"property\":[{\"pname\":\"QQ����\",\"pvalue\":\"" + FriendN + "\",\"id\":\"6786\",\"mainid\":\"BCP3\"},{\"pname\":\"���֤\",\"pvalue\":\"" + IDn + "\",\"id\":\"6784\",\"mainid\":\"BCP1\"},{\"pname\":\"�ȼ�\",\"pvalue\":\"" + Glevel + "\",\"id\":\"6787\",\"mainid\":\"BCP4\"},{\"pname\":\"QQ�ȼ�\",\"pvalue\":\"" + Grade + "\",\"id\":\"6785\",\"mainid\":\"BCP2\"},{\"pname\":\"�ֻ���ѡ��\",\"pvalue\":\"" + BMPN + "\",\"id\":\"11032\",\"mainid\":\"0\"},{\"pname\":\"�����ѡ��\",\"pvalue\":\"" + emailband + "\",\"id\":\"11033\",\"mainid\":\"0\"},{\"pname\":\"Ӣ��\",\"pvalue\":\"" + inthero + "\",\"id\":\"6788\",\"mainid\":\"BCP5\"},{\"pname\":\"Ƥ��\",\"pvalue\":\"" + intskin + "\",\"id\":\"6789\",\"mainid\":\"BCP6\"},{\"pname\":\"��˫�Ŷ�λ\",\"pvalue\":\"" + LEVEL + "\",\"id\":\"6790\",\"mainid\":\"BCP7\"},{\"pname\":\"�������\",\"pvalue\":\"" + intcoin + "\",\"id\":\"11039\",\"mainid\":\"0\"},{\"pname\":\"��Ϸ��ȯ\",\"pvalue\":\"" + strdjc + "\",\"id\":\"11040\",\"mainid\":\"0\"}],\"id\":\"" + ordNo + "\",\"property_values\":" + property_values + "}";

            string temp = string.Format("4$_Y&wqz$#9!ck_data={0}", strData);

            //��ȡtemp��MD5
            string strMd5 = GetStringMD5(temp);
            string postData = "{\"data\":" + strData + "," + "\"mainSign\":\"" + strMd5 + "\"}";
            WriteToFile(postData);
            string strHTML = "";
            try
            {
                //�����ݷ������ӿ�
                //strHTML = Post("https://m.5173.com/api/mobile-goodsSearch-service/rs/gtrAliyunService/gtrToAliYun", postData);
                strHTML = Post("https://m.5173.com/api/mobile-goods-service/rs/gtrAliyunService/gtrToAliYun", postData);
                //strHTML = Post("http://192.168.42.38:8086/mobile-goods-service/rs/gtrAliyunService/gtrToAliYun", postData);

                //��֤���͵������Ƿ���ȷ
                //string ss = string.Format("���֤��{0}\r\n                  QQ���ѣ�{1}\r\n                  QQ�ȼ���{2}\r\n                  ��ɫ�ȼ���{3}\r\n                  ��λ�ȼ���{4}\r\n                  Ӣ�۸�����{5}\r\n                  Ƥ��������{6}\r\n                  ����ҳ��{7}\r\n                  ���������{8}\r\n                  ԭ���ֻ��ţ�{9}", IDn, FriendN, Grade, Glevel, LEVEL, inthero, intskin, intrenus, intcoin, BMPN);
                //ͨ�����ص���־��������Ƿ��ͳɹ����������ݷ���Ҫ��
                WriteToFile(strHTML);

                return strHTML;
            }
            catch (Exception e)
            {
                WriteToFile(e.Message);
                WriteToFile("��̬�����ϴ��쳣");
                return "";
            }
            WriteToFile("������������ʺ���Ϣ�ɹ�");
        }
        //��ȡ���ݣ����ͷ�����
        public string AutoVerifyb()
        {
            //�ж���ȡ��ҳ��Ϣ�Ƿ�ɹ�
            string reviewedresult = "1";
            //����QQ����
            string Friend = "";
            //QQ�ȼ���Χ
            string QQlevelRange = "";
            string postData = "";
            if (FriendNumber == "0")
                Friend = "��QQ����";
            else if (FriendNumber == "")
                Friend = "";
            else
                Friend = "��QQ����";
            int a = int.Parse(QQLevel);
            if (a == 0)
            {
                QQlevelRange = "QQ�ȼ�0��";
            }
            if (0 < a && a <= 10)
            {
                QQlevelRange = "QQ�ȼ�1-10��";
            }
            if (10 < a && a <= 20)
            {
                QQlevelRange = "QQ�ȼ�11-20��";
            }
            if (20 < a && a <= 30)
            {
                QQlevelRange = "QQ�ȼ�21-30��";
            }
            if (30 < a && a <= 40)
            {
                QQlevelRange = "QQ�ȼ�31-40��";
            }
            if (a > 40)
            {
                QQlevelRange = "QQ�ȼ�40������";
            }
            //�ж���ҳ��֤�Ƿ�ɹ�
            if (IDNumber == "" || Friend == "")
            {
                reviewedresult = "2";
                IDNumber = "0";
                QQlevelRange = "0";
                a = 0;
                Friend = "0";
                Level = "0";
                grade = "0";
            }
            //��ȡ��֮ǰ��ȡ���������ݲ������ǽ��и�ʽ��
            string IDn = string.Format("���֤{0}#", IDNumber);
            string Grade = string.Format("QQ�ȼ���QQ{0}����{1}#", a, QQlevelRange);
            string FriendN = string.Format("{0}#", Friend);
            string LEVEL = string.Format("��λ��{0}", Level);
            string inthero = string.Format("{0}��Ӣ��", intHero);
            string intskin = string.Format("{0}��Ƥ��", intSkin);
            string Glevel = string.Format("{0}��", grade);
            string ordNO = OrdNo;
            string strHTML = "";
            string reviewed = "";
            if (FriendN == "" || Grade == "")
            {
                FriendN = "0";
                Grade = "0";
            }

            reviewed = string.Format("���֤��{0}{1}QQ���ѣ�QQ����{2}����{3}�ȼ���{4}��{5}#Ӣ�ۣ�{6}��{7}#Ƥ����{8}��{9}#{10}����λ:{11}", IDn, Grade, QQLevel, FriendN, Glevel, grade, inthero, intHero, intskin, intSkin, LEVEL, Level);
            postData = string.Format("?PublishNO=" + ordNO + "&ReviewedResult=" + reviewedresult + "&Reviewed=" + reviewed);
            WriteToFile(postData);
            try
            {
                //�����ݷ������ӿ�
                strHTML = Get("http://gtr.5173.com:7080/RobotCallback.asmx/GetByRobotReviewed", postData);
                //ͨ�����ص���־��������Ƿ��ͳɹ����������ݷ���Ҫ��
                WriteToFile(strHTML);
                return strHTML;
            }
            catch (Exception e)
            {
                WriteToFile(e.Message);
                return "";
            }
        }
        public static string GetStringMD5(string strPwd)
        {
            System.Security.Cryptography.MD5
            md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(strPwd);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();
            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
            }
            return ret.PadLeft(32, '0');
        }
        public static string PostUrlData(string url, string postData)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            System.Net.HttpWebRequest objWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            objWebRequest.Method = "POST";
            objWebRequest.ContentType = "application/x-www-form-urlencoded";
            objWebRequest.ContentLength = byteArray.Length;
            Stream newStream = objWebRequest.GetRequestStream();
            // Send the data. 
            newStream.Write(byteArray, 0, byteArray.Length); //д����� 
            newStream.Close();
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)objWebRequest.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);//Encoding.Default
            string textResponse = sr.ReadToEnd(); // ���ص�����
            return textResponse;
        }
        //�������ݣ�JSON��ʽ��
        public static string Post(string url, string postData)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            System.Net.HttpWebRequest objWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            objWebRequest.Method = "POST";
            objWebRequest.ContentType = "application/json";
            objWebRequest.ContentLength = byteArray.Length;
            Stream newStream = objWebRequest.GetRequestStream();
            // Send the data. 
            newStream.Write(byteArray, 0, byteArray.Length); //д����� 
            newStream.Close();
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)objWebRequest.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);//Encoding.Default
            string textResponse = sr.ReadToEnd(); // ���ص�����
            return textResponse;
        }

        public static string Get(string url, string postData)
        {
            //url = string.Format(url + "{0}", postData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        //������֤���,0Ϊ����,1Ϊ��ȷ
        public void VerifyResult(int isTrue)
        {
            string strHTML = "";
            String postData = string.Format("orderNo={0}&IsTrue={1}", OrdNo, isTrue);
            try
            {
                strHTML = PostUrlData("http://192.168.36.245/autotalk/service.asmx/ResultAnswer2", postData);
            }
            catch (Exception e)
            {
                WriteToFile(e.Message);
            }
        }
        /// <summary>
        ///�����Ƿ���ȷ
        /// </summary>
        /// <param name="isTrue">��ȷ���0��ȷ��1����</param>
        public static void codeRight(int isTrue)
        {
            string strHTML = "";
            String postData = string.Format("orderNo={0}&IsTrue={1}", OrdNo, isTrue);
            try
            {
                strHTML = PostUrlData("http://192.168.36.245/autotalk/service.asmx/ResultAnswer2", postData);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            return;
        }
        /// <summary>
        /// ɾ��ָ������֮ǰ���ļ���
        /// </summary>
        /// <param name="path">�ļ���·��</param>
        /// <param name="time">ʱ�䣺��λ��</param>
        public void DeleteFolder(string path, int time)
        {
            WriteToFile("ɾ���ļ�");
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (dir.Exists)
                {
                    DirectoryInfo[] childs = dir.GetDirectories();
                    foreach (DirectoryInfo child in childs)
                    {
                        DirectoryInfo[] m_childs = child.GetDirectories();
                        foreach (DirectoryInfo m_child in m_childs)
                        {
                            DateTime dt = m_child.CreationTime;
                            TimeSpan ts = DateTime.Now - dt;
                            if (ts.Days >= time)
                                child.Delete(true);
                        }
                    }
                }
            }
            catch (Exception e) { WriteToFile(e.ToString()); }
        }
        /// <summary>
        /// ��ͼ
        /// </summary>
        public void CaptureJpg()
        {
            //����ͼ·���Ƿ����쳣
            try
            {
                string tmp = SetPicPathBmp(LocalPicPath, OrdNo, "");
                if (!IsSendCapPath)
                {
                    WriteToFile("��ͼĿ¼��" + tmp);
                    IsSendCapPath = true;
                }
                Bitmap bm = ImageTool.GetScreenCapture(User32API.GetDesktopWindow());
                User32API.MakeSureDirectoryPathExists(m_strCapturePath);
                try
                {
                    RECT rect = new RECT(0, 0, 1280, 900);
                    Game.CaptureBmp(bm, rect, tmp);
                    return;
                }
                catch
                {
                    RECT rect = new RECT(0, 0, 1024, 768);
                    Game.CaptureBmp(bm, rect, tmp);
                    return;
                }

            }
            //���·�����쳣��·����Ϊ "Z:\\jiaoben\\"
            catch
            {
                LocalPicPath = "Z:\\jiaoben\\";
                string tmp = SetPicPathBmp(LocalPicPath, OrdNo, "");
                if (!IsSendCapPath)
                {
                    WriteToFile("�쳣��ͼĿ¼��" + tmp);
                    IsSendCapPath = true;
                }
                Bitmap bm = ImageTool.GetScreenCapture(User32API.GetDesktopWindow());
                User32API.MakeSureDirectoryPathExists(m_strCapturePath);
                try
                {
                    RECT rect = new RECT(0, 0, 1280, 1024);
                    Game.CaptureBmp(bm, rect, tmp);
                    return;
                }
                catch
                {
                    RECT rect = new RECT(0, 0, 1024, 768);
                    Game.CaptureBmp(bm, rect, tmp);
                    return;
                }


            }
        }
        public void CaptureJpg(string picName)
        {
            //����ͼ·���Ƿ����쳣
            try
            {
                string tmp = SetPicPathBmp(LocalPicPath, OrdNo, picName);
                if (!IsSendCapPath)
                {
                    WriteToFile("��ͼĿ¼��" + tmp);
                    IsSendCapPath = true;
                }

                Bitmap bm = ImageTool.GetScreenCapture(User32API.GetDesktopWindow());
                User32API.MakeSureDirectoryPathExists(m_strCapturePath);
                try
                {
                    RECT rect = new RECT(0, 0, 1280, 1024);
                    Game.CaptureBmp(bm, rect, tmp);
                    return;
                }
                catch
                {
                    RECT rect = new RECT(0, 0, 1024, 768);
                    Game.CaptureBmp(bm, rect, tmp);
                    return;
                }

            }
            //���·�����쳣��·����Ϊ "Z:\\jiaoben\\"
            catch
            {
                LocalPicPath = "Z:\\jiaoben\\";
                string tmp = SetPicPathBmp(LocalPicPath, OrdNo, picName);
                if (!IsSendCapPath)
                {
                    WriteToFile("��ͼĿ¼��" + tmp);
                    IsSendCapPath = true;
                }
                Bitmap bm = ImageTool.GetScreenCapture(User32API.GetDesktopWindow());
                User32API.MakeSureDirectoryPathExists(m_strCapturePath);
                try
                {
                    RECT rect = new RECT(0, 0, 1280, 1024);
                    Game.CaptureBmp(bm, rect, tmp);
                    return;
                }
                catch
                {
                    RECT rect = new RECT(0, 0, 1024, 768);
                    Game.CaptureBmp(bm, rect, tmp);
                    return;
                }


            }
        }
        public void CaptureJpg(bool vnc)
        {
            if (true)
            {
                //���·�����쳣��·����Ϊ "Z:\\jiaoben\\"
                try
                {
                    LocalPicPath = "\\\\192.168.92.156\\vnc\\lol\\";
                    string tmp = SetPicPathBmp(LocalPicPath, OrdNo, "");
                    Bitmap bm = ImageTool.GetScreenCapture(User32API.GetDesktopWindow());
                    User32API.MakeSureDirectoryPathExists(LocalPicPath);
                    try
                    {
                        RECT rect = new RECT(0, 0, 1280, 1024);
                        Game.CaptureBmp(bm, rect, tmp);
                        return;
                    }
                    catch
                    {
                        RECT rect = new RECT(0, 0, 1024, 768);
                        Game.CaptureBmp(bm, rect, tmp);
                        return;
                    }
                }
                catch (Exception e)
                {
                    WriteToFile(e.ToString());
                    WriteToFile("���Ӵﵽ���");
                }
            }
            else
                return;
        }
        public void CaptureJpg(bool vnc, string PathName)
        {
            if (true)
            {

                try
                {
                    LocalPicPath = "\\\\192.168.92.156\\vnc\\lol\\" + PathName + "\\";
                    string tmp = SetPicPathBmp(LocalPicPath, OrdNo, "");
                    Bitmap bm = ImageTool.GetScreenCapture(User32API.GetDesktopWindow());
                    User32API.MakeSureDirectoryPathExists(LocalPicPath);
                    try
                    {
                        RECT rect = new RECT(0, 0, 1280, 1024);
                        Game.CaptureBmp(bm, rect, tmp);
                        return;
                    }
                    catch
                    {
                        RECT rect = new RECT(0, 0, 1024, 768);
                        Game.CaptureBmp(bm, rect, tmp);
                        return;
                    }
                }
                catch (Exception e)
                {
                    WriteToFile(e.ToString());
                    WriteToFile("���Ӵﵽ���");
                }
            }
            else
                return;
        }
        //ͼƬ����bmp
        public bool picResize(string strFile, string strNewFile, int intWidth, int intHeight)
        {
            System.Drawing.Bitmap objPic, objNewPic;
            try
            {

                if (!File.Exists(strFile))
                    return false;
                objPic = new System.Drawing.Bitmap(strFile);
                if (intHeight <= 0)
                    intHeight = (intWidth * objPic.Height / objPic.Width);
                objNewPic = new System.Drawing.Bitmap(objPic, intWidth, intHeight);
                objPic.Dispose();
                objPic = null;
                string newFile = strNewFile.Substring(0, strNewFile.LastIndexOf('.'));
                objNewPic.Save(newFile + ".bmp", ImageFormat.Jpeg);
                objNewPic.Dispose();
                // File.Delete(strFile);

            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {

                objNewPic = null;
            }
            return true;
        }
        //ͼƬ����
        public bool jpgResize(string strFile, string strNewFile, int intWidth, int intHeight)
        {
            System.Drawing.Bitmap objPic, objNewPic;
            try
            {

                if (!File.Exists(strFile))
                    return false;
                objPic = new System.Drawing.Bitmap(strFile);
                if (intHeight <= 0)
                    intHeight = (intWidth * objPic.Height / objPic.Width);
                objNewPic = new System.Drawing.Bitmap(objPic, intWidth, intHeight);
                objPic.Dispose();
                objPic = null;
                string newFile = strNewFile.Substring(0, strNewFile.LastIndexOf('.'));
                objNewPic.Save(newFile + ".jpg", ImageFormat.Jpeg);
                objNewPic.Dispose();
                //File.Delete(strFile);

            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {

                objNewPic = null;
            }
            return true;
        }
        //ͼƬ����
        public bool jpgResize(string strFile, string strNewFile, int intWidth, int intHeight, bool IsDeleteStrFile)
        {
            System.Drawing.Bitmap objPic, objNewPic;
            try
            {

                if (!File.Exists(strFile))
                    return false;
                objPic = new System.Drawing.Bitmap(strFile);
                if (intHeight <= 0)
                    intHeight = (intWidth * objPic.Height / objPic.Width);
                objNewPic = new System.Drawing.Bitmap(objPic, intWidth, intHeight);
                objPic.Dispose();
                objPic = null;
                string newFile = strNewFile.Substring(0, strNewFile.LastIndexOf('.'));
                objNewPic.Save(newFile + ".jpg", ImageFormat.Jpeg);
                objNewPic.Dispose();
                if (IsDeleteStrFile)
                {
                    File.Delete(strFile);
                }

            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {

                objNewPic = null;
            }
            return true;
        }
        public string SetPicPath(string str, string strPicID)
        {

            if (strLastPicID != strPicID)
                PicNum = 1;
            string strFileName;
            if (strPicID == "")
                strFileName = string.Format("{0}R_{1:00}.bmp", str, PicNum++);

            else
                strFileName = string.Format("{0}{1}_{2:00}.bmp", str, strPicID, PicNum++);
            strLastPicID = strPicID;
            return strFileName;
        }
        /// <summary>
        /// ���ý�ͼ·��-�����쳣��ͼ
        /// </summary>
        /// <param name="str">�ļ���·��</param>
        /// <param name="strPicID">ͼƬ���</param>
        /// <returns>ͼƬ·��</returns>
        public string SetPicPathBmp(string str, string strPicID, string picName)
        {
            if (strLastPicID != strPicID)
                PicNum = 1;
            string m_month;
            m_month = string.Format("{0}{1}_{2}\\{3}\\{4}", str, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, strPicID);
            if (!Directory.Exists(m_month))
            {
                Directory.CreateDirectory(m_month);
            }
            string strFileName;
            if (picName != "")
                strFileName = string.Format("{0}\\{1}.bmp", m_month, picName);
            else if (strPicID == "")
                strFileName = string.Format("{0}\\R_{1:00}.bmp", m_month, PicNum++);
            else
                strFileName = string.Format("{0}\\{1}_{2:00}.bmp", m_month, strPicID, PicNum++);
            strLastPicID = strPicID;
            return strFileName;
        }
        /// <summary>
        /// bmp��ͼ
        /// </summary>
        /// <param name="bm">bmpͼƬ��</param>
        /// <param name="strPicName">��ͼ����</param>
        /// <param name="left">�߽磺��</param>
        /// <param name="top">�߽磺��</param>
        /// <param name="right">�߽磺��</param>
        /// <param name="bottom">�߽磺��</param>
        public void CaptureBmpInRect(string strPicName, int left, int top, int right, int bottom)
        {
            //if (m_strLastName == strPicName)
            //{
            //    strPicName += "1";
            //}
            strPicName += ".bmp";
            Bitmap bm = ImageTool.GetScreenCapture(User32API.GetDesktopWindow());
            User32API.MakeSureDirectoryPathExists(m_strCapturePath);
            RECT rect = new RECT(left, top, right, bottom);
            Game.CaptureBmp(bm, rect, m_strCapturePath + strPicName);
            //m_strLastName = strPicName;
            return;
        }
        public void CaptureBmpInRect(string strPicName, string strPicPath, int left, int top, int right, int bottom)
        {
            //if (m_strLastName == strPicName)
            //{
            //    strPicName += "1";
            //}
            strPicName += ".bmp";
            Bitmap bm = ImageTool.GetScreenCapture(User32API.GetDesktopWindow());
            User32API.MakeSureDirectoryPathExists(strPicPath);
            RECT rect = new RECT(left, top, right, bottom);
            Game.CaptureBmp(bm, rect, strPicPath + strPicName);
            //m_strLastName = strPicName;
            return;
        }
        /// <summary>
        /// bmp��ͼ��ˮӡ����
        /// </summary>
        /// <param name="bm">bmpͼƬ��</param>
        /// <param name="strPicName">��ͼ����</param>
        /// <param name="left">�߽磺��</param>
        /// <param name="top">�߽磺��</param>
        /// <param name="right">�߽磺��</param>
        /// <param name="bottom">�߽磺��</param>
        /// <param name="waterleft">ˮӡ�߽�</param>
        /// <param name="watertop">ˮӡ�߽�</param>
        /// <param name="waterright">ˮӡ�߽�</param>
        /// <param name="waterbottom">ˮӡ�߽�</param>
        /// <param name="waterleft1">ˮӡ�߽�1</param>
        /// <param name="watertop1">ˮӡ�߽�1</param>
        /// <param name="waterright1">ˮӡ�߽�1</param>
        /// <param name="waterbottom1">ˮӡ�߽�1</param>
        public void CaptureBmpInRect(string strPicName, int left, int top, int right, int bottom, int waterleft, int watertop, int waterright, int waterbottom, int waterleft1, int watertop1, int waterright1, int waterbottom1)
        {
            strPicName += ".bmp";
            Bitmap bm = ImageTool.GetScreenCapture(User32API.GetDesktopWindow());
            User32API.MakeSureDirectoryPathExists(m_strCapturePath);
            RECT rect = new RECT(left, top, right, bottom);
            Game.CaptureBmp(bm, rect, m_strCapturePath + strPicName);
            if (waterleft > 0)
            {
                RECT rt = new RECT(waterleft - left, watertop - top, waterright - left, waterbottom - top);
                WaterMark(m_strCapturePath + strPicName, rt);
            }
            if (waterleft1 > 0)
            {
                RECT rt1 = new RECT(waterleft1 - left, watertop1 - top, waterright1 - left, waterbottom1 - top);
                WaterMark(m_strCapturePath + strPicName, rt1);
            }
            return;
        }
        /// <summary>
        /// ˮӡ���
        /// </summary>
        /// <param name="filePic">ԭͼ</param>
        /// <param name="rect">ˮӡ�߽�</param>
        /// <returns></returns>
        public bool WaterMark(string filePic, RECT rect)
        {
            if (filePic.IndexOf(".bmp") < 0)
                filePic += ".bmp";
            if (!File.Exists(filePic))
            {

                FileRW.WriteToFile(filePic + "<< �ļ������ڣ�");
                return false;
            }
            Bitmap srcBit = (Bitmap)Bitmap.FromFile(filePic, false);
            Rectangle srcRect = new Rectangle(0, 0, srcBit.Width, srcBit.Height);
            BitmapData pBData = srcBit.LockBits(srcRect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            int Swidth = pBData.Width;
            int Sheight = pBData.Height;
            byte[] tData = new byte[Swidth * Sheight * 4];
            System.Runtime.InteropServices.Marshal.Copy(pBData.Scan0, tData, 0, pBData.Stride * pBData.Height);
            srcBit.UnlockBits(pBData);
            srcBit.Dispose();

            for (int y = 0; y < Sheight; y++)
            {
                int num = y * pBData.Stride;
                for (int x = 0; x < Swidth; x++)
                {
                    if (x > rect.left && y > rect.top && x < rect.right && y < rect.bottom)
                    {
                        tData[num + 2] = 20;
                        tData[num + 1] = 20;
                        tData[num + 0] = 20;
                    }
                    num += 4;
                }
            }
            try
            {
                ImageTool.CreatBmpFromByte(tData, Swidth, Sheight).Save(filePic);
            }
            catch (Exception err)
            {
            }
            return true;
        }
        /// <summary>
        /// ƴͼ
        /// </summary>
        /// <param name="strAllPic">ͼƬ���Ƽ���</param>
        /// <param name="strPicID">ƴͼID</param>
        /// <param name="bVerbical">true������bmp��false������jpg</param>
        /// <returns></returns>
        /// 
        public int PinTu(string strAllPic, string strPicID, bool bVerbical)
        {
            string[] arrPicName;
            int num = SplitString(strAllPic, ",", out arrPicName);

            for (int i = 0; i < num + 1; i++)
            {
                if (arrPicName[i] == "����")
                {
                    CreatePlate("����", "", nZHPicWidth);
                    continue;
                }

                CreatePlate(m_strCapturePath + arrPicName[i], "", nZHPicWidth);
            }
            string strPic = m_strCapturePath + "ģ��.bmp";
            if (bVerbical)
            {
                if (!CreatePlate("����ͼƬ", strPic, 0))
                    return 1;
            }
            else
            {
                if (!CreatePlate("����ͼƬ", strPic, nZHPicWidth))
                    return 1;
            }
            Bitmap bbmp = new Bitmap(strPic, true);
            int x = 0, y = 0, z = 0;
            for (int i = 0; i < num + 1; i++)
            {

                if (arrPicName[i] == "����")
                {
                    //ImageTool.CreatBmpFromByte(bbmp, bbmp, ref x, ref y, ref z, "����");
                    ImageTool.BmpInsert(bbmp, bbmp, ref x, ref y, ref z, "����");
                    continue;
                }
                if (!File.Exists(m_strCapturePath + arrPicName[i] + ".bmp"))
                    continue;
                Bitmap sbmp = new Bitmap(m_strCapturePath + arrPicName[i] + ".bmp", true);
                //ImageTool.CreatBmpFromByte(bbmp, sbmp, ref x, ref y, ref z, "");
                ImageTool.BmpInsert(bbmp, sbmp, ref x, ref y, ref z, "");
                Sleep(500);
                try
                {
                    sbmp.Dispose();
                }
                catch (Exception e)
                {
                    WriteToFile(e.ToString());
                    WriteToFile(arrPicName[i]);
                }

                //ɾ��Сͼ
                if (Program.bRelease)
                    File.Delete(m_strCapturePath + arrPicName[i] + ".bmp");


            }
            string PicName = SetPicPath(m_strCapturePath, strPicID);
            if (bVerbical)
                //ImageTool.CreatBmpFromByte(bbmp, bbmp, ref x, ref y, ref z, "").Save(m_strCapturePath + strPicID + ".bmp", ImageFormat.Bmp);
                ImageTool.BmpInsert(bbmp, bbmp, ref x, ref y, ref z, "").Save(m_strCapturePath + strPicID + ".bmp", ImageFormat.Bmp);
            else
            {
                if (OrdNo.IndexOf("MZH") == 0 || OrdNo == "���Զ���")
                {
                    Bitmap sbmp = new Bitmap(m_strPicPath + "ˮӡ.bmp", true);
                    ImageTool.BmpInsert(bbmp, sbmp, ref x, ref y, ref z, "ˮӡ");
                    sbmp.Dispose();
                }

                string strJpg = PicName.Replace(".bmp", ".jpg");
                //ImageTool.CreatBmpFromByte(bbmp, bbmp, ref x, ref y, ref z, "").Save(strJpg, ImageFormat.Jpeg);
                ImageTool.BmpInsert(bbmp, bbmp, ref x, ref y, ref z, "").Save(strJpg, ImageFormat.Jpeg);
                picNum++;
            }
            bbmp.Dispose();
            File.Delete(m_strCapturePath + "ģ��.bmp");
            return 1;
        }
        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="strScr">ԭ�ַ���</param>
        /// <param name="strFG">�ָ���</param>
        /// <param name="strArray">�õ��ַ�������</param>
        /// <returns></returns>
        public int SplitString(string strScr, string strFG, out string[] strArray)
        {
            strArray = new string[2000];
            int n = 0;
            int num = 0;
            while (true)
            {
                n = strScr.IndexOf(strFG);
                if (n < 0)
                {
                    strArray[num] = strScr;
                    break;
                }
                strArray[num] = strScr.Substring(0, n);
                strScr = strScr.Substring(n + 1, strScr.Length - n - 1);
                if (strScr == "")
                    break;
                num++;
            }
            return num;
        }
        /// <summary>
        /// ͼƬ����
        /// </summary>
        /// <param name="filePic">������ʾ</param>
        /// <param name="strPicID">ͼƬID</param>
        /// <param name="width">��</param>
        /// <returns></returns>
        public bool CreatePlate(string filePic, string strPicID, int width)
        {
            if (filePic == "����ͼƬ")
            {
                bPicFull = true;
                goto NEXT_STEP;
            }
            if (filePic == "����")
            {
                ptMAX.X = Math.Max(ptBigPic.X, ptMAX.X);
                ptBigPic.X = 0;
                ptBigPic.Y += ptMAX.Y + 1;
                ptMAX.Y = 0;
                return true;
            }
            if (filePic.IndexOf(".bmp") < 0)
                filePic += ".bmp";
            if (!File.Exists(filePic))
            {

                FileRW.WriteToFile(filePic + "<< �ļ������ڣ�");
                return false;
            }
            Bitmap srcBit = (Bitmap)Bitmap.FromFile(filePic, false);
            Rectangle srcRect = new Rectangle(0, 0, srcBit.Width, srcBit.Height);
            BitmapData pBData = srcBit.LockBits(srcRect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);


            //System.Runtime.InteropServices.Marshal.Copy(pBData.Scan0, tData, 0, pBData.Stride * pBData.Height);
            srcBit.UnlockBits(pBData);
            srcBit.Dispose();




            int Swidth = pBData.Width;
            int Sheight = pBData.Height;

            if ((Lwidth - ptBigPic.X) < (Swidth/*+8*/))
            {
                //WriteToFile("��Ȳ���,����\r\n");
                ptMAX.X = Math.Max(ptBigPic.X, ptMAX.X);
                ptBigPic.X = 0;
                ptBigPic.Y += ptMAX.Y + 1;
                ptMAX.Y = 0;
                //WriteToFile("ptBigPic.y=%d\r\n",ptBigPic.y);
            }

            if ((Lheight - ptBigPic.Y) < Sheight)
            {
                //WriteToFile("Lheight-ptBigPic.y={0}-{1}",Lheight,ptBigPic.Y);
                WriteToFile("�߶Ȳ���\r\n");
                return false;

            }


            Point ptLPic = new Point(0, 0);
            ptLPic.Y = ptBigPic.Y;
            ptLPic.X = ptBigPic.X;


            ptMAX.Y = Math.Max(ptMAX.Y, Sheight);/*ptMAX.y<Sheight?Sheight:ptMAX.y;*/


            ptBigPic.X += Swidth;

            if (!bPicFull)
                return true;

        NEXT_STEP:
            if (ptMAX.X == 0 && ptMAX.Y == 0)
            {
                WriteToFile("��ͼΪ��\r\n");
                C = C + 1;
                bPicFull = false;
                return false;
            }

            if (ptBigPic.Y > 0)//����
            {
                ptMAX.X = Math.Max(ptBigPic.X, ptMAX.X);
                ptMAX.Y += ptBigPic.Y;
            }
            else
            {
                if (ptBigPic.X < 130)
                    ptMAX.X = ptBigPic.X + 130;//��ͼƬС��ˮӡ�ߴ�ʱ���������ˮӡ�ĳߴ磨ˮӡ���Ϊ130��
                else
                    ptMAX.X += ptBigPic.X;
            }

            if (width != nZHPicWidth || MZH)  //ȡ���������
                width = ptMAX.X;
            //byte[] pBMPData = new byte[(width + 3) / 4 * 4 * ptMAX.Y * 4];
            byte[] pBMPData = new byte[width * 4 * ptMAX.Y];




            try
            {
                if (filePic == "����ͼƬ")
                {
                    ImageTool.CreatBmpFromByte1(pBMPData, width, ptMAX.Y).Save(strPicID);
                }
                else
                {
                    ImageTool.CreatBmpFromByte(pBMPData, width, ptMAX.Y).Save(strPicID);
                }
            }
            catch (Exception err)
            {
                //throw err;
            }
            //ImageTool.CreatBmpFromByte(pBMPData, width, ptMAX.Y).Dispose();
            bPicFull = false;
            ptBigPic.X = 0;
            ptBigPic.Y = 0;
            ptMAX.Y = 0;
            ptMAX.X = 0;
            return true;
        }
        //��ҳ��֤
        private string GetTheVison(string ExeName)
        {

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://172.16.74.11:38800/ZH_QQ_CHECK/syupversion.txt");
                WebResponse response = request.GetResponse();
                Stream myStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("gb2312"));
                string jsContent = sr.ReadToEnd();// FileRW.ReadFile("d:\\dq_server_237.js");
                if (jsContent != "")
                {
                    int ipos = jsContent.IndexOf(ExeName);
                    if (ipos >= 0)
                    {
                        jsContent = jsContent.Substring(ipos + ExeName.Length + 1);
                        ipos = jsContent.IndexOf("\r\n");
                        if (ipos >= 0)
                        {
                            jsContent = jsContent.Substring(0, ipos);
                        }
                        return jsContent;
                    }
                }
            }
            catch
            {
                WriteToFile("�汾��ȡʧ��");
            }
            return "";
        }
        public void CheckVersion()
        {
            long a;
            WebClient client = new WebClient();
            string URLAddress = @"http://172.16.74.11:38800/ZH_QQ_CHECK/��Ѷ����ϵ��.exe";

            string receivePath = m_strProgPath + "\\";
            string localpath = m_strProgPath + "\\QQlogin.exe";
            if (!File.Exists(localpath))
            {
                client.DownloadFile(URLAddress, receivePath + System.IO.Path.GetFileName(URLAddress));
                string localpath1 = m_strProgPath + "\\��Ѷ����ϵ��.exe";
                Game.StartProcess(localpath1, "start");
                Sleep(2000);
            }
            System.Diagnostics.FileVersionInfo fv = System.Diagnostics.FileVersionInfo.GetVersionInfo(localpath);
            string WebVersion = GetTheVison("TengXun");
            if (fv.FileVersion == WebVersion)
            {
                return;
            }
            else
            {
                client.DownloadFile(URLAddress, receivePath + System.IO.Path.GetFileName(URLAddress));
                string localpath1 = m_strProgPath + "\\��Ѷ����ϵ��.exe";
                Game.StartProcess(localpath1, "start");
                Sleep(2000);
                return;
            }
            //WebClient client = new WebClient();
            //client.DownloadFile(URLAddress, receivePath + System.IO.Path.GetFileName(URLAddress));//ͨ��url����
            //Game.StartProcess(localpath, "start");
            //return;
        }
        private int CheckAccount()
        {
            int status = 1;
            string strlog;
            strlog = "�ȴ���˽��...";
            bool flag = false;
            bool WaitFlag = false;
            int SecondN = 0;
            CheckVersion();
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, "QQlogin", out flag);
            try
            {
                WaitFlag = mutex.WaitOne();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //GTR.Cookies ck = new Cookies();
            //ck.CleanAll();//��cookies
            for (int j = 0; j < 2; j++)
            {
                Sleep(5000);
                string orderdata;
                WriteToFile("��ȡ�ʺ�������");
                orderdata = string.Format("{0} {1} {2} {3} {4}", m_strAccount, m_strPassword, OrdNo, "1", the_nRC2Port.ToString());
                Game.StartProcess(m_strProgPath + "\\QQlogin.exe", orderdata);
                m_hGameWnd = IntPtr.Zero;
                m_hGameWnd = User32API.FindWindow(null, "QQlogin");
                for (int i = 0; i < 10; i++)
                {
                    if (i == 9)
                    {
                        WriteToFile("�ȴ���˳�������ʱ");
                        Game.tskill("WangYiFGF");
                        Game.tskill("WangYi");
                        Game.tskill("MailCheck");
                        mutex.ReleaseMutex();
                        return 2120;
                    }
                    if (Game.processStay("QQlogin"))
                    {
                        if (m_hGameWnd != IntPtr.Zero)
                        {
                            WriteToFile("�򿪳ɹ�");
                            break;
                        }
                        else
                            m_hGameWnd = User32API.FindWindow(null, "QQlogin");
                    }
                    Thread.Sleep(2000);
                }
                status = ProcessStpe();
                WriteToFile("�����������...");
                Game.tskill("QQlogin");
                Game.tskill("QQlogin");
                Game.tskill("MailCheck");
                if (status == 3120)
                    continue;
                else
                    break;
            }
            mutex.ReleaseMutex();
            return status;
        }
        public int ProcessStpe()
        {
            for (int i = 0; i < 50; i++)
            {
                m_hGameWnd = User32API.FindWindow(null, "QQlogin");
                if (m_hGameWnd != IntPtr.Zero)
                    Sleep(6000);
                else
                {
                    StringBuilder retVal = new StringBuilder(512);
                    StringBuilder strBuilder = new StringBuilder(512);
                    StringBuilder strBuilder1 = new StringBuilder(512);
                    StringBuilder strBuilder2 = new StringBuilder(512);
                    StringBuilder strBuilder3 = new StringBuilder(512);
                    StringBuilder strBuilder4 = new StringBuilder(512);
                    User32API.GetPrivateProfileString("�˺���Ϣ", "ִ��״̬", "", retVal, 512, m_strProgPath + "\\roleInfo.ini");
                    int a = int.Parse(retVal.ToString());
                    if (a != 1000)
                        return a;
                    User32API.GetPrivateProfileString("�˺���Ϣ", "֤������", "", strBuilder, 512, m_strProgPath + "\\roleInfo.ini");
                    User32API.GetPrivateProfileString("�˺���Ϣ", "�ܱ��ֻ�", "", strBuilder1, 512, m_strProgPath + "\\roleInfo.ini");
                    User32API.GetPrivateProfileString("�˺���Ϣ", "����", "", strBuilder2, 512, m_strProgPath + "\\roleInfo.ini");
                    User32API.GetPrivateProfileString("�˺���Ϣ", "QQ�ȼ�", "", strBuilder3, 512, m_strProgPath + "\\roleInfo.ini");
                    User32API.GetPrivateProfileString("�˺���Ϣ", "QQ����", "", strBuilder4, 512, m_strProgPath + "\\roleInfo.ini");
                    return a;
                }
                if (i % 9 == 0)
                    WriteToFile("��ȡQQ�˺���Ϣ��...");
            }
            return 3120;
        }

        //ȡ��TGP��ȡӢ�ۺ�Ƥ������ƴͼ������·��
        /// <summary>
        /// ��ȡӢ����Ƥ��
        /// </summary>
        /// <returns></returns>
        public int GetHeroAndSkin()
        {
            Point pt = new Point(-1, -2);
            string strWinTitle = string.Empty;
            int index = 0;

            for (int i = 0; i < 10; i++)
            {
                #region ����TGP.exe
                Game.RunCmd("taskkill /im  LOL.exe /F");
                Game.RunCmd("taskkill /im  TGP.exe /F");
                Game.RunCmd("taskkill /im  QQlogin.exe /F");
                Game.RunCmd("taskkill /im  WerFault.exe /F");

                Game.StartProcess(m_strProgPath + @"\TGP.exe", "start");
                Sleep(1000 * 5);
                strWinTitle = WinTitle();
                if (m_hGameWnd != IntPtr.Zero && strWinTitle == "TGP")
                {
                    CaptureJpg();
                    WriteToFile("Ӧ�ó��������ɹ�");
                }
                else
                {
                    WriteToFile("Ӧ�ó����ʧ��");
                    continue;
                }

                TuningWin();//���õ������ں���

                pt = ImageTool.fPic(wwPath + "��.bmp", 0, 0, 50, 50);
                if (pt.X <= 0)
                    pt = ImageTool.fPic(wwPath + "xnj��.bmp", 0, 0, 50, 50);
                if (pt.X <= 0 && i > 2)
                {
                    if (i >= 2)
                    {
                        return 2120;
                    }
                    WriteToFile("��ҳ����ʧ�ܣ�����TGP");
                    continue;
                }
                #endregion

                #region  ��¼
                if (pt.X > 0)
                {
                    //-----------------------------------------------------------------------------------------
                    TuningWin();//���õ������ں���
                    WriteToFile("��ʼ�����˺�[" + m_strAccount + "] ����[" + m_strPassword.Length + "]λ");
                    KeyMouse.MouseClick(220, 80, 1, 1, 500);//����˺������
                    KeyMouse.SendKeys(m_strAccount, 200); //�����˺�
                    //-----------------------------------------------------------------------------------------
                    KeyMouse.MouseClick(220, 115, 1, 1, 500);//������������
                    KeyMouse.SendKeys(m_strPassword, 300); //��������
                    KeyMouse.MouseClick(125, 200, 1, 1, 3000);//�����¼��ť
                    //-----------------------------------------------------------------------------------------                         
                    switch (CheckPW())//���õ�¼��֤����
                    {
                        case 2:
                            {
                                index++;
                                WriteToFile("��" + index.ToString() + "���˺��������");
                                if (index < 3)
                                    continue;
                                CaptureJpg();
                                return 3000;
                            }
                        case 3:
                            return 3333;
                        case 4:
                            return 2230;
                        case 6:
                            return 3700;
                        case 7:
                            return 3360;
                        case 5:
                            return 2120;

                    }
                }
                #endregion

                #region �󶨴���
                if (WinTitle().Contains("�˶�����ɹ�") || WinTitle().Contains("�þ�֮��"))
                {
                    Sleep(1000);
                    if (IsCallPone == 0)
                    {
                        WriteToFile("֪ͨ��վ������ȷ����������");
                        string PostData = string.Format("PublishNO={0}", OrdNo);
                        string strHTML = PostUrlData("http://gtr.5173.com:7080/RobotCallback.asmx/ChangePassword", PostData);
                        WriteToFile(strHTML);

                        PostData = string.Format("gameId={0}&OrdNo={1}&Status={2}", "60", OrdNo, "1000");
                        strHTML = PostUrlData(" http://172.16.74.147:8010/WebService.asmx/SetPhoneData", PostData);
                        WriteToFile(strHTML);
                    }
                    Sleep(3000);//�ȴ����ڼ�����Ϸ����϶�
                    TuningWin();//���õ������ں���
                    WriteToFile("��������:" + m_strServer);
                    KeyMouse.MouseClick(370, 50, 1, 1, 500);//������������
                    tagPoint at = new tagPoint();
                    at.x = 370;
                    at.y = 50;
                    IntPtr s_hGameWnd = User32API.WindowFromPoint(at);//�ú�����ð���ָ����Ĵ��ڵľ��
                    Game.SendString(s_hGameWnd, m_strServer, true);
                    Sleep(1000);
                    KeyMouse.MouseClick(520, 50, 1, 1, 500);//�����ȡָ���������ݰ�ť
                }
                #endregion

                #region ������Դ
                for (int k = 0; k < 300; k++)
                {
                    Sleep(1000);
                    if (k % 20 == 0)
                        WriteToFile("���ڼ�����Դ�����Ե�...");
                    if (WinTitle().Contains("��ȡ���"))
                    {
                        CaptureJpg();
                        WriteToFile("ͼƬ�������");
                        Sleep(1000 * 2);
                        if (File.Exists(m_strProgPath + @"\RoleInfo.txt"))
                        {
                            FileInfo fi = new FileInfo(m_strProgPath + @"\RoleInfo.txt");
                            if (fi.Length == 0)
                            {
                                WriteToFile("�ı�����ʧ��");
                                return 2120;
                            }
                            else
                            {
                                WriteToFile("�������");
                                return 1000;
                            }
                        }
                    }
                    if (WinTitle().Contains("��ȡ����ʧ��"))
                    {
                        WriteToFile("��ȡ����ʧ��");
                        return 2120;
                    }
                }
                WriteToFile("�ı����س�ʱ");
                return 2120;
                #endregion
            }
            WriteToFile("δ֪ԭ�򹤾߻�ȡʧ��");
            return 2120;

        }
        public int GetLOLInfo()
        {
            Point pt = new Point(-1, -2);
            string strWinTitle = string.Empty;
            File.Delete(m_strProgPath + @"\RoleInfo.txt");
            for (int i = 0; i < 3; i++)
            {
                //--------------------------------------------����
                //m_strServer = "��ɫõ��";
                //m_strAccount = "2747902166";
                //m_strPassword = "1234..cc";
                //--------------------------------------------
                Game.RunCmd("taskkill /im  TGP.exe /F");
                Game.RunCmd("taskkill /im  LOL.exe /F");
                Game.StartProcess(m_strProgPath + @"\LOL.exe", m_strServer);
                Sleep(1000 * 3);
                strWinTitle = WinTitle();
                if (m_hGameWnd != IntPtr.Zero && strWinTitle.Contains("LOL��¼"))
                {
                    CaptureJpg();
                    WriteToFile("Ӧ�ó��������ɹ�,�ȴ���ҳ����");
                }
                else
                {
                    WriteToFile("Ӧ�ó����ʧ��");
                    continue;
                }

                TuningWin();//���õ������ں��� 
                //-------------------------------------------------------------------
                for (int z = 0; z < 3; z++)
                {
                    if (z > 0)
                        KeyMouse.SendF5Key();
                    Sleep(10000);
                    pt = ImageTool.fPic(wwPath + "w�˺������¼.bmp", 100, 200, 300, 500, 60);
                    if (pt.X < 0)
                        pt = ImageTool.fPic(wwPath + "xw�˺������¼.bmp", 100, 200, 300, 500, 60);
                    if (pt.X < 0)
                        continue;
                    KeyMouse.MouseClick(194, 380, 1, 1, 1000);//����˺������¼��ť
                    pt = ImageTool.fPic(wwPath + "x��¼.bmp", 140, 250, 300, 350, 60);
                    if (pt.X < 0)
                        pt = ImageTool.fPic(wwPath + "x��¼1.bmp", 140, 250, 300, 350, 60);
                    if (pt.X < 0)
                        pt = ImageTool.fPic(wwPath + "x��¼2.bmp", 140, 250, 300, 350, 60);
                    if (pt.X < 0)
                        pt = ImageTool.fPic(wwPath + "x��¼3.bmp", 140, 250, 300, 350, 60);
                    if (pt.X < 0)
                        pt = ImageTool.fPic(wwPath + "x��¼4.bmp", 140, 250, 300, 350, 60);
                    if (pt.X < 0)
                        pt = ImageTool.fPic(wwPath + "LOL��ҳ��ȡ��¼.bmp", 140, 250, 300, 350, 60);
                    if (pt.X > 0)
                        break;
                }
                if (pt.X < 0)
                    continue;
                //-------------------------------------------------------------------
                KeyMouse.MouseClick(311, 179, 1, 1, 500);//����˺������
                KeyMouse.SendKeys(m_strAccount, 200); //�����˺�               
                KeyMouse.MouseClick(199, 232, 1, 1, 500);//������������
                KeyMouse.SendKeys(m_strPassword, 300); //��������
                KeyMouse.MouseClick(199, 288, 1, 1, 3000);
                WriteToFile("�˺������������");

                for (int k = 0; k < 10; k++)
                {
                    Sleep(500);
                    pt = ImageTool.fPic(wwPath + "LOL��ҳ��֤��.bmp", 0, 0, 0, 0, 60);
                    if (pt.X < 0)
                        pt = ImageTool.fPic(wwPath + "w��֤.bmp", 0, 0, 0, 0, 60);
                    if (pt.X > 0)
                    {
                        WriteToFile("��Ҫ������֤��");
                        CaptureBmpInRect("��֤��", m_strProgPath, pt.X - 213, pt.Y - 76, pt.X - 74, pt.Y - 24);
                        string yzm = AutoVerify(m_strProgPath + "��֤��.BMP", 100);
                        WriteToFile("��֤�뷵�أ�" + yzm);
                        KeyMouse.MouseClick(pt.X - 13, pt.Y - 44, 1, 1, 300);
                        KeyMouse.SendKeys(yzm, 100); //������֤��
                        KeyMouse.MouseClick(pt.X + 5, pt.Y + 5, 1, 1, 300);
                        continue;
                    }
                    if (pt.X < 0 && k > 4)
                        break;
                }
                Sleep(3000);
                //-------------------------------������ڲ���----------------------------
                if (true)
                {
                    List<int> listhwnd = myapp.EnumWindow("", "#32770");
                    foreach (int hwdl in listhwnd)
                    {
                        IntPtr hwdl2 = (IntPtr)hwdl;
                        string winTitle = User32API.GetWindowText(hwdl2).Trim();//��ȡ���ڱ���
                        //WriteToFile(winTitle);
                        if (winTitle.Contains("���"))
                        {
                            WriteToFile("���");
                            return 3360;
                        }
                    }
                    //IntPtr fath = User32API.FindWindow("#32770", "XXX");
                    //IntPtr fath = myapp.FindWindow(null, "�˺ŵ�ǰ״̬");
                    //string winTitle = User32API.GetWindowText(fath).Trim();//��ȡ���ڱ���
                    //IntPtr fath = User32API.GetDesktopWindow();
                    //IntPtr hwnd = User32API.FindWindowEx(fath, IntPtr.Zero, "Button", "ȷ��");
                    //WriteToFile(hwnd.ToString());

                }
                //---------------------------------------------------------------------
                if (WinTitle().Contains("�ٻ�ʦ����"))
                {
                    WriteToFile("��¼�ɹ�,���ݼ�����...");
                    for (int z = 0; z < 30; z++)
                    {
                        Sleep(2000);
                        if (File.Exists(m_strProgPath + @"\RoleInfo.txt"))
                        {
                            WriteToFile("�ı��������...");
                            return 1;
                        }
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// ��ȡ���ڱ���
        /// </summary>
        /// <returns></returns>
        public string WinTitle()
        {
            m_hGameWnd = User32API.FindWindow("WTWindow", null);//���ݴ���������ȡ���
            string winTitle = User32API.GetWindowText(m_hGameWnd).Trim();//��ȡ���ڱ���
            return winTitle;
        }
        /// <summary>
        /// ��������
        /// </summary>
        public void TuningWin()
        {
            RECT rt = new RECT();
            Point at = new Point(-1, -2);

            for (int k = 0; k < 3; k++)
            {
                m_hGameWnd = User32API.FindWindow("WTWindow", null);//���ݴ���������ȡ���
                if (m_hGameWnd == IntPtr.Zero)
                {
                    string HwndList = User32API.FindWindowEx_ByProcessName("TGP");
                    int i;
                    int.TryParse(HwndList, out i);
                    m_hGameWnd = (IntPtr)i;
                }
                if (User32API.IsWindowVisible(m_hGameWnd))
                {
                    break;
                }
            }

            for (int k = 0; k < 20; k++)
            {
                User32API.GetWindowRect(m_hGameWnd, out rt);
                User32API.MoveWindow(m_hGameWnd, 0, 0, rt.Width, rt.Height, true);//�϶������Ͻ�
                User32API.SwitchToThisWindow(m_hGameWnd, true);//����ָ�����ڵ��߳����õ�ǰ̨,���Ҽ���ô���
                User32API.SetForegroundWindow(m_hGameWnd);
                Sleep(200);
                at = ImageTool.fPic(wwPath + "��.bmp", 1, 1, 30, 30);
                if (at.X <= 0)
                    at = ImageTool.fPic(wwPath + "xnj��.bmp", 1, 1, 30, 30);
                if (at.X > 0 && k > 1)
                {
                    //WriteToFile("TGP�����������Ͻ�");
                    return;
                }
            }
            WriteToFile("TGP�����϶�ʧ��");
        }
        /// <summary>
        /// ��¼��֤
        /// </summary>
        /// <returns></returns>
        public int CheckPW()
        {
            Point at = new Point(-1, -2);
            WriteToFile("��¼��֤");
            for (int l = 0; l < 20; l++)
            {
                if (WinTitle().Contains("���绷���쳣"))
                {
                    WriteToFile("���绷���쳣,��Ҫ���Ҹ������·���");
                    CaptureJpg("���绷���쳣");
                    return 3;
                }
                if (WinTitle().Contains("�������绷�����ܷ����˱仯"))
                {
                    WriteToFile("���绷�������仯,��Ҫ���Ҹ������·���");
                    CaptureJpg("���绷���쳣");
                    return 6;
                }
                if (WinTitle().Contains("��Ҫ��֤��"))
                {
                    WriteToFile("��Ҫ������֤��");
                    if (!PIN())//������֤�뺯��
                        return 4;
                }
                if (WinTitle().Contains("����") || WinTitle().Contains("����") || WinTitle().Contains("�޷���½"))
                {
                    WriteToFile("��ص�¼�����˺��޷���¼");
                    CaptureJpg("�޷���½");
                    return 3;
                }
                if (WinTitle().Contains("���벻��ȷ") || WinTitle().Contains("UDP") || WinTitle().Contains("���Զ�ѡ��"))
                {
                    //WriteToFile("���벻��ȷ");
                    return 2;
                }
                if (WinTitle().Contains("���"))
                {
                    WriteToFile(WinTitle());
                    return 7;
                }

                if (WinTitle().Contains("�˶�����ɹ�"))
                {
                    WriteToFile("�˶�����ɹ�");
                    CaptureJpg("�˶�����ɹ�");
                    return 1;
                }
                if (WinTitle().Contains("�þ�֮��"))
                {
                    WriteToFile("�˶�����ɹ�,�˺Ųþ�");
                    CaptureJpg("�˶�����ɹ�");
                    return 1;
                }
                Sleep(300);
            }
            return 5;
        }
        /// <summary>
        /// ww��֤��
        /// </summary>
        public bool PIN()
        {
            string wwPath = m_strPicPath + "ww\\";
            string yzm = string.Empty;
            int ytimes = 1;

            for (int i = 0; i < 30; i++)
            {
                TuningWin();//���õ������ں���
                CaptureJpg("��֤�����");
                CaptureBmpInRect("��֤��", m_strProgPath, 24, 133, 135, 178);
                if (ytimes <= 5)
                {
                    yzm = AutoVerify(m_strProgPath + "��֤��.BMP", 100);
                }
                else
                {
                    if (ytimes == 6)
                        WriteToFile("�����������Σ�ת���˹�����");
                    jpgResize(m_strProgPath + "��֤��.bmp", m_strProgPath + "��֤��1.jpg", 125, 52);
                    //�˹����ⷵ�ص���֤��
                    yzm = RequestSafeCardInfo(1, m_strProgPath + "��֤��1.jpg", "", 180);
                }
                if (yzm.Length != 4)
                {
                    KeyMouse.MouseClick(125, 200, 1, 1, 500);//���ˢ����֤��
                    continue;
                }
                WriteToFile("��" + ytimes + "��������֤��:" + yzm);
                KeyMouse.MouseClick(220, 155, 1, 1, 500);//�����֤�������
                KeyMouse.SendBackSpaceKey(4);//ɾ��������֤����ĸ
                KeyMouse.SendKeys(yzm, 200);
                Sleep(1000);
                if (WinTitle().Contains("��֤�����") || WinTitle().Contains("��Ҫ��֤��") || WinTitle().Contains("��������"))
                {
                    WriteToFile("��֤�����");
                    if (ytimes >= 8)
                    {
                        WriteToFile("��֤ʧ��");
                        CaptureJpg("��֤ʧ��");
                        return false;
                    }
                    ytimes++;
                    KeyMouse.MouseClick(125, 200, 1, 1, 500);//���ˢ����֤��
                    continue;
                }
                else
                    break;
            }
            return true;
        }
        /// <summary>
        /// ����ƴͼӢ����Ƥ��
        /// </summary>
        /// <param name="isHero"></param>
        /// <param name="picPath"></param>
        /// <returns></returns>
        public int ReplaceTGP(bool isHero, string picPath)
        {
            if (TraversalFile(picPath) <= 0)
                return 2120;
            int re = 0;
            int ft = 1;
            int max = 0;
            int hp = 11;
            int sl = 88;
            string type = "h";
            string[] arrTemp;
            arrTemp = FileArr;

            List<string> listTemp = new List<string>();//�ȶ���list����

            if (!isHero)
            {
                hp = 7;
                sl = 35;
                type = "s";
                WriteToFile("��ʼƤ��ƴͼ");
            }
            else { WriteToFile("��ʼӢ��ƴͼ"); }
            if (FileArr.Length > sl)
            {
                ft = FileArr.Length / sl;
                re = FileArr.Length % sl;
                if (re != 0)
                    ft += 1;
            }
            for (int t = 0; t < ft; t++)
            {
                string pStr = string.Empty;
                if (arrTemp.Length >= sl)
                    max = sl;
                else
                    max = arrTemp.Length;
                for (int j = 0; j < max; j++)
                {
                    if ((j + 1) % sl == 0 || j + 1 == arrTemp.Length)
                    {
                        pStr += arrTemp[j];
                        arrTemp = null;
                        for (int k = sl * (t + 1); k < FileArr.Length; k++)
                        {
                            listTemp.Add(FileArr[k]);
                        }
                        arrTemp = listTemp.ToArray();
                        listTemp.Clear();
                        break;
                    }
                    else
                        pStr += arrTemp[j] + ",";
                    if ((j + 1) % hp == 0)
                        pStr += "����,";
                }
                string pn = string.Empty;
                if (type == "h")//Ӣ��
                {
                    try
                    {
                        PinTuPng(pStr, "LOL5", false, picPath);
                    }
                    catch (Exception ex) { WriteToFile(ex.ToString()); }
                    pn = "LOL5_0" + (t + 1).ToString() + ".jpg";
                }
                else//Ƥ��
                {
                    try
                    {
                        PinTuPng(pStr, "LOL3", false, picPath);
                    }
                    catch (Exception ex) { WriteToFile(ex.ToString()); }
                    if (t > 8)
                        pn = "LOL3_" + (t + 1).ToString() + ".jpg";
                    else
                        pn = "LOL3_0" + (t + 1).ToString() + ".jpg";
                }
                if (File.Exists(m_strCapturePath + pn))
                    File.Delete(m_strCapturePath + pn);
                File.Move(picPath + pn, m_strCapturePath + pn);
            }
            return 1000;
        }
        /// <summary>
        /// ƴͼpng
        /// </summary>
        /// <param name="strAllPic"></param>
        /// <param name="strPicID"></param>
        /// <param name="bVerbical"></param>
        /// <returns></returns>
        public int PinTuPng(string strAllPic, string strPicID, bool bVerbical, string picPath)
        {
            string[] arrPicName;
            int num = SplitString(strAllPic, ",", out arrPicName);

            for (int i = 0; i < num + 1; i++)
            {
                if (arrPicName[i] == "����")
                {
                    CreatePlatePng("����", "", nZHPicWidth);
                    continue;
                }

                CreatePlatePng(picPath + arrPicName[i], "", nZHPicWidth);
            }
            string strPic = picPath + "ģ��.bmp";
            if (bVerbical)
            {
                if (!CreatePlatePng("����ͼƬ", strPic, 0))
                    return 1;
            }
            else
            {
                if (!CreatePlatePng("����ͼƬ", strPic, nZHPicWidth))
                    return 1;
            }
            Bitmap bbmp = new Bitmap(strPic, true);
            int x = 0, y = 0, z = 0;
            for (int i = 0; i < num + 1; i++)
            {

                if (arrPicName[i] == "����")
                {
                    //ImageTool.CreatBmpFromByte(bbmp, bbmp, ref x, ref y, ref z, "����");
                    try
                    {
                        ImageTool.BmpInsert(bbmp, bbmp, ref x, ref y, ref z, "����");//��һ��BmpInsert
                    }
                    catch (Exception ex)
                    {
                        WriteToFile("BmpInsert1");
                        WriteToFile(ex.ToString());
                    }
                    continue;
                }
                if (!File.Exists(picPath + arrPicName[i] + ".png"))
                    continue;
                Bitmap sbmp = new Bitmap(picPath + arrPicName[i] + ".png", true);
                try
                {
                    ImageTool.BmpInsert(bbmp, sbmp, ref x, ref y, ref z, "");//�ڶ���BmpInsert
                }
                catch (Exception ex)
                {
                    WriteToFile("BmpInsert2");
                    WriteToFile(ex.ToString());
                }
                Sleep(50);
                try
                {
                    sbmp.Dispose();
                }
                catch (Exception e)
                {
                    WriteToFile(e.ToString());
                    WriteToFile(arrPicName[i]);
                    Sleep(500);
                    sbmp.Dispose();
                }

                //ɾ��Сͼ
                if (Program.bRelease)
                {
                    string[] arrPicRank = new string[] { "��ǰ������", "��ͭ", "����", "�ƽ�", "����", "��ʯ", "��ʦ", "��ǿ" };

                    for (int o = 0; o < 8; o++)
                    {
                        if (arrPicName[i].Contains(arrPicRank[o]))
                        {
                            noDel = true;
                            break;
                        }
                    }
                    if (!noDel)
                        File.Delete(picPath + arrPicName[i] + ".png");
                }
            }
            string PicName = SetPicPath(picPath, strPicID);
            if (bVerbical)
            {
                try
                {
                    //ImageTool.CreatBmpFromByte(bbmp, bbmp, ref x, ref y, ref z, "").Save(m_strCapturePath + strPicID + ".bmp", ImageFormat.Bmp);
                    ImageTool.BmpInsert(bbmp, bbmp, ref x, ref y, ref z, "").Save(picPath + strPicID + ".bmp", ImageFormat.Bmp);//������BmpInsert
                }
                catch (Exception ex)
                {
                    WriteToFile("BmpInsert3");
                    WriteToFile(ex.ToString());
                }
            }
            else
            {
                //if (OrdNo.IndexOf("MZH") == 0 || OrdNo == "���Զ���")
                //{
                //    Bitmap sbmp = new Bitmap(m_strPicPath + "ˮӡ.bmp", true);
                //    try
                //    {
                //        ImageTool.BmpInsert(bbmp, sbmp, ref x, ref y, ref z, "ˮӡ");//���ĸ�BmpInsert
                //    }
                //    catch (Exception ex)
                //    {
                //        WriteToFile("BmpInsert4");
                //        WriteToFile(ex.ToString());
                //    }
                //    sbmp.Dispose();
                //}
                string strJpg = PicName.Replace(".bmp", ".jpg");
                //ImageTool.CreatBmpFromByte(bbmp, bbmp, ref x, ref y, ref z, "").Save(strJpg, ImageFormat.Jpeg);
                try
                {
                    if (m_strOrderType == "������")
                    {
                        CreatWaterMark(strJpg, ImageTool.BmpInsert(bbmp, bbmp, ref x, ref y, ref z, ""));
                    }
                    else
                        ImageTool.BmpInsert(bbmp, bbmp, ref x, ref y, ref z, "").Save(strJpg, ImageFormat.Jpeg);//�����BmpInsert 
                }
                catch (Exception ex)
                {
                    WriteToFile("BmpInsert5");
                    WriteToFile(ex.ToString());
                }
                picNum++;
            }
            bbmp.Dispose();

            for (int j = 0; j < 3; j++)
            {
                File.Delete(strPic);
                if (File.Exists(strPic))
                {
                    Sleep(1000);
                    bbmp.Dispose();
                    continue;
                }
                break;
            }
            File.Delete(picPath + "RoleList.png");
            File.Delete(picPath + "TierInfo.png");
            return 1;
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <returns></returns>
        public int TraversalFile(string dirPath)
        {
            List<string> list = new List<string>();//�ȶ���list����
            int count = 0;
            //��ָ��Ŀ¼�����ļ�
            if (Directory.Exists(dirPath))
            {
                DirectoryInfo Dir = new DirectoryInfo(dirPath);
                try
                {
                    foreach (FileInfo file in Dir.GetFiles())//������Ŀ¼ 
                    {
                        string arrName = string.Empty;
                        count++;
                        if (file.Name.Contains("jpg"))
                        {

                            using (FileStream fs = new FileStream(dirPath + file.Name, FileMode.Open, FileAccess.Read))
                            {
                                System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                                Bitmap map = new Bitmap(image);
                                arrName = file.Name.Replace(".jpg", "");
                                if (IsGetZie)
                                    picResizePng(dirPath + file.Name, dirPath + arrName + ".png", 122, 222);
                                else
                                    picResizePng(dirPath + file.Name, dirPath + arrName + ".png", image.Width, image.Height);
                            }
                            file.Delete();
                        }
                        else if (file.Name.Contains("png"))
                            arrName = file.Name.Replace(".png", "");

                        list.Add(arrName); //��list��ֵ                    
                    }
                    list.Sort();
                    FileArr = list.ToArray();//��ת������   
                    if (dirPath.Contains("Hero"))
                    {
                        WriteToFile("����" + intHero + "��Ӣ��ͼƬ����ȡ�����鳤��Ϊ" + count);
                        if (count < intHero)
                        {
                            WriteToFile("��ȡӢ���������ȡ��ƥ��,�ȴ���������");
                            if (IsGetZie)
                                KeyMouse.MouseClick(520, 50, 1, 2, 500);//�����ȡָ���������ݰ�ť
                            Sleep(3000);
                        }
                    }
                    if (dirPath.Contains("Skin"))
                    {
                        WriteToFile("����" + intSkin + "��Ƥ��ͼƬ����ȡ�����鳤��Ϊ" + count);
                        if ((count + 2) < intSkin)
                        {
                            writetime++;
                            WriteToFile("��ȡƤ������������ƥ��,�ȴ���������");
                            if (IsGetZie)
                                KeyMouse.MouseClick(520, 50, 1, 2, 500);//�����ȡָ���������ݰ�ť
                            Sleep(20 * 1000);
                            TraversalFile(m_strProgPath + @"\Skin\");
                            if (writetime == 5)
                            {
                                WriteToFile("�ȴ�����100��");
                                return 0;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return FileArr.Length;
        }
        /// <summary>
        /// ������Ҫ�ϴ���jpg��ʽ��ͼƬ���»��ߡ�
        /// </summary>
        public void TraversalPicJpg()
        {
            if (Directory.Exists(m_strCapturePath))
            {
                DirectoryInfo Dir = new DirectoryInfo(m_strCapturePath);
                try
                {
                    foreach (FileInfo file in Dir.GetFiles("*.jpg"))//������Ŀ¼ 
                    {
                        string arrName = string.Empty;
                        if (file.Name.Contains("jpg") && file.Name.Contains("_"))
                        {
                            using (FileStream fs = new FileStream(m_strCapturePath + file.Name, FileMode.Open, FileAccess.Read))
                            {
                                System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                                WriteToFile("ͼƬ���ƣ�" + file.Name + ",ͼƬ��ȣ�" + image.Width + ",ͼƬ�߶ȣ�" + image.Height);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        /// <summary>
        /// ��ȡ�˺���Ϸ��Ϣ
        /// </summary>
        public void LOLRead(string path)
        {
            // �����ļ�������
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                string str = Encoding.GetEncoding("GB18030").GetString(array);
                try
                {
                    if (str.Contains("��ȯ") && str.Contains("���"))
                    {
                        WriteToFile("��ɫ��ȡ�ɹ�");
                    }
                    else
                    {
                        WriteToFile("�÷������޽�ɫ");
                        Status = 3010;
                        return;
                    }
                    string[] strArr = Regex.Split(str, "\r\n");
                    string newStr = string.Empty;
                    for (int i = 0; i < 7; i++)
                    {
                        newStr += strArr[i] + "\r\n";
                    }
                    WriteToFile(newStr);
                }
                catch (Exception e) { WriteToFile(e.ToString()); }
                //string name = MyStr.FindStr(str, "�ٻ�ʦ���֣�", "\r\n").Trim();

                grade = MyStr.FindStr(str, "�ȼ���", "\r\n").Trim();
                Level = MyStr.FindStr(str, "S7��˫�ţ�", "\r\n").Trim();
                string strRANK = Level;
                if (Level == "�޶�λ")
                {
                    Random ro = new Random();
                    int iResult = ro.Next(1, 5);
                    if (iResult >= 4)
                        Level = "��λ��-��ŷ��";
                    else if (iResult >= 3)
                        Level = "��λ��-¬����";
                    else if (iResult >= 2)
                        Level = "��λ��-����";
                    else if (iResult >= 1)
                        Level = "��λ��-��";
                    strRANK = "��ǰ������";
                }
                if (Level.Contains("��ǿ����"))
                {
                    Level = "��ǿ����";
                    strRANK = "��ǿ����";
                }
                if (Level.Contains("������ʦ"))
                {
                    Level = "������ʦ";
                    strRANK = "������ʦ";
                }
                //Level = "��ҫ�ƽ�II";
                string Level2 = MyStr.FindStr(str, "S7�����λ��", "\r\n").Trim();
                djc = int.Parse(MyStr.FindStr(str, "��ȯ��", "\r\n").Trim());
                intCoin = int.Parse(MyStr.FindStr(str, "��ң�", "\r\n").Trim());
                string hero = MyStr.FindStr(str, "Ӣ��������", "\r\n").Trim();
                string skin = MyStr.FindStr(str, "Ƥ��������", "\r\n").Trim();
                if (hero == "" || hero == null)
                    hero = "0";
                if (skin == "" || skin == null)
                    skin = "0";
                intHero = int.Parse(hero);
                intSkin = int.Parse(skin);

                int width = 250;

                string LOLTempPath = m_strProgPath + @"\LOLTemp\";
                try
                {
                    if (File.Exists(@m_strCapturePath + "temp.png"))
                        File.Delete(@m_strCapturePath + "temp.png");
                    Bitmap bmp = new Bitmap(LOLTempPath + "�Ű�.bmp"); //��ȡ��Ҫ������ֵ�ͼƬ    
                    Graphics g1 = Graphics.FromImage(bmp);
                    Font font1 = new Font("΢���ź�", 16, FontStyle.Bold);                       //��������ʹ�С
                    SolidBrush sbrush1 = new SolidBrush(Color.FromArgb(218, 218, 218));                //����������ɫ             
                    g1.DrawString(grade, font1, sbrush1, new PointF(353, 32));
                    g1.DrawString(strRANK, font1, sbrush1, new PointF(353, 58));
                    g1.DrawString(Level2, font1, sbrush1, new PointF(353, 84));
                    g1.DrawString(djc.ToString(), font1, sbrush1, new PointF(353, 109));
                    g1.DrawString(intCoin.ToString(), font1, sbrush1, new PointF(353, 136)); //������ͼƬ�ϵ�����x,y
                    g1.DrawString(hero, font1, sbrush1, new PointF(353, 162));
                    g1.DrawString(skin, font1, sbrush1, new PointF(353, 189));
                    if (!Directory.Exists(m_strCapturePath))
                        Directory.CreateDirectory(m_strCapturePath);
                    bmp.Save(@m_strCapturePath + "temp.png");
                    PicAddWaterMark1(m_strCapturePath + "\\temp.png", LOLTempPath + (Level + ".jpg"), 24, 27, false);
                    bmp.Dispose();
                    PinTuPng("temp", "LOL1", false, m_strCapturePath);
                }
                catch (Exception ex)
                {
                    WriteToFile(ex.ToString());
                }
                if ((m_strOrderType == "������" && m_GameId == "60") || (OrdNo == "���Զ���"))
                {
                    File.Copy(m_strProgPath + "\\TierInfo.jpg", m_strCapturePath + "LOL7_01.jpg", true);
                    if (strRANK == "��ǰ������")
                        jpgResize(LOLTempPath + (strRANK + ".png"), m_strCapturePath + "LOL6_01.jpg", 150, 150);
                    else
                        jpgResize(LOLTempPath + (strRANK + ".jpg"), m_strCapturePath + "LOL6_01.jpg", 150, 150);
                    WriteToFile("����ԭͼ��ͼ�ɹ�");
                }
                if (File.Exists(m_strProgPath + "\\RoleList.jpg"))
                {
                    if (m_GameId == "100" || m_strOrderType == "������")
                    {
                        using (FileStream fsm = new FileStream(m_strProgPath + "\\RoleList.jpg", FileMode.Open, FileAccess.Read))
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromStream(fsm);
                            picResize(LOLTempPath + "\\LOLˮӡ.bmp", m_strProgPath + "\\LOLˮӡ.bmp", 100, image.Height - 28);
                        }
                        PicAddWaterMark1(m_strProgPath + "\\RoleList.jpg", m_strProgPath + "\\LOLˮӡ.bmp", 160, 26);
                    }
                    using (FileStream fsm = new FileStream(m_strProgPath + "\\RoleList.jpg", FileMode.Open, FileAccess.Read))
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromStream(fsm);
                        image.Save(@m_strProgPath + "\\RoleList.png", ImageFormat.Png);
                    }
                    File.Move(m_strProgPath + "\\RoleList.png", m_strCapturePath + "RoleList.png");
                    PinTuPng("RoleList", "LOL1", false, m_strCapturePath);
                }
                if (File.Exists(m_strProgPath + "\\TierInfo.jpg"))
                {
                    using (FileStream fsm = new FileStream(m_strProgPath + "\\TierInfo.jpg", FileMode.Open, FileAccess.Read))
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromStream(fsm);
                        image.Save(@m_strProgPath + "\\TierInfo.png", ImageFormat.Png);
                    }
                    File.Move(m_strProgPath + "\\TierInfo.png", m_strCapturePath + "TierInfo.png");
                    PinTuPng("TierInfo", "LOL1", false, m_strCapturePath);
                }
                if (File.Exists(m_strProgPath + "\\Punish.jpg"))
                {
                    using (FileStream fsm = new FileStream(m_strProgPath + "\\Punish.jpg", FileMode.Open, FileAccess.Read))
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromStream(fsm);
                        image.Save(@m_strProgPath + "\\Punish.png", ImageFormat.Png);
                    }
                    File.Move(m_strProgPath + "\\Punish.png", m_strCapturePath + "Punish.png");
                    PinTuPng("Punish", "LOL1", false, m_strCapturePath);
                    WriteToFile("��⵽�˺Ŵ��ڲþ�֮��");
                }

            }
            Sleep(1000);
        }
        /// <summary>
        /// ��ȡ�˺���Ϸ��Ϣ
        /// </summary>
        public void LOLRead2(string path)
        {
            // �����ļ�������
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                string str = Encoding.GetEncoding("GB18030").GetString(array);
                try
                {
                    string[] strArr = Regex.Split(str, "\r\n");
                    string newStr = string.Empty;
                    for (int i = 0; i < 7; i++)
                    {
                        newStr += strArr[i] + "\r\n";
                    }
                    WriteToFile(newStr);
                }
                catch (Exception e) { WriteToFile(e.ToString()); }
                string name = MyStr.FindStr(str, "�ٻ�ʦ���֣�", "\r\n").Trim();
                grade = MyStr.FindStr(str, "�ٻ�ʦ�ȼ���", "\r\n").Trim();
                Level = MyStr.FindStr(str, "�ٻ�ʦ��λ��", "\r\n").Trim();
                string strRANK = Level;
                if (Level == "�޶�λ")
                {
                    Random ro = new Random();
                    int iResult = ro.Next(1, 5);
                    if (iResult >= 4)
                        Level = "��λ��-��ŷ��";
                    else if (iResult >= 3)
                        Level = "��λ��-¬����";
                    else if (iResult >= 2)
                        Level = "��λ��-����";
                    else if (iResult >= 1)
                        Level = "��λ��-��";
                    strRANK = "��ǰ������";
                }
                if (Level.Contains("��ǿ����"))
                {
                    Level = "��ǿ����";
                    strRANK = "��ǿ����";
                }
                if (Level.Contains("������ʦ"))
                {
                    Level = "������ʦ";
                    strRANK = "������ʦ";
                }
                djc = int.Parse(MyStr.FindStr(str, "��ȯ��", "\r\n").Trim());
                intCoin = int.Parse(MyStr.FindStr(str, "��ң�", "\r\n").Trim());
                string hero = MyStr.FindStr(str, "Ӣ��������", "\r\n").Trim();
                string skin = MyStr.FindStr(str, "Ƥ��������", "\r\n").Trim();
                if (hero == "" || hero == null)
                    hero = "0";
                if (skin == "" || skin == null)
                    skin = "0";
                intHero = int.Parse(hero);
                intSkin = int.Parse(skin);

                int width = 250;

                string LOLTempPath = m_strProgPath + @"\LOLTemp\";
                try
                {
                    if (File.Exists(@m_strCapturePath + "temp.png"))
                        File.Delete(@m_strCapturePath + "temp.png");
                    Bitmap bmp = new Bitmap(LOLTempPath + "�ر��Ű�.bmp");        //��ȡ��Ҫ������ֵ�ͼƬ    
                    Graphics g1 = Graphics.FromImage(bmp);
                    Font font1 = new Font("΢���ź�", 16, FontStyle.Bold);                       //��������ʹ�С
                    SolidBrush sbrush1 = new SolidBrush(Color.FromArgb(218, 218, 218));                //����������ɫ 
                    if (m_strOrderType == "������")
                        g1.DrawString("������������������", font1, sbrush1, new PointF(353, 32));
                    else
                        g1.DrawString(name, font1, sbrush1, new PointF(353, 32));
                    g1.DrawString(grade, font1, sbrush1, new PointF(353, 58));
                    g1.DrawString(strRANK, font1, sbrush1, new PointF(353, 84));
                    g1.DrawString(djc.ToString(), font1, sbrush1, new PointF(353, 109));
                    g1.DrawString(intCoin.ToString(), font1, sbrush1, new PointF(353, 136)); //������ͼƬ�ϵ�����x,y
                    g1.DrawString(hero, font1, sbrush1, new PointF(353, 162));
                    g1.DrawString(skin, font1, sbrush1, new PointF(353, 189));
                    if (!Directory.Exists(m_strCapturePath))
                        Directory.CreateDirectory(m_strCapturePath);
                    bmp.Save(@m_strCapturePath + "temp.png");
                    PicAddWaterMark1(m_strCapturePath + "\\temp.png", LOLTempPath + (Level + ".jpg"), 29, 27, false);
                    PinTuPng("temp", "LOL1", false, m_strCapturePath);
                }
                catch (Exception ex)
                {
                    WriteToFile(ex.ToString());
                }
                if ((m_strOrderType == "������" && m_GameId == "60") || (OrdNo == "���Զ���"))
                {
                    if (strRANK == "��ǰ������")
                    {
                        jpgResize(LOLTempPath + (Level + "150.jpg"), m_strCapturePath + "LOL6_01.jpg", 150, 150);
                    }
                    else
                        jpgResize(LOLTempPath + (Level + ".jpg"), m_strCapturePath + "LOL6_01.jpg", 150, 150);
                    WriteToFile("����ԭͼ��ͼ�ɹ�");
                }
                if (File.Exists(m_strProgPath + "\\Punish.jpg"))
                {
                    using (FileStream fsm = new FileStream(m_strProgPath + "\\Punish.jpg", FileMode.Open, FileAccess.Read))
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromStream(fsm);
                        image.Save(@m_strProgPath + "\\Punish.png", ImageFormat.Png);
                    }
                    File.Move(m_strProgPath + "\\Punish.png", m_strCapturePath + "Punish.png");
                    PinTuPng("Punish", "LOL1", false, m_strCapturePath);
                    WriteToFile("��⵽�˺Ŵ��ڲþ�֮��");
                }
            }
            Sleep(1000);
        }
        /// <summary>
        /// ͼƬ����
        /// </summary>
        /// <param name="strFile"></param>
        /// <param name="strNewFile"></param>
        /// <param name="intWidth"></param>
        /// <param name="intHeight"></param>
        /// <returns>����:ԭ�ļ���������,���ļ���������,�µĿ��,�µĸ߶�(���߶�Ϊ0,����������)</returns>
        public bool picResizePng(string strFile, string strNewFile, int intWidth, int intHeight)
        {
            System.Drawing.Bitmap objPic, objNewPic;
            try
            {

                if (!File.Exists(strFile))
                    return false;
                objPic = new System.Drawing.Bitmap(strFile);
                if (intHeight <= 0)
                    intHeight = (intWidth * objPic.Height / objPic.Width);
                objNewPic = new System.Drawing.Bitmap(objPic, intWidth, intHeight);
                objPic.Dispose();
                objPic = null;
                string newFile = strNewFile.Substring(0, strNewFile.LastIndexOf('.'));
                objNewPic.Save(newFile + ".png", ImageFormat.Png);
                objNewPic.Dispose();
                File.Delete(strFile);

            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {

                objNewPic = null;
            }
            return true;
        }
        /// <summary>
        /// ͼƬ����png
        /// </summary>
        /// <param name="filePic">������ʾ</param>
        /// <param name="strPicID">ͼƬID</param>
        /// <param name="width">��</param>
        /// <returns></returns>
        public bool CreatePlatePng(string filePic, string strPicID, int width)
        {
            if (filePic == "����ͼƬ")
            {
                bPicFull = true;
                goto NEXT_STEP;
            }
            if (filePic == "����")
            {
                ptMAX.X = Math.Max(ptBigPic.X, ptMAX.X);
                ptBigPic.X = 0;
                //ptBigPic.Y += ptMAX.Y + 1;
                ptBigPic.Y += ptMAX.Y;
                ptMAX.Y = 0;
                return true;
            }
            if (filePic.IndexOf(".png") < 0)
                filePic += ".png";
            if (!File.Exists(filePic))
            {

                FileRW.WriteToFile(filePic + "<< �ļ������ڣ�");
                return false;
            }
            Bitmap srcBit = (Bitmap)Bitmap.FromFile(filePic, false);
            Rectangle srcRect = new Rectangle(0, 0, srcBit.Width, srcBit.Height);
            BitmapData pBData = srcBit.LockBits(srcRect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);


            //System.Runtime.InteropServices.Marshal.Copy(pBData.Scan0, tData, 0, pBData.Stride * pBData.Height);
            srcBit.UnlockBits(pBData);
            srcBit.Dispose();




            int Swidth = pBData.Width;
            int Sheight = pBData.Height;

            if ((Lwidth - ptBigPic.X) < (Swidth/*+8*/))
            {
                //WriteToFile("��Ȳ���,����\r\n");
                ptMAX.X = Math.Max(ptBigPic.X, ptMAX.X);
                ptBigPic.X = 0;
                ptBigPic.Y += ptMAX.Y + 1;
                ptMAX.Y = 0;
                //WriteToFile("ptBigPic.y=%d\r\n",ptBigPic.y);
            }

            if ((Lheight - ptBigPic.Y) < Sheight)
            {
                //WriteToFile("Lheight-ptBigPic.y={0}-{1}",Lheight,ptBigPic.Y);
                WriteToFile("�߶Ȳ���\r\n");
                return false;

            }


            Point ptLPic = new Point(0, 0);
            ptLPic.Y = ptBigPic.Y;
            ptLPic.X = ptBigPic.X;


            ptMAX.Y = Math.Max(ptMAX.Y, Sheight);/*ptMAX.y<Sheight?Sheight:ptMAX.y;*/


            ptBigPic.X += Swidth;

            if (!bPicFull)
                return true;

        NEXT_STEP:
            if (ptMAX.X == 0 && ptMAX.Y == 0)
            {
                WriteToFile("��ͼΪ��\r\n");
                C = C + 1;
                bPicFull = false;
                return false;
            }

            if (ptBigPic.Y > 0)//����
            {
                ptMAX.X = Math.Max(ptBigPic.X, ptMAX.X);
                ptMAX.Y += ptBigPic.Y;
            }
            else
            {
                if (ptBigPic.X < 130)
                    ptMAX.X = ptBigPic.X + 130;//��ͼƬС��ˮӡ�ߴ�ʱ���������ˮӡ�ĳߴ磨ˮӡ���Ϊ130��
                else
                    ptMAX.X += ptBigPic.X;
            }

            if (width != nZHPicWidth || MZH)  //ȡ���������
                width = ptMAX.X;
            //byte[] pBMPData = new byte[(width + 3) / 4 * 4 * ptMAX.Y * 4];
            byte[] pBMPData = new byte[width * 4 * ptMAX.Y];

            try
            {
                if (filePic == "����ͼƬ")
                {
                    ImageTool.CreatBmpFromByte1(pBMPData, width, ptMAX.Y).Save(strPicID);
                }
                else
                {
                    ImageTool.CreatBmpFromByte(pBMPData, width, ptMAX.Y).Save(strPicID);
                }
            }
            catch (Exception err)
            {
                //throw err;
            }
            //ImageTool.CreatBmpFromByte(pBMPData, width, ptMAX.Y).Dispose();
            bPicFull = false;
            ptBigPic.X = 0;
            ptBigPic.Y = 0;
            ptMAX.Y = 0;
            ptMAX.X = 0;
            return true;
        }
        public bool PicAddWaterMark1(string filePic, string filewater, int left, int top, bool del)
        {
            if (!File.Exists(filePic))
            {
                FileRW.WriteToFile(filePic + "<< �ļ������ڣ�");
                return false;
            }


            Bitmap srcBit = (Bitmap)Bitmap.FromFile(filePic, true);
            Bitmap waterBit = (Bitmap)Bitmap.FromFile(filewater, false);

            int x = left, y = top;
            Rectangle srcRect = new Rectangle(x, y, waterBit.Width, waterBit.Height);
            Rectangle waterRect = new Rectangle(0, 0, waterBit.Width, waterBit.Height);
            BitmapData srcBData = srcBit.LockBits(srcRect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);//Format24bppRgb
            BitmapData waterBData = waterBit.LockBits(waterRect, ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            srcBData.Scan0 = waterBData.Scan0;
            srcBit.UnlockBits(srcBData);
            waterBit.UnlockBits(waterBData);
            srcRect = new Rectangle(0, 0, srcBit.Width, srcBit.Height);
            srcBData = srcBit.LockBits(srcRect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
            int Swidth = srcBData.Width;
            int Sheight = srcBData.Height;
            byte[] tData = new byte[Swidth * Sheight * 4];
            System.Runtime.InteropServices.Marshal.Copy(srcBData.Scan0, tData, 0, srcBData.Stride * srcBData.Height);
            srcBit.UnlockBits(srcBData);
            srcBit.Dispose();
            waterBit.Dispose();
            try
            {
                ImageTool.CreatBmpFromByte(tData, Swidth, Sheight).Save(filePic, ImageFormat.Jpeg);
            }
            catch (Exception err)
            {
            }
            if (del)
            {
                File.Delete(filewater);
            }
            return true;
        }
        public bool PicAddWaterMark1(string filePic, string filewater, int left, int top)
        {
            if (!File.Exists(filePic))
            {
                FileRW.WriteToFile(filePic + "<< �ļ������ڣ�");
                return false;
            }


            Bitmap srcBit = (Bitmap)Bitmap.FromFile(filePic, true);
            Bitmap waterBit = (Bitmap)Bitmap.FromFile(filewater, false);

            int x = left, y = top;
            Rectangle srcRect = new Rectangle(x, y, waterBit.Width, waterBit.Height);
            Rectangle waterRect = new Rectangle(0, 0, waterBit.Width, waterBit.Height);
            BitmapData srcBData = srcBit.LockBits(srcRect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);//Format24bppRgb
            BitmapData waterBData = waterBit.LockBits(waterRect, ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            srcBData.Scan0 = waterBData.Scan0;
            srcBit.UnlockBits(srcBData);
            waterBit.UnlockBits(waterBData);
            srcRect = new Rectangle(0, 0, srcBit.Width, srcBit.Height);
            srcBData = srcBit.LockBits(srcRect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
            int Swidth = srcBData.Width;
            int Sheight = srcBData.Height;
            byte[] tData = new byte[Swidth * Sheight * 4];
            System.Runtime.InteropServices.Marshal.Copy(srcBData.Scan0, tData, 0, srcBData.Stride * srcBData.Height);
            srcBit.UnlockBits(srcBData);
            srcBit.Dispose();
            waterBit.Dispose();
            try
            {
                ImageTool.CreatBmpFromByte(tData, Swidth, Sheight).Save(filePic, ImageFormat.Jpeg);
            }
            catch (Exception err)
            {
            }

            File.Delete(filewater);

            return true;
        }
        public void CreatWaterMark(string strJpg, Bitmap bit)
        {
            #region ��ɫ����
            Bitmap picbmp = bit;
            Rectangle srcRect = new Rectangle(0, 0, picbmp.Width > 1000 ? 1000 : picbmp.Width, picbmp.Height > 1000 ? 1000 : picbmp.Height);
            BitmapData bigBData1 = picbmp.LockBits(srcRect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Bitmap picbtm = new Bitmap(picbmp.Width, picbmp.Height, bigBData1.Stride, PixelFormat.Format32bppArgb, bigBData1.Scan0);//ԭ��
            Bitmap mybm = new Bitmap(m_strPicPath + "����.bmp");
            int Width = mybm.Width;
            int height = mybm.Width;
            Bitmap bm = new Bitmap(Width, height);//��ʼ��һ����¼��ɫЧ����ͼƬ����
            int x, y;
            Color pixel;

            for (x = 0; x < Width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//��ȡ��ǰ���������ֵ
                    if (pixel.R == 8 && pixel.G == 8 && pixel.B == 8)
                        bm.SetPixel(x, y, Color.FromArgb(0, pixel.R, pixel.G, pixel.B));//��ͼ
                    else if (pixel.R == 42 && pixel.G == 42 && pixel.B == 42)
                        bm.SetPixel(x, y, Color.FromArgb(90, 242, 242, 242));//��ͼ
                    else if (pixel.R > 42 && pixel.G > 42 && pixel.B > 42)
                    {
                        int a = 90 - (pixel.R + pixel.G + pixel.B - 42 * 3) / 3;
                        bm.SetPixel(x, y, Color.FromArgb(a, 242, 242, 242));//��ͼ
                    }
                    else
                    {
                        int a = 90 + (pixel.R + pixel.G + pixel.B - 42 * 3) / 3;
                        bm.SetPixel(x, y, Color.FromArgb(a, 242, 242, 242));//��ͼ
                    }
                }
            }
            BitmapData bigBData = bm.LockBits(srcRect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Bitmap bmp2 = new Bitmap(picbmp.Width > 1000 ? 1000 : picbmp.Width, picbmp.Height > 1000 ? 1000 : picbmp.Height, bigBData.Stride, PixelFormat.Format32bppArgb, bigBData.Scan0);
            Sleep(50);

            Graphics graph1 = Graphics.FromImage(picbtm);//picbtm
            graph1.DrawImage(bmp2, 0, 0);
            picbtm.Save(strJpg, ImageFormat.Jpeg);

            graph1.Dispose();
            bmp2.Dispose();
            bm.UnlockBits(bigBData);
            bm.Dispose();
            mybm.Dispose();
            picbmp.Dispose();
            Sleep(100);
            #endregion
        }
    }
}
