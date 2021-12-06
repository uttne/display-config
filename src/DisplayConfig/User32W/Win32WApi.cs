using System.Runtime.InteropServices;

namespace User32W
{
    static class Win32WApi
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern DISP_CHANGE ChangeDisplaySettingsEx(string lpszDeviceName, ref DEVMODE lpDevMode, IntPtr hwnd, ChangeDisplaySettingsFlags dwflags, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern DISP_CHANGE ChangeDisplaySettingsEx(IntPtr lpszDeviceName, IntPtr lpDevMode, IntPtr hwnd, ChangeDisplaySettingsFlags dwflags, IntPtr lParam);

        [DllImport("User32", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDisplaySettingsEx(string? lpszDeviceName, EnumDisplaySettingsExModeNumFlags iModeNum, ref DEVMODE lpDevMode, EnumDisplaySettingsExFlags dwFlags);

        [DllImport("User32", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDisplayDevicesW(string? lpDevice, int iDevNum, ref PDISPLAY_DEVICEW lpDisplayDevice, EnumDisplayDevicesFlags dwFlags);

    }
}