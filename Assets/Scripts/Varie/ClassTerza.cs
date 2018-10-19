using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTerza {

    ClassPadre padre;

    public ClassTerza() {
        padre = new ClassFiglio();
        ClassFiglio figlio = padre as ClassFiglio;
    }

}
