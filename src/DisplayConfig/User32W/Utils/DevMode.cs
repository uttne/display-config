
namespace User32W.Utils
{
    public class DevMode
    {
        public DevMode() { }
        public DevMode(User32W.DEVMODE devMode)
        {
            this.dmDeviceName = devMode.dmDeviceName;
            this.dmSpecVersion = devMode.dmSpecVersion;
            this.dmDriverVersion = devMode.dmDriverVersion;
            this.dmSize = devMode.dmSize;
            this.dmDriverExtra = devMode.dmDriverExtra;
            this.dmFields = (uint)devMode.dmFields;

            this.dmPosition = devMode.dmPosition;
            this.dmDisplayOrientation = devMode.dmDisplayOrientation;
            this.dmDisplayFixedOutput = devMode.dmDisplayFixedOutput;

            this.dmColor = devMode.dmColor;
            this.dmDuplex = devMode.dmDuplex;
            this.dmYResolution = devMode.dmYResolution;
            this.dmTTOption = devMode.dmTTOption;
            this.dmCollate = devMode.dmCollate;
            this.dmFormName = devMode.dmFormName;
            this.dmLogPixels = devMode.dmLogPixels;
            this.dmBitsPerPel = devMode.dmBitsPerPel;
            this.dmPelsWidth = devMode.dmPelsWidth;
            this.dmPelsHeight = devMode.dmPelsHeight;
            this.dmDisplayFlags = devMode.dmDisplayFlags;
            this.dmNup = devMode.dmNup;
            this.dmDisplayFrequency = devMode.dmDisplayFrequency;
            this.dmICMMethod = devMode.dmICMMethod;
            this.dmICMIntent = devMode.dmICMIntent;
            this.dmMediaType = devMode.dmMediaType;
            this.dmDitherType = devMode.dmDitherType;
            this.dmReserved1 = devMode.dmReserved1;
            this.dmReserved2 = devMode.dmReserved2;
            this.dmPanningWidth = devMode.dmPanningWidth;
            this.dmPanningHeight = devMode.dmPanningHeight;
        }

        public User32W.DEVMODE ConvertTo()
        {
            return new User32W.DEVMODE()
            {
                dmDeviceName = this.dmDeviceName,
                dmSpecVersion = this.dmSpecVersion,
                dmDriverVersion = this.dmDriverVersion,
                dmSize = this.dmSize,
                dmDriverExtra = this.dmDriverExtra,
                dmFields = (User32W.DM)this.dmFields,
                dmPosition = this.dmPosition,
                dmDisplayOrientation = this.dmDisplayOrientation,
                dmDisplayFixedOutput = this.dmDisplayFixedOutput,
                dmColor = this.dmColor,
                dmDuplex = this.dmDuplex,
                dmYResolution = this.dmYResolution,
                dmTTOption = this.dmTTOption,
                dmCollate = this.dmCollate,
                dmFormName = this.dmFormName,
                dmLogPixels = this.dmLogPixels,
                dmBitsPerPel = this.dmBitsPerPel,
                dmPelsWidth = this.dmPelsWidth,
                dmPelsHeight = this.dmPelsHeight,
                dmDisplayFlags = this.dmDisplayFlags,
                dmNup = this.dmNup,
                dmDisplayFrequency = this.dmDisplayFrequency,
                dmICMMethod = this.dmICMMethod,
                dmICMIntent = this.dmICMIntent,
                dmMediaType = this.dmMediaType,
                dmDitherType = this.dmDitherType,
                dmReserved1 = this.dmReserved1,
                dmReserved2 = this.dmReserved2,
                dmPanningWidth = this.dmPanningWidth,
                dmPanningHeight = this.dmPanningHeight,
            };
        }

        public string dmDeviceName { get; set; }

        public Int16 dmSpecVersion { get; set; }
        public Int16 dmDriverVersion { get; set; }
        public Int16 dmSize { get; set; }
        public Int16 dmDriverExtra { get; set; }
        public uint dmFields { get; set; }

        public User32W.POINTL dmPosition { get; set; }
        public Int32 dmDisplayOrientation { get; set; }
        public Int32 dmDisplayFixedOutput { get; set; }

        public short dmColor { get; set; }
        public short dmDuplex { get; set; }
        public short dmYResolution { get; set; }
        public short dmTTOption { get; set; }
        public short dmCollate { get; set; }
        public string dmFormName { get; set; }
        public Int16 dmLogPixels { get; set; }
        public Int32 dmBitsPerPel { get; set; }
        public Int32 dmPelsWidth { get; set; }
        public Int32 dmPelsHeight { get; set; }
        public Int32 dmDisplayFlags { get; set; }
        public Int32 dmNup { get; set; }
        public Int32 dmDisplayFrequency { get; set; }
        public UInt32 dmICMMethod { get; set; }
        public UInt32 dmICMIntent { get; set; }
        public UInt32 dmMediaType { get; set; }
        public UInt32 dmDitherType { get; set; }
        public UInt32 dmReserved1 { get; set; }
        public UInt32 dmReserved2 { get; set; }
        public UInt32 dmPanningWidth { get; set; }
        public UInt32 dmPanningHeight { get; set; }
    }
}
