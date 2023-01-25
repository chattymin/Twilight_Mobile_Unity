using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour { //.exe 게임 파일 실행 -> MainScene 실행
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    static void FirstLoad() {
        Cursor.visible = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1920, 1080, true);

        if (SceneManager.GetActiveScene().name.CompareTo("MainScene") != 0) {
            SceneManager.LoadScene("MainScene");
        }
    }
}