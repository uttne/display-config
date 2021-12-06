using User32W.Utils;

namespace User32W
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// </summary>
    /// <remarks>
    /// 
    /// 以下の PInvoke.NET を参考にして書いていたが
    /// http://www.pinvoke.net/default.aspx/Structures/DEVMODE.html
    /// 以下の公式のソースを参考にしたときに足りないフィールドがあったのでこちらに合わせる
    /// https://referencesource.microsoft.com/#PresentationFramework/src/Framework/MS/Internal/Printing/NativeMethods.cs,b427afffac878b6d,references
    /// 実際のコードには足りないフィールドが追加されていた
    /// https://github.com/dotnet/pinvoke/blob/9b53ec468d9906368fb050a1f625973292418c11/src/Windows.Core/DEVMODE.cs
    /// 
    /// ちなみにここで定義される DEVMODE は DEVMODEW のことなので Unicode 仕様となる 
    /// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-devmodew
    /// また Ansi 仕様は以下を参照
    /// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-devmodea
    /// 
    /// String32 以降の FieldOffset が 64 ずれるのは DEVMODEW で1文字が 2 byte になるため
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct DEVMODE
    {
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
        [System.Runtime.InteropServices.FieldOffset(0)]
        public String32W dmDeviceName;

        [System.Runtime.InteropServices.FieldOffset(64)]
        public Int16 dmSpecVersion;
        [System.Runtime.InteropServices.FieldOffset(66)]
        public Int16 dmDriverVersion;
        [System.Runtime.InteropServices.FieldOffset(68)]
        public Int16 dmSize = (Int16)Marshal.SizeOf<DEVMODE>();
        [System.Runtime.InteropServices.FieldOffset(70)]
        public Int16 dmDriverExtra;
        [System.Runtime.InteropServices.FieldOffset(72)]
        public DM dmFields;

        [System.Runtime.InteropServices.FieldOffset(76)]
        Int16 dmOrientation;
        [System.Runtime.InteropServices.FieldOffset(78)]
        Int16 dmPaperSize;
        [System.Runtime.InteropServices.FieldOffset(80)]
        Int16 dmPaperLength;
        [System.Runtime.InteropServices.FieldOffset(82)]
        Int16 dmPaperWidth;
        [System.Runtime.InteropServices.FieldOffset(84)]
        Int16 dmScale;
        [System.Runtime.InteropServices.FieldOffset(86)]
        Int16 dmCopies;
        [System.Runtime.InteropServices.FieldOffset(88)]
        Int16 dmDefaultSource;
        [System.Runtime.InteropServices.FieldOffset(90)]
        Int16 dmPrintQuality;

        [System.Runtime.InteropServices.FieldOffset(76)]
        public POINTL dmPosition;
        [System.Runtime.InteropServices.FieldOffset(84)]
        public Int32 dmDisplayOrientation;
        [System.Runtime.InteropServices.FieldOffset(88)]
        public Int32 dmDisplayFixedOutput;

        [System.Runtime.InteropServices.FieldOffset(92)]
        public short dmColor; // See note below!
        [System.Runtime.InteropServices.FieldOffset(94)]
        public short dmDuplex; // See note below!
        [System.Runtime.InteropServices.FieldOffset(96)]
        public short dmYResolution;
        [System.Runtime.InteropServices.FieldOffset(98)]
        public short dmTTOption;
        [System.Runtime.InteropServices.FieldOffset(100)]
        public short dmCollate; // See note below!
        [System.Runtime.InteropServices.FieldOffset(102)]
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME )]
        public String32W dmFormName;
        [System.Runtime.InteropServices.FieldOffset(166)]
        public Int16 dmLogPixels;
        [System.Runtime.InteropServices.FieldOffset(168)]
        public Int32 dmBitsPerPel;
        [System.Runtime.InteropServices.FieldOffset(172)]
        public Int32 dmPelsWidth;
        [System.Runtime.InteropServices.FieldOffset(176)]
        public Int32 dmPelsHeight;
        [System.Runtime.InteropServices.FieldOffset(180)]
        public Int32 dmDisplayFlags;
        [System.Runtime.InteropServices.FieldOffset(184)]
        public Int32 dmNup;
        [System.Runtime.InteropServices.FieldOffset(184)]
        public Int32 dmDisplayFrequency;
        [System.Runtime.InteropServices.FieldOffset(188)]
        public UInt32 dmICMMethod;
        [System.Runtime.InteropServices.FieldOffset(192)]
        public UInt32 dmICMIntent;
        [System.Runtime.InteropServices.FieldOffset(196)]
        public UInt32 dmMediaType;
        [System.Runtime.InteropServices.FieldOffset(200)]
        public UInt32 dmDitherType;
        [System.Runtime.InteropServices.FieldOffset(204)]
        public UInt32 dmReserved1;
        [System.Runtime.InteropServices.FieldOffset(208)]
        public UInt32 dmReserved2;
        [System.Runtime.InteropServices.FieldOffset(212)]
        public UInt32 dmPanningWidth;
        [System.Runtime.InteropServices.FieldOffset(216)]
        public UInt32 dmPanningHeight;
    }
}
