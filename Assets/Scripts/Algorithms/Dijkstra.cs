using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra<V,E>
{
    public static List<Edge<V, E>> Run(Graph<V, E> graph, Vertex<V, E> start, Vertex<V, E> goal)
    {
        Dictionary<Vertex<V, E>, List<Edge<V,E>>> paths = new Dictionary<Vertex<V, E>, List<Edge<V,E>>>();
        Dictionary<Vertex<V, E>, int> distances = new Dictionary<Vertex<V, E>, int>();

        paths.Add(start, new List<Edge<V, E>>());
        distances.Add(start, 0);

        while (!distances.ContainsKey(goal))
        {
            Vertex<V, E> nextVertex = null;
            Edge<V, E> nextEdge = null;
            Vertex<V, E> lastVertex = null;
            int dist = int.MaxValue;
            foreach (KeyValuePair<Vertex<V, E>, int> p in distances)
            {
                foreach (KeyValuePair<Vertex<V, E>, Edge<V, E>> kvp in p.Key.Neighbors)
                {
                    if (!distances.ContainsKey(kvp.Key) && p.Value + kvp.Value.Weight <= dist)
                    {
                        nextVertex = kvp.Key;
                        nextEdge = kvp.Value;
                        lastVertex = p.Key;
                        dist = p.Value + kvp.Value.Weight;
                    }
                }
            }
            if (nextVertex != null)
            {
                distances[nextVertex] = dist;
                paths[nextVertex] = new List<Edge<V, E>>(paths[lastVertex]);
                paths[nextVertex].Add(nextEdge);
            }
            else
            {
                return new List<Edge<V, E>>(); // in this case, the goal cannot be reached.
            }
        }
        return paths[goal];
    }
}
