using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleFadeManager : MonoBehaviour {
    public Image image;
    public GameObject storeButton;


    // *** Fade In ***
    void BattleFadeInRun() {
        //(+ Fade In 코드)
    }


    // *** Fade Out ***
    void BattleFadeOutRun() {
        image.enabled = true;
        //(+ Fade Out 코드)
        //(+ 엔딩 씬 or 상점 씬 전환 코드)
    }
}
