using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class TextureCombiner : MonoBehaviour
    {
        [SerializeField] private string rootMapsFolder = string.Empty;
        [SerializeField] private int startX = 284570;
        [SerializeField] private int startY = 184250;
        [SerializeField] private int lengthX = 16;
        [SerializeField] private int lengthY = 16;
        [SerializeField] private Material matShader = null;
        private Transform myTransform = null;

        private void Awake()
        {
            this.myTransform=this.GetComponent<Transform>();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.L))
            {
                List<List<Texture2D>> textures = this.LoadTextures();
                Texture2D texFinal = this.CombineTextures(textures);
                this.CreateQuad(texFinal);
            }
        }

        private new List<List<Texture2D>> LoadTextures()
        {
            List<List<Texture2D>> textures = new List<List<Texture2D>>();
            for (int i = startX; i < startX + lengthY; i++)
            {
                List<Texture2D> texturesLine = new List<Texture2D>();
                for(int j = startY; j < startY + lengthY; j++)
                {
                    Debug.Log("Texture path: " + rootMapsFolder + "/19/" + i + "/" + j + ".png");
                    texturesLine.Add(LoadPNG(rootMapsFolder + "/19/" + i + "/" + j + ".png"));
                }
                textures.Add(texturesLine);
            }
            return textures;
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

        private Texture2D CombineTextures(List<List<Texture2D>> textures)
        {
            Texture2D texFinal = new Texture2D(256*this.lengthX, 256*this.lengthY);
            for (int i = 0; i < textures.Count; i++)
            {
                for(int j = 0; j < textures[i].Count; j++)
                {
                    if (textures[i][j] != null)
                    {
                        int iPos = /*((16-1)-i)*/i * 256;
                        int jPos = ((16-1)-j) * 256;
                        Debug.Log("SET PIXELS: " + iPos + " " + jPos);
                        texFinal.SetPixels(iPos, jPos, 256, 256, textures[i][j].GetPixels());// 0, 0, 256, 256));
                    }
                    else
                    {
                        Debug.Log("Missing texture: " + i + " " + j);
                    }
                }
            }
            texFinal.Apply();
            return texFinal;
        }

        private void CreateQuad(Texture2D texFinal)
        {
            GameObject goTile = new GameObject("tex_final");
            Transform tTile = goTile.GetComponent<Transform>();
            tTile.parent = this.myTransform;
            tTile.localPosition = new Vector3(0f, 0f, 0f);
            tTile.localEulerAngles = new Vector3(90f, 0f, 0f);
            MeshRenderer mrTile = this.gameObject.AddComponent<MeshRenderer>();
            Material matTile = new Material(matShader);
            matTile.mainTexture = texFinal;
            mrTile.material = matTile;
            MeshFilter meshFilter = this.gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = MapTile.BuildQuad(1f, 1f, "mesh_quad");
        }
    }
}
