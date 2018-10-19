using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassFiglio : ClassPadre {

    public string Soprannome;

    public ClassFiglio() {
        
    }

    public override void SetName() {
        Name = "Marco";
    }
}

public class ClassFiglio2 : ClassPadre {
    public override void SetName() {
        Name = "Pino";
    }
}

public class ClassFiglio3 : ClassPadre {
    public override void SetName() {
        Name = "Pino";
    }
}
