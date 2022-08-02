using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VertexBaseState
{
    public abstract void EnterState(VertexStateManager vertex);

    public abstract void UpdateState(VertexStateManager vertex);

    public abstract void DragEvent(VertexStateManager vertex, Vector3 pos);

    public abstract void ClickEvent(VertexStateManager vertex);
}
