using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomData", menuName = "Exercises/Config", order = 1)]
public class ExerciseConfiguration : ScriptableObject {

    public string DataName;
    public float MyFloat;
    public Tollerances tollerances;
    // etc...

}
