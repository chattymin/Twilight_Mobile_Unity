using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MouseOverController : MonoBehaviour {


    private void Update() {
        if (Input.touchCount > 0) { 
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) {
                //GameObject.Find("ScriptObject").GetComponent<ParticleController>().touchParticleOn(1, 1);
                GameObject.Find("ScriptObject").GetComponent<UiController>().itemDescribePopup.SetActive(true);
            }
        }   
    }
}
