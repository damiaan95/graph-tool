using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GhostVertex : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler, IDropHandler
{

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private VertexStateManager vertex;
    public VertexStateManager Vertex
    {
        get => vertex; set => vertex = value;
    }

    public bool Selected;

    public CanvasGroup CanvasGroup
    {
        get => canvasGroup;
    }
 
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin dragging ghost");
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //canvasGroup.blocksRaycasts = false;
        //Debug.Log("dragging");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag of Ghost");
        //canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("something was dropped on me: " + eventData.pointerDrag.name);
        Destroy(gameObject);
    }
}
