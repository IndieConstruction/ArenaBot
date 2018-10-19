using UnityEngine;
using DG.Tweening;

namespace CSToU {

    public interface IMovable {
        void MoveTo(Vector3 targetPosition);

        void Wait(float timeToWait, TweenCallback callback = null);

        void Collide();

        Vector3 CurrentPosition { get; }
        Vector3 OldPosition { get; }
    }

}