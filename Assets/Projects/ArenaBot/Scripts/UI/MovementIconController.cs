using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CSToU.Core;
using CSToU.Units;
using System;

namespace CSToU.UI {


    public class MovementIconController : MonoBehaviour {

        public Image Icon;
        public Image Background;

        public Sprite WaitIcon;
        public Color ColorWait;
        public Sprite MoveIcon;
        public Color ColorMove;
        public Sprite CollisionIcon;
        public Color ColorCollisionPositive;
        public Color ColorCollisionNegative;

        UnitBase unit;

        private void OnEnable() {
            GlobalEventManager.OnGMSetupFinished += SetupDone;
        }

        private void SetupDone() {
            unit = GetComponentInParent<UnitBase>();
            unit.SM.OnStateChanged += SMStateChanged;
        }

        private void SMStateChanged(UnitState currentState, UnitState oldState) {
            switch (currentState) {
                case UnitState.not_ready:
                    break;
                case UnitState.idle:
                    Icon.sprite = WaitIcon;
                    Background.color = ColorWait;
                    break;
                case UnitState.walk:
                    Icon.sprite = MoveIcon;
                    Background.color = ColorMove;
                    break;
                case UnitState.collision_cooldown_positive:
                    Icon.sprite = CollisionIcon;
                    Background.color = ColorCollisionPositive;
                    break;
                case UnitState.collision_cooldown_negative:
                    Icon.sprite = CollisionIcon;
                    Background.color = ColorCollisionNegative;
                    break;
                default:
                    break;
            }
        }

        private void OnDisable() {
            GlobalEventManager.OnGMSetupFinished -= SetupDone;
            unit.SM.OnStateChanged -= SMStateChanged;
        }
    }
}