// See https://aka.ms/new-console-template for more information

namespace DisplayConfig
{
    public record DisplayOption
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Rotation { get; set; }
        public int Bits { get; set; }
        public int Frequency { get; set; }
        public bool Enable { get; set; }
        public string? DeviceName { get; set; }

        public static DisplayOption Create(string deviceName, User32W.DEVMODE devMode)
        {
            return new DisplayOption
            {
                X = devMode.dmPosition.x,
                Y = devMode.dmPosition.y,
                Width = devMode.dmPelsWidth,
                Height = devMode.dmPelsHeight,
                Rotation = ConvertToRotationFromDisplayOrientation(devMode.dmDisplayOrientation),
                DeviceName = deviceName,
                Enable = (devMode.dmPelsWidth + devMode.dmPelsHeight) != 0,
                Bits = devMode.dmBitsPerPel,
                Frequency = devMode.dmDisplayFrequency,
            };
        }

        public const int DMDO_DEFAULT = 0;
        public const int DMDO_90 = 1;
        public const int DMDO_180 = 2;
        public const int DMDO_270 = 3;

        public static int ConvertToRotationFromDisplayOrientation(int dmDisplayOrientation)
        {
            switch (dmDisplayOrientation)
            {
                case 0: return 0;
                case 1: return 90;
                case 2: return 180;
                case 3: return 270;
                default: throw new ArgumentOutOfRangeException($"'{nameof(dmDisplayOrientation)}' is 0 - 3.");
            }
        }
        public static int ConvertToDisplayOrientationFromRotation(int rotation)
        {
            switch (rotation)
            {
                case 0: return DMDO_DEFAULT;
                case 90: return DMDO_90;
                case 180: return DMDO_180;
                case 270: return DMDO_270;
                default: throw new ArgumentOutOfRangeException($"'{nameof(rotation)}' is 0, 90, 180 or 270.");
            }
        }
    }
}
