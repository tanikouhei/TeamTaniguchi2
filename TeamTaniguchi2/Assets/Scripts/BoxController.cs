using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    GameObject obj;
    BoxManager bm;
    BoxComplete bc;
    Vector3 pos;
    Vector3 moveTo;
    Rigidbody2D rb2d;
    public int no = 0;
    int boxSize = 0;
    bool placeUp = false;//一個ずつ上昇
    bool stop = false;
    bool move = false;//移動中かどうか
    bool comp = false;//揃ったかどうか
    bool dead = false;//デストロイの判定に使う
    //bool send = false;

    // Use this for initialization
    void Start()
    {
        obj = GameObject.Find("GameManager");
        bm = obj.GetComponent<BoxManager>();
        bc = GetComponent<BoxComplete>();
        rb2d = this.GetComponent<Rigidbody2D>();
        no = bm.SetNoCount();

        switch (gameObject.name.Substring(0, 4))
        {
            case "Box1":
                boxSize = 1;
                break;
            case "Box2":
                boxSize = 2;
                break;
            case "Box3":
                boxSize = 3;
                break;
            case "Box4":
                boxSize = 4;
                break;
            case "Box5":
                boxSize = 5;
                break;
        }
    }

    void Update()
    {        
        if (dead)
        {
            Destroy(gameObject);
        }

        if (bm.GetPlaceUp())//個別に止めるために
        {
            pos.y += 0.71f;
            transform.position = pos;
            stop = false;//動く
            //send = false;//ここで送ったものをリセット
            move = false;//強制的に解除

            if (no == bm.GetNoCount())//番号が最後のGameObjectまで来たらfalseにして止める
            {
                bm.SetPlaceUp();
            }
        }
        else if (move)
        {
            movePosition();
        }
        else
        {
            if (pos == transform.position)
            {
                stop = true;
            }

            if (pos != transform.position)
            {
                stop = false;
            }
            pos = transform.position;
        }

        //if (no == 1 || no == 2)
        {
            //Debug.Log("stop:send: " + stop + send);
        }
        //Debug.Log("Box" + no + "pos : 場所"+ pos + " " +transform.position);
    }
    
    void movePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        moveTo = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));

        pos.x = moveTo.x;//X方向だけ動かしすため
        transform.position = pos;
    }

    public Vector3 posNow()
    {
        return pos;
    } 

    public int SetNo()
    {
        return no;
    }

    public int SetBoxSize()
    {
        return boxSize;
    }

    public bool stopNow()
    {
        return stop;
    }

    public bool compNow()
    {
        return comp;
    }

    public void compTrue()
    {
        comp = true;
    }
    public void deadTrue()
    {
        dead = true;
    }

    public void Die(int a)
    {
        Destroy(gameObject,a);
    }

    public void PointerDown()//クリックされたら
    {
        move = true;
        Debug.Log("クリックされました");
    }

    public void PointerUp()//クリックされたら
    {
        move = false;
        Debug.Log("離しました");
    }
}
/*
    public bool SetSend()
    {
        return send;
    }

    public void sendTrue()
    {
        send = true;
    }

    public void sendFalse()
    {
        send = false;
    }
/*
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Box" || other.gameObject.tag == "Block")
        {
            stop = true;
            Debug.Log("止まっています:" + stop);
        }
    }
    */

/*
 void OnCollisionExit2D(Collision2D other)
 {
     if (other.gameObject.tag == "Box" || other.gameObject.tag == "Block")
     {
         stop = false;
         send = false;
         Debug.Log("ブロックが落ちていますNO" + no + " stop:" + stop + " send:" + send);
     }
 }
/*
void OnTriggerStay2D(Collider2D other)
{
 bc = other.gameObject.GetComponent<BoxComplete>();
 if (other.gameObject.tag == "Line" && stop && !send)
 {
     bc.SetBox(box);
     send = true;
 }
}
void OnTriggerEnter2D(Collider2D other)
{
 bc = other.gameObject.GetComponent<BoxComplete>();
 if (other.gameObject.tag == "Line")
 {
     send = false;
 }
}
*/
