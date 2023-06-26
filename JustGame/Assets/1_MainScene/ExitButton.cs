using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD:JustGame/Assets/1_MainScene/ExitButton.cs
public class ExitButton : MonoBehaviour
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
=======
public class ExitButton : MonoBehaviour {
    public GameObject startParenthese;
    public GameObject settingParenthese;
    public GameObject extraParenthese;
    public GameObject exitParenthese;

    public void OnMouseEnter() {
        startParenthese.SetActive(false);
        settingParenthese.SetActive(false);
        extraParenthese.SetActive(false);
        exitParenthese.SetActive(true);
        BTNManager.button = 4;
>>>>>>> feature/Issue15:JustGame/Assets/1_MainScene/Scripts/ExitButton.cs
    }
}
