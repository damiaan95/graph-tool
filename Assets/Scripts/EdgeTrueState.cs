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

        /*if(Input.GetMouseButtonDown(1))
        {
            edge.SelfDestruct();
        }*/
    }
}
