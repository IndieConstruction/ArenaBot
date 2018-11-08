using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace IntroCSharp.StateMachine {
    public class MyStateMachine : BaseStateMachine {



    }

    public struct MyContext : IContext {
        public string ContextName;
        public GameObject ParentGameObject;
        public Action SetupDoneCallback;
        public MyCustomData CustomData;
    }
}
