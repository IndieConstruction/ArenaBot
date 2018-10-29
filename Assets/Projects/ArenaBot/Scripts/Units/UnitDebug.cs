using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSToU.Units;

namespace CSToU.UI {

    public class UnitDebug : MonoBehaviour {

        public TextBox DebugTextBox;

        public UnitStateMachine SM;

        private void Update() {
            if (DebugTextBox == null)
                return;

            if (SM == null)
                SM = GetComponent<UnitStateMachine>();

            DebugTextBox.SetText(SM.CurrentState.ToString());
        }

    }
}