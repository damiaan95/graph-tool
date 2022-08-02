using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph<T>
{
    private List<Vertex<T>> V;

    public Graph()
    {
        this.V = new List<Vertex<T>>();
    }

    public void AddVertex(Vertex<T> vertex)
    {
        V.Add(vertex);
    }

    public void AddVertex(T data, LinkedList<Vertex<T>> neighbors)
    {
        V.Add(new Vertex<T>(data, neighbors));
    }

    public void RemoveVertex(Vertex<T> v)
    {
        foreach (Vertex<T> u in v.Neighbors)
        {
            DeleteEdge(v, u);
        }
        V.Remove(v);
    }

    public bool AddEdge(Vertex<T> v1, Vertex<T> v2)
    {
        bool canAddAsNeighbors = v1.AddNeighbor(v2);
        canAddAsNeighbors = v2.AddNeighbor(v1);

        return canAddAsNeighbors;
    }

    public bool DeleteEdge(Vertex<T> v1, Vertex<T> v2)
    {
        if(ContainsEdge(v1, v2))
        {
            if(v1.RemoveNeighbor(v2))
            {
                return v2.RemoveNeighbor(v1); // somehow need to add exception here if it turns out to be false.
            } else
            {
                return false;// Can add exceptions here
            }
        }
        return false; // if this point is reached, removing was nog succesfull.
    }

    public bool ContainsEdge(Vertex<T> v1, Vertex<T> v2)
    {
        return v1.HasNeighbor(v2) && v2.HasNeighbor(v1);
    }
    public bool ContainsVertex(Vertex<T> vertex)
    {
        return V.Contains(vertex);
    }
}
