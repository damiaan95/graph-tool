using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph<V, E>
{
    private List<Vertex<V, E>> Vertices;

    public Graph()
    {
        this.Vertices = new List<Vertex<V, E>>();
    }

    public void AddVertex(Vertex<V, E> vertex)
    {
        Vertices.Add(vertex);
    }

    public void AddVertex(V data)
    {
        Vertices.Add(new Vertex<V, E>(data));
    }

    public void RemoveVertex(Vertex<V, E> v)
    {
        foreach (KeyValuePair<Vertex<V, E>, Edge<V, E>> u in v.Neighbors)
        {
            DeleteEdge(v, u.Key);
        }
        Vertices.Remove(v);
    }

    public bool AddEdge(Vertex<V, E> v1, Vertex<V, E> v2, Edge<V, E> e)
    {
        bool canAddAsNeighbors1 = v1.AddNeighbor(v2, e);
        bool canAddAsNeighbors2 = v2.AddNeighbor(v1, e);
        if(canAddAsNeighbors1 != canAddAsNeighbors2)
        {
            throw new BrokenGraphException("edge already exists for one vertex but not the other");
        }

        return canAddAsNeighbors1;
    }

    public bool DeleteEdge(Vertex<V, E> v1, Vertex<V, E> v2)
    {
        if(ContainsEdge(v1, v2))
        {
            return v1.RemoveNeighbor(v2) && v2.RemoveNeighbor(v1); //exceptions can be added here.
        }
        return false; // if this point is reached, edge did not exist succesfull.
    }

    public bool ContainsEdge(Vertex<V, E> v1, Vertex<V, E> v2)
    {
        if(v1.HasNeighbor(v2) != v2.HasNeighbor(v1))
        {
            throw new BrokenGraphException("one vertex has other as neighbor but not the reverse");
        }
        return v1.HasNeighbor(v2);
    }

    public bool ContainsVertex(Vertex<V, E> vertex)
    {
        return Vertices.Contains(vertex);
    }
}
