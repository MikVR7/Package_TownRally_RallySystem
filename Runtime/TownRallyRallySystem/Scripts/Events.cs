using CoDeEvents;
using System;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class Events
    {
        // AssetBundleLoader.cs
        internal class EventIn_LoadAssetbundle : EventSystem<AssetBundleLoader.AssetType, AssetBundleLoader.City, EventIn_DisplayMap> { }

        // UIPanelLoading.cs
        internal class EventIn_ActivatePanel : EventSystem<bool> { }

        // MapManager.cs
        internal class EventIn_DisplayMap : EventSystem<GameObject> { }
    }
}
