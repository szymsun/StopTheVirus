using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBackend : App
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        appType = AppType.FixedPositionAndScale;
        appWindowState = AppWindowState.Normal;
    }

    public void SwitchBetweenOpenAndClosed()
    {
        if (isOpened)
        {
            gameObject.SetActive(false);
            isOpened = false;
        }
        else
        {
            gameObject.SetActive(true);
            isOpened = true;
        }
    }

    public void ChangeOpenState(bool state)
    {
        isOpened = state;
    }

    protected override void OnAppFocusChanged()
    {
        if (Manager.FocusedApp != this)
        {
            base.OnAppFocusChanged();
            SwitchBetweenOpenAndClosed();
            gameObject.SetActive(false);
        }
    }
}
