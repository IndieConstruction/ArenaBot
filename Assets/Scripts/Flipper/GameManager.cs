using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static GameManager I {
        get { return _instance; }
        set { _instance = value; }
    }
    private static GameManager _instance;

    private void Awake() {
        if (I == null) {
            I = this;
            DontDestroyOnLoad(this);
        } else {
            GameObject.Destroy(this.gameObject);
        }

    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            foreach (ISetuppable item in GetComponentsInChildren<ISetuppable>()) {
                item.Setup(new ObjectSettings() { IsEnableTilt = true, IsMultiplierEnabled = true });
            }
        }
    }

    private void OnEnable() {
        BumperController.OnPointCollect += PointCollected;
    }

    void PointCollected(int _pointToAdd) {
        Debug.Log(_pointToAdd);
    }

    private void OnDisable() {
        BumperController.OnPointCollect -= PointCollected;
    }
}
