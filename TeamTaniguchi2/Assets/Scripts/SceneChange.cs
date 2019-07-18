using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// 1.UIシステムを使うときに必要なライブラリ
using UnityEngine.UI;
// 2.Scene関係の処理を行うときに必要なライブラリ
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(540, 960, true);
    }

    // 3.OnRetry関数が実行されたら、sceneを読み込む
    public void OnRetryTitle()
    {
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("Title");
    }

    public void OnRetrySelect()
    {
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("Select");
    }

    public void OnRetryRule()
    {
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("Rule");
    }

    public void OnRetryStage()
    {
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("Stage");
    }

    public void OnRetryResult()
    {
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("Result");
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      Application.Quit(); 
#endif
    }
}