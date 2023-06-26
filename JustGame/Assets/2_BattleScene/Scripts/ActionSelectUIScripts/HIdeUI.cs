using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIdeUI : MonoBehaviour
{
    const int speed = 20;
    const int uiPositionMin = -255;
    const int uiPositionMax = 30;
    public int flag = 0;

    void Update()
    {
        if (StateSetting.CompareStates("BattleST")) {
            if (this.transform.position.y > uiPositionMin)
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed, this.transform.position.z);

            if (this.transform.position.y < uiPositionMin && flag == 0)
            {
                flag = 1;
            }
        }
        else if(StateSetting.CompareStates("SelectST"))
        {
            if (this.transform.position.y < uiPositionMax)
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed, this.transform.position.z);

            flag = 0;
        }
    }
}
