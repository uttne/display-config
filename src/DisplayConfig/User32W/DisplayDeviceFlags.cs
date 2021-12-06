
namespace User32W
{
    [Flags]
    public enum DisplayDeviceFlags : uint
    {
        DISPLAY_DEVICE_ACTIVE = 0x1u,
        DISPLAY_DEVICE_MIRRORING_DRIVER = 0x8u,
        DISPLAY_DEVICE_MODESPRUNED = 0x8000000u,
        DISPLAY_DEVICE_PRIMARY_DEVICE = 0x4u,
        DISPLAY_DEVICE_REMOVABLE = 0x20u,
        DISPLAY_DEVICE_VGA_COMPATIBLE = 0x10u
    }
}
