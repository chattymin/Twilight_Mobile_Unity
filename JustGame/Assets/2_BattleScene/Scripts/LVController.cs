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
        AttackLV.text = "LV" + PlayerSetting.attackLV;
        DefenseLV.text = "LV" + PlayerSetting.defenseLV;
        RecoveryLV.text = "LV" + PlayerSetting.recoveryLV;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
