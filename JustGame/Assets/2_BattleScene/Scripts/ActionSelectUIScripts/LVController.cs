using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LVController : MonoBehaviour
{
    public TextMeshProUGUI AttackLV;
    public TextMeshProUGUI DefenseLV;
    public TextMeshProUGUI RecoveryLV;
    

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
        
    }
}
