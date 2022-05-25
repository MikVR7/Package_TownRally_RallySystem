using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class MapAPICommunicator : MonoBehaviour
    {
        [SerializeField] private Vector2 bottomLeft = Vector2.zero;
        [SerializeField] private Vector2 topRight = Vector2.zero;
        [SerializeField] private GameObject prefabNode = null;
        [SerializeField] private Transform tMap = null;
        [SerializeField] private GameObject prefabWay = null;

        private Dictionary<string, OnlineMapsOSMNode> nodes;
        private List<OnlineMapsOSMWay> ways;
        private List<OnlineMapsOSMRelation> relations;
        private List<OnlineMapsOSMArea> areas;

        private void Start()
        {
            string requestData = String.Format("node({0},{1},{2},{3});way(bn)[{4}];area[de: regionalschluessel~ ^ 057](._;>;);out;",
                bottomLeft.x.ToString(OnlineMapsUtils.numberFormat),
                bottomLeft.y.ToString(OnlineMapsUtils.numberFormat),
                topRight.x.ToString(OnlineMapsUtils.numberFormat),
                topRight.y.ToString(OnlineMapsUtils.numberFormat),

                "'highway'~'primary|residential'");

            // Send request and subscribe to complete event
            OnlineMapsOSMAPIQuery.Find(requestData).OnComplete += OnComplete;

            Debug.Log("SENT: " + requestData);
        }

        /// This event called when the request is completed.
        private void OnComplete(string response)
        {
            

            //// Get nodes, ways and relations from response
            OnlineMapsOSMAPIQuery.ParseOSMResponse(response, out nodes, out ways, out relations, out areas);

            Debug.Log("NODES: " + nodes.Count + " Ways: " + ways.Count + " Relations: " + relations.Count + " AREA: " + areas.Count);

            SaveFile(response);

            this.VisualizeNodes();
            this.VisualizeWays();
        }

        private void SaveFile(string data)
        {
            string destination = Application.dataPath + "/save.dat";
            File.WriteAllText(destination, data);
        }

        private void VisualizeNodes()
        {
            foreach(string nKey in nodes.Keys)
            {
                OnlineMapsOSMNode node = nodes[nKey];
                GameObject goNode = Instantiate(prefabNode, tMap);
                goNode.name = "node_" + node.id;
                Transform tNode = goNode.GetComponent<Transform>();
                tNode.localPosition = new Vector3((node.lat-47f)*1000f, 0.01f, (node.lon-15f)*1000f);
                tNode.localEulerAngles = new Vector3(90f, 0f, 0f);
                tNode.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }

        private void VisualizeWays()
        {
            ways.ForEach(w =>
            {
                GameObject goWay = Instantiate(prefabWay, tMap);
                goWay.name = "way_" + w.id;
                LineRenderer lrWay = goWay.GetComponent<LineRenderer>();
                List<OnlineMapsOSMNode> wNodes = w.GetNodes(nodes);
                lrWay.positionCount = wNodes.Count;
                int index = 0;
                wNodes.ForEach(wNode => { lrWay.SetPosition(index++, new Vector3((wNode.lat-47f) * 1000f, 0f, (wNode.lon-15f)*1000f)); });
            });
        }
    }
}
