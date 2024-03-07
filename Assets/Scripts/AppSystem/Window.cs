using UnityEngine;

public class Window : MonoBehaviour
{
    public WindowBackend backend;

    private bool _maximized;
    private bool _minimized;

    public void MaximizeSwitch()
    {
        if (_maximized)
        {
            backend.UnmaximizeWindow();
            _maximized = false;
        }
        else
        {
            backend.MaximizeWindow();
            _maximized = true;
        }
    }

    public void MinimizeSwitch()
    {
        if (_minimized)
        {
            backend.UnMinimizeWindow();
            _minimized = false;
        }
        else
        {
            backend.MinimizeWindow();
            _minimized = true;
        }
    }

    public void Close()
    {
        backend.StopApp();
    }

    private void OnMouseDown()
    {
        DesktopManager manager = FindObjectOfType<DesktopManager>();
        if (manager != null)
        {
            manager.FocusedApp = backend;
        }
    }
}
