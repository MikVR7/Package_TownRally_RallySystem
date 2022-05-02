using CoDeEvents;
using Lean.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class RallySelectableObject : LeanSelectableBehaviour
    {
        internal Action actionOnSelected = null;
        internal Action actionOnDeselected = null;

        internal void Init(Action actionOnSelected, Action actionOnDeselected)
        {
            this.actionOnSelected = actionOnSelected;
            this.actionOnDeselected = actionOnDeselected;
        }

        protected override void OnSelected(LeanSelect select)
        {
            Debug.Log("ON SELECTO OBJECTO!!");
            if(this.actionOnSelected != null) { this.actionOnSelected.Invoke(); }
        }

        protected override void OnDeselected(LeanSelect select)
        {
            Debug.Log("ON SELECTO OBJECTO!!");
            if (this.actionOnDeselected != null) { this.actionOnDeselected.Invoke(); }
        }
    }
}
