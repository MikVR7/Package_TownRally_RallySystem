
using CoDeEvents;
using System.Collections.Generic;

namespace TownRally.RallySystem
{
    internal class EventIn_SetRallyData : EventSystem<Rally> { }
    internal class EventIn_SetRalliesData : EventSystem<List<Rally>> { }
}
