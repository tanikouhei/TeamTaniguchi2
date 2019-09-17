using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    GameObject obj;
    BoxManager bm;
    BoxComplete bc;
    Vector3 pos;
    Rigidbody2D rb2d;
    int no = 0;
    int box = 0;
    bool placeUp = false;

	// Use this for initialization
	void Start ()
    {
        obj = GameObject.Find("GameManager");
        bm = obj.GetComponent<BoxManager>();
        bc = GetComponent<BoxComplete>();
        rb2d = GetComponent<Rigidbody2D>();
        no = bm.SetNoCount();
        switch (gameObject.name.Substring(0, 4))
        {
            case "Box1":
                box = 1;
                break;
            case "Box2":
                box = 2;
                break;
            case "Box3":
                box = 3;
                break;
            case "Box4":
                box = 4;
                break;
            case "Box5":
                box = 5;
                break;
        }
    }

    void Update()
    {
        pos = transform.position;
        if(bm.GetPlaceUp())//個別に止めるために
        {
            pos.y += 0.71f;
            transform.position = pos;

            if(no == bm.GetNoCount())//番号が最後のGameObjectまで来たらfalseにして止める
            {
                bm.SetPlaceUp();
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    /*
    void OnTriggerEnter2D(Collider other)
    {
        if(other.gameObject.tag == "Line")
        {
            SetBox();
        }
    }

    public int SetBox()
    {
        return box;
    }
    */

}
