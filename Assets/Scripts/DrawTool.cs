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
   // [SerializeField] private GameObject[] selectedVertices = new GameObject[2];

    [Header("Boxes")]
    [SerializeField] private GameObject startBoxPrefab;
    [SerializeField] private GameObject goalBoxPrefab;

    private DropScript startBox;
    private DropScript goalBox;

    internal static Graph<VertexStateManager> G;

    private void Awake()
    {
        G = new Graph<VertexStateManager>();
        drawCanvas.OnDrawCanvasLeftClickEvent += AddVertex;

        startBox = startBoxPrefab.GetComponent<DropScript>();
        goalBox = goalBoxPrefab.GetComponent<DropScript>();
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
        vertex.OnBeginDragEvent += BeginDrag;
        //vertex.OnEndDragEvent += EndDrag;

        G.AddVertex(vertex);
    }

   /* private void EndDrag(VertexStateManager vertex)
    {
        vertex.EndDrag();
    }*/

    private void RemoveVertex(VertexStateManager vertex)
    {
        vertex.SelfDestruct();
        G.RemoveVertex(vertex);
    }

    private void Drag(VertexStateManager vertex)
    {
        vertex.UpdatePosition(GetMousePosition());
    }

    private void BeginDrag(VertexStateManager vertex)
    {
        vertex.BeginDrag(GetMousePosition());
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
        
        if(startBox.HasVertex() && goalBox.HasVertex())
        {
            List<VertexStateManager> path = G.FindShortestPath(startBox.GhostVertex.Vertex, 
                                                               goalBox.GhostVertex.Vertex);

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