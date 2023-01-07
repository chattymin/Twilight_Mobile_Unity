using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIdeUI : MonoBehaviour
{
    public const int speed = 20;
    public int flag = 0;

    void Update()
    {
        if (StateSetting.CompareStates("BattleST")) {
            if (this.transform.position.y > -255)
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed, this.transform.position.z);

            if (this.transform.position.y < -260 && flag == 0)
            {
                // 전투씬 출력 함수 실행 
                //GameObject.Find("BattleMechanism").GetComponent<BattleEffect>()
                flag = 1;
            }
        }
        else if(StateSetting.CompareStates("SelectST"))
        {
            if (this.transform.position.y < 30)
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed, this.transform.position.z);

            flag = 0;
        }
    }
}
