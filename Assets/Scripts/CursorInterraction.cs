using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorInterraction : MonoBehaviour
{
    public string windowBarMask;

    public Transform windowRoot;

    private bool _isHoldingWindow;
    
    public RectTransform cursorTracker;
    
    [SerializeField] private GraphicRaycaster mouseRaycaster;
    private PointerEventData _mousePointerEventData;
    [SerializeField] private EventSystem mouseEventSystem;
    
    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)) CursorClick();
        if (Input.GetKeyUp(KeyCode.Mouse0)) CursorUnclick();
    }

    private GameObject _temp;
    private WindowElement _win;

    private void CursorClick()
    {
        if (_isHoldingWindow)
            cursorTracker.localPosition = Input.mousePosition;
        else
        {
            _mousePointerEventData = new PointerEventData(mouseEventSystem);
            _mousePointerEventData.position = Input.mousePosition;
            
            List<RaycastResult> results = new List<RaycastResult>();
            
            mouseRaycaster.Raycast(_mousePointerEventData, results);

            try

            {
                if (results[0].gameObject.CompareTag(windowBarMask))
                {
                    if (_temp != null)
                    {
                        cursorTracker.localPosition = Input.mousePosition;
                        _win = results[0].gameObject.GetComponent<WindowElement>();

                        if (_win.window.backend.appWindowState == AppWindowState.Maximized)
                        {
                            _win.window.backend.UnmaximizeWindow();
                            _win.window.transform.SetParent(_temp.transform);
                            _isHoldingWindow = true;
                        }
                        else
                        {
                            _win.window.transform.SetParent(_temp.transform);
                            _isHoldingWindow = true;
                        }

                    }
                    else
                    {
                        cursorTracker.localPosition = Input.mousePosition;
                        _temp = cursorTracker.gameObject;
                        _win = results[0].gameObject.GetComponent<WindowElement>();

                        if (_win.window.backend.appWindowState == AppWindowState.Maximized)
                            _win.window.backend.UnmaximizeWindow();

                        _win.window.gameObject.transform.SetParent(_temp.transform);
                        _isHoldingWindow = true;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }
        }
        
        
    }

    private void CursorUnclick()
    {
        if (_temp != null)
        {
            _temp = null;
            _isHoldingWindow = false;
            _win.window.gameObject.transform.SetParent(windowRoot);
        }
    }
}
