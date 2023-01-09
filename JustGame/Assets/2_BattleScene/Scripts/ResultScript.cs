using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultScript : MonoBehaviour
{
    GameObject WinPage;
    TextMeshProUGUI Hp;
    TextMeshProUGUI playerAttack;
    TextMeshProUGUI playerDefense;
    TextMeshProUGUI playerRecovery;
    TextMeshProUGUI playerMoney; 
    // Start is called before the first frame update
    void Start(){

        Hp = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
        playerAttack = GameObject.Find("PlayerAttackLV").GetComponent<TextMeshProUGUI>();
        playerDefense = GameObject.Find("PlayerDefenseLV").GetComponent<TextMeshProUGUI>();
        Hp = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();

        Hp = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();



        WinPage = GameObject.Find("WinPopup");
        WinPage.SetActive(false);
    }

    void popupOn() {
        if (PlayerSetting.HP < 0 && EnemySetting.HP <= 0) {
            WinPage.SetActive(true);
        } 
    }

    void btnClick() {
        SceneManager.LoadScene("");
    }

    void showCurState() { 
    }

    public void MainSceneBT()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitSceneBT()
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
