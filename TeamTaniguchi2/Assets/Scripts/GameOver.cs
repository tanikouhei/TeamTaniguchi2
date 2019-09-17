using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    bool gameOver = false;

    public bool gameOverNow()
    {
        return gameOver;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        gameOver = true;
        Debug.Log("GameOver");
    }
}
