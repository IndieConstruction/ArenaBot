using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSToU.Core;

namespace CSToU.Units {

    public class UnitStateMachine : MonoBehaviour {

        #region Properties

        private Animator anim;
        private UnitState _currentState = UnitState.not_ready;

        public UnitState CurrentState {
            get { return _currentState; }
            set {
                if (_currentState != value) {
                    UnitState oldState = _currentState;
                    _currentState = value;
                    StateChanged(oldState);
                }
            }
        }

        IMovable movable;

        public delegate void SMEventDelegate(UnitState currentState, UnitState oldState);

        public SMEventDelegate OnStateChanged;

        #endregion

        public void Setup(IMovable _movable) {
            movable = _movable;
            anim = GetComponentInChildren<Animator>();
        }

        #region Lifecycle

        /// <summary>
        /// Chiamata appena lo stato è stato cambiato.
        /// </summary>
        private void StateChanged(UnitState oldState) {

            switch (CurrentState) {
                case UnitState.not_ready:
                    break;
                case UnitState.idle:
                    // anim idle
                    anim.SetInteger("State", 1);
                    movable.Wait(Random.Range(GM.I.CurrentConfiguration.WaitTimeAverage - GM.I.CurrentConfiguration.WaitTimeVariation, GM.I.CurrentConfiguration.WaitTimeAverage + GM.I.CurrentConfiguration.WaitTimeVariation));
                    break;
                case UnitState.walk:
                    // anim walk
                    anim.SetInteger("State", 2);
                    // movimento verso direzione target
                    movable.MoveTo(GM.I.GetRandomSpownPosition(movable.CurrentPosition));
                    break;
                case UnitState.collision_cooldown_positive:
                    anim.SetInteger("State", 1);
                    movable.Collide();
                    if(GlobalEventManager.OnUnitCollisionPositive != null)
                        GlobalEventManager.OnUnitCollisionPositive(movable as UnitBase);
                    break;
                case UnitState.collision_cooldown_negative:
                    anim.SetInteger("State", 1);
                    movable.Collide();
                    if (GlobalEventManager.OnUnitCollisionNegative != null)
                        GlobalEventManager.OnUnitCollisionNegative(movable as UnitBase);
                    break;
                default:
                    break;
            }

            if (OnStateChanged != null)
                OnStateChanged(CurrentState, oldState);

        }

        private void Update() {

            switch (CurrentState) {
                case UnitState.not_ready:
                    break;
                case UnitState.idle:
                    break;
                case UnitState.walk:
                    break;
                case UnitState.collision_cooldown_positive:
                    break;
                default:
                    break;
            }

        }

        #endregion

    }

    public enum UnitState {
        not_ready = 0,
        idle = 1,
        walk = 2,
        collision_cooldown_positive = 3,
        collision_cooldown_negative = 4,
    }
}