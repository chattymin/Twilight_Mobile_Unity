using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LVController : MonoBehaviour {
    public TextMeshProUGUI AttackLV;
    public TextMeshProUGUI DefenseLV;
    public TextMeshProUGUI RecoveryLV;
    

<<<<<<< Updated upstream:JustGame/Assets/2_BattleScene/Scripts/LVController.cs
    // Start is called before the first frame update
    void Start()
    {
        AttackLV.text = "LV" + GameManager.instance.playerAttackLV;
        DefenseLV.text = "LV" + GameManager.instance.playerDefenseLV;
        RecoveryLV.text = "LV" + GameManager.instance.playerRecoveryLV;
    }

    // Update is called once per frame
    void Update()
    {
        
=======
    void Start() {
        AttackLV.text = "LV " + GameManager.instance.playerAttackLV;
        DefenseLV.text = "LV " + GameManager.instance.playerDefenseLV;
        RecoveryLV.text = "LV " + GameManager.instance.playerRecoveryLV;
>>>>>>> Stashed changes:JustGame/Assets/2_BattleScene/Scripts/ActionSelectUIScripts/LVController.cs
    }
}
