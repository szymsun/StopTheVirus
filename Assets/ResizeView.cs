using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ResizeView : MonoBehaviour
{
    public float lineSize;

    private RectTransform _tr;
    
    private int TerminalLines => transform.childCount;

    private void Start()
    {
        _tr = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _tr.sizeDelta = new Vector2(_tr.sizeDelta.x, lineSize * transform.childCount);
    }
}
