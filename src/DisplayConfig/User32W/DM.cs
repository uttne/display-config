
namespace User32W
{
    [Flags]
    public enum DM : uint
    {
        DM_ORIENTATION = 0x1, // dmOrientation
        DM_PAPERSIZE = 0x2, // dmPaperSize
        DM_PAPERLENGTH = 0x4, // dmPaperLength
        DM_PAPERWIDTH = 0x8, // dmPaperWidth
        DM_SCALE = 0x10, //    dmScale
        DM_POSITION = 0x20, //    dmPosition
        DM_COPIES = 0x100, //   dmCopies
        DM_DEFAULTSOURCE = 0x200, //   dmDefaultSource
        DM_PRINTERQUALITY = 0x400, //  dmPrinterQuality
        DM_COLOR = 0x800, //   dmColor
        DM_DUPLEX = 0x1000, //  dmDuplex
        DM_YRESOLUTION = 0x2000, //  dmYResolution
        DM_TTOPTION = 0x4000, //  dmTTOption
        DM_COLLATE = 0x8000, //	dmCollate
        DM_FORMNAME = 0x10000, // dmFormName
        DM_LOGPIXELS = 0x20000, // dmLogPixels
        DM_BITSPERPEL = 0x40000, // dmBitsPerPel
        DM_PELSWIDTH = 0x80000, // dmPelsWidth
        DM_PELSHEIGHT = 0x100000, //    dmDisplayFlags
        DM_DISPLAYFREQUENCY = 0x400000, //    dmDisplayFrequency
        DM_ICMMETHOD = 0x2000000, //   dmICMMetHod
        DM_ICMINTENT = 0x4000000, //   dmICMintent
        DM_MEDIANTENT = 0x8000000, //   dmMediaType
        DM_DITHERTYPE = 0x10000000, //  dmDitherType
    }
}
