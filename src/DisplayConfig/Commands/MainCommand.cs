// See https://aka.ms/new-console-template for more information

using McMaster.Extensions.CommandLineUtils;
using DisplayConfig;

namespace Commands
{
    [Command("discon")]
    [Subcommand(typeof(SaveCommand), typeof(LoadCommand), typeof(ListCommand))]
    class MainCommand
    {
        private readonly DisplayOperator _displayOperator;
        private readonly ConfigManager _configManager;

        public MainCommand(DisplayOperator displayOperator, ConfigManager configManager)
        {
            _displayOperator = displayOperator;
            _configManager = configManager;
        }

        public async Task OnExecuteAsync(CommandLineApplication app)
        {
            var names = _configManager.GetConfigNames();

            if (!names.Any())
            {
                var config = _displayOperator.GetConfig();
                var name = ConfigManager.DefaultConfigName;
                var configPath = await _configManager.SaveAsync(name, config);

                Console.WriteLine($"Created default config. ({configPath})");
                return;
            }

            app.ShowHelp();
        }

    }
}