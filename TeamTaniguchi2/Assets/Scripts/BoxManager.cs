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

            if (timeCount % 180 == 0)
            {
                newGenerate();
            }
        }
	}

    void newGenerate()
    {
        for(int i = 0; i < 8; i++)
        {
            bc[7 - i].SetPlaceUp();
        }
        bg.GenerateStart(1);//ボックスを生成する処理を呼び出す(1)
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
}