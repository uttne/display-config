
namespace User32W.Utils
{
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// PINVOKE.NET に書いている DEVMODE の定義をそのまま使用すると Marshal.SizeOf でサイズを取得するタイミングで以下のようなエラーが発生してしまう。
    /// そのため苦肉の策としてオブジェクトではなくサイズ 32 の文字列用の構造体を定義する。
    /// 
    /// エラー
    /// "it contains an object field at offset 70 that is incorrectly aligned or overlapped by a non-object field."
    /// 
    /// http://www.pinvoke.net/default.aspx/Structures/DEVMODE.html
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct String32W
    {
        public ushort c00;
        public ushort c01;
        public ushort c02;
        public ushort c03;
        public ushort c04;
        public ushort c05;
        public ushort c06;
        public ushort c07;
        public ushort c08;
        public ushort c09;
        public ushort c10;
        public ushort c11;
        public ushort c12;
        public ushort c13;
        public ushort c14;
        public ushort c15;
        public ushort c16;
        public ushort c17;
        public ushort c18;
        public ushort c19;
        public ushort c20;
        public ushort c21;
        public ushort c22;
        public ushort c23;
        public ushort c24;
        public ushort c25;
        public ushort c26;
        public ushort c27;
        public ushort c28;
        public ushort c29;
        public ushort c30;
        public ushort c31;

        public override string ToString()
        {
            var buffer = new byte[64];
            int i = 0;
            unsafe
            {
                fixed (String32W* pFm = &this)
                fixed (byte* pBuffer = buffer)
                {
                    var pSrc = (ushort*)pFm;
                    var pDest = (ushort*)pBuffer;
                    for (i = 0; i < 32; i++)
                    {
                        var c = *(pSrc + i);
                        if (c == 0)
                            break;
                        *(pDest + i) = c;
                    }
                }
            }
            return Encoding.Unicode.GetString(buffer, 0, i * 2);
        }

        public void SetString(string str)
        {
            var buffer = Encoding.Unicode.GetBytes(str);
            unsafe
            {
                fixed (String32W* pFm = &this)
                fixed (byte* pBuffer = buffer)
                {
                    var pDest = (ushort*)pFm;
                    var pSrc = (ushort*)pBuffer;

                    int i = 0;
                    var count = Math.Min(32, buffer.Length / 2);
                    for (; i < count; ++i)
                    {
                        *(pDest + i) = *(pSrc + i);
                    }
                    for (; i < 32; ++i)
                    {
                        *(pDest + i) = 0;
                    }
                    pFm->c31 = 0;
                }
            }
        }

        public static implicit operator string(String32W str) => str.ToString();
        public static implicit operator String32W(string str)
        {
            var res = new String32W();
            res.SetString(str);
            return res;
        }
    }
}
