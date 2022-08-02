using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VertexStateManager : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    VertexBaseState currentState;
    public VertexNormalState NormalState = new VertexNormalState();
    public VertexEdgeDrawState EdgeDrawState = new VertexEdgeDrawState();
    public VertexConnectingState ConnectingState = new VertexConnectingState();
    public VertexSelectableState SelectableState = new VertexSelectableState();

    [SerializeField] GameObject edgePrefab;
    public Color CurrentColor;
    public EdgeStateManager EmptyEdge;
    private LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentState = EdgeDrawState;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            currentState = SelectableState;
        }
        else
        {
            currentState = NormalState;
        }

        EmptyEdge = Instantiate(edgePrefab,
                                transform.position,
                                Quaternion.identity, transform)
            .GetComponent<EdgeStateManager>();

        CurrentColor = Color.white;
        lr = EmptyEdge.GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, this.transform.position);
        lr.SetPosition(1, this.transform.position);
        EmptyEdge.Vertices[0] = gameObject;
        currentState.EnterState(this);

        Debug.Log(currentState.GetType());
    }

    private void RemoveEdge(EdgeStateManager edge)
    {
        Destroy(edge.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void UpdatePosition(Vector3 pos)
    {
        currentState.DragEvent(this, pos);
    }

    public void SwitchState(VertexBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    internal void SelectVertex()
    {
        currentState.ClickEvent(this);
    }

    public VertexBaseState GetState()
    {
        return currentState;
    }

    public LineRenderer GetLineRenderer()
    {
        return lr;
    }

    public void ResetEmptyEdge()
    {
        EmptyEdge = Instantiate(edgePrefab, transform.position, Quaternion.identity, transform).GetComponent<EdgeStateManager>();
        lr = EmptyEdge.GetComponent<LineRenderer>();
        lr.SetPosition(0, this.transform.position);
        lr.SetPosition(1, this.transform.position);
        EmptyEdge.Vertices[0] = this.gameObject;
    }

    public Action<VertexStateManager> OnDragEvent;
    public void OnDrag(PointerEventData eventData)
    {
        OnDragEvent?.Invoke(this);
    }

    public Action<VertexStateManager> OnRightClickEvent;
    public Action<VertexStateManager> OnLeftClickEvent;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -2) //Right click
        {
            OnRightClickEvent?.Invoke(this);
        }
        else if (eventData.pointerId == -1) //Left Click
        { 
            OnLeftClickEvent?.Invoke(this);
        }

    }

    public void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
