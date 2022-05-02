using UnityEngine;
using UnityEngine.UI;

namespace TownRally.RallySystem
{
    internal class GUIHandler : MonoBehaviour
    {
        [SerializeField] private Button btnCamView = null;
        [SerializeField] private Button btnMapView = null;

        internal void Init()
        {
            this.btnCamView.onClick.AddListener(OnBtnCamView);
            this.btnMapView.onClick.AddListener(OnBtnMapView);

            
        }

        private void OnBtnCamView()
        {
            Debug.Log("ON BTN CAM VIEW!");
        }

        private void OnBtnMapView()
        {
            Debug.Log("ON BTN MAP VIEW!");
        }
    }
}
