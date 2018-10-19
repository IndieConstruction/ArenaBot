using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace CSToU.UI {

    public class TextBox : MonoBehaviour {

        public bool LookAtCamera = true;

        public TMPro.TextMeshProUGUI Lable;

        /// <summary>
        /// Scrive il stesto in parametro sulla lable di testo del controller.
        /// </summary>
        /// <param name="_text"></param>
        public void SetText(string _text) {
            Lable.text = _text;
        }



    }

}