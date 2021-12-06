using User32W.Utils;

namespace User32W
{
    using System.Runtime.InteropServices;

    public struct PDISPLAY_DEVICEW
    {
        public uint cb = (uint)Marshal.SizeOf<PDISPLAY_DEVICEW>();
        public String32W DeviceName;
        public String128W DeviceString;
        public DisplayDeviceFlags StateFlags;
        public String128W DeviceID;
        public String128W DeviceKey;
    }
}
