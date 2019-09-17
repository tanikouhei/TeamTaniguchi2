using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    GameObject obj;
    public GameObject[] Lines = new GameObject[8];
    BoxComplete[] bc = new BoxComplete[8];
    BoxGenerate bg;
    GameOver go;
    int timeCount = 0;//(仮)
    int noCount = 0;
    bool placeUp = false;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < 8; i++)
        {
            bc[i] = Lines[i].GetComponent<BoxComplete>();
        }
        bg = GetComponent<BoxGenerate>();
        obj = GameObject.Find("TopBlock");
        go = obj.GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!go.gameOverNow())
        {
            timeCount++;
            if (timeCount % 120 == 0)
            {
                newGenerate();
                Reset();
            }
        }
	}

    void newGenerate()
    {
        placeUp = true;
        bg.GenerateStart(1);//ボックスを生成する処理を呼び出す(1)
    }
    
    void Reset()
    {
        for(int i = 0; i < 8; i++)
        {
            bc[i].boxReset();
        }
    }    

    public int SetNoCount()
    {
        noCount++;
        return noCount;
    }

    public int GetNoCount()
    {
        return noCount;
    }

    public bool GetPlaceUp()
    {
        return placeUp;
    }

    public bool SetPlaceUp()//boolをチェンジ
    {
        if (placeUp) placeUp = false;
        else placeUp = true;
        return placeUp;
    }
    
}
