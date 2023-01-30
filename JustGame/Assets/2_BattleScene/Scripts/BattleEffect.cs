using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BattleEffect : MonoBehaviour {
    public GameObject basicPanel;
    public GameObject winPanel;
    public GameObject losePanel;

    float timer;
    const int WAITING_TIME = 2;
    const int UI_POSITION_Y = -250;


    void Start() {
        timer = 0.0f;
        basicPanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }
    
    void Update() {
        if (StateSetting.CompareStates("SelectST")) {
            GameObject.Find("PlayerBattleEffect").GetComponent<PlayerBattleEffect>().Reset();
            GameObject.Find("EnemyBattleEffect").GetComponent<EnemyBattleEffect>().Reset();
            GameObject.Find("BattleManager").GetComponent<PlayerBattleController>().Reset();
            GameObject.Find("BattleManager").GetComponent<EnemyBattleController>().Reset();
            // 액션 이펙트 지우는 코드

            StateSetting.SetStates(GameObject.Find("BattleManager").GetComponent<BattleMechanism>().StateCheck());
        }else if (StateSetting.CompareStates("BattleST")) {
            if (GameObject.Find("Action_Back").transform.position.y < UI_POSITION_Y) {
                // 특정 시간 지나면 다시 ui 올라오도록  ()밀리세크
                timer += Time.deltaTime;

                if (timer > WAITING_TIME) {
                    StateSetting.SetStates("SelectST");
                    GameObject.Find("ActionManager").GetComponent<ActionSelectController>().Reset();
                    timer = 0.0f;
                }
            }
        }else if (StateSetting.CompareStates("WinST")) {
            basicPanel.SetActive(true);
            winPanel.SetActive(true);
            GameManager.instance.enemyCurrentHP = GameManager.instance.enemyMaxHP;
        }else if (StateSetting.CompareStates("LoseST")) {
            basicPanel.SetActive(true);
            losePanel.SetActive(true);
        }
    }
}
