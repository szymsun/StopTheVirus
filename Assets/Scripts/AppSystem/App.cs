using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AppType
{
    FixedPositionAndScale,
    Resizable,
    FixedScale
}

public enum AppWindowState
{
    Minimized,
    Normal,
    Maximized
}

public class App : MonoBehaviour
{
    public AppWindowState appWindowState;
    public AppType appType;

    public bool isVisibleOnDock;
    public bool isOpened;

    protected DesktopManager _manager;    
    protected virtual void Start()
    {
        _manager = FindObjectOfType<DesktopManager>();
        _manager.appFocusChangeEvent.AddListener(OnAppFocusChanged);
    }

    public virtual void RunApp()
    {
        
    }

    public virtual void StopApp()
    {
        
    }
    
    protected virtual void OnAppFocusChanged()
    {
        
    }
    
    protected virtual void OnMouseDown()
    {
        _manager.FocusedApp = GetComponent<App>();
    }
}
