public class Edge<V, E>
{
    private int weight;
    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    private E data;
    public E Data
    {
        get { return data; }
    }

    private Vertex<V, E>[] vertices;

    public Vertex<V, E>[] Vertices
    {
        get { return vertices; }
    }

    public Edge(E data, Vertex<V, E> v1, Vertex<V, E> v2)
    {
        this.data = data;
        this.vertices = new Vertex<V, E>[] { v1, v2 };
    }
}