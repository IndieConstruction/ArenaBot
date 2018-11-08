using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomData", menuName = "Exercises/Tolleracens", order = 1)]
public class Tollerances : ScriptableObject {

    public string DataName;
    public float TolleranceMax;
    public float TolleranceMin;
    // etc...

}
