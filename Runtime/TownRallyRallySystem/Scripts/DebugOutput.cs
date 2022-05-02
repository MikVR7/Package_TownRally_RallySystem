using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class DebugOutput : MonoBehaviour
    {
        internal static EventIn_DebugLog EventIn_DebugLog = new EventIn_DebugLog();

        [SerializeField] private TextMeshProUGUI tmpDebug = null;

        private List<string> dataList = new List<string>();
        private readonly int dataListMax = 100;

        internal void Init()
        {
            EventIn_DebugLog.AddListener(DebugLog);
        }

        private void DebugLog(string data)
        {
            // add data to list
            dataList.Add(data);
            if(dataList.Count > dataListMax) {
                dataList.RemoveAt(0);
            }

            // display data
            string strData = string.Empty;
            for (int i = this.dataList.Count - 1; i >= 0; i--)
            {
                strData += this.dataList[i] + "\n";
            }
            this.tmpDebug.text = strData;
        }
    }
}
