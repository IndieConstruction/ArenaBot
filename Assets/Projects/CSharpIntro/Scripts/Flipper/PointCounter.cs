using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour, ISetuppable {
    public string GetName {
        get {
            throw new System.NotImplementedException();
        }
    }

    public void Setup(ObjectSettings _settings) {
        Debug.Log("PointCounter setup done");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
