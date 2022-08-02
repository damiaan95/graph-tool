using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EdgeBaseState
{
    public abstract void EnterState(EdgeStateManager edge);
    public abstract void UpdateState(EdgeStateManager edge);

}
