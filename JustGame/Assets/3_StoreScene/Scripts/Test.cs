using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Test : MonoBehaviour
    ,IPointerEnterHandler
    ,IPointerExitHandler
{
    public GameObject itemDescribePopup;

    // Start is called before the first frame update
    void Start()
    {
        itemDescribePopup.SetActive(false);
    }

    // Update is called once per frame
    public void OnPointerEnter(PointerEventData eventData) {

        itemDescribePopup.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        itemDescribePopup.SetActive(false);

    }
}
