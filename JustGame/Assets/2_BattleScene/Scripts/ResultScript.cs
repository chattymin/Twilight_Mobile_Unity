using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultScript : MonoBehaviour
{
    GameObject WinPage;
    public TextMeshProUGUI Hp;
    public TextMeshProUGUI playerAttack;
    public TextMeshProUGUI playerDefense;
    public TextMeshProUGUI playerRecovery;
    public TextMeshProUGUI playerMoney; 
    // Start is called before the first frame update
    void Start(){

        Hp.text = PlayerSetting.HP.ToString();
        playerAttack.text = PlayerSetting.attackLV.ToString();
        playerDefense.text = PlayerSetting.defenseLV.ToString();
        playerRecovery.text = PlayerSetting.recoveryLV.ToString();
        playerMoney.text = PlayerSetting.money.ToString();

        //WinPage = GameObject.Find("WinPopup");
        //WinPage.SetActive(false);
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
