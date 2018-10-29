using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSToU.Core;
using System;
using DG.Tweening;

namespace CSToU.Units {

    public abstract class UnitBase : MonoBehaviour, IMovable {

        #region Properties
        public enum Class {
            Cylinder = 1,
            Cube = 2,
            Sphere = 3,
        }

        public Class CurrentClass;
        public string CurrentFaction = "";

        #endregion

        #region LifeCycle
        private void OnEnable() {
            GlobalEventManager.OnPostSetup += MandatorySetup;
        }

        private void OnDisable() {
            GlobalEventManager.OnPostSetup -= MandatorySetup;
        }
        #endregion

        #region Setup
        /// <summary>
        /// Esegue le funzioni essenziali per il setup di ogni unità.
        /// </summary>
        private void MandatorySetup() {
            CreateGraphic();
            Setup();
            GM.I.MngUnit.UnitReady(this);
            SetFactionSetup();
            setupStateMachine();
        }

        /// <summary>
        /// Azioni di setup custom per le classi derivate.
        /// </summary>
        protected abstract void Setup();

        /// <summary>
        /// Crea la grafica della unit.
        /// </summary>
        protected virtual void CreateGraphic() {
            //CurrentClass = GetRandomClass();
            GameObject graphicPrefab = GM.I.MngUnit.GetPrefab(CurrentClass);
            if (graphicPrefab == null) {
                Debug.LogError("Prefab " + CurrentClass + " not found");
                return;
            }
            GameObject graphicInstance = Instantiate<GameObject>(graphicPrefab, transform);

        }

        /// <summary>
        /// Setto tutte le operazioni riguardanti la fazione.
        /// </summary>
        protected void SetFactionSetup() {
            GetComponentInChildren<Renderer>().material.color = GM.I.MngUnit.GetColor(CurrentFaction);
        }

        /// <summary>
        /// Get random class type.
        /// </summary>
        /// <returns></returns>
        protected Class GetRandomClass() {
            return (Class)UnityEngine.Random.Range(0, 2);
        }
        #endregion

        #region StateMachine controller

        [HideInInspector]
        public UnitStateMachine SM;

        /// <summary>
        /// Inizializzo la state machine e posiziono la unit in uno spawnPoint.
        /// </summary>
        void setupStateMachine() {
            SM = GetComponent<UnitStateMachine>();
            if (SM == null) {
                Debug.LogError(string.Format("SM not found!"));
                return;
            }
            SM.Setup(this);
            transform.position = GM.I.GetRandomSpownPosition(Vector3.zero);
            SM.CurrentState = UnitState.idle;
        }

        #endregion

        #region Movements (IMovable)

        public Vector3 CurrentPosition { get { return transform.position; } }

        public Vector3 OldPosition { get { return _oldPosition; } }
        public Vector3 _oldPosition;

        Sequence movementSequence;

        public void MoveTo(Vector3 targetPosition) {
            _oldPosition = transform.position;
            if(movementSequence != null)
                movementSequence.Kill();
            movementSequence = DOTween.Sequence();
            movementSequence.Append(transform.DOLookAt(targetPosition, UnityEngine.Random.Range(GM.I.CurrentConfiguration.RotationSpeedAverage - GM.I.CurrentConfiguration.WaitTimeVariation, GM.I.CurrentConfiguration.WaitTimeAverage + GM.I.CurrentConfiguration.RotationSpeedVariation)));
            movementSequence.Append(transform.DOMove(targetPosition, UnityEngine.Random.Range(GM.I.CurrentConfiguration.MoveSpeedAverage - GM.I.CurrentConfiguration.MoveSpeedVariation, GM.I.CurrentConfiguration.MoveSpeedAverage + GM.I.CurrentConfiguration.MoveSpeedVariation))
                .SetSpeedBased(true)
                .SetEase(Ease.Linear)
            );
            movementSequence.OnComplete(() => {
                SM.CurrentState = UnitState.idle;
            });
        }

        public void Wait(float timeToWait, TweenCallback onCompletedCallback = null) {
            if (movementSequence != null)
                movementSequence.Kill();
            transform.DOMove(transform.position, timeToWait).OnComplete(() => {
                if (onCompletedCallback == null)
                    SM.CurrentState = UnitState.walk;
                else
                    onCompletedCallback();
            });
        }

        public void Collide() {
            movementSequence.Kill();
            movementSequence = DOTween.Sequence();
            movementSequence.Append(transform.DOMove(transform.position - transform.TransformDirection(transform.forward * 0.2f), 0.3f));
            movementSequence.OnComplete( () => {
                Wait(UnityEngine.Random.Range(GM.I.CurrentConfiguration.WaitTimeAverage - GM.I.CurrentConfiguration.WaitTimeVariation, GM.I.CurrentConfiguration.WaitTimeAverage + GM.I.CurrentConfiguration.WaitTimeVariation));
            });
        } 

        #endregion

        #region Collision

        /// <summary>
        /// Reagisce ad una collisione.
        /// </summary>
        /// <param name="collision"></param>
        public void DoCollision(Collider other, bool isOffensiveCollidder) {
            //if (movementSequence != null)
            //    movementSequence.Kill();
            //MoveTo(OldPosition);
            if(isOffensiveCollidder)
                SM.CurrentState = UnitState.collision_cooldown_positive;
            else
                SM.CurrentState = UnitState.collision_cooldown_negative;
        }

        #endregion

        #region Debug

        private void OnMouseDown() {
            if (!SM)
                return;
            switch (SM.CurrentState) {
                case UnitState.not_ready:
                    SM.CurrentState = UnitState.idle;
                    break;
                case UnitState.idle:
                    SM.CurrentState = UnitState.walk;
                    break;
                case UnitState.walk:
                    SM.CurrentState = UnitState.idle;
                    break;
                default:
                    break;
            }





        }

        #endregion

    }
}
