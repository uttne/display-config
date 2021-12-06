
namespace User32W
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdisplaysettingsexa#parameters
    /// </remarks>
    [Flags]
    public enum EnumDisplaySettingsExFlags : uint
    {
        EDS_RAWMODE = 0x2u,
        EDS_ROTATEDMODE = 0x4u
    }
}
