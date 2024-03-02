using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : App
{
    public App[] appsOnDock;
    
    private void Start()
    {
        base.Start();
        isVisibleOnDock = false;
    }

    protected override void OnAppFocusChanged()
    {
        base.OnAppFocusChanged();
        if (Manager.FocusedApp == this)
        {
            
        }
    }

    public void ShowFocusedAppOverlay()
    {
        
    }

    public void HideOverlay()
    {
        
    }
}
