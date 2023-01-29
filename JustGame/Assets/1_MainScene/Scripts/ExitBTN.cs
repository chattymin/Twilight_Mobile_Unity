using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBTN : MonoBehaviour {
    public void OnClick() { // 게임 종료 버튼 클릭
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //프로그램 종료
        #else
            Application.Quit();
        #endif
    }
}