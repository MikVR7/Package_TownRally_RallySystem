using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class MapTiler : MonoBehaviour
    {
		[SerializeField] private Material matTile = null;
        private Dictionary<KeyValuePair<int, int>, MapTile> mapTiles = new Dictionary<KeyValuePair<int, int>, MapTile>();
		private Transform myTransform = null;

        internal void Init()
        {
			this.myTransform = this.GetComponent<Transform>();
        }

        internal void CreateNewTile(int coordX, int coordY, int minCoordX, int minCoordY, Texture2D texture)
        {
            // if coordinate does not exist, create it;
            KeyValuePair<int, int> coord = this.VerifyCoordinate(coordX-minCoordX, coordY-minCoordY);
            Debug.Log("TILE: " + coord.Key + " " + coord.Value + " - " + coordX + " " + minCoordX + " - " + coordY + " " + minCoordY);
            // create tile
            GameObject goTile = new GameObject("tile_" + coord.Key + "_" + coord.Value);
            mapTiles[coord] = goTile.AddComponent<MapTile>();
            mapTiles[coord].Init(coord, this.myTransform, matTile, texture);
        }

        private KeyValuePair<int, int> VerifyCoordinate(int coordX, int coordY)
        {
            KeyValuePair<int, int> coord = new KeyValuePair<int, int>(coordX, coordY);
            if (!this.mapTiles.ContainsKey(coord))
            {
                this.mapTiles.Add(coord, null);
            }
            return coord;
        }
	}
}
