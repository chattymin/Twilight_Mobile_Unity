using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream:JustGame/Assets/2_BattleScene/Scripts/HIdeUI.cs
public class HIdeUI : MonoBehaviour
{
    public const int speed = 20;
=======
public class HIdeUI : MonoBehaviour {
    const int speed = 20;
    const int uiPositionMin = -255;
    const int uiPositionMax = 30;
>>>>>>> Stashed changes:JustGame/Assets/2_BattleScene/Scripts/ActionSelectUIScripts/HIdeUI.cs
    public int flag = 0;

    void Update() {
        if (StateSetting.CompareStates("BattleST")) {
            if (this.transform.position.y > -255)
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed, this.transform.position.z);

<<<<<<< Updated upstream:JustGame/Assets/2_BattleScene/Scripts/HIdeUI.cs
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
=======
            if (this.transform.position.y < uiPositionMin && flag == 0) {
                flag = 1;
            }
        }

        else if(StateSetting.CompareStates("SelectST")) {
            if (this.transform.position.y < uiPositionMax)
>>>>>>> Stashed changes:JustGame/Assets/2_BattleScene/Scripts/ActionSelectUIScripts/HIdeUI.cs
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed, this.transform.position.z);

            flag = 0;
        }
    }
}
