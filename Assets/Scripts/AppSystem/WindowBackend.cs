using UnityEngine;

public class WindowBackend : App
{
    public AppOnDock appIconOnDock;
    public RectTransform windowObject;
    public RectTransform desktopRoot;
    public Vector2 windowSize;
    public Vector2 startPlace;

    public RectTransform rectNormalWin, rectMaximizedWin;
    
    
    [SerializeField]
    private Vector2 _whereWasTheWindow;
    private AppWindowState _lastState;

    
    
    protected override void Start()
    {
        base.Start();
        
    }
    
    public override void RunApp()
    {
        windowObject.gameObject.SetActive(true);
        isOpened = true;
        Manager.FocusedApp = this;
        
        windowObject.anchorMin = rectNormalWin.anchorMin;
        windowObject.anchorMax = rectNormalWin.anchorMax;
        windowObject.localPosition = startPlace;
        windowObject.sizeDelta = rectNormalWin.sizeDelta;
        appWindowState = AppWindowState.Normal;
    }

    public override void StopApp()
    {
        windowObject.gameObject.SetActive(false);
        appIconOnDock.OnAppClose();
        isOpened = false;
    }
        
    public void MaximizeWindow()
    {
        _lastState = appWindowState;
        _whereWasTheWindow = windowObject.localPosition;
        
        windowObject.anchorMax = rectMaximizedWin.anchorMax;
        windowObject.anchorMin = rectMaximizedWin.anchorMin;
        windowObject.localPosition = rectMaximizedWin.localPosition;
        windowObject.sizeDelta = new Vector2(0f, 0f);
        appWindowState = AppWindowState.Maximized;
    }

    public void UnmaximizeWindow()
    {
        _lastState = appWindowState;
        windowObject.anchorMax = rectNormalWin.anchorMax;
        windowObject.anchorMin = rectNormalWin.anchorMin;
        windowObject.localPosition = _whereWasTheWindow;
        windowObject.sizeDelta = rectNormalWin.sizeDelta;
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

    protected override void OnAppFocusChanged()
    {
        base.OnAppFocusChanged();
        if (Manager.FocusedApp == this)
            windowObject.transform.SetAsLastSibling();
    }
}
