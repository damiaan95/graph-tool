using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeTrueState : EdgeBaseState
{
    public override void EnterState(EdgeStateManager edge)
    {
        edge.SetPositions(new Vector3[] { edge.Vertices[0].transform.position, edge.Vertices[1].transform.position });
        edge.SetColliderPoints();
        edge.GetComponentInParent<VertexStateManager>()
            .ResetEmptyEdge();
        edge.Vertices[0].AddEdge(edge.Vertices[1], edge);
        edge.Vertices[1].AddEdge(edge.Vertices[0], edge);
        DrawTool.G.AddEdge(edge.Vertices[0], edge.Vertices[1]);
    }

    public override void UpdateState(EdgeStateManager edge)
    {
        if (edge.Vertices[1].gameObject == null)
        {
            edge.SelfDestruct();
        }
        else
        {
            edge.SetPositions(new Vector3[] { edge.Vertices[0].transform.position, edge.Vertices[1].transform.position });
            edge.SetColliderPoints();
        }
    }
}
