
using CoDeEvents;
using System.Collections.Generic;

namespace TownRally.RallySystem
{
    // RallyManager.cs
    internal class EventIn_SetRallyData : EventSystem<Rally> { }
    internal class EventIn_SetRalliesData : EventSystem<List<Rally>> { }
    internal class EventOut_OnUpdate : EventSystem { }

    // DebugOutput.cs
    internal class EventIn_DebugLog : EventSystem<string> { }

    // GPSHandler.cs
    internal class EventOut_GPSDataUpdated : EventSystem<float, float, float> { }

}
