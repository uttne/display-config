// See https://aka.ms/new-console-template for more information

namespace DisplayConfig
{
    public class Config : List<DisplayOption>
    {
        public Config() { }
        public Config(IEnumerable<DisplayOption> options) : base(options) { }
    }
}
