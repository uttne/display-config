// See https://aka.ms/new-console-template for more information

using McMaster.Extensions.CommandLineUtils;
using DisplayConfig;

namespace Commands
{
    [Command("save")]
    class SaveCommand
    {
        private readonly DisplayOperator _displayOperator;
        private readonly ConfigManager _configManager;

        [Option("-n|--name", CommandOptionType.SingleValue, Description = "Config name")]
        public string? Name { get; }

        public SaveCommand(DisplayOperator displayOperator, ConfigManager configManager)
        {
            _displayOperator = displayOperator;
            _configManager = configManager;
        }

        public async Task OnExecuteAsync()
        {
            var config = _displayOperator.GetConfig();

            var name = ConfigManager.DefaultConfigName;
            if (!string.IsNullOrEmpty(Name))
            {
                name = Name;
            }

            var configPath = await _configManager.SaveAsync(name, config);
            Console.WriteLine($"Saved '{configPath}'");
        }
    }
}