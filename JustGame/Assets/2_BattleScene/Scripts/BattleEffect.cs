using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BattleEffect : MonoBehaviour {
    public GameObject basicPanel;
    public GameObject winPanel;
    public GameObject losePanel;

    float timer = 0.0f;
    const int WAITING_TIME = 2;
    const int UI_POSITION_Y = -250;


    void Start() {
        basicPanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    void Update() {
        if (StateSetting.CompareStates("SelectST")) {
            // 액션 이펙트 지우는 코드
            GameObject.Find("PlayerBattleEffect").GetComponent<PlayerBattleEffect>().EffectOff();
            GameObject.Find("EnemyBattleEffect").GetComponent<EnemyBattleEffect>().EffectOff();
            GameObject.Find("PlayerBattleManager").GetComponent<PlayerBattleController>().EffectOff();
            GameObject.Find("EnemyBattleManager").GetComponent<EnemyBattleController>().EffectOff();

            StateSetting.SetStates(GameObject.Find("BattleMechanism").GetComponent<BattleMechanism>().StateCheck());

            basicPanel.SetActive(false);
            winPanel.SetActive(false);
            losePanel.SetActive(false);
        }

        else if (StateSetting.CompareStates("BattleST")) {
            if (GameObject.Find("Action_Back").transform.position.y < UI_POSITION_Y) {
                // 특정 시간 지나면 다시 ui 올라오도록  ()밀리세크
                timer += Time.deltaTime;

                if (timer > WAITING_TIME) {
                    StateSetting.SetStates("SelectST");
                    GameObject.Find("ActionManager").GetComponent<ActionSelectController>().EffectOff();
                    timer = 0.0f;
                }
            }
        }

        else if (StateSetting.CompareStates("WinST")) {
            basicPanel.SetActive(true);
            winPanel.SetActive(true);
            EnemySetting.HP = EnemySetting.MaxHP;
        }
       
        else if (StateSetting.CompareStates("LoseST")) {
            basicPanel.SetActive(true);
            losePanel.SetActive(true);
        }
    }
}
