using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IntroCSharp.StateMachine {

    public class SetupState : BaseState {

        MyContext myContext;

        public override void Enter() {
            myContext = (MyContext)context;
            myContext.ParentGameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        float waitingTime = 2;
        public override void Tick() {
            Debug.LogFormat("Setup state {0} tick.", "SetupState");
            waitingTime -= Time.deltaTime;
            if (waitingTime < 0)
                myContext.SetupDoneCallback();
        }

        public override void Exit() {
            Debug.LogFormat("Setup state {0} unloaded.", "SetupState");
        }

    }



}