using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex<V,E>
{
    private Dictionary<Vertex<V,E>, Edge<V,E>> neighbors;

    public Dictionary<Vertex<V,E>, Edge<V,E>> Neighbors
    {
        get { return neighbors; }
    }
    private V data;

    public V Data
    {
        get { return data; }
        set { data = value; }
    }

    public Vertex(V data)
    {
        this.data = data;
        this.neighbors = new Dictionary<Vertex<V,E>, Edge<V, E>>();
    }

    public bool AddNeighbor(Vertex<V, E> v, Edge<V, E> edge)
    {
        if(!neighbors.ContainsKey(v))
        {
            neighbors.Add(v, edge);
            return true;
        }
        return false;
    }

    public bool RemoveNeighbor(Vertex<V, E> v)
    {
        return neighbors.Remove(v);
        
    }
    public bool HasNeighbor(Vertex<V, E> v)
    {
        return neighbors.ContainsKey(v);
    } 




}
