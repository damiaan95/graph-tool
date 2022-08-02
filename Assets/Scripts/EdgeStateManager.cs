using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeStateManager : MonoBehaviour
{ 
    EdgeBaseState currentState;
    public EdgeInitializationState InitializationState = new EdgeInitializationState();
    public EdgeNormalState NormalState = new EdgeNormalState();
    public EdgeTrueState TrueState = new EdgeTrueState();

    GameObject[] vertices = new GameObject[2];

    LineRenderer lr;
    EdgeCollider2D edgeCollider;

    public GameObject[] Vertices { get => vertices; set => vertices = value; }

    void Start()
    {
       // Debug.Log("a new edge was spawned");
        currentState = InitializationState;
        currentState.EnterState(this);
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        edgeCollider = this.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EdgeBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public EdgeBaseState GetState()
    {
        return currentState;
    }

    public void SetColliderPoints()
    {
        List<Vector2> points = new List<Vector2>
        {
            transform.InverseTransformPoint(new Vector3(lr.GetPosition(0).x, lr.GetPosition(0).y)),
            transform.InverseTransformPoint(new Vector3(lr.GetPosition(1).x, lr.GetPosition(1).y))
        };
        edgeCollider.SetPoints(points);
    }

    public Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[2];

        lr.GetPositions(positions);
        return positions;
    }

    public void SetPositions(Vector3[] positions)
    {
        lr.SetPositions(positions);
    }

    public float GetWidth()
    {
        return lr.startWidth;
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1)){
            Destroy(gameObject);
        }
    }
}
