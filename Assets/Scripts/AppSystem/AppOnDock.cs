using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AppOnDock : MonoBehaviour
{
    public App app;
    public Image appRunningIndicator;

    public RectTransform GetLocalPosition()
    {
        RectTransform tr = GetComponent<RectTransform>();
        if (tr != null)
        {
            return tr;
        }
        else
        {
            return null;
        }
    }

    public void ClickCallback()
    {
        if (!app.isOpened)
        {
            app.RunApp();
            appRunningIndicator.gameObject.SetActive(true);
        }

        else
        {
            DesktopManager manager = FindObjectOfType<DesktopManager>();

            WindowBackend windowBackend = app.GetComponent<WindowBackend>();
            switch (app.appWindowState)
            {
                case AppWindowState.Maximized:
                    windowBackend.MinimizeWindow();
                    manager.FocusedApp = manager.dock;
                    break;
                case AppWindowState.Minimized:
                    windowBackend.UnMinimizeWindow();
                    manager.FocusedApp = app;
                    break;
                case AppWindowState.Normal:
                    windowBackend.MinimizeWindow();
                    manager.FocusedApp = manager.dock;
                    break;
            }
        }
    }

    public void OnAppClose()
    {
        appRunningIndicator.gameObject.SetActive(false);
    }
}