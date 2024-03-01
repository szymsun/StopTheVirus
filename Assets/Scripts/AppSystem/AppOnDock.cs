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
            Window window = app.GetComponent<Window>();
            switch (app.appWindowState)
            {
                case AppWindowState.Maximized:
                    window.MaximizeWindow();
                    break;
                case AppWindowState.Minimized:
                    window.UnMinimizeWindow();
                    break;
                case AppWindowState.Normal:
                    window.MinimizeWindow();
                    break;
            }
        }
    }
}
