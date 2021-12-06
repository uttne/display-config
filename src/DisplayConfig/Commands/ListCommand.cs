// See https://aka.ms/new-console-template for more information

using McMaster.Extensions.CommandLineUtils;
using DisplayConfig;

namespace Commands
{
    [Command("list")]
    class ListCommand
    {
        private readonly ConfigManager _configManager;

        public ListCommand(ConfigManager configManager)
        {
            _configManager = configManager;
        }

        public void OnExecute()
        {
            var configNames = _configManager.GetConfigNames();

            foreach (var n in configNames)
            {
                Console.WriteLine($"{n}");
            }
        }
    }
}