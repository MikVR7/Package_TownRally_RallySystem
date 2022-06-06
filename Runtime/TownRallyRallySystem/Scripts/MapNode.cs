using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class MapNode : SerializedMonoBehaviour
    {
        [SerializeField] private OnlineMapsOSMNode node = null;
        private List<OnlineMapsOSMTag> tags = new List<OnlineMapsOSMTag>();
        
        internal void Init(OnlineMapsOSMNode node)
        {
            this.node = node;
            this.tags = this.node.tags;
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
