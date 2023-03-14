using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CoroutineController : MonoBehaviour
{
    private GameManager gameManager = GameManager.instance;
    // Start is called before the first frame update
    public IEnumerator FadeMoneyText(TextMeshProUGUI curMoneyText) {

        curMoneyText.color = new Color(curMoneyText.color.r, curMoneyText.color.g, curMoneyText.color.b, 1);
        RectTransform rect2 = (RectTransform)curMoneyText.transform;
        rect2.anchoredPosition = new Vector3(100, 124);
        Vector3 dir = new Vector3(0, 30f, 0);

        while (curMoneyText.color.a >= 0.0f) {
            float colorA = curMoneyText.color.a - 0.05f;
            curMoneyText.color = new Color(curMoneyText.color.r, curMoneyText.color.g, curMoneyText.color.b, colorA);
            rect2.transform.Translate(dir * 0.1f);
            yield return null;
        }
    }

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
}
