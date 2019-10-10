using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCompleteChilde : MonoBehaviour
{
    GameObject obj;
    BoxComplete bc;

	// Use this for initialization
	void Start ()
    {
        obj = transform.parent.gameObject;
        bc = obj.GetComponent<BoxComplete>();
        //Debug.LogError(obj + ":" + bc);
	}
	
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            bc.LoadOnTriggerExit2D(other);
            //Debug.LogError("離れました:" +gameObject.name);
        }
    }

}
