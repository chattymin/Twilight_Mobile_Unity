using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour {
    public Image image;
    const float FADE_SPEED = 0.01f;

    private void Awake() {
        StartCoroutine(FadeInCoroutine());
    }

    // *** Fade Out ***
    public IEnumerator FadeOutCoroutine(string state, string scene) {
        image.enabled = true;
        float fadeCount = 0;
        while (fadeCount < 1.0f) {
            fadeCount += FADE_SPEED;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        SceneChange(state, scene);
    }

    // *** Fade In ***
    IEnumerator FadeInCoroutine() {
        float fadeCount = 1.0f;

        while (fadeCount > 0) {
            fadeCount -= FADE_SPEED;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        image.enabled = false;
    }

    public void SceneChange(string state, string scene) {
        StateSetting.states = state;
        SceneManager.LoadScene(scene);
    }

}