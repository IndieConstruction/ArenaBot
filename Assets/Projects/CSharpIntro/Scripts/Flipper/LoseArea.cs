using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseArea : FlipperObjectBase {

    protected override bool CheckIfOk() {
        // se sono invincibilità attiva ritorno false
        return false;
    }

    protected override void ApplyPoints() {
    }

    protected override void PhysicEffect() {
        // ... 
    }

    protected override void VisualEffect() {
        // ExplosionManager.Explode(...)
    }

    protected override void ExtraSetup() {
        Debug.Log("LoseArea setup Done");
    }
}
