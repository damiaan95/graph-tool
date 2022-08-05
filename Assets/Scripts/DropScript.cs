using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropScript : MonoBehaviour, IDropHandler
{
    private GhostVertex selectedVertex;
    public GhostVertex GhostVertex
    {
        get => selectedVertex;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropped onto " + gameObject.name);
        if(eventData.pointerDrag != null)
        {
            if(selectedVertex != null)
            {
                Destroy(selectedVertex.gameObject);
            }
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            selectedVertex = eventData.pointerDrag.GetComponent<GhostVertex>(); //need exception handling here.
            selectedVertex.Selected = true;
        }
    }

    public bool HasVertex()
    {
        return selectedVertex != null;
    }
}
