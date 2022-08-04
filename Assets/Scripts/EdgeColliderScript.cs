using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeStateManager))]
public class EdgeColliderScript : MonoBehaviour
{
    EdgeStateManager edge;

    void Start()
    {
        edge = GetComponent<EdgeStateManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(edge.GetState() == edge.InitializationState) {
            if (collision.gameObject.transform != transform.parent)
            {
                edge.Vertices[1] = collision.gameObject.GetComponent<VertexStateManager>();
                //Debug.Log("hit something");
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (edge.GetState() == edge.InitializationState)
        {
            if (edge.Vertices[1] == collision.GetComponent<VertexStateManager>())
            {
                edge.Vertices[1] = null;
            }
        }
    }
    /*EdgeStateManager edgeStateMan;
    List<Vector2> collisionPoints = new List<Vector2>();
    PolygonCollider2D polyCollider;
    //EdgeCollider2D edgeCollider;
    // Start is called before the first frame update
    void Start()
    {
        edgeStateMan = this.GetComponent<EdgeStateManager>();
        polyCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        collisionPoints = CalculateColliderPoints();
    }

    void UpdateColliderLength()
    {
        //Vector3 v1 = this.GetComponentInParent<LineRenderer>().GetPosition(0);
        //Vector3 v2 = this.GetComponentInParent<LineRenderer>().GetPosition(1);

        //edgeCollider.points = new Vector2[] { new Vector2(v1.x, v1.y), new Vector2(v2.x, v2.y) };
    }

    List<Vector2> CalculateColliderPoints()
    {
        Vector3[] positions = edgeStateMan.GetPositions();
        float width = edgeStateMan.GetWidth();

        float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
        float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
        float deltaY = (width / 2f) * (1 / Mathf.Pow(m * m + 1, 0.5f));

        Vector3[] offsets = new Vector3[2];
        offsets[0] = new Vector3(-deltaX, deltaY);
        offsets[1] = new Vector3(deltaX,-deltaY);

        List<Vector2> collisionPositions = new List<Vector2>
        {
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1]
        };

        return collisionPositions;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        if(collisionPoints != null)
        {
            collisionPoints.ForEach(p => Gizmos.DrawSphere(p, 0.1f));
        }
    }*/
}
