using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSToU.Units {

    public class UnitGreen : UnitBase {


        protected override void Setup() {
            Debug.Log("Setup Unit Green");
        }

        protected override void CreateGraphic() {
            base.CreateGraphic();
            Debug.Log("Setup graphic for green unit");
        }
    }
}