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
    const float wallLeft = -2.45f;//左の壁
    float wallRight = 0.0f;//右の壁 こっちはボックスの大きさによって変わる
    float boxLeft = -10.0f;
    float boxRight = 10.0f;
    bool stop = false;
    bool move = false;//移動中かどうか
    bool comp = false;//揃ったかどうか

    // Use this for initialization
    void Start()
    {
        obj = GameObject.Find("GameManager");
        bm = obj.GetComponent<BoxManager>();
        bc = GetComponent<BoxComplete>();
        rb2d = this.GetComponent<Rigidbody2D>();
        no = bm.SetNoCount();

        switch (gameObject.name.Substring(0, 7))
        {
            case "Box1":
                boxSize = 1;
                wallRight = 2.5f;
                break;
            case "Box2":
                boxSize = 2;
                wallRight = 1.8f;
                break;
            case "Box3":
                boxSize = 3;
                wallRight = 1.1f;
                break;
            case "Box4":
                boxSize = 4;
                wallRight = 0.4f;
                break;
            case "Box5":
                boxSize = 5;
                wallRight = -0.35f;
                break;
            case "BoxHit1":
                boxSize = 1;
                wallRight = 2.5f;
                break;
            case "BoxHit2":
                boxSize = 2;
                wallRight = 1.8f;
                break;
            case "BoxHit3":
                boxSize = 3;
                wallRight = 1.1f;
                break;
            case "BoxHit4":
                boxSize = 4;
                wallRight = 0.4f;
                break;
            case "BoxHit5":
                boxSize = 5;
                wallRight = -0.35f;
                break;
        }
    }

    void Update()
    {
        if(move)
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
    }
    
    void movePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        moveTo = Camera.main.ScreenToWorldPoint(mousePos);
        //Debug.Log(mousePos);
        //sDebug.Log(Camera.main.ScreenToWorldPoint(mousePos));
        if (moveTo.x >= wallLeft && moveTo.x <= wallRight &&
            moveTo.x >= boxLeft &&moveTo.x <= boxRight)
        {
            pos.x = moveTo.x;//X方向だけ動かしすため
        }
        transform.position = pos;
    }

    void fixedPosition()//固定position
    {
        if(pos.x < -2.14f)
        {
            pos.x = -2.47f;
        }
        else if(pos.x < -1.4f)
        {
            pos.x = -1.77f;
        }
        else if(pos.x < -0.7f)
        {
            pos.x = -1.05f;
        }
        else if(pos.x <= 0.0f)
        {
            pos.x = -0.33f;
        }
        else if(pos.x <= 0.74f)
        {
            pos.x = 0.37f;
        }
        else if (pos.x <= 1.45f)
        {
            pos.x = 1.08f;
        }
        else if(pos.x < 2.15f)
        {
            pos.x = 1.8f;
        }
        else if (pos.x < 2.8f)
        {
            pos.x = 2.49f;
        }
        transform.position = pos;
        //Debug.Log("位置を変更しています");
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

    public void compFalse()
    {
        comp = false;
    }    
    
    public void placeUp()
    {
        pos.y += 0.71f;
        transform.position = pos;
        stop = false;//動く
        move = false;//強制的に解除
        //Debug.Log("呼ばれました" + no);
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

    public void PointerUp()//離したら
    {
        fixedPosition();
        move = false;
        Debug.Log("離しました");
    }

    public void LoadOnTriggerEnter2D(Collider2D other,string s)
    {
        if (move)
        {
            switch (s)
            {
                case "LeftHit":
                    boxLeft = pos.x;
                    Debug.LogWarning("呼ばれました:" + boxLeft);
                    break;
                case "RightHit":
                    boxRight = pos.x;
                    Debug.LogWarning("呼ばれました:" + boxRight);
                    break;
            }
        }
    }

    public void LoadOnTriggerExit2D(Collider2D other,string s)
    {
        if (move)
        {
            switch (s)
            {
                case "LeftHit":
                    boxLeft = -10.0f;
                    Debug.LogWarning("離れました:" + boxLeft);
                    break;
                case "RightHit":
                    boxRight = 10.0f;
                    Debug.LogWarning("離れました:" + boxLeft);
                    break;
            }
        }
    }
}