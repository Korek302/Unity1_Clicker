using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackButtonController : MonoBehaviour, IPointerClickHandler
{
    public GameObject ButtonPanel;
    public GameObject FinishPanel;

    public void OnPointerClick(PointerEventData eventData)
    {
        FinishPanel.gameObject.SetActive(false);
        ButtonPanel.gameObject.SetActive(true);
    }
}
