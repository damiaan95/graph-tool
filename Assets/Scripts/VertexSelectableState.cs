using UnityEngine;
using UnityEngine.UI;

public class VertexSelectableState: VertexBaseState
{

    public override void ClickEvent(VertexStateManager vertex)
    {
        if (!vertex.Selected)
        {
            vertex.Selected = true;
            vertex.gameObject.GetComponent<Image>().color = Color.red;
            vertex.CurrentColor = Color.red;
        } else
        {
            vertex.Selected = false;
            vertex.gameObject.GetComponent<Image>().color = Color.white;
            vertex.CurrentColor = Color.white;
        }
    }

    public override void DragEvent(VertexStateManager vertex, Vector3 pos)
    {
        //vertex.GetGhost().transform.position = pos;
        //DrawTool.CreateGhostVertex(Input.mousePosition);
        //vertex.CreateGhost(pos)
        //GameObject ghostVertex = Instantiate(vertex.GhostVertexPrefab, Input.mousePosition, Quaternion.identity, vertex.transform.parent);
    }

    public override void EnterState(VertexStateManager vertex)
    {
        Debug.Log("this vertex now entered its SelectableState");
        vertex.CreateGhost(vertex.transform.position);
    }

    public override void UpdateState(VertexStateManager vertex)
    {
        if(!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)))
        {
            if (!vertex.GetGhost().Selected)
            {
                vertex.DestroyGhost();
            }
            vertex.SwitchState(vertex.NormalState);
        }
    }

    internal override void BeginDragEvent(VertexStateManager vertex, Vector3 pos)
    {
        //Debug.Log("beginning drag");
        //vertex.CreateGhost(pos);
        //GhostVertex ghostVertex = vertex.GetGhost();
        //Debug.Log(ghostVertex.gameObject.name);
        //ghostVertex.CanvasGroup.blocksRaycasts = false;
    }

    internal override void EndDragEvent(VertexStateManager vertex, Vector3 pos)
    {
        //Debug.Log("dragging ended");
        //vertex.GetGhost().CanvasGroup.blocksRaycasts = true;
    }
}