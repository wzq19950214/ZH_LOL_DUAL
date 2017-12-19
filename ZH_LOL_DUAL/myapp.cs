using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using System.IO;
using System.Diagnostics;

namespace RC_ZH_LOL
{
    class myapp
    {
       
        private delegate bool WNDENUMPROC(IntPtr hWnd, int lParam);
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, int lParam);
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        public struct WindowInfo
        {
            public IntPtr hWnd;
            public string szWindowName;
            public string szClassName;
        }
        /// <summary>
        /// �������� - ����һ��List<WindowInfo> ����
        /// </summary>
        /// <returns></returns>
        public static List<WindowInfo> GetAllDesktopWindows()
        {
            List<WindowInfo> wndList = new List<WindowInfo>();

            //enum all desktop windows
            EnumWindows(delegate(IntPtr hWnd, int lParam)
            {
                WindowInfo wnd = new WindowInfo();
                StringBuilder sb = new StringBuilder(256);
                wnd.hWnd = hWnd;
                GetWindowTextW(hWnd, sb, sb.Capacity);
                wnd.szWindowName = sb.ToString();
                GetClassNameW(hWnd, sb, sb.Capacity);
                wnd.szClassName = sb.ToString();
                wndList.Add(wnd);
                return true;
            }, 0);

            return wndList;
        }
        /// <summary>
        /// ��ѡ���� - �������������ľ������
        /// </summary>
        /// <param name="textName">���ڱ��� - Ϊ�ղ�ƥ�����( ģ��ƥ�䣬�����ִ�Сд)</param>
        /// <param name="textClass">�������� - Ϊ�ղ�ƥ������( ģ��ƥ�䣬�����ִ�Сд)</param>
        /// <returns></returns>
        public static List<int> EnumWindow(string textName, string textClass)
        {
            CompareInfo Compare = CultureInfo.InvariantCulture.CompareInfo;
            List<int> gethwnd = new List<int>();
            //��ȡ�����о��
            List<WindowInfo> Listwindows = GetAllDesktopWindows();
            //
            foreach (WindowInfo wdf in Listwindows)
            {
                if (textName != "" && textClass != "")
                {
                    if (Compare.IndexOf(wdf.szClassName.ToUpper(), textClass.ToUpper()) > -1 && Compare.IndexOf(wdf.szWindowName.ToUpper(), textName.ToUpper()) > -1)
                    {
                        gethwnd.Add((int)wdf.hWnd);
                    }
                }
                else if (textName == "" && textClass == "")
                {
                    gethwnd.Add((int)wdf.hWnd);
                    //������
                }
                else if (textName == "")
                {
                    //ֻƥ������
                    if (Compare.IndexOf(wdf.szClassName.ToUpper(), textClass.ToUpper()) > -1)
                    {
                        gethwnd.Add((int)wdf.hWnd);
                    }
                }
                else if (textClass == "")
                {
                    //ֻƥ�����
                    if (Compare.IndexOf(wdf.szWindowName.ToUpper(), textName.ToUpper()) > -1)
                    {
                        gethwnd.Add((int)wdf.hWnd);
                    }
                }
            }
            return gethwnd;
        }
        public static void RunBat(string batPath)
        {
            Process pro = new Process();
            FileInfo file = new FileInfo(batPath);
            pro.StartInfo.WorkingDirectory = file.Directory.FullName;
            pro.StartInfo.FileName = batPath;
            pro.StartInfo.CreateNoWindow = false;
            pro.Start();
        }
    }
}
