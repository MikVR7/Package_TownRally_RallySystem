using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TownRally.RallySystem
{
    internal class PanelDebugGUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputPath = null;
        [SerializeField] private TMP_InputField inputZoomFactor = null;
        [SerializeField] private Button btnLoadMaps = null;

        private void Awake()
        {
            this.btnLoadMaps.onClick.AddListener(OnBtnLoadMaps);
        }

        private void OnBtnLoadMaps()
        {
            int zoomFactor = 0;
            if(int.TryParse(inputZoomFactor.text, out zoomFactor)) {
                MapLoader.EventIn_LoadMaps.Invoke(inputPath.text, zoomFactor);
            }
        }
    }
}
