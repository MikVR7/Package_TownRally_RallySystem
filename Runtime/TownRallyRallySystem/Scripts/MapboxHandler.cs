using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;

namespace TownRally.RallySystem
{
    internal class MapboxHandler : MonoBehaviour
    {
        [SerializeField] private AbstractMap map = null;
        [SerializeField] private double latitude = 0;
        [SerializeField] private double longitude = 0;
        [SerializeField] private int zoom = 0;

        private void Awake()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                map.Initialize(new Vector2d(latitude, longitude), zoom);
            }
        }
    }
}