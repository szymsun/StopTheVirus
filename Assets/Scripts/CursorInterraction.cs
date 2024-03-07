using System.Collections;
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
    
    [SerializeField]  GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;
    [SerializeField] RectTransform canvasRect;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)) CursorClick();
        if (Input.GetKeyUp(KeyCode.Mouse0)) CursorUnclick();
    }

    private GameObject _temp;
    private WindowTopBar _win;
    
    void CursorClick()
    {
        if (_isHoldingWindow)
        {
            cursorTracker.localPosition = Input.mousePosition;
        }
        else
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the game object
            m_PointerEventData.position = Input.mousePosition;
 
            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();
 
            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            if (results[0].gameObject.CompareTag(windowBarMask))
            {
                if (_temp != null)
                {
                    cursorTracker.localPosition = Input.mousePosition;
                    _win = results[0].gameObject.GetComponent<WindowTopBar>();
                    _win.window.transform.SetParent(_temp.transform);
                    _isHoldingWindow = true;
                }
                else
                {
                    cursorTracker.localPosition = Input.mousePosition;
                    _temp = cursorTracker.gameObject;
                    _win = results[0].gameObject.GetComponent<WindowTopBar>();
                    _win.window.transform.SetParent(_temp.transform);
                    _isHoldingWindow = true;
                }
            
            
            
            }
        }
        
        
    }

    void CursorUnclick()
    {
        _temp = null;
        _isHoldingWindow = false;
        _win.window.gameObject.transform.SetParent(windowRoot);
    }
}
