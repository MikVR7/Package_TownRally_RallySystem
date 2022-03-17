using System.Collections.Generic;

namespace TownRally.RallySystem
{
    public class Station
    {
        public string ID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Description description { get; set; } = new Description();
    }
}
