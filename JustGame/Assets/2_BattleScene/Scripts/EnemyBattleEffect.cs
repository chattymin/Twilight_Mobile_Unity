using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AttackEffect;
    public GameObject DefenseEffect;
    public GameObject RecoveryEffect;

    // Start is called before the first frame update
    void Start()
    {
        AttackEffect.SetActive(false);
        DefenseEffect.SetActive(false);
        RecoveryEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EffectOn(int num)
    {
        switch (num)
        {
            case 1:
                AttackEffect.SetActive(true);
                DefenseEffect.SetActive(false);
                RecoveryEffect.SetActive(false);
                break;
            case 2:
                AttackEffect.SetActive(false);
                DefenseEffect.SetActive(true);
                RecoveryEffect.SetActive(false);
                break;
            case 3:
                AttackEffect.SetActive(false);
                DefenseEffect.SetActive(false);
                RecoveryEffect.SetActive(true);
                break;
        }
    }

    public void EffectOff()
    {
        AttackEffect.SetActive(false);
        DefenseEffect.SetActive(false);
        RecoveryEffect.SetActive(false);
    }

}
