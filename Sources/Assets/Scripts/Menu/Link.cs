using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Link : MonoBehaviour, IPointerDownHandler
{
    public string url;

    public void OnPointerDown(PointerEventData eventData)
    {
        Application.OpenURL(url);
    }
}
