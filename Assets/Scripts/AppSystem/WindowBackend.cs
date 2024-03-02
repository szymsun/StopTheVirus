using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindowBackend : App
{
    public AppOnDock appIconOnDock;
    public RectTransform windowObject;
    public RectTransform desktopRoot;
    public Vector2 windowSize;
    public Vector2 startPlace;


    private Vector2 _whereWasTheWindow;
    private AppWindowState _lastState;
    
    public override void RunApp()
    {
        windowObject.gameObject.SetActive(true);
        isOpened = true;
        windowObject.localPosition = startPlace;
        windowObject.sizeDelta = windowSize;
        appWindowState = AppWindowState.Normal;
    }

    public override void StopApp()
    {
        windowObject.gameObject.SetActive(false);
        
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
        _lastState = appWindowState;
        windowObject.gameObject.SetActive(false);
        appWindowState = AppWindowState.Minimized;
    }

    public void UnMinimizeWindow()
    {
        windowObject.gameObject.SetActive(true);
        appWindowState = _lastState;
    }

    public void CloseWindow() => StopApp();

    protected override void OnAppFocusChanged()
    {
        base.OnAppFocusChanged();
        if (Manager.FocusedApp == this)
        {
            
        }
    }
}
