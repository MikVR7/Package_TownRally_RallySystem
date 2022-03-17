using System.Collections.Generic;

namespace TownRally.RallySystem
{
    public class Rally
    {
        public string ID { get; set; } = string.Empty;
        public uint EnumID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string PreviewImgFolder { get; set; } = string.Empty;
        public Description description { get; set; } = new Description();
        public List<Station> stations { get; set; } = new List<Station>();
    }
}
