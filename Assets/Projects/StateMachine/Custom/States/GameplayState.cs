
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IntroCSharp.StateMachine {

    public class GameplayState : BaseState {

        MyContext myContext;

        public override void Enter() {
            Debug.LogFormat("State {0} loaded.", "GameplayState");
            myContext = (MyContext)context;
            myContext.ParentGameObject.GetComponent<Renderer>().material.color = Color.green;

            Debug.Log("Custom Float: " + myContext.CustomData.MyFloat);
            
        }

        public override void Tick() {
            Debug.LogFormat("Setup state {0} tick.", "GameplayState");
        }

        public override void Exit() {
            Debug.LogFormat("Setup state {0} unloaded.", "GameplayState");
        }
        
    }



}