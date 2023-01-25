using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstStart : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FirstLoad()
    {
        Cursor.visible = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1920, 1080, true);

        if (SceneManager.GetActiveScene().name.CompareTo("MainScene") != 0)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}