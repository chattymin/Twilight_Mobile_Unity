using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonController : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("MainPage");
    }
}
