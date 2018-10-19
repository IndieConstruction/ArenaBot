using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSToU.Units {

    public class UnitRed : UnitBase {

        protected override void Setup() {
            Debug.Log("Setup Unit Red");
        }

        protected override void CreateGraphic() {
            base.CreateGraphic();
            Debug.Log("Setup graphic for Red unit");
        }

    }
}