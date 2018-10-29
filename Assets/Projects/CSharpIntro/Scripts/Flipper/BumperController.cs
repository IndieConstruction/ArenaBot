using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : FlipperObjectBase {

    int multiplier = 1;

    private bool SetupDone = false;

    public delegate void BumperDelegate(int points);

    public static BumperDelegate OnPointCollect;
    public BumperDelegate OnBumpVisualEffect;


    protected override bool CheckIfOk() {
        return SetupDone;
    }

    protected override void ApplyPoints() {
        //if (objectSettings.IsMultiplierEnabled) {
        //    // ... applica punteggio 10 * multiplier
        //    // gamemanager.addPoints(10 * multiplier)
        //} else {
        //    // ... applica punteggio 10

        //}

        if (OnPointCollect != null) {
            OnPointCollect(10);
        }
    }

    protected override void PhysicEffect() {
        
    }

    protected override void PlaySound() {
        
    }

    protected override void VisualEffect() {
        if(OnBumpVisualEffect != null)
            OnBumpVisualEffect(0);
    }

    protected override void ExtraSetup() {
        Debug.Log("BumperController setup Done");
        SetupDone = true;
        CollisionEffect();
    }
}
