using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nizigen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //二次元配列の初期化
        //new[,] {{要素１,要素２},{要素３,要素４},...};
                          //縦、横
        int[,] iAry = new int[5,3]
            {
                {0,1,2 },
                {10,11,12 },
                {20,21,22 },
                {30,31,32 },
                {40,41,42 }
            };

        //配列の次元を取得する
        Debug.Log($"配列の次元数 = {iAry.Rank}");

        //Lengthは配列全体の要素数（5*3 つまり15）を返す
        Debug.Log($"Length = {iAry.Length}");

        //各次元ごとの要素数はGetLength()メソッドから取得出来る
        Debug.Log($"１次元目 = {iAry.GetLength(0)}");
        Debug.Log($"2次元目 = {iAry.GetLength(1)}");

        //通常の配列に1軸追加した物
        //要素を並べるだけという点は通常の配列と同じ
        //データアクセスに各次元のインデックスを追加できる.


        for (var i = 0; i < 5; i++)
        {
            for(int k = 0; k < 3; k++)
            {
                Debug.Log($"{i},{k} = {iAry[i, k]}");
            }
        }
        //foreachを使うことも出来る
        foreach(var e in iAry)
        {
            Debug.Log($"e={e}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
