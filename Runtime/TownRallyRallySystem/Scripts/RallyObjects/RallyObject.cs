using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class RallyObject : MonoBehaviour
    {
        [SerializeField] private GameObject letters = null;
        [SerializeField] private Material matGlowRingOff = null;
        [SerializeField] private Material matGlowRingOn = null;
        [SerializeField] private TextMeshPro tmpInfo = null;
        [SerializeField] private RallySelectableObject rallySelectable = null;
        [SerializeField] private RallyObjectMeshWriter rallyObjectMeshWriter = null;
        [SerializeField] private ParticleSystem particleSys = null;
        [SerializeField] private string txtHeader = string.Empty;
        [SerializeField] private string txtStartMsg = string.Empty;
        [SerializeField] private string txtMainMsg = string.Empty;

        private Transform myTransform = null;
        private Transform tMainCamera = null;
        private bool isClicked = false;

        private void Start()
        {
            

            this.myTransform = this.GetComponent<Transform>();
            //for (int i = 0; i < this.myTransform.childCount; i++)
            //{
            //    this.myTransform.GetChild(i).gameObject.SetActive(true);
            //}

            this.tMainCamera = Camera.main.GetComponent<Transform>();
            this.rallySelectable.Init(OnClickObject, OnClickObject);
            this.rallyObjectMeshWriter.Init();
            this.isClicked = false;

            //SetObjectState(matGlowRingOff, "Hallo!\nTippe hier...", true);
            SetObjectState(matGlowRingOff, txtStartMsg, txtHeader, true);
        }

        private bool isOn = false;
        private void Update()
        {
            
                if (this.myTransform.GetChild(0).gameObject.activeSelf)
                {
                    isOn = true;
                }
                {
                    for (int i = 0; i < this.myTransform.childCount; i++)
                    {
                        this.myTransform.GetChild(i).gameObject.SetActive(true);
                    }
                }
            

            this.myTransform.LookAt(this.tMainCamera);
        }

        public void OnClickObject()
        {
            Debug.Log("ON CLICK!!!!");
            if (!isClicked)
            {
                //SetObjectState(matGlowRingOn, "Willkommen zur Murrally!\nFolge dem Pfeil!", txtHeader, false);
                SetObjectState(matGlowRingOn, txtMainMsg, txtHeader, false);

                isClicked = true;
            }
            //else
            //{
            //    SetObjectState(matGlowRingOff, "Click again!");
            //    isClicked = false;
            //}
        }

        private void SetObjectState(Material mat, string info, string header, bool emit)
        {
            this.rallyObjectMeshWriter.WriteWord(header);
            this.rallyObjectMeshWriter.SetRenderMaterial(mat);
            
            this.tmpInfo.text = info;
            if (emit)
            {
                particleSys.Play();
            }
            else
            {
                particleSys.Stop();
            }
        }
    }
}
