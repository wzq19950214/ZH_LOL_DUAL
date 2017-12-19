using System;
using System.Runtime;
using System.Runtime.InteropServices;

// ʹ�����ڴ��������ô������ռ�Ϳ���
namespace GTR
{
	// ���ô���ľ�̬��Ա����
	public class KmHelper
	{
        protected enum KmError
		{
			KE_Ok	= 0,
			KE_NotDriverService				= -1,	// δ��װ����
			KE_StartDriverFailure			= -2,	// ������������ʧ��
			KE_OutOfMemory					= -3,	// �����ڲ�����. ( ��: �����ڴ�ʧ��֮�� )
			KE_InvalidParameter				= -4,	// ��������
			KE_LoadResourceDriverFailure	= -5,	// ������Դ����ʧ��
			KE_NotSupportCurrentOS			= -6,	// ������֧�ֵ�ǰ����ϵͳ
			KE_SaveDriverFileFailure		= -7,	// ������������ǰDLL����Ŀ¼ʱʧ��
			KE_FileNotExists				= -8,	// ָ���������ļ�������
			KE_InstallDriverFailure			= -9,	// ��װ����ʧ��
		};

        protected static UInt32 KEY_MAKE = 0;
        protected static UInt32 KEY_BREAK = 1;
        protected static UInt32 KEY_E0 = 2;
        protected static UInt32 KEY_E1 = 4;

		[DllImport( "KeyMouseHelper.dll", EntryPoint="InitKeyMouseDriver", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Winapi )]
        protected static extern Int32 InitKeyMouseDriver();

		[DllImport( "KeyMouseHelper.dll", EntryPoint="CloseKeyMouseDriver", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Winapi )]
        protected static extern void CloseKeyMouseDriver();

		[DllImport( "KeyMouseHelper.dll", EntryPoint="KmSendKey", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Winapi )]
        protected static extern bool KmSendKey(byte ScanCode, bool bKeyDown);

		[DllImport( "KeyMouseHelper.dll", EntryPoint="KmSendExtentKey", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Winapi )]
        protected static extern bool KmSendExtentKey(UInt32 uFuncKey, bool bKeyDown);

		[DllImport( "KeyMouseHelper.dll", EntryPoint="KmMouseKey", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Winapi )]
        protected static extern bool KmMouseKey(bool bLeftButton, bool bButtonDown);

		[DllImport( "KeyMouseHelper.dll", EntryPoint="KmMouseMove", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Winapi )]
        protected static extern bool KmMouseMove(int x, int y, bool bIsAbsolute, bool bScreenCoordinate);

		[DllImport( "KeyMouseHelper.dll", EntryPoint="WiReadPort", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Winapi )]
        protected unsafe static extern bool WiReadPort(UInt16 PortAddr, UInt32* pPortValue, byte bSize);
       // protected static extern bool WiReadPort(UInt16 PortAddr, IntPtr pPortValue, byte bSize);

		[DllImport( "KeyMouseHelper.dll", EntryPoint="WiWritePort", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Winapi )]
        protected static extern bool WiReadPort(UInt16 PortAddr, UInt32 PortValue, byte bSize);

		[DllImport( "KeyMouseHelper.dll", EntryPoint="KmGetCharScanCode", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Winapi )]
        protected static extern Int16 KmGetCharScanCode(Char chKey);

		[DllImport( "KeyMouseHelper.dll", EntryPoint="KmGetExtentScanCode", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Winapi )]
        protected static extern UInt32 WiReadPort(UInt32 uFuncKey);
	}
}