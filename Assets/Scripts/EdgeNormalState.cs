using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeNormalState : EdgeBaseState
{
    public override void EnterState(EdgeStateManager edge)
    {
        //Debug.Log("Edge is in NormalState");
        edge.SetColliderPoints();
    }

    public override void UpdateState(EdgeStateManager edge)
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            edge.SwitchState(edge.InitializationState);
        } else
        {
            edge.SetColliderPoints();
        }
    }
}

