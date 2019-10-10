using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControllerChild : MonoBehaviour
{
    GameObject obj;
    BoxController bc;

    // Use this for initialization
    void Start()
    {
        obj = transform.parent.gameObject;
        bc = obj.GetComponent<BoxController>();
        Debug.Log(bc);
    }  
     
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box" || other.gameObject.tag == "BoxHit")
        {
            bc.LoadOnTriggerEnter2D(other, gameObject.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box" || other.gameObject.tag == "BoxHit")
        {
            bc.LoadOnTriggerExit2D(other, gameObject.name);
        }
    }
}
