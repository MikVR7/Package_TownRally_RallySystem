using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TownRally.RallySystem
{
    internal class ObjectSetter : MonoBehaviour
    {
        [SerializeField] private GameObject prefabObject = null;
        [SerializeField] private Button btnSetObject = null;
        [SerializeField] private Transform tCamera = null;
        private Transform myTransform = null;

        private void Awake()
        {
            this.myTransform = this.GetComponent<Transform>();
            this.btnSetObject.onClick.AddListener(OnBtnSetObject);
        }

        private void OnBtnSetObject()
        {
            GameObject goObj = GameObject.Instantiate(prefabObject, myTransform);
            Transform tObj = goObj.GetComponent<Transform>();
            tObj.position = tCamera.position;

        }

        
    }
}
