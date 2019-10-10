using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    Text[] txt = new Text[4];
    static int[] rank = new int[3];
    int nowScore;

    // Use this for initialization
    void Start()
    {
        txt[0] = GameObject.Find("Canvas/Text0").GetComponent<Text>();
        txt[1] = GameObject.Find("Canvas/Text1").GetComponent<Text>();
        txt[2] = GameObject.Find("Canvas/Text2").GetComponent<Text>();
        txt[3] = GameObject.Find("Canvas/Text3").GetComponent<Text>();

        nowScore = Score.GetScore();

        if (rank[0] < nowScore)//1位が出たら順に下げていく
        {
            rank[2] = rank[1];
            rank[1] = rank[0];
            rank[0] = nowScore;
        }
        else if (rank[1] < nowScore)//2位が出たら
        {
            rank[2] = rank[1];
            rank[1] = nowScore;
        }
        else if (rank[2] < nowScore)//3位
        {
            rank[2] = nowScore;
        }

        txt[0].text = nowScore.ToString() + "Point";//今回のスコア

        for (int i = 1; i < 4; i++)//ランキング表示
        {
            txt[i].text = i + "位:  " + rank[i - 1].ToString() + "Point";
            Debug.Log(rank[i - 1]);
        }
    }
}
