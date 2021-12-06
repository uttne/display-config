// See https://aka.ms/new-console-template for more information

namespace DisplayConfig
{
    public class DisplayOperator
    {
        private IEnumerable<(User32W.PDISPLAY_DEVICEW device, User32W.DEVMODE devMode)> GetDevModeList()
        {
            for (int i = 0; ; ++i)
            {
                var device = new User32W.PDISPLAY_DEVICEW();
                if (!User32W.Win32WApi.EnumDisplayDevicesW(null, i, ref device, User32W.EnumDisplayDevicesFlags.EDD_GET_DEVICE_INTERFACE_NAME))
                    break;

                var devMode = new User32W.DEVMODE();
                User32W.Win32WApi.EnumDisplaySettingsEx(device.DeviceName, User32W.EnumDisplaySettingsExModeNumFlags.ENUM_CURRENT_SETTINGS, ref devMode, User32W.EnumDisplaySettingsExFlags.EDS_RAWMODE);
                yield return (device, devMode);
            }
        }

        public Config GetConfig()
        {
            var devModes = GetDevModeList();

            return new Config(devModes.Select(x => DisplayOption.Create(x.device.DeviceName, x.devMode)).ToArray());
        }

        public bool SetDisplayOption(DisplayOption option)
        {
            var deviceName = option.DeviceName;

            if (string.IsNullOrEmpty(deviceName)){
                throw new ArgumentException();
            }

            var devMode = new User32W.DEVMODE();

            {
                var result = User32W.Win32WApi.EnumDisplaySettingsEx(
                    deviceName,
                    //User32W.EnumDisplaySettingsExModeNumFlags.ENUM_CURRENT_SETTINGS,
                    User32W.EnumDisplaySettingsExModeNumFlags.ENUM_REGISTRY_SETTINGS,
                    ref devMode,
                    User32W.EnumDisplaySettingsExFlags.EDS_RAWMODE);

                if (!result)
                {
                    throw new InvalidOperationException("Failed enum display settings.");
                }
            }

            var currentOption = DisplayOption.Create(deviceName, devMode);

            // 現在値と設定値が互いに False であればその他の設定値が変わっていても API の呼び出しは行わない
            if((option.Enable | currentOption.Enable) == false || option == currentOption)
            {
                return false;
            }

            if (option.Enable)
            {
                devMode.dmPosition.x = option.X;
                devMode.dmPosition.y = option.Y;
                devMode.dmPelsWidth = option.Width;
                devMode.dmPelsHeight = option.Height;
                devMode.dmDisplayOrientation = DisplayOption.ConvertToDisplayOrientationFromRotation(option.Rotation);
                devMode.dmBitsPerPel = 32;
                devMode.dmDisplayFrequency = 60;
            }
            else
            {
                devMode.dmPosition.x = 0;
                devMode.dmPosition.y = 0;
                devMode.dmPelsWidth = 0;
                devMode.dmPelsHeight = 0;
                devMode.dmPosition.x = 0;
            }

            if (currentOption.Enable)
            {
                var result = User32W.Win32WApi.ChangeDisplaySettingsEx(
                    deviceName, 
                    ref devMode, 
                    IntPtr.Zero, 
                    //User32W.ChangeDisplaySettingsFlags.CDS_NONE,
                    User32W.ChangeDisplaySettingsFlags.CDS_UPDATEREGISTRY,
                    IntPtr.Zero);

                if (result != User32W.DISP_CHANGE.Successful)
                {
                    throw new InvalidOperationException("Failed change display settings.");
                }
            }
            else
            {
                var result = User32W.Win32WApi.ChangeDisplaySettingsEx(
                    deviceName, 
                    ref devMode, 
                    IntPtr.Zero, 
                    User32W.ChangeDisplaySettingsFlags.CDS_UPDATEREGISTRY | User32W.ChangeDisplaySettingsFlags.CDS_NORESET, 
                    IntPtr.Zero);

                if(result != User32W.DISP_CHANGE.Successful)
                {
                    throw new InvalidOperationException("Failed change display settings.");
                }

                // ディスプレイの有効を変更を確定する
                var result2 = User32W.Win32WApi.ChangeDisplaySettingsEx(
                    IntPtr.Zero, 
                    IntPtr.Zero, 
                    IntPtr.Zero, 
                    User32W.ChangeDisplaySettingsFlags.CDS_NONE, 
                    IntPtr.Zero);


                if (result2 != User32W.DISP_CHANGE.Successful)
                {
                    throw new InvalidOperationException("Failed change display settings.");
                }

                // ディスプレイを有効にしたときに位置情報の反映などができない場合があるので改めて設定を行う
                SetDisplayOption(option);
            }

            return true;
        }
    }
}
