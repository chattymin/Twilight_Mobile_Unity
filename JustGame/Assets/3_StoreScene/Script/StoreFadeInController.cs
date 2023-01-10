using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreFadeInController : MonoBehaviour {
    public Image image; //���� ȭ��

    void Start() {
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine() {
        float fadeCount = 1.0f;
        while (fadeCount > 0) {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        image.enabled = false;
    }
}
