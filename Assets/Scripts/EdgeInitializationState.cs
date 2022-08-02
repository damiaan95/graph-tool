using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeInitializationState : EdgeBaseState
{
    public override void EnterState(EdgeStateManager edge)
    {
        //Debug.Log("This is the Edge Initialization State!");
    }

    public override void UpdateState(EdgeStateManager edge)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            /*if (edge.Vertices[1] != null)
            {
                edge.SwitchState(edge.TrueState);
            }*/
            edge.Vertices[1] = null;
            edge.SwitchState(edge.NormalState);
        } else if(!Input.GetMouseButton(0) && edge.Vertices[1] != null)
        {
            edge.SwitchState(edge.TrueState);
        } else
        {
            edge.SetColliderPoints();
        }

        if (!Input.GetMouseButton(0))
        {
            edge.GetComponent<LineRenderer>().SetPosition(1, edge.Vertices[0].transform.position);
            edge.SetColliderPoints();
        }
        
    }
}
