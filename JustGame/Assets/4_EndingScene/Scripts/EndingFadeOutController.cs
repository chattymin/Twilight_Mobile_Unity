using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class EndingFadeOutController : MonoBehaviour {
    public Image image; //���� ȭ��
    public GameObject RestartButton; //���� ��ư

    public void EndingButton() {
        image.enabled = true;

        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine() {
        float fadeCount = 0;
        while (fadeCount < 1.0f) {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }

        SceneManager.LoadScene("MainScene");
    }
}
