using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static TownRally.RallySystem.Events;

namespace TownRally.RallySystem
{
    internal class AssetBundleLoader : MonoBehaviour
    {
        private static readonly string bundleUrlMapGrazWinStandalone =
            "https://drive.google.com/uc?export=download&id=1nqx4kZblGbiFQNZwWYvx7J9-8-461JSq";
        private static readonly string bundleUrlMapGrazAndroid =
            "https://drive.google.com/uc?export=download&id=1AT4x6MUUSqP4MvlWemKTbJ5sOfsXZFkw";
        
        internal enum AssetType
        {
            MapMesh = 0,
        }

        internal enum City
        {
            Graz = 0,
        }

        internal static EventIn_LoadAssetbundle EventIn_LoadAssetbundle = new EventIn_LoadAssetbundle();

        private Dictionary<AssetType, Dictionary<City, string>> assetPaths = new Dictionary<AssetType, Dictionary<City, string>>();

        internal void Init()
        {
            this.assetPaths.Clear();
            this.assetPaths.Add(AssetType.MapMesh, 
                new Dictionary<City, string>() { { City.Graz, "graz" } });
            EventIn_LoadAssetbundle.AddListenerSingle(LoadAssetbundle);
        }

        private void LoadAssetbundle(AssetType assetType, City city, EventIn_DisplayMap action)
        {
            StartCoroutine(LoadAssetbundleIE(assetType, city, action));
        }

        private IEnumerator LoadAssetbundleIE(AssetType assetType, City city, EventIn_DisplayMap action)
        {
            string url = GetBundleURL();
            string assetName = GetAssetName();
            using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(url))
            {
                yield return uwr.SendWebRequest();
                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    Debug.Log(uwr.error);
                }
                else
                {
                    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
                    GameObject goAsset = bundle.LoadAsset(assetName) as GameObject;
                    action.Invoke(goAsset);
                }
            }
        }

        private string GetBundleURL()
        {
            // TODO: make that more dynamic... get it from dictionary...
            if(Application.platform.Equals(RuntimePlatform.Android))
            {
                return bundleUrlMapGrazAndroid;
            }
            else
            {
                return bundleUrlMapGrazWinStandalone;
            }
        }

        private string GetAssetName()
        {
            // TODO: make that more dynamic... get it from dictionary...
            return "graz";
        }

    }
}
