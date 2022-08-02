using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VertexNormalState : VertexBaseState
{
    public override void EnterState(VertexStateManager vertex)
    {
        vertex.GetLineRenderer().SetPosition(1, vertex.transform.position);
        vertex.GetComponent<Image>().color = Color.white;
    }

    public override void UpdateState(VertexStateManager vertex)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            vertex.SwitchState(vertex.EdgeDrawState);
        }
    }

    public override void DragEvent(VertexStateManager vertex, Vector3 pos)
    {
        LineRenderer lr = vertex.GetLineRenderer();
        vertex.transform.position = pos;
        vertex.EmptyEdge.transform.position = pos;
        lr.SetPosition(0, pos);
        lr.SetPosition(1, pos);
    }
}
