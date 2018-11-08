using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomData", menuName = "MyConfigurations/Custom", order = 1)]
public class MyCustomData : ScriptableObject {

    public string DataName;
    public float MyFloat;
    // etc...

}
