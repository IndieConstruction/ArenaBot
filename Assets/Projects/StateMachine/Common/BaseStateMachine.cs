using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace IntroCSharp.StateMachine {

    public abstract class BaseStateMachine : MonoBehaviour {

        #region properties

        public List<IState> States = new List<IState>();

        /// <summary>
        /// Stato attuale.
        /// </summary>
        public IState CurrentState {
            get { return _currentState; }
            set {
                if (_currentState == value)
                    return;
                OldState = _currentState;
                OnPreStateChanged(_currentState, OldState);
                _currentState = value;
                OnStateChanged(_currentState, OldState);
            }
        }


        private IState _currentState;

        /// <summary>
        /// Vecchi stato.
        /// </summary>
        public IState OldState {
            get { return _oldState; }
            private set { _oldState = value; }
        }
        private IState _oldState;

        /// <summary>
        /// Contesto della state machine.
        /// </summary>
        protected IContext context;

        #endregion

        #region Setup

        /// <summary>
        /// Imposta il riferimento al contesto.
        /// </summary>
        /// <param name="_context"></param>
        public void Setup(IContext _context, List<IState> _states) {
            States = _states;
            foreach (IState state in States) {
                state.Setup(_context);
            }
        }

        #endregion

        /// <summary>
        /// Chiamata prima del cambio di stato
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="oldState"></param>
        private void OnPreStateChanged(IState currentState, IState oldState) {
            if(oldState != null)
                oldState.Exit();
        }

        /// <summary>
        /// Chiamata dopo del cambio stato.
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="value"></param>
        private void OnStateChanged(IState currentState, IState value) {
            currentState.Enter();
        }

        private void Update() {
            if (CurrentState != null)
                CurrentState.Tick();
        }

    }

}
