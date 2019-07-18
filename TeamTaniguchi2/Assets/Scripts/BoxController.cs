using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    GameObject gm;
    BoxManager bm;
    Vector3 pos;
    int no = 0;
    bool placeUp = false;

	// Use this for initialization
	void Start ()
    {
        gm = GameObject.Find("GameManager");
        bm = gm.GetComponent<BoxManager>();
        no = bm.SetNoCount();
        pos = transform.position;
    }

    void Update()
    {
        if (bm.GetPlaceUp())//個別に止めるために
        {
            pos.y += 0.13f;
            transform.position = pos;

            if(no == bm.GetNoCount())//番号が最後のGameObjectまで来たらfalseにして止める
            {
                bm.SetPlaceUp();
            }
        }
    }
}
