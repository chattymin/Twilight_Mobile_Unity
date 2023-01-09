using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextStageController : MonoBehaviour
{

    // Start is called before the first frame update
    public void nextBtnClick() {
        StateSetting.SetStates("SelectST");
        
        PlayerSetting.round++;
        SceneManager.LoadScene("BattleScene" + StateSetting.boss[PlayerSetting.round]);
    }
}
