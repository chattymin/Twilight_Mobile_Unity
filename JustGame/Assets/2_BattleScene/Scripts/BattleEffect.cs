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
            // 액션 이펙트 지우는 코드
            GameObject.Find("PlayerBattleEffect").GetComponent<PlayerBattleEffect>().EffectOff();
            GameObject.Find("EnemyBattleEffect").GetComponent<EnemyBattleEffect>().EffectOff();
        }
        else if (StateSetting.CompareStates("BattleST"))
        {
            if (GameObject.Find("Action_Back").transform.position.y < -250)
            {
                // 특정 시간 지나면 다시 ui 올라오도록  ()밀리세크
                Thread.Sleep(2000);
                StateSetting.SetStates("SelectST");
            }
        }
    }
}
