// See https://aka.ms/new-console-template for more information

using McMaster.Extensions.CommandLineUtils;
using DisplayConfig;

namespace Commands
{
    [Command("load")]
    class LoadCommand
    {
        private readonly DisplayOperator _displayOperator;
        private readonly ConfigManager _configManager;

        [Option("-n|--name", CommandOptionType.SingleValue, Description = "Config name")]
        public string? Name { get; }

        public LoadCommand(DisplayOperator displayOperator, ConfigManager configManager)
        {
            _displayOperator = displayOperator;
            _configManager = configManager;
        }

        public async Task OnExecuteAsync()
        {
            var name = ConfigManager.DefaultConfigName;
            if (!string.IsNullOrEmpty(Name))
            {
                name = Name;
            }

            var configNames = _configManager.GetConfigNames();
            var configName = configNames.FirstOrDefault(x => x == name);

            if (string.IsNullOrEmpty(configName))
            {
                Console.WriteLine($"'{Name}' is not found.");
                Console.WriteLine($"Please choose from the following candidates.");
                foreach (var n in configNames)
                {
                    Console.WriteLine($"{n}");
                }

                return;
            }


            var (success, config) = await _configManager.TryLoadAsync(configName);

            if (!success)
            {
                throw new InvalidOperationException();
            }
            foreach (var option in config)
            {
                var result = _displayOperator.SetDisplayOption(option);
                if (result)
                {
                    Console.WriteLine($"'{option.DeviceName}' changed.");
                }
            }
        }
    }
}