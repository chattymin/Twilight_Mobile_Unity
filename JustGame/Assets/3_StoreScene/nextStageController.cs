using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextStageController : MonoBehaviour
{
    // Start is called before the first frame update
    public void nextBtnClick() {
        SceneManager.LoadScene("BattleScene");
    }
}
