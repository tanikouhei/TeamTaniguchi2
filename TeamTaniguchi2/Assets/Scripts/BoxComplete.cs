﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxComplete : MonoBehaviour
{
    BoxController bc;
    BoxController[] bcClone = new BoxController[8];
    public int boxSizeCnt = 0;
    int boxCnt = 0;
    int cnt = 0;
    int time = 0;
    int resetTime = 0;
    int[] noNow = new int[8];
    int[] boxSize = new int[8];
    bool resetAll = false;

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            noNow[i] = 0;
            boxSize[i] = 0;
            bcClone[i] = null;
        }
    }

    void Update()
    {
        //boxSizeCntの合計
        boxSizeCnt = boxSize[0] + boxSize[1] + boxSize[2] + boxSize[3] + boxSize[4] + boxSize[5] + boxSize[6] + boxSize[7];

        Debug.Log(gameObject.name + noNow[0] + ":" + noNow[1] + ":" + noNow[2] + ":" + noNow[3] + ":" + noNow[4] + ":" + noNow[5] + ":" + noNow[6] + ":" + noNow[7]);
        //Debug.Log(gameObject.name + boxSize[0] + ":" + boxSize[1] + ":" + boxSize[2] + ":" + boxSize[3] + ":" + boxSize[4] + ":" + boxSize[5] + ":" + boxSize[6] + ":" + boxSize[7]);
        Debug.Log(gameObject.name + ":" + boxSizeCnt);

        if (boxSizeCnt == 8)
        {
            for (int i = 0; i < 8;i++)
            {
                if (bcClone[i] != null)
                {
                    bcClone[i].Die(0);
                    noNow[i] = 0;
                    boxSize[i] = 0;
                }
            }
            resetAll = true;
            boxSizeCnt = 0;//念のためリセット
            Debug.LogError("リセット(box):" + gameObject.name + noNow[0] + ":" + noNow[1] + ":" + noNow[2] + ":" + noNow[3] + ":" + noNow[4] + ":" + noNow[5] + ":" + noNow[6] + ":" + noNow[7]);
            Debug.LogError("リセット(size):" + gameObject.name + boxSize[0] + ":" + boxSize[1] + ":" + boxSize[2] + ":" + boxSize[3] + ":" + boxSize[4] + ":" + boxSize[5] + ":" + boxSize[6] + ":" + boxSize[7]);
        }
    }

    public bool resetAllNow()
    {
        return resetAll;
    }

    public void boxReset()//初期化
    {
        for (int i = 0; i < 8; i++)
        {
            noNow[i] = 0;
            boxSize[i] = 0;
            if(bcClone[i] != null)
            { 
            bcClone[i].compFlase();//falseにしてから
            bcClone[i] = null;//初期化
            }
        }
        resetAll = false;
        boxSizeCnt = 0;//ここで初期化
        Debug.LogWarning("呼ばれました");
        Debug.LogWarning(/*gameObject.name + */noNow[0] + ":" + noNow[1] + ":" + noNow[2] + ":" + noNow[3] + ":" + noNow[4] + ":" + noNow[5] + ":" + noNow[6] + ":" + noNow[7]);
        Debug.LogWarning(/*gameObject.name + */boxSize[0] + ":" + boxSize[1] + ":" + boxSize[2] + ":" + boxSize[3] + ":" + boxSize[4] + ":" + boxSize[5] + ":" + boxSize[6] + ":" + boxSize[7]);
        Debug.LogWarning(/*gameObject.name + ":" + */boxSizeCnt);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        bc = other.gameObject.GetComponent<BoxController>();
        //if (bc.stopNow()))//止まっている
        {//resetこれを追加しないと途中でboxSizeCntに加算されて０にならなくなるため
            if (bc.SetNo() != noNow[0] && bc.SetNo() != noNow[1] && bc.SetNo() != noNow[2] && 
                bc.SetNo() != noNow[3] && bc.SetNo() != noNow[4] && bc.SetNo() != noNow[5] && 
                bc.SetNo() != noNow[6] && bc.SetNo() != noNow[7])
            {//番号を読み込む時に、かぶっていなければ
                if (noNow[0] == 0)//順番に番号とサイズの大きさを記憶
                {
                    noNow[0] = bc.SetNo();
                    boxSize[0] = bc.SetBoxSize();
                    bcClone[0] = bc;
                }
                else if (noNow[1] == 0)
                {
                    noNow[1] = bc.SetNo();
                    boxSize[1] = bc.SetBoxSize();
                    bcClone[1] = bc;
                }
                else if (noNow[2] == 0)
                {
                    noNow[2] = bc.SetNo();
                    boxSize[2] = bc.SetBoxSize();
                    bcClone[2] = bc;
                }
                else if (noNow[3] == 0)
                {
                    noNow[3] = bc.SetNo();
                    boxSize[3] = bc.SetBoxSize();
                    bcClone[3] = bc;
                }
                else if (noNow[4] == 0)
                {
                    noNow[4] = bc.SetNo();
                    boxSize[4] = bc.SetBoxSize();
                    bcClone[4] = bc;
                }
                else if (noNow[5] == 0)
                {
                    noNow[5] = bc.SetNo();
                    boxSize[5] = bc.SetBoxSize();
                    bcClone[5] = bc;
                }
                else if (noNow[6] == 0)
                {
                    noNow[6] = bc.SetNo();
                    boxSize[6] = bc.SetBoxSize();
                    bcClone[6] = bc;
                }
                else if (noNow[7] == 0)
                {
                    noNow[7] = bc.SetNo();
                    boxSize[7] = bc.SetBoxSize();
                    bcClone[7] = bc;
                }
                bc.compTrue();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        bc = other.gameObject.GetComponent<BoxController>();
        if (noNow[0] == bc.SetNo())//記憶した番号を削除
        {
            noNow[0] = 0;
            boxSize[0] = 0;
            bcClone[0] = null;
        }
        else if (noNow[1] == bc.SetNo())
        {
            noNow[1] = 0;
            boxSize[1] = 0;
            bcClone[1] = null;
        }
        else if (noNow[2] == bc.SetNo())
        {
            noNow[2] = 0;
            boxSize[2] = 0;
            bcClone[2] = null;
        }
        else if (noNow[3] == bc.SetNo())
        {
            noNow[3] = 0;
            boxSize[3] = 0;
            bcClone[3] = null;
        }
        else if (noNow[4] == bc.SetNo())
        {
            noNow[4] = 0;
            boxSize[4] = 0;
            bcClone[4] = null;
        }
        else if (noNow[5] == bc.SetNo())
        {
            noNow[5] = 0;
            boxSize[5] = 0;
            bcClone[5] = null;
        }
        else if (noNow[6] == bc.SetNo())
        {
            noNow[6] = 0;
            boxSize[6] = 0;
            bcClone[6] = null;
        }
        else if (noNow[7] == bc.SetNo())
        {
            noNow[7] = 0;
            boxSize[7] = 0;
            bcClone[7] = null;
        }
        bc.compFlase();
        Debug.LogError("離れました:" + gameObject.name + ":" + bc.SetNo() + ":" + bc.SetBoxSize());
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxComplete : MonoBehaviour
{
    BoxController bc;
    //Collider2D[] other = new Collider2D[8];
    BoxController[] bcClone = new BoxController[8];
    public int boxSizeCnt = 0;
    int boxCnt = 0;
    int cnt = 0;
    int time = 0;
    int resetTime = 0;
    int[] noNow = new int[8];
    int[] boxSize = new int[8];
    bool reset = false;
    bool allReset = false;

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            noNow[i] = 0;
            boxSize[i] = 0;
        }
    }

    void Update()
    {
        if (reset)// && boxSizeCnt <= 0)
        {
            /*
            for (int i = 0; i < 8; i++)
            {
                if (boxSize[i] != 0)//ボックスが何個当たっているか知るため
                {
                    boxCnt++;
                }
            }
            Debug.LogError("boxCnt:" + boxCnt);

            for (int i = 0; i< 8;i++)
            {
                if (bcClone[i] != null)
                {
                    bcClone[i].Die(0);
                }
            }
            reset = false;
            boxSizeCnt = 0;
            //allReset = true;
            for (int i = 0; i< 8; i++)
            {
                noNow[i] = 0;
                boxSize[i] = 0;
            }
            Debug.LogError(gameObject.name + noNow[0] + ":" + noNow[1] + ":" + noNow[2] + ":" + noNow[3] + ":" + noNow[4] + ":" + noNow[5] + ":" + noNow[6] + ":" + noNow[7]);
            Debug.LogError(gameObject.name + boxSize[0] + ":" + boxSize[1] + ":" + boxSize[2] + ":" + boxSize[3] + ":" + boxSize[4] + ":" + boxSize[5] + ":" + boxSize[6] + ":" + boxSize[7]);
        }
    }

    public void boxReset()
{
    for (int i = 0; i < 8; i++)
    {
        noNow[i] = 0;
        boxSize[i] = 0;
    }
    boxSizeCnt = 0;
    Debug.Log("呼ばれました");
}

void OnTriggerStay2D(Collider2D other)
{
    //stay = true;
    bc = other.gameObject.GetComponent<BoxController>();
    //if (bc.stopNow())// && !bc.SetSend())//止まっている　//且つ　送っていなければ
    {//resetこれを追加しないと途中でboxSizeCntに加算されて０にならなくなるため
        if (bc.SetNo() != noNow[0] && bc.SetNo() != noNow[1] && bc.SetNo() != noNow[2] &&
            bc.SetNo() != noNow[3] && bc.SetNo() != noNow[4] && bc.SetNo() != noNow[5] &&
            bc.SetNo() != noNow[6] && bc.SetNo() != noNow[7] && !reset)
        {//番号を読み込む時に、かぶっていなければ
            if (noNow[0] == 0)//順番に番号とサイズの大きさを記憶
            {
                noNow[0] = bc.SetNo();
                boxSize[0] = bc.SetBoxSize();
                bcClone[0] = bc;
            }
            else if (noNow[1] == 0)
            {
                noNow[1] = bc.SetNo();
                boxSize[1] = bc.SetBoxSize();
                bcClone[1] = bc;
            }
            else if (noNow[2] == 0)
            {
                noNow[2] = bc.SetNo();
                boxSize[2] = bc.SetBoxSize();
                bcClone[2] = bc;
            }
            else if (noNow[3] == 0)
            {
                noNow[3] = bc.SetNo();
                boxSize[3] = bc.SetBoxSize();
                bcClone[3] = bc;
            }
            else if (noNow[4] == 0)
            {
                noNow[4] = bc.SetNo();
                boxSize[4] = bc.SetBoxSize();
                bcClone[4] = bc;
            }
            else if (noNow[5] == 0)
            {
                noNow[5] = bc.SetNo();
                boxSize[5] = bc.SetBoxSize();
                bcClone[5] = bc;
            }
            else if (noNow[6] == 0)
            {
                noNow[6] = bc.SetNo();
                boxSize[6] = bc.SetBoxSize();
                bcClone[6] = bc;
            }
            else if (noNow[7] == 0)
            {
                noNow[7] = bc.SetNo();
                boxSize[7] = bc.SetBoxSize();
                bcClone[7] = bc;
            }
            bc.compTrue();
            /*
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
        }
    }
    if (!reset)
    {   //boxSizeCntの合計
        boxSizeCnt = boxSize[0] + boxSize[1] + boxSize[2] + boxSize[3] + boxSize[4] + boxSize[5] + boxSize[6] + boxSize[7];
    }

    Debug.Log(gameObject.name + noNow[0] + ":" + noNow[1] + ":" + noNow[2] + ":" + noNow[3] + ":" + noNow[4] + ":" + noNow[5] + ":" + noNow[6] + ":" + noNow[7]);
    Debug.Log(gameObject.name + boxSize[0] + ":" + boxSize[1] + ":" + boxSize[2] + ":" + boxSize[3] + ":" + boxSize[4] + ":" + boxSize[5] + ":" + boxSize[6] + ":" + boxSize[7]);
    Debug.LogWarning(gameObject.name + ":" + boxSizeCnt);

    if (boxSizeCnt == 8)
    {
        reset = true;
    }

    if (reset)//trueになったら削除していく
    {
        /*
        if (noNow[0] == bc.SetNo())//記憶した番号を削除
        {
            noNow[0] = 0;
            boxSize[0] = 0;
        }
        else if (noNow[1] == bc.SetNo())
        {
            noNow[1] = 0;
            boxSize[1] = 0;
        }
        else if (noNow[2] == bc.SetNo())
        {
            noNow[2] = 0;
            boxSize[2] = 0;
        }
        else if (noNow[3] == bc.SetNo())
        {
            noNow[3] = 0;
            boxSize[3] = 0;
        }
        else if (noNow[4] == bc.SetNo())
        {
            noNow[4] = 0;
            boxSize[4] = 0;
        }
        else if (noNow[5] == bc.SetNo())
        {
            noNow[5] = 0;
            boxSize[5] = 0;
        }
        else if (noNow[6] == bc.SetNo())
        {
            noNow[6] = 0;
            boxSize[6] = 0;
        }
        else if (noNow[7] == bc.SetNo())
        {
            noNow[7] = 0;
            boxSize[7] = 0;
        }
        */
        //boxSizeCnt -= bc.SetBoxSize();
        //bc.compTrue();
        //boxSizeCnt = boxSize[0] + boxSize[1] + boxSize[2] + boxSize[3] + boxSize[4] + boxSize[5] + boxSize[6] + boxSize[7];
        //bc.Die(1);
        /*
        if (boxSizeCnt <= 0)
        {
            reset = false;
            boxSizeCnt = 0;
            //allReset = true;
            for (int i = 0; i < 8; i++)
            {
                noNow[i] = 0;
                boxSize[i] = 0;
            }
            Debug.LogError(gameObject.name + noNow[0] + ":" + noNow[1] + ":" + noNow[2] + ":" + noNow[3] + ":" + noNow[4] + ":" + noNow[5] + ":" + noNow[6] + ":" + noNow[7]);
            Debug.LogError(gameObject.name + boxSize[0] + ":" + boxSize[1] + ":" + boxSize[2] + ":" + boxSize[3] + ":" + boxSize[4] + ":" + boxSize[5] + ":" + boxSize[6] + ":" + boxSize[7]);
        }
        Debug.LogError(gameObject.name + boxSizeCnt + " reset:" + reset);
    }
    else
    {
        boxSizeCnt = 0;
    }
}

void OnTriggerExit2D(Collider2D other)
{
    bc = other.gameObject.GetComponent<BoxController>();
    if (noNow[0] == bc.SetNo())//記憶した番号を削除
    {
        noNow[0] = 0;
        boxSize[0] = 0;
        boxCnt--;
    }
    else if (noNow[1] == bc.SetNo())
    {
        noNow[1] = 0;
        boxSize[1] = 0;
        boxCnt--;
    }
    else if (noNow[2] == bc.SetNo())
    {
        noNow[2] = 0;
        boxSize[2] = 0;
        boxCnt--;
    }
    else if (noNow[3] == bc.SetNo())
    {
        noNow[3] = 0;
        boxSize[3] = 0;
        boxCnt--;
    }
    else if (noNow[4] == bc.SetNo())
    {
        noNow[4] = 0;
        boxSize[4] = 0;
        boxCnt--;
    }
    else if (noNow[5] == bc.SetNo())
    {
        noNow[5] = 0;
        boxSize[5] = 0;
        boxCnt--;
    }
    else if (noNow[6] == bc.SetNo())
    {
        noNow[6] = 0;
        boxSize[6] = 0;
        boxCnt--;
    }
    else if (noNow[7] == bc.SetNo())
    {
        noNow[7] = 0;
        boxSize[7] = 0;
        boxCnt--;
    }

    //Debug.LogError("離れました");

    /*
    if (0 < boxSizeCnt)
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
        Debug.Log("呼ばれました");
    }
}
 */