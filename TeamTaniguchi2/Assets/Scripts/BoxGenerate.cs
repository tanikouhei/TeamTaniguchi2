using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerate : MonoBehaviour
{
    GameObject[] box = new GameObject[5];//ボックス
    //テーブル
    int[] tableBox01 = { 1, 0, 2, 0, 0, 1, 2, 0 };
    int[] tableBox02 = { 0, 1, 1, 0, 2, 0, 0, 1 };
    int[] tableBox03 = { 1, 0, 1, 2, 0, 0, 1, 1 };
    int[] tableBox04 = { 2, 0, 0, 1, 2, 0, 2, 0 };
    int[] tableBox05 = { 2, 0, 2, 0, 0, 1, 0, 1 };
    int[] tableBox06 = { 2, 0, 1, 0, 1, 0, 2, 0 };
    int[] tableBox07 = { 2, 0, 2, 0, 0, 2, 0, 0 };
    int[] tableBox08 = { 0, 0, 2, 0, 3, 0, 0, 1 };
    int[] tableBox09 = { 0, 1, 0, 3, 0, 0, 2, 0 };
    int[] tableBox10 = { 3, 0, 0, 0, 2, 0, 2, 0 };
    int[] tableBox11 = { 0, 2, 0, 3, 0, 0, 0, 1 };
    int[] tableBox12 = { 1, 0, 1, 0, 4, 0, 0, 0 };
    int[] tableBox13 = { 4, 0, 0, 0, 0, 1, 0, 1 };
    int[] tableBox14 = { 0, 2, 0, 4, 0, 0, 0, 0 };
    int[] tableBox15 = { 5, 0, 0, 0, 0, 0, 0, 1 };
    int[] tbn;//テーブルのコピー
    float scale_x = 1.0f;
    float scale_y = 1.0f;
    float scale_z = 1.0f;

	// Use this for initialization
	void Start ()
    {
        for(int i = 0; i < 5; i++)//ボックスの型(1～5の大きさ)
        {
            box[i] = (GameObject)Resources.Load("Box" + (i + 1));//ボックスの型を読み込んで番号をつける
            box[i].transform.localScale = new Vector3(scale_x, scale_y, scale_z);//ボックスの大きさ
        }
        GenerateStart(0);//最初
    }
	
    public void GenerateStart(int now)//生成開始
    {
        float position_x = -2.45f;
        float position_y = -2.5f;
        int maxLoop = 1;//何段積むか

        if(now == 0)//最初又は全部消えたら3段積む
        {
            maxLoop = 3;
        } 
        else       //それ以外は1段
        {
            maxLoop = 1;
        }  
         
        for (int i = 0; i < maxLoop; i++)
        {
            SetTable();

            for (int j = 0; j < 8; j++)//マイナス１になったらテーブル終了
            {
                switch (tbn[j])
                {
                    case 0://ゼロは空白だから何もしない
                        break;
                    case 1:
                        Instantiate(box[0], new Vector3(position_x, position_y, 0), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(box[1], new Vector3(position_x + 0.35f, position_y, 0), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(box[2], new Vector3(position_x + 0.68f, position_y, 0), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(box[3], new Vector3(position_x + 1.04f, position_y, 0), Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(box[4], new Vector3(position_x + 1.4f, position_y, 0), Quaternion.identity);
                        break;
                }
                position_x += 0.7f;
            }
            position_x = -2.45f;
            position_y += 0.71f;
        }
    }

    void SetTable()//テーブルをランダムで読み込む
    {
        int rnd = Random.Range(1, 16);//呼び出すテーブル
        Debug.Log(rnd + "テーブル");
        switch (rnd)
        {
            case 1:
                tbn = tableBox01;
                break;
            case 2:
                tbn = tableBox02;
                break;
            case 3:
                tbn = tableBox03;
                break;
            case 4:
                tbn = tableBox04;
                break;
            case 5:
                tbn = tableBox05;
                break;
            case 6:
                tbn = tableBox06;
                break;
            case 7:
                tbn = tableBox07;
                break;
            case 8:
                tbn = tableBox08;
                break;
            case 9:
                tbn = tableBox09;
                break;
            case 10:
                tbn = tableBox10;
                break;
            case 11:
                tbn = tableBox11;
                break;
            case 12:
                tbn = tableBox12;
                break;
            case 13:
                tbn = tableBox13;
                break;
            case 14:
                tbn = tableBox14;
                break;
            case 15:
                tbn = tableBox15;
                break;
        }
    }
}
