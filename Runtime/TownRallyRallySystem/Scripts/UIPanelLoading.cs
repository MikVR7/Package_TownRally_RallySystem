using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TownRally.RallySystem.Events;

namespace TownRally.RallySystem
{
    internal class UIPanelLoading : MonoBehaviour
    {
        internal static EventIn_ActivatePanel EventIn_ActivatePanel = new EventIn_ActivatePanel();

        internal void Init()
        {
            EventIn_ActivatePanel.AddListenerSingle(ActivatePanel);
            ActivatePanel(false);
        }

        private void ActivatePanel(bool activate)
        {
            this.gameObject.SetActive(activate);
        }
    }
}
