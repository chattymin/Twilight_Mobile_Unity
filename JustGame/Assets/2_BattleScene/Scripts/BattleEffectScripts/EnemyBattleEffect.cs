using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AttackEffect;
    public GameObject DefenseEffect;
    public GameObject RecoveryEffect;

    public GameObject EnemyStay;
    public GameObject EnemyAttack;
    public GameObject EnemyDefense;
    public GameObject EnemyRecovery;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EffectOn(int num)
    {
        Reset();
        switch (num)
        {
            case 1:
                AttackEffect.SetActive(true);
                EnemyStay.SetActive(false);
                EnemyAttack.SetActive(true);
                break;
            case 2:
                DefenseEffect.SetActive(true);
                EnemyStay.SetActive(false);
                EnemyDefense.SetActive(true);
                break;
            case 3:
                RecoveryEffect.SetActive(true);
                EnemyStay.SetActive(false);
                EnemyRecovery.SetActive(true);
                break;
        }
    }

    public void Reset()
    {
        AttackEffect.SetActive(false);
        DefenseEffect.SetActive(false);
        RecoveryEffect.SetActive(false);

        EnemyStay.SetActive(true);
        EnemyAttack.SetActive(false);
        EnemyDefense.SetActive(false);
        EnemyRecovery.SetActive(false);
    }

}
