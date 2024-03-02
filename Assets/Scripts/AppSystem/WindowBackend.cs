using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class WindowBackend : App
{
    public AppOnDock appIconOnDock;
    public RectTransform windowObject;
    public RectTransform desktopRoot;
    public Vector2 windowSize;
    public Vector2 startPlace;


    private RectTransform _whereWasTheWindow;
    private AppWindowState _lastState;

    
    
    protected virtual void Start()
    {
        base.Start();
        _whereWasTheWindow = new RectTransform();
    }
    
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
        _lastState = appWindowState;
        _whereWasTheWindow = windowObject;
        windowObject.anchorMax = desktopRoot.anchorMax;
        windowObject.anchorMin = desktopRoot.anchorMin;
        windowObject.localPosition = desktopRoot.localPosition;
        windowObject.sizeDelta = desktopRoot.sizeDelta;
        appWindowState = AppWindowState.Maximized;
    }

    public void UnmaximizeWindow()
    {
        _lastState = appWindowState;
        windowObject.anchorMax = _whereWasTheWindow.anchorMax;
        windowObject.anchorMin = _whereWasTheWindow.anchorMin;
        windowObject.localPosition = _whereWasTheWindow.localPosition;
        windowObject.sizeDelta = _whereWasTheWindow.sizeDelta;
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
