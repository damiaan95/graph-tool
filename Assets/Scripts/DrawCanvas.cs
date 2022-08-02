using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawCanvas : MonoBehaviour, IPointerClickHandler
{
    public Action OnDrawCanvasLeftClickEvent;
    public Action OnPenCanvasRightClickEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1) //Left Click
        {
            
            OnDrawCanvasLeftClickEvent?.Invoke();
        } 
        else if (eventData.pointerId == -2) //Right Click
        {
            OnPenCanvasRightClickEvent?.Invoke();
        }
    }


}
