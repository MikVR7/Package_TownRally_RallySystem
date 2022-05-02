using ARLocation;
using System.Collections;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class ARLocationManager : MonoBehaviour
    {
        [SerializeField] private PlaceAtLocation placeAtLocation = null;

        internal void Init()
        {
            GPSHandler.EventOut_GPSDataUpdated.AddListener(SetLocationObject);

            //StartCoroutine(SetLocationObjectDelayed(1f, 47.06383f, 15.44808f, 404f));
        }

        private IEnumerator SetLocationObjectDelayed(float delay, float latitude, float longitude, float altitude)
        {
            yield return new WaitForSeconds(delay);
            SetLocationObject(latitude, longitude, altitude);
        }

        private void SetLocationObject(float latitude, float longitude, float altitude)
        {
            //this.placeAtLocation.LocationOptions.LocationInput.Location.Longitude = longitude;
            //this.placeAtLocation.LocationOptions.LocationInput.Location.Latitude = latitude;
            //this.placeAtLocation.LocationOptions.LocationInput.Location.Altitude = altitude;

            //ARLocationProvider.Instance.MockLocationData.Location.Latitude = latitude;
            //ARLocationProvider.Instance.MockLocationData.Location.Longitude = longitude;
        }
    }
}
