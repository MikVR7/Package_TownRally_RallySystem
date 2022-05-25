using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class MapTiler : MonoBehaviour
    {
		[SerializeField] private Material matTile = null;
        private Dictionary<Tile, MapTile> mapTiles = new Dictionary<Tile, MapTile>();

        internal void Init()
        {
        }

        internal void CreateNewTile(Transform parentObject, Tile tile, Texture2D texture)
        {
            if (!this.mapTiles.ContainsKey(tile))
            {
                this.mapTiles.Add(tile, null);

                // create tile
                GameObject goTile = new GameObject("tile_" + tile.Horizontal + "_" + tile.Vertical);
                mapTiles[tile] = goTile.AddComponent<MapTile>();
                mapTiles[tile].Init(tile, parentObject, matTile, texture);
            }
        }

        private Tile VerifyCoordinate(Tile tile)
        {
            if (!this.mapTiles.ContainsKey(tile))
            {
                this.mapTiles.Add(tile, null);
            }
            return tile;
        }
	}
}
