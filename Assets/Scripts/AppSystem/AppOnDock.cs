using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AppOnDock : MonoBehaviour
{
    public App app;
    public Image appRunningIndicator;
    
    public void ClickCallback()
    {
        if(!app.isOpened)
            app.RunApp();
        else
        {
            WindowBackend windowBackend = app.GetComponent<WindowBackend>();
            switch (app.appWindowState)
            {
                case AppWindowState.Maximized:
                    windowBackend.MinimizeWindow();
                    break;
                case AppWindowState.Minimized:
                    windowBackend.UnMinimizeWindow();
                    break;
                case AppWindowState.Normal:
                    windowBackend.MinimizeWindow();
                    break;
            }
        }
    }
}
