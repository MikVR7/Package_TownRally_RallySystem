using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class PlayerHandler : MonoBehaviour
    {
        [SerializeField] private double originX = 47.05764;
        [SerializeField] private double originZ = 15.43184;
        [SerializeField] private int gridX = 4;
        [SerializeField] private int gridZ = 4;
        [SerializeField] private float sizePerTileX = 256f;
        [SerializeField] private float sizePerTileZ = 256f;
        [SerializeField] private double maxLocationX = 47.05879;
        [SerializeField] private double maxLocationZ = 15.4335277;

        private double distanceX = 0;
        private double distanceZ = 0;
        private float tileDistanceX = 0;
        private float tileDistanceZ = 0;
        private Transform myTransform = null;

        private void Awake()
        {
            this.myTransform = this.GetComponent<Transform>();
            this.distanceX = maxLocationX - originX;
            this.distanceZ = maxLocationZ - originZ;
            this.tileDistanceX = (gridX - 0.5f) * sizePerTileX;
            this.tileDistanceZ = (gridZ - 0.5f) * sizePerTileZ;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                this.SetPosition(47.058, 15.432);
            }
        }

        private void SetPosition(double posX, double posZ)
        {
            double distNewX = posX - originX;
            distNewX = distNewX / distanceX;
            float posNewX = (float)distNewX * ((gridX - 0.5f) * sizePerTileX);

            double distNewZ = posZ - originZ;
            distNewZ = distNewZ / distanceZ;
            float posNewZ = (float)distNewZ * ((gridZ - 0.5f) * sizePerTileZ);

            this.myTransform.position = new Vector3(posNewX, 0f, posNewZ);
        }
    }
}
