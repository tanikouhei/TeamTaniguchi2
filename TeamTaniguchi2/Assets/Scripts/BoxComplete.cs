using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxComplete : MonoBehaviour
{
    BoxController bc;
    int boxSizeCnt = 0;

    public void boxReset()
    {
        boxSizeCnt = 0;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        var rb2d = other.GetComponent<Rigidbody2D>();//相手のrigidbody2Dを取得
        //if(rb2d.IsSleeping())//動いてなければ
        {
            switch (other.gameObject.name.Substring(0, 4))
            {
                case "Box1":
                    boxSizeCnt++;
                    break;
                case "Box2":
                    boxSizeCnt += 2;
                    break;
                case "Box3":
                    boxSizeCnt += 3;
                    break;
                case "Box4":
                    boxSizeCnt += 4;
                    break;
                case "Box5":
                    boxSizeCnt += 5;
                    break;
            }
            Debug.Log(gameObject.name + ":" + boxSizeCnt);
        }
        if (boxSizeCnt == 8)
        {
            Debug.Log("一列揃いました:" + gameObject.name);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        bc = other.gameObject.GetComponent<BoxController>();
        if(boxSizeCnt == 8)
        {
            bc.Die();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //var rb2d = other.GetComponent<Rigidbody2D>();//相手のrigidbody2Dを取得
        //if (rb2d.IsSleeping())//動いてなければ
        if(boxSizeCnt < 0)
        {
            switch (other.gameObject.name.Substring(0, 4))
            {
                case "Box1":
                    boxSizeCnt--;
                    break;
                case "Box2":
                    boxSizeCnt -= 2;
                    break;
                case "Box3":
                    boxSizeCnt -= 3;
                    break;
                case "Box4":
                    boxSizeCnt -= 4;
                    break;
                case "Box5":
                    boxSizeCnt -= 5;
                    break;
            }
        }
    }

}
