using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class RallyManager : MonoBehaviour
    {
        public static EventIn_SetRallyData EventIn_SetRallyData = new EventIn_SetRallyData();
        public static EventIn_SetRalliesData EventIn_SetRalliesData = new EventIn_SetRalliesData();

        private Dictionary<RallyType, Rally> rallies = new Dictionary<RallyType, Rally>();
        private void Awake()
        {
            EventIn_SetRallyData.AddListener(SetRallyData);
            EventIn_SetRalliesData.AddListener(SetRalliesData);
        }

        private void SetRallyData(Rally rally)
        {
            RallyType type = (RallyType)rally.EnumID;
            if (rallies.ContainsKey(type)) { rallies[type] = rally; }
            else { rallies.Add(type, rally); }
        }

        private void SetRalliesData(List<Rally> rallies)
        {
            rallies.ForEach(i => this.SetRallyData(i));
        }
    }
}
