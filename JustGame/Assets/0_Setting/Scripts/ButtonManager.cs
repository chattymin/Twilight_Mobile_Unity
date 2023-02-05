using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    public Image image;
    public GameObject Fade;
    public GameObject Main;
    public GameObject Battle;
    public GameObject Store;
    public GameObject Exit;

    // *** Start Button Click ***
    public void BattleButton() {
        StartCoroutine(Fade.GetComponent<FadeManager>().FadeOutCoroutine("SelectST", "BattleScene"));
    }

    public void StoreButton() {
        StartCoroutine(Fade.GetComponent<FadeManager>().FadeOutCoroutine("SelectST", "StoreScene"));
    }

    public void MainButton() {
        // GameManager의 값을 초기화 하는 코드가 필요(초기화를 안할경우 적 스텟, 내 스텟 등이 그대로라 재시작이 아님)
        // ex) GameManager내부에 Reset()이라는 매서드를 통해 다시 초기화
        StartCoroutine(Fade.GetComponent<FadeManager>().FadeOutCoroutine("SelectST", "MainScene"));
    }

    public void EndingButton() {
        StartCoroutine(Fade.GetComponent<FadeManager>().FadeOutCoroutine("SelectST", "EndingScene"));
    }

    public void ExitButton() { // 게임 종료 버튼 클릭
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //프로그램 종료
#else
            Application.Quit();
#endif
    }
}