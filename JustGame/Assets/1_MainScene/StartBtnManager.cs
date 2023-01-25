using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBtnManager : MonoBehaviour {
    public Image image; //���� ȭ��
    public GameObject startButton; //���� ����
    public GameObject exitButton; //���� ����

    public void FadeButton() {
        startButton.SetActive(false);
        exitButton.SetActive(false);
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine() {
        float fadeCount = 0;
        while (fadeCount < 1.0f) {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        SceneChange();
    }

    public void SceneChange() {
        StateSetting.states = "SelectST";
        SceneManager.LoadScene("BattleScene");
    }
}
