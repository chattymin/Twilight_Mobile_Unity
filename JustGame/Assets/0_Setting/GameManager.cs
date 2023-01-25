using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    private void Awake() {
        if (instance == null) { //instance가 존재하지 않는다면
            instance = this; //자신을 instance로 넣어 줌.
            DontDestroyOnLoad(gameObject); //씬 로드 시 데이터 유지
        }
        else {
            if (instance != this) //이미 instance가 존재할 때
                Destroy(this.gameObject);
            //유일한 객체이므로 새로 Awake된 자신 삭제
        }
    }

    /*public static GameManager Instance {
        //Instance를 static으로 선언. 다른 클래스에서 호출 가능
        get {
            if (null == instance)
                return null;
            return instance;
        }
    }*/


    // *** 사용법 ***
    // GameManager.instance.(메서드 or 변수);


    // *** PlayerSetting ***
    public int playerCurrentHP = 100; //플레이어 현재 체력
    public int playerMoney = 0; //플레이어 현재 소지금
    public int playerAttackLV = 1; //플레이어 공격 레벨
    public int playerDefenseLV = 1; //방어
    public int playerRecoveryLV = 1; //회복
    public Item playerInventoryItem = null; //플레이어 소지 아이템


    // *** EnemySetting ***
    public int EnemyBaseNumber = 1; //적 스텟 기반 숫자


    // *** ShopSetting ***
    private const int NUMBER_OF_ITEMS = 10; //상점 아이템 가짓수(기본값)
    public List<Item> ShopItemList = new List<Item>(NUMBER_OF_ITEMS);
    //상점 아이템 리스트


    // *** GameManagement ***
    public void StartGame() { //메인 씬 -> 새 게임 시작

    }
    public void ContinueGame() { //메인 씬 -> 이어하기

    }
    public void PauseGame() { //Esc 게임 멈춤

    }
}