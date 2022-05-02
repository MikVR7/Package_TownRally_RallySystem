using CoDeEvents;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class EventIn_LoadMaps : EventSystem<string, int> { }
    internal class MapLoader : MonoBehaviour
    {
        internal static EventIn_LoadMaps EventIn_LoadMaps= new EventIn_LoadMaps();
        [SerializeField] private MapTiler mapTiler = null;
        [SerializeField] private string rootMapsFolder = string.Empty;

        private void Init()
        {
            mapTiler.Init();
            EventIn_LoadMaps.AddListener(LoadMaps);
        }

        //int baseHor = 284638;
        //int baseVert = 184266;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                this.LoadMaps(this.rootMapsFolder, 19);
            }
        }

        private void LoadMaps(string pathRoot, int zoomFactor)
        {
            pathRoot += "\\" + zoomFactor;
            KeyValuePair<int, int> valuesMinMaxI = GetMinMaxFilenameDirectories(pathRoot, true);
            for (int i = valuesMinMaxI.Key; i <= valuesMinMaxI.Value; i++)
            {
                string pathNew = pathRoot + "\\" + i;
                KeyValuePair<int, int> valuesMinMaxJ = GetMinMaxFilenameDirectories(pathNew, false);
                for (int j = valuesMinMaxJ.Key; j <= valuesMinMaxJ.Value; j++)
                {
                    
                    this.CreateTile(pathNew + "\\" + j + ".png", i, j, valuesMinMaxI.Key, valuesMinMaxJ.Key);
                }
            }
        }

        private KeyValuePair<int, int> GetMinMaxFilenameDirectories(string pathRoot, bool searchForDirectories)
        {
            List<string> fileFolderNames = new List<string>();
            if (searchForDirectories)
            {
                fileFolderNames = Directory.GetDirectories(pathRoot).ToList();
                for (int i = 0; i < fileFolderNames.Count; i++) {
                    fileFolderNames[i] = RemovePrefixPath(fileFolderNames[i]);
                }
            }
            else
            {
                fileFolderNames = Directory.GetFiles(pathRoot).ToList();
                for(int i = fileFolderNames.Count - 1; i >= 0; i--)
                {
                    if(!fileFolderNames[i].EndsWith(".png") && !fileFolderNames[i].EndsWith(".jpg"))
                    {
                        fileFolderNames.RemoveAt(i);
                    }
                    else
                    {
                        fileFolderNames[i] = fileFolderNames[i].Replace(".png", "").Replace(".jpg", "");
                        fileFolderNames[i] = RemovePrefixPath(fileFolderNames[i]);
                    }
                }
            }
            // parse to int
            List<int> fileFolderInts = new List<int>();
            for(int i = 0; i < fileFolderNames.Count; i++)
            {
                int number = 0;
                if(int.TryParse(fileFolderNames[i], out number)) {
                    fileFolderInts.Add(number);
                }
            }
            return new KeyValuePair<int, int>(fileFolderInts.Min(), fileFolderInts.Max()); ;
        }

        private string RemovePrefixPath(string path)
        {
            List<string> listFFN = path.Split('\\').ToList();
            return listFFN[listFFN.Count - 1];
        }

        private void CreateTile(string pathRoot, int hor, int vert, int minHor, int minVert)
        {
            Debug.Log("PATH ROOT: " + pathRoot);
            if(pathRoot.EndsWith("/")) { pathRoot = pathRoot.Remove(pathRoot.Length - 1, 1); }
            string path = pathRoot;// + "/" + zoomFactor + "/" + hor + "/" + vert + ".png";
            Texture2D texture = LoadPNG(path);
            if(texture == null)
            {
                Debug.Log("ERROR: Texture not found (" + path + ")");
                return;
            }
            mapTiler.CreateNewTile(hor, vert, minHor, minVert, texture);
        }

        private Texture2D LoadPNG(string filePath)
        {
            Texture2D tex = null;
            byte[] fileData;

            if (File.Exists(filePath))
            {
                fileData = File.ReadAllBytes(filePath);
                tex = new Texture2D(2, 2);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            }
            return tex;
        }
    }

    
}
