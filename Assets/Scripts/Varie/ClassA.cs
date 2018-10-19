using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IntroCSharp {

    public class ClassA {

        private string Name = "das kjdaskl jdaslk j";
        public int Life;
        private float Range = 8f;
        private bool IsAlive = false;

        public ClassA() {

        }

        public ClassA(int initialLife) {
            InitLife(initialLife);
        }

        public void ResetLife() {
            Life = 0;
        }

        private void InitLife(int lifeAmount) {
            Life = lifeAmount;
        }

        public int GetLifeReadOnly() {
            return Life;
        }

    }

}



public class MathHelper {

    float gravityValue;

    public MathHelper(float initialGravity) {
        gravityValue = initialGravity;
    }

    public static int Multiply(int int1, int int2) {
        return int1 * int2;
    }

    public float MultiplyGravity(float multiplyValue) {
        return gravityValue * multiplyValue; 
    }

}
