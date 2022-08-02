using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexEdgeDrawState : VertexBaseState
{
    public override void DragEvent(VertexStateManager vertex, Vector3 pos)
    {
        vertex.GetLineRenderer().SetPosition(1, pos);
    }

    public override void EnterState(VertexStateManager vertex)
    {
        //Debug.Log("this vertex now entered its EdgeDrawState");
    }

    public override void UpdateState(VertexStateManager vertex)
    {   
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            vertex.SwitchState(vertex.NormalState);
        }
    }
}
