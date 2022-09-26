using UnityEngine;

namespace TownRally.RallySystem
{
    internal class RallySystemMain : MonoBehaviour
    {
        [SerializeField] private MapManager mapManager = null;
        [SerializeField] private AssetBundleLoader assetBundleLoader = null;
        [SerializeField] private UIPanels uiPanels = null;

        private void Awake()
        {
            this.mapManager.Init();
            this.assetBundleLoader.Init();
            this.uiPanels.Init();
        }
    }
}
