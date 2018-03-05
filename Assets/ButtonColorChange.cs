using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button but;
    public void OnPointerEnter(PointerEventData eventData)
    {
        but.GetComponent<Image>().color = Color.grey;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        but.GetComponent<Image>().color = Color.white;
    }
}
