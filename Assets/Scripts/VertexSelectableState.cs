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
        //throw new System.NotImplementedException();
    }

    public override void EnterState(VertexStateManager vertex)
    {
        Debug.Log("this vertex now entered its SelectableState");
    }

    public override void UpdateState(VertexStateManager vertex)
    {
        if(!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)))
        {
            vertex.SwitchState(vertex.NormalState);
        }
    }
}