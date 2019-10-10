using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text txt;
    static int score = 0;

    // Use this for initialization
    void Start()
    {
        score = 0;
        txt = GameObject.Find("Canvas/Point").GetComponent<Text>();
    }

    public void SetScore()
    {
        score += 800;
        txt.text = score + "Score";
    }

    public static int GetScore()
    {
        return score;
    }
}
