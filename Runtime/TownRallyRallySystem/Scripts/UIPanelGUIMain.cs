using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TownRally.RallySystem
{
    internal class UIPanelGUIMain : MonoBehaviour
    {
        [SerializeField] private Button btnLoadMap = null;

        internal void Init()
        {
            this.btnLoadMap.onClick.AddListener(OnBtnLoadMap);
        }

        private void OnBtnLoadMap()
        {
            AssetBundleLoader.EventIn_LoadAssetbundle.Invoke(
                AssetBundleLoader.AssetType.MapMesh,
                AssetBundleLoader.City.Graz,
                MapManager.EventIn_DisplayMap);
        }
    }
}
