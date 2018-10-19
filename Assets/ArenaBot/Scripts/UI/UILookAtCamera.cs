using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSToU.UI {

    public class UILookAtCamera : MonoBehaviour {

        //Tween lookAtCameraTW;

        //public void Update() {
        //    if (lookAtCameraTW != null)
        //        lookAtCameraTW.Kill();
        //    lookAtCameraTW = transform.DOLookAt(Camera.main.transform.position, 0.1f);
        //}

        public void Update() {
            transform.LookAt(Camera.main.transform.position);
        }
    }

}