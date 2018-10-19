using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourExt : NewBehaviourScript {
    NewBehaviourScript b;
	// Use this for initialization
	void Start () {
        class1.Life = MathHelper.Multiply(class1.Life, 2);
        float result = new MathHelper(100).MultiplyGravity(1.3f);
        float result2 = new MathHelper(20).MultiplyGravity(1.3f);
        Debug.Log("Gravity: " + result);
        Debug.Log("Gravity2: " + result2);
        // b.GlobalInitialLifeValue = b.GlobalInitialLifeValue -2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
