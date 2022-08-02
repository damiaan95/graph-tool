using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawTool : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [Header("Draw Canvas")]
    [SerializeField] private DrawCanvas drawCanvas;

    [Header("Vertices")]
    [SerializeField] private GameObject vertexPrefab;
    [SerializeField] Transform vertexParent;

    [Header("Edges")]
    [SerializeField] private GameObject edgePrefab;

    //Graph<VertexStateManager> G;

    private void Awake()
    {
        //G = new Graph<VertexStateManager>();
        drawCanvas.OnDrawCanvasLeftClickEvent += AddVertex;
    }

    private void AddVertex()
    {

        VertexStateManager vertex = Instantiate(vertexPrefab,
                                        GetMousePosition(),
                                        Quaternion.identity, transform
                                        )
            .GetComponent<VertexStateManager>();
        
        vertex.OnDragEvent += Drag;
        vertex.OnRightClickEvent += RemoveVertex;
        vertex.OnLeftClickEvent += Select;
        //Vertex<VertexStateManager> v = new Vertex<VertexStateManager>(vertex, new LinkedList<Vertex<VertexStateManager>>()); 
        //G.AddVertex(v);
    }

    private void RemoveVertex(VertexStateManager vertex)
    {
        vertex.SelfDestruct();
    }

    public void AddEdge(GameObject v1, GameObject v2)
    {
        EdgeStateManager edge = Instantiate(edgePrefab, v1.transform.position, Quaternion.identity, transform).GetComponent<EdgeStateManager>();
        edge.Vertices = new GameObject[] {v1,v2};
        edge.SwitchState(edge.TrueState);
    }

    private void Drag(VertexStateManager vertex)
    {
        vertex.UpdatePosition(GetMousePosition());
    }

    private void Select(VertexStateManager vertex)
    {
        vertex.SelectVertex();
    }

    private Vector3 GetMousePosition()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }
}