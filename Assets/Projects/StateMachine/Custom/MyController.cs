using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IntroCSharp.StateMachine;

public class MyController : MonoBehaviour {

    public MyCustomData CustomData;

    MyStateMachine sm;

	// Use this for initialization
	void Start () {
        // Setup SM
        sm = gameObject.AddComponent<MyStateMachine>();

        MyContext context = new MyContext() {
            ContextName = "MyContext",
            ParentGameObject = this.gameObject,
            SetupDoneCallback = OnSetupDone,
            CustomData = CustomData,
        };
        List<IState> states = new List<IState>() {
            new SetupState().Setup(context),
            new GameplayState().Setup(context),
        };

        sm.Setup(context, states);

        // Inizio
        OnStart();
	}



    void OnStart() {
        sm.CurrentState = sm.States[0];
    }

    void OnSetupDone() {
        sm.CurrentState = sm.States[1];
    }

}
