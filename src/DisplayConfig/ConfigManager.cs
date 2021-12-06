// See https://aka.ms/new-console-template for more information

namespace DisplayConfig
{
    public class ConfigManager
    {
        public const string DefaultConfigName = "default";

        public const string ConfigFolderName = ".discon";
        public string ConfigDirectoryPath { get; set; } = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ConfigFolderName);

        public async Task<string> SaveAsync(string name, Config config)
        {
            var dir = ConfigDirectoryPath;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var configFilePath = Path.Combine(dir, $"{name}.json");
            using var fs = new FileStream(configFilePath, FileMode.Create);
            var option = new System.Text.Json.JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
            };
            await System.Text.Json.JsonSerializer.SerializeAsync(fs, config, option);

            return configFilePath;
        }

        public string[] GetConfigNames()
        {
            var dir = ConfigDirectoryPath;
            if (!Directory.Exists(dir))
            {
                return new string[0];
            }

            return new DirectoryInfo(dir).GetFiles().Select(x => x.Name[0..^x.Extension.Length]).ToArray();
        }

        public async Task<(bool success, Config config)> TryLoadAsync(string name)
        {
            var dir = ConfigDirectoryPath;
            if (!Directory.Exists(dir))
            {
                return (false, new Config());
            }

            var configFilePath = Path.Combine(dir, $"{name}.json");

            if (!File.Exists(configFilePath))
            {
                return (false, new Config());
            }

            using var fs = new FileStream(configFilePath, FileMode.Open);
            var option = new System.Text.Json.JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
            };
            var config = await System.Text.Json.JsonSerializer.DeserializeAsync<Config>(fs, option);
            return (true, config);
        }
    }
}
