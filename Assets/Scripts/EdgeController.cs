using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeController : MonoBehaviour
{
    private LineRenderer lr;
    private List<VertexController> vertices;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;
        vertices = new List<VertexController>();
    }

    public void AddVertex(VertexController vertex)
    {
        vertex.index = vertices.Count;
        vertex.SetEdge(this);
        lr.positionCount++;
        vertices.Add(vertex);
    }
    public void SplitVerticesAtIndex(int index,
                                     out List<VertexController> beforeVertices,
                                     out List<VertexController> afterVertices)
    {
        List<VertexController> before = new List<VertexController>();
        List<VertexController> after = new List<VertexController>();

        int i = 0;
        for(; i< index; i++)
        {
            before.Add(vertices[i]);
        }
        i++;
        for(; i < vertices.Count; i++)
        {
            after.Add(vertices[i]);
        }

        beforeVertices = before;
        afterVertices = after;
    }

    private void LateUpdate()
    {
        if (vertices.Count >= 2)
        {
            for(int i = 0; i < vertices.Count; i++)
            {
                lr.SetPosition(i, vertices[i].transform.position);
            }
        }
    }
}
