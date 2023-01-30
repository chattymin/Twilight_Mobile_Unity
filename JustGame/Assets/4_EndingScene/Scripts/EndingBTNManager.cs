using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingBTNManager : MonoBehaviour
{
    public Image image;

    public GameObject endButton;
    public GameObject restartButton;

    private void Start() {
        
    }

    // *** Restart Button Click ***
    public void RestartButtonRun() {
        RestartClick();
        SceneChange();
    }

    public void RestartClick() {
        restartButton.SetActive(false);
        endButton.SetActive(false);
    }

    public void SceneChange() {
        StateSetting.states = "SelectST";
        SceneManager.LoadScene("BattleScene");
    }

    // *** End Button Click ***
    public void EndButtonRun() {
        //GameObject.Find("FadeOutCoroutine").GetComponent<FadeManager>().FadeOutCoroutine();
        //FadeOut 코루틴 실행
        EndClick();
    }

    public void EndClick() { // 게임 종료 버튼 클릭
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //프로그램 종료
#else
            Application.Quit();
#endif
    }
}
