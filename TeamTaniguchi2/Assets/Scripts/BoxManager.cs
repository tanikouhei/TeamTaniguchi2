using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    BoxGenerate bg;
    int count = 0;
    int noCount = 0;
    bool placeUp = false;

    // Use this for initialization
    void Start ()
    {
        bg = GetComponent<BoxGenerate>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        count++;
        Debug.Log(count);
        if(count % 120 == 0)
        {
            NewGenerate();
        }
	}

    void NewGenerate()
    {
        placeUp = true;
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
