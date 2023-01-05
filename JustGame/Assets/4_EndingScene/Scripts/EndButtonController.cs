using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButtonController : MonoBehaviour
{
    public void OnClick()
    {
        // 메인페이지로 돌아갈 경우
        // SceneManager.LoadScene("NextScene");

        // 게임을 종료할 경우
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
