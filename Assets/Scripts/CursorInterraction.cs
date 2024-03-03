using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorInterraction : MonoBehaviour
{
    [SerializeField]  GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;
    [SerializeField] RectTransform canvasRect;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) CursorClick();
    }
    
    
    void CursorClick()
    {
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the game object
        m_PointerEventData.position = Input.mousePosition;
 
        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();
 
        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);
        Debug.Log(results[0]);
        
    }
}
