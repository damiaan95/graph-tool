using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra<V>
{
    public static List<Vertex<V>> Run(Vertex<V> start, Vertex<V> goal)
    {
        Dictionary<Vertex<V>, List<Vertex<V>>> paths = new Dictionary<Vertex<V>, List<Vertex<V>>>();
        Dictionary<Vertex<V>, int> distances = new Dictionary<Vertex<V>, int>();

        paths.Add(start, new List<Vertex<V>>() { start });
        distances.Add(start, 0);

        while (!paths.ContainsKey(goal))
        {
            Vertex<V> nextVertex = null;
            Vertex<V> lastVertex = null;

            int dist = int.MaxValue;

            foreach (KeyValuePair<Vertex<V>, int> p in distances)
            {
                foreach (KeyValuePair<Vertex<V>, Edge<V>> kvp in p.Key.Neighbors)//edge is used here to get the weight. If used for nothing else, we can replace neighbors dictionary to store only a number.
                {
                    if (!distances.ContainsKey(kvp.Key) && p.Value + kvp.Value.Weight <= dist)
                    {
                        nextVertex = kvp.Key;
                        lastVertex = p.Key;
                        dist = p.Value + kvp.Value.Weight;
                    }
                }
            }
            if (nextVertex != null)
            {
                distances[nextVertex] = dist;
                paths[nextVertex] = new List<Vertex<V>>(paths[lastVertex]);
                paths[nextVertex].Add(nextVertex);
            }
            else
            {
                Debug.Log("the next vertex is null");
                return new List<Vertex<V>>(); // in this case, the goal cannot be reached.
            }
        }
        return paths[goal];
    }
}
