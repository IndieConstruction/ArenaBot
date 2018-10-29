using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSToU.Units {

    public class UnitCollisionController : MonoBehaviour {

        public bool IsOffensiveCollider = false;

        UnitBase unit;

        private void Start() {
            unit = GetComponentInParent<UnitBase>();
        }

        private void OnTriggerEnter(Collider other) {
            if(unit)
                unit.DoCollision(other, IsOffensiveCollider);
        }
    }

}
