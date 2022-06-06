using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class MapWay : SerializedMonoBehaviour
    {
        [SerializeField] private OnlineMapsOSMWay way = null;
        private List<OnlineMapsOSMTag> tags = new List<OnlineMapsOSMTag>();

        internal void Init(OnlineMapsOSMWay way)
        {
            this.way = way;
            this.tags = this.way.tags;
            this.tags.ForEach(t => MapAPICommunicator.EventIn_ReportTag.Invoke(t.key, t.value));

            this.tags.ForEach(t =>
            {
                if (t.key == "building")
                {
                    this.gameObject.name = "building";
                }
            });
        }
    }
}
