using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BattleEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StateSetting.CompareStates("SelectST"))
        {
            GameObject.Find("PlayerBattleEffect").GetComponent<PlayerBattleEffect>().EffectOff();
            GameObject.Find("EnemyBattleEffect").GetComponent<EnemyBattleEffect>().EffectOff();
        }
        else if (StateSetting.CompareStates("BattleST"))
        {
            if (GameObject.Find("Action_Back").transform.position.y < -250)
            {
                // 배틀 이펙트
                //GameObject.Find("BattleMechanism").GetComponent<BattleMechanism>().BattleRun();
                Thread.Sleep(2000);
                StateSetting.SetStates("SelectST");
            }
        }
    }
}
