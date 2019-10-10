using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Scene関係の処理を行うときに必要なライブラリ
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameObject obj;
    SceneChange sc;
    bool gameOver = false;    

    void Start()
    {
        obj = GameObject.Find("GameManager");
        sc = obj.GetComponent<SceneChange>();
    }

    public bool gameOverNow()
    {
        return gameOver;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        gameOver = true;
        sc.OnRetryResult();
        Debug.Log("GameOver");
    }
}
