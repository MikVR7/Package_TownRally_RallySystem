using Lean.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    public class TestLeanTouch : LeanSelectableBehaviour
    {
        [SerializeField] private MeshRenderer myMeshRenderer = null;
        [SerializeField] private Material mat1 = null;
        [SerializeField] private Material mat2 = null;
        private bool isMat1 = false;

        private void Awake()
        {
            
        }

        public void ChangeMaterial()
        {
            Debug.Log("CLICKI! " + gameObject.name);
            if(isMat1)
            {
                myMeshRenderer.material = mat2;
                isMat1 = false;

            }
            else
            {
                myMeshRenderer.material = mat1;
                isMat1 = true;
            }
        }

        protected override void OnSelected(LeanSelect select)
        {
            ChangeMaterial();
        }

        protected override void OnDeselected(LeanSelect select)
        {
            ChangeMaterial();
        }
    }
}
