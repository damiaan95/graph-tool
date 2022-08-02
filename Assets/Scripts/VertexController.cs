using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VertexController : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    public EdgeController edge;
    public int index;

    public Action<VertexController> OnDragEvent;
    public void OnDrag(PointerEventData eventData)
    {
        OnDragEvent?.Invoke(this);
    }


    public Action<VertexController> OnRightClickEvent;
    public Action<VertexController> OnLeftClickEvent;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerId == -2) //Right click
        {
            OnRightClickEvent?.Invoke(this);
        }
        else if (eventData.pointerId == -1) //Left Click
        {
            OnLeftClickEvent?.Invoke(this);
        }
        
    }

    public void SetEdge(EdgeController edge)
    {
        this.edge = edge;
    }
}
