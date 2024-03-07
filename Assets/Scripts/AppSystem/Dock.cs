using UnityEngine.UI;

public class Dock : App
{
    public App[] appsOnDock;
    public Image focusedImg;
    
    
    protected override void Start()
    {
        base.Start();
        isVisibleOnDock = false;
    }

    protected override void OnAppFocusChanged()
    {
        base.OnAppFocusChanged();
        if (Manager.FocusedApp == this)
        {
            HideOverlay();
        }
        else
        {
            HideOverlay();
            ShowFocusedAppOverlay();
        }
    }

    public void ShowFocusedAppOverlay()
    {
        var windowBackend = Manager.FocusedApp.GetComponent<WindowBackend>();
        if (windowBackend == null) return;
        focusedImg.gameObject.SetActive(true);
        focusedImg.rectTransform.localPosition = windowBackend.appIconOnDock.GetLocalPosition().localPosition;
    }
        

    public void HideOverlay()
    {
        focusedImg.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        Manager.FocusedApp = this;
    }
}
