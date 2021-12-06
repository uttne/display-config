
namespace User32W.Utils
{
    using System.Runtime.InteropServices;
    using System.Text;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct String128W
    {
        public ulong c00; // 000 - 003
        public ulong c01; // 004 - 007
        public ulong c02; // 008 - 011
        public ulong c03; // 012 - 015
        public ulong c04; // 016 - 019
        public ulong c05; // 020 - 023
        public ulong c06; // 024 - 027
        public ulong c07; // 028 - 031
        public ulong c08; // 032 - 035
        public ulong c09; // 036 - 039
        public ulong c10; // 040 - 043
        public ulong c11; // 044 - 047
        public ulong c12; // 048 - 051
        public ulong c13; // 052 - 055
        public ulong c14; // 056 - 059
        public ulong c15; // 060 - 063
        public ulong c16; // 064 - 067
        public ulong c17; // 068 - 071
        public ulong c18; // 072 - 075
        public ulong c19; // 076 - 079
        public ulong c20; // 080 - 083
        public ulong c21; // 084 - 087
        public ulong c22; // 088 - 091
        public ulong c23; // 092 - 095
        public ulong c24; // 096 - 099
        public ulong c25; // 100 - 103
        public ulong c26; // 104 - 107
        public ulong c27; // 108 - 111
        public ulong c28; // 112 - 115
        public ulong c29; // 116 - 119
        public ulong c30; // 120 - 123
        public ulong c31; // 124 - 127

        public override string ToString()
        {
            var buffer = new byte[128];
            int i = 0;
            unsafe
            {
                fixed (String128W* pFm = &this)
                fixed (byte* pBuffer = buffer)
                {
                    var pSrc = (ushort*)pFm;
                    var pDest = (ushort*)pBuffer;
                    for (i = 0; i < 128; i++)
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
                fixed (String128W* pFm = &this)
                fixed (byte* pBuffer = buffer)
                {
                    var pDest = (ushort*)pFm;
                    var pSrc = (ushort*)pBuffer;

                    int i = 0;
                    var count = Math.Min(128, buffer.Length / 2);
                    for (; i < count; ++i)
                    {
                        *(pDest + i) = *(pSrc + i);
                    }
                    for (; i < 128; ++i)
                    {
                        *(pDest + i) = 0;
                    }
                    *(pDest + 127) = 0;
                }
            }
        }

        public static implicit operator string(String128W str) => str.ToString();
        public static implicit operator String128W(string str)
        {
            var res = new String128W();
            res.SetString(str);
            return res;
        }
    }
}
