using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Window : App
{
    public AppOnDock appIconOnDock;
    public RectTransform windowObject;
    public RectTransform desktopRoot;
    public Vector2 windowSize;
    public Vector2 startPlace;


    private Vector2 _whereWasTheWindow;
    public override void RunApp()
    {
        windowObject.localPosition = startPlace;
        windowObject.sizeDelta = windowSize;
        appWindowState = AppWindowState.Normal;
    }

    public override void StopApp()
    {
        
    }
        
    public void MaximizeWindow()
    {
        _whereWasTheWindow = windowObject.localPosition;
        windowObject.localPosition = new Vector2(0,0);
        windowObject.sizeDelta = desktopRoot.sizeDelta;
        appWindowState = AppWindowState.Maximized;
    }

    public void UnmaximizeWindow()
    {
        windowObject.sizeDelta = windowSize;
        windowObject.localPosition = _whereWasTheWindow;
        appWindowState = AppWindowState.Normal;
    }

    public void MinimizeWindow()
    {
        windowObject.gameObject.SetActive(false);
    }

    public void UnMinimizeWindow()
    {
        windowObject.gameObject.SetActive(true);
    }

    public void CloseWindow() => StopApp();

    private void OnMouseDown()
    {
        _manager.FocusedApp = this;
    }

    protected override void OnAppFocusChanged()
    {
        base.OnAppFocusChanged();
        if (_manager.FocusedApp == this)
        {
            
        }
    }
}
