using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutController : MonoBehaviour {
    public Image image; //���� ȭ��
    public GameObject storeButton; //���� ��ư

    public void StoreButton() {
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
        if(PlayerSetting.round == 3) SceneManager.LoadScene("EndingScene");
        else SceneManager.LoadScene("StoreScene");
    }
}
