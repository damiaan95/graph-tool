using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex<T>
{
    private LinkedList<Vertex<T>> neighbors;

    public LinkedList<Vertex<T>> Neighbors
    {
        get { return neighbors; }
    }
    private T data;

    public T Data
    {
        get { return data; }
        set { data = value; }
    }

    public Vertex(T data, LinkedList<Vertex<T>> neighbors)
    {
        this.data = data;
        this.neighbors = neighbors;
    }

    public bool AddNeighbor(Vertex<T> v)
    {
        if(!neighbors.Contains(v))
        {
            neighbors.AddLast(v);
            return true;
        }
        return false;
    }

    public bool RemoveNeighbor(Vertex<T> v)
    {
        return neighbors.Remove(v);
        
    }
    public bool HasNeighbor(Vertex<T> v)
    {
        return neighbors.Contains(v);
    } 




}
