using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    [SerializeField] private GameObject[] selectedVertices = new GameObject[2];

    internal static Graph<VertexStateManager> G;

    private void Awake()
    {
        G = new Graph<VertexStateManager>();
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

        G.AddVertex(vertex);
    }

    private void RemoveVertex(VertexStateManager vertex)
    {
        vertex.SelfDestruct();
        G.RemoveVertex(vertex);
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

    public void RunDijkstra()
    {
        
        if(selectedVertices[0] != null && selectedVertices[1] != null)
        {
            List<VertexStateManager> path = G.FindShortestPath(selectedVertices[0].GetComponent<VertexStateManager>(), 
                                                               selectedVertices[1].GetComponent<VertexStateManager>());

            for(int i=0; i<path.Count - 1; i++)
            {
                EdgeStateManager edge = path[i].GetEdge(path[i+1]);
                edge.gameObject.GetComponent<LineRenderer>().endColor = Color.blue;
            }
        } else
        {
            Debug.Log("no vertices to look for path");
        }
        
    }
}