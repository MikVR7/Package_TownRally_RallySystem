using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Android;

namespace TownRally.RallySystem
{
    internal class GPSHandler : MonoBehaviour
    {
        internal static EventOut_GPSDataUpdated EventOut_GPSDataUpdated = new EventOut_GPSDataUpdated();

        private bool isGPSRunning = false;
        private float lastTimeChecked = 0f;
        private float checkDelay = 0.5f;
        private float latitude = 0f;
        private float longitude = 0f;
        private float altitude = 0f;

        internal void Init()
        {
            RallyManager.EventOut_OnUpdate.AddListener(OnUpdate);
            StartCoroutine(StartGPSTracking());

#if UNITY_ANDROID && !UNITY_EDITOR
            this.StartAndroidPluginCommunication();
#endif
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        private AndroidJavaClass pluginAndroidClass = null;
        private void StartAndroidPluginCommunication()
        {
            AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.pluginAndroidClass = new AndroidJavaClass("com.example.gpsupdater.LocationHelper");
            this.pluginAndroidClass.CallStatic("setContext", activityContext);
            this.pluginAndroidClass.CallStatic("StartUpdates");
        }
#endif


        private void OnUpdate()
        {
            this.GetGPSData();
        }

        private IEnumerator StartGPSTracking()
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                Permission.RequestUserPermission(Permission.FineLocation);
                Permission.RequestUserPermission(Permission.CoarseLocation);
            }

            if (!Input.location.isEnabledByUser)
            {
                DebugOutput.EventIn_DebugLog.Invoke("GPS is not enabled on this device.");
                isGPSRunning = false;
                yield return null;
            }

            // Starts the location service.
            Input.location.Start();

            // Waits until the location service initializes
            int maxWait = 3;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            // If the service didn't initialize in 20 seconds this cancels location service use.
            if (maxWait < 1)
            {
                DebugOutput.EventIn_DebugLog.Invoke("Timed out");
            }
            isGPSRunning = maxWait >= 1;
            yield break;
        }

        private void StopGPSTracking()
        {
            isGPSRunning=false;
            Input.location.Stop();
#if UNITY_ANDROID && !UNITY_EDITOR
            this.pluginAndroidClass.CallStatic("StopUpdates");
#endif
        }

        private void GetGPSData()
        {
            if (Input.location.isEnabledByUser && isGPSRunning)
            {
                // If the connection failed this cancels location service use.
                if (Input.location.status == LocationServiceStatus.Failed)
                {
                    DebugOutput.EventIn_DebugLog.Invoke("Unable to determine device location");
                }
                else
                {
                    if ((this.lastTimeChecked + this.checkDelay) < Time.realtimeSinceStartup)
                    {
                        // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
#if UNITY_ANDROID && !UNITY_EDITOR
                        this.SetGPSDataAndroid();
#else
                        this.SetGPSDataUnity();
#endif
                        Input.gyro.enabled = true;
                        DebugOutput.EventIn_DebugLog.Invoke("Location: " + latitude + " " + longitude + " " + altitude + " "+ Input.gyro.attitude);
                        EventOut_GPSDataUpdated.Invoke(latitude, longitude, altitude);
                        this.lastTimeChecked = Time.realtimeSinceStartup;
                    }
                }
            }
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        private void SetGPSDataAndroid()
        {
            string data = pluginAndroidClass.CallStatic<string>("GetGPSData");
            if (!data.Equals("no_data"))
            {
                //DebugOutput.EventIn_DebugLog.Invoke("DAT: " + data);
                data = data.Replace('.', ',');
                List<string> dataSplit = data.Split('_').ToList();
                
                this.latitude = float.Parse(dataSplit[2]);
                this.longitude = float.Parse(dataSplit[1]);
                this.altitude = float.Parse(dataSplit[0]);
            }
            else
            {
                this.SetGPSDataUnity();
            }
        }
#endif

        private void SetGPSDataUnity()
        {
            this.latitude = Input.location.lastData.latitude;
            this.longitude = Input.location.lastData.longitude;
            this.altitude = Input.location.lastData.altitude;
        }
    }
}
//https://markcastle.com/steps-to-create-a-native-android-plugin-for-unity-in-java-using-android-studio-part-2-of-2/