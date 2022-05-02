using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class MapTile : MonoBehaviour
    {
        internal void Init(KeyValuePair<int, int> coords, Transform parent, Material matShader, Texture2D texture)
        {
			Transform tTile = this.GetComponent<Transform>();
			tTile.parent = parent;
			tTile.localPosition = new Vector3(coords.Key, 0f, -coords.Value);
			tTile.localEulerAngles = new Vector3(90f, 0f, 0f);
			MeshRenderer mrTile = this.gameObject.AddComponent<MeshRenderer>();
			Material matTile = new Material(matShader);
			matTile.mainTexture = texture;
			mrTile.material = matTile;
			MeshFilter meshFilter = this.gameObject.AddComponent<MeshFilter>();
			meshFilter.mesh = this.BuildQuad(1f, 1f, "mesh_quad");
		}

		private Mesh BuildQuad(float width, float height, string name)
		{
			Mesh mesh = new Mesh();
			mesh.name = name;

			// Setup vertices
			Vector3[] newVertices = new Vector3[4];
			float halfHeight = height * 0.5f;
			float halfWidth = width * 0.5f;
			newVertices[0] = new Vector3(-halfWidth, -halfHeight, 0);
			newVertices[1] = new Vector3(-halfWidth, halfHeight, 0);
			newVertices[2] = new Vector3(halfWidth, -halfHeight, 0);
			newVertices[3] = new Vector3(halfWidth, halfHeight, 0);

			// Setup UVs
			Vector2[] newUVs = new Vector2[newVertices.Length];
			newUVs[0] = new Vector2(0, 0);
			newUVs[1] = new Vector2(0, 1);
			newUVs[2] = new Vector2(1, 0);
			newUVs[3] = new Vector2(1, 1);

			// Setup triangles
			int[] newTriangles = new int[] { 0, 1, 2, 3, 2, 1 };

			// Setup normals
			Vector3[] newNormals = new Vector3[newVertices.Length];
			for (int i = 0; i < newNormals.Length; i++)
			{
				newNormals[i] = Vector3.forward;
			}

			// Create quad
			mesh.vertices = newVertices;
			mesh.uv = newUVs;
			mesh.triangles = newTriangles;
			mesh.normals = newNormals;

			return mesh;
		}
	}
}
