using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlipperObjectBase : MonoBehaviour, ISetuppable {

    public string GetName {
        get {
            return "FlipperObjectBase";
        }
    }

    private void OnCollisionEnter(Collision collision) {
        CollisionEffect();
    }

    /// <summary>
    /// Logiche da eseguire durante la collisione con questo oggetto.
    /// </summary>
    protected void CollisionEffect() {
        if (CheckIfOk() == false) {
            return;
        }
        // Eventuale punteggio
        ApplyPoints();
        // Sound
        PlaySound();
        // Effetto Visivo
        VisualEffect();
        // Fisica
        PhysicEffect();
    }

    protected virtual bool CheckIfOk() {
        return true;
    }

    /// <summary>
    /// Logiche eventuali per applicare punteggio per una collisione.
    /// </summary>
    protected abstract void ApplyPoints();

    protected virtual void PlaySound() {
        GetComponent<AudioSource>().Play();
    }

    protected abstract void VisualEffect();

    protected abstract void PhysicEffect();

    ObjectSettings settings;

    public void Setup(ObjectSettings _settings) {
        settings = _settings;
        ExtraSetup();
    }

    protected virtual void ExtraSetup() { }


}

public class ObjectSettings {

    public bool IsMultiplierEnabled;

    public bool IsEnableTilt;

}

public interface ISetuppable {

    string GetName { get; }

    void Setup(ObjectSettings _settings);

}
