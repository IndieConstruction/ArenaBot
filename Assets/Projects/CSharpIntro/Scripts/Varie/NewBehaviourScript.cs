using IntroCSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public int GlobalInitialLifeValue {
        get {
            return globalInitialLifeValue;
        }
        set {
            if (value > 0) {
                globalInitialLifeValue = value;
            } else
                globalInitialLifeValue = 100;
        }
    }
    int globalInitialLifeValue = 100;

    public ClassA class1 = new ClassA();
    public ClassA class2;

    // Use this for initialization
    void Start () {
        class2 = new ClassA(globalInitialLifeValue);
        globalInitialLifeValue = 0;
        class1 = class2;
        class1.Life = 10;

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

