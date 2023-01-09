using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BattleEffect : MonoBehaviour
{
    float timer;
    int waitingTime;
    public GameObject basicPanel;
    public GameObject winPanel;
    public GameObject losePanel;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StateSetting.CompareStates("SelectST"))
        {
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
        else if (StateSetting.CompareStates("BattleST"))
        {
            if (GameObject.Find("Action_Back").transform.position.y < -250)
            {
                // 특정 시간 지나면 다시 ui 올라오도록  ()밀리세크
                //Thread.Sleep(2000);
                timer += Time.deltaTime;

                if (timer > waitingTime)
                {
                    StateSetting.SetStates("SelectST");
                    GameObject.Find("ActionManager").GetComponent<ActionSelectController>().EffectOff();
                    timer = 0.0f;
                }
            }
        }
        else if (StateSetting.CompareStates("WinST"))
        {
            basicPanel.SetActive(true);
            winPanel.SetActive(true);
        }
        else if (StateSetting.CompareStates("LoseST"))
        {
            basicPanel.SetActive(true);
            losePanel.SetActive(true);
        }
    }
}
