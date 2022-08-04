using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph<V>
{
    private List<Vertex<V>> Vertices;
    private Dictionary<V, Vertex<V>> DataDictionary;

    public Graph()
    {
        this.Vertices = new List<Vertex<V>>();
        this.DataDictionary = new Dictionary<V, Vertex<V>>();
    }


    //to be used internally
    public void AddVertex(Vertex<V> vertex)
    {
        Vertices.Add(vertex);
    }

    //to be used by frontend
    public void AddVertex(V data)
    {
        Vertex<V> v = new Vertex<V>(data);
        Vertices.Add(v);
        DataDictionary.Add(data, v);//new
    }

    //to be used internally
    public void RemoveVertex(Vertex<V> v)
    {
        foreach (KeyValuePair<Vertex<V>, Edge<V>> u in v.Neighbors)
        {
            DeleteEdge(v, u.Key);
        }
        Vertices.Remove(v);
        DataDictionary.Remove(v.Data);//new
        //still need to clear memory. Find out how.
    }

    //to be used by frontend
    public void RemoveVertex(V v)
    {
        RemoveVertex(DataDictionary[v]);
    }

    //to be used internally
    public bool AddEdge(Vertex<V> v1, Vertex<V> v2)
    {
        Edge<V> e = new Edge<V>(v1, v2);
        bool canAddAsNeighbors1 = v1.AddNeighbor(v2, e);
        bool canAddAsNeighbors2 = v2.AddNeighbor(v1, e);
        if(canAddAsNeighbors1 != canAddAsNeighbors2)
        {
            throw new BrokenGraphException("edge already exists for one vertex but not the other");
        }
        return canAddAsNeighbors1;
    }

    //to be used by frontend
    public bool AddEdge(V v1, V v2)
    {
        return AddEdge(DataDictionary[v1], DataDictionary[v2]);
    }


    public bool DeleteEdge(Vertex<V> v1, Vertex<V> v2)
    {
        if(ContainsEdge(v1, v2))
        {
            return v1.RemoveNeighbor(v2) && v2.RemoveNeighbor(v1); //exceptions can be added here.
        }
        return false; // if this point is reached, edge did not exist succesfull.
    }

    public bool ContainsEdge(Vertex<V> v1, Vertex<V> v2)
    {
        if(v1.HasNeighbor(v2) != v2.HasNeighbor(v1))
        {
            throw new BrokenGraphException("one vertex has other as neighbor but not the reverse");
        }
        return v1.HasNeighbor(v2);
    }

    public bool ContainsVertex(Vertex<V> vertex)
    {
        return Vertices.Contains(vertex);
    }

    public List<V> FindShortestPath(V v1, V v2)
    {
        List<Vertex<V>> path = Dijkstra<V>.Run(DataDictionary[v1], DataDictionary[v2]); //checks need to be made to check if vertices exist in Dictionary!
        List<V> dataPath = new List<V>();
        foreach(Vertex<V> v in path)
        {
            dataPath.Add(v.Data);
        }
        return dataPath;
    }
}
