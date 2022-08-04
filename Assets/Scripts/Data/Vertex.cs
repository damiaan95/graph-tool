using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex<V>
{
    private Dictionary<Vertex<V>, Edge<V>> neighbors;

    public Dictionary<Vertex<V>, Edge<V>> Neighbors
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
        this.neighbors = new Dictionary<Vertex<V>, Edge<V>>();
    }

    public bool AddNeighbor(Vertex<V> v, Edge<V> edge)
    {
        if(!neighbors.ContainsKey(v))
        {
            neighbors.Add(v, edge);
            return true;
        }
        return false;
    }

    public bool RemoveNeighbor(Vertex<V> v)
    {
        return neighbors.Remove(v);
        
    }
    public bool HasNeighbor(Vertex<V> v)
    {
        return neighbors.ContainsKey(v);
    } 




}
