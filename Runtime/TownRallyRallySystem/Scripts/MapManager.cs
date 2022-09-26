using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TownRally.RallySystem.Events;

namespace TownRally.RallySystem
{
    internal class MapManager : MonoBehaviour
    {
        internal static EventIn_DisplayMap EventIn_DisplayMap = new EventIn_DisplayMap();

        private GameObject goMap = null;
        private Transform myTransform = null;

        internal void Init()
        {
            this.myTransform = this.GetComponent<Transform>();
            EventIn_DisplayMap.AddListenerSingle(DisplayMap);
        }

        private void DisplayMap(GameObject mapPrefab)
        {
            this.goMap = Instantiate(mapPrefab, Vector3.zero, Quaternion.identity);
            this.goMap.name = mapPrefab.name;
            Transform tMap = goMap.GetComponent<Transform>();
            tMap.SetParent(this.myTransform);
        }
    }
}
