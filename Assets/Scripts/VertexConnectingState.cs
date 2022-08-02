using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexConnectingState : VertexBaseState
{
    public override void ClickEvent(VertexStateManager vertex)
    {
        throw new System.NotImplementedException();
    }

    public override void DragEvent(VertexStateManager vertex, Vector3 pos)
    {
        //throw new System.NotImplementedException();
    }

    public override void EnterState(VertexStateManager vertex)
    {
        Debug.Log("I am now in connecting state! ", vertex);
    }

    public override void UpdateState(VertexStateManager vertex)
    {
        throw new System.NotImplementedException();
    }
}
