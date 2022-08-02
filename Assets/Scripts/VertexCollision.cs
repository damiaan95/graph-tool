using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VertexCollision : MonoBehaviour
{
    [SerializeField] GameObject edgePrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.tag == "Edge") { }
        //EdgeStateManager edge = (EdgeStateManager)collision.gameObject.GetComponent<EdgeStateManager>();
        //Debug.Log("Collision detected");
        if(!collision.gameObject.transform.IsChildOf(transform) /*&& edge.GetState() == edge.InitializationState*/)
        {
            //Debug.Log("I was touched! ", this);
            //GameObject g = collision.gameObject;
            GetComponent<Image>().color = Color.green;
            //edge.Vertices[1] = this.GetComponent<VertexStateManager>();
            //GetComponent<VertexStateManager>().SwitchState(GetComponent<VertexStateManager>().ConnectingState);
            /*if(Input.GetMouseButtonUp(0))
            {
                Debug.Log("doing somehting");
                DrawTool dt = this.GetComponentInParent<DrawTool>();
                VertexStateManager v1 = this.GetComponent<VertexStateManager>();
                VertexStateManager v2 = collision.GetComponentInParent<VertexStateManager>();
                dt.AddEdge(v1, v2);
            }*/
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //EdgeStateManager edge = (EdgeStateManager)collision.GetComponent<EdgeStateManager>();
        if (!collision.transform.IsChildOf(transform))
        {
            //Debug.Log("I was touched! ", this);

            GetComponent<Image>().color = Color.white;
            //edge.Vertices[1] = null;
        }
    }
}
