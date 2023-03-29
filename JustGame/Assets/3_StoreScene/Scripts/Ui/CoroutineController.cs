using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class CoroutineController : MonoBehaviour
{
    private GameManager gameManager = GameManager.instance;
    
    /*FadeMoneyText : 구매시 구매 상품의 가격 텍스트 Fade out+위로 올라가는 효과 주는 코루틴*/
    public IEnumerator FadeMoneyText(TextMeshProUGUI curMoneyText) {

        curMoneyText.color = new Color(curMoneyText.color.r, curMoneyText.color.g, curMoneyText.color.b, 1);
        RectTransform rect2 = (RectTransform)curMoneyText.transform;
        rect2.anchoredPosition = new Vector3(549, 32);
        Vector3 dir = new Vector3(0, 30f, 0);

        while (curMoneyText.color.a >= 0.0f) {
            float colorA = curMoneyText.color.a - 0.05f;
            curMoneyText.color = new Color(curMoneyText.color.r, curMoneyText.color.g, curMoneyText.color.b, colorA);
            rect2.transform.Translate(dir * 0.1f);
            yield return null;
        }
    }

    /*CountingMoney : 구매시 구매 상품의 가격 카운팅 효과 주는 코루틴*/
    public IEnumerator CountingMoney(TextMeshProUGUI curMoneyText, TextMeshProUGUI curMoney) {

        float max = gameManager.playerMoney - int.Parse(curMoneyText.text);

        do {
            if ((-int.Parse(curMoneyText.text)) < 10) {
                max -= 0.8f;
            }
            else if ((-int.Parse(curMoneyText.text)) < 200) {
                max -= 5.0f;
            }
            else if ((-int.Parse(curMoneyText.text)) < 400) {
                max -= 10.0f;
            }
            else {
                max -= 20.0f;
            }
            GameObject.Find("curmoney").GetComponent<TextMeshProUGUI>().text = ((int)max).ToString();
            yield return null;
        } while (max >= gameManager.playerMoney);
        GameObject.Find("curmoney").GetComponent<TextMeshProUGUI>().text = gameManager.playerMoney.ToString();
    }

    /*FadeIcon : 구매한 해당 상품이 업그레이드 해주는 능력치 아이콘 Fadein&Fadeout 효과 주는 코루틴*/
    public IEnumerator FadeIcon(Image icon) {

        icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, 1);
        float time = 0;

        while (time<0.5f) {

            if (time < 0.25f) {
                float colorA = icon.color.a - 0.05f;
                icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, colorA);
            }
            else if (time < 0.5f) {
                float colorA = icon.color.a + 0.05f;
                icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, colorA);
            }
            time += Time.deltaTime;
            yield return null;
        }
    }
}
