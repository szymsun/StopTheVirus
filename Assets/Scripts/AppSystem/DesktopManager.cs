using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DesktopManager : MonoBehaviour
{
    public App[] activeApps;
    public Dock dock;

    public UnityEvent appFocusChangeEvent;
    
    public App FocusedApp
    {
        get => _focusedApp;
        set
        {
            if (value != null && _focusedApp != value)
            {
                appFocusChangeEvent.Invoke();
                
            }

            _focusedApp = value;
            
            
        }
    }

    private App _focusedApp;

    void Start()
    {
        FocusedApp = dock;
    }
        
    public void ChangeFocusedApp(App app)
    {
        FocusedApp = app;
    }
}
