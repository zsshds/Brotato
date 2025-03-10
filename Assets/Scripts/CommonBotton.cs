using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommonBotton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;

    private TextMeshProUGUI text;

    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.white;
        text.color = Color.black;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.black;
        text.color = Color.white;
    }
    
   
}
