public class Edge<V>
{
    private int weight = 1;
    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    private Vertex<V>[] vertices;

    public Vertex<V>[] Vertices
    {
        get { return vertices; }
    }

    public Edge(Vertex<V> v1, Vertex<V> v2)
    {
        this.vertices = new Vertex<V>[] { v1, v2 };
    }
}