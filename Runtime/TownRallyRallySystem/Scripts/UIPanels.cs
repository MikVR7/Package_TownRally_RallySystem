using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class UIPanels : MonoBehaviour
    {
        [SerializeField] private UIPanelLoading uiPanelLoading = null;
        [SerializeField] private UIPanelGUIMain uiPanelGUIMain = null;

        internal void Init()
        {
            this.uiPanelLoading.Init();
            this.uiPanelGUIMain.Init();
        }
    }
}
