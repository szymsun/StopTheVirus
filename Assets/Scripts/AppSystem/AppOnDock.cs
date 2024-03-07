using UnityEngine;

public class AppOnDock : MonoBehaviour
{
    public App app;
    public GameObject appRunningIndicator;

    public RectTransform GetLocalPosition()
    {
        var tr = GetComponent<RectTransform>();
        return tr != null ? tr : null;
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