using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samplecode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //配列型変数の宣言
        //要素型[] 変数名;
        //int[] iAry = new int[]{ 10,20,30};//int 型 3 要素の配列を生成
        var iAry = new[] { 10, 20, 30 };

        Debug.Log($"iAry配列の長さは{iAry.Length}");

        for(var i = 0; i < iAry.Length; i++)
        {
            Debug.Log($"iAry[{i}]={iAry[i]}");
        }

        foreach(var e in iAry)
        {
            Debug.Log($"e={e}");
        }
        //配列要素へのアクセス
        //iAry[0] = 10;
        //iAry[1] = 20;
        //iAry[2] = 30;
    }

    //void kiso()
    //{
    //変数型 変数名 = 初期値;
    //int i = 100;//整数型の変数

    //string str = "文字列";

    //str = "Start";//変数は上書き可能、型が異なる値は代入不可

    //変数型を暗黙的に推論してくれる var が便利
    //var v = 1234;//初期値から型を推論する
    // var v;　エラー、初期化は省略できない

    //変数型 変数名 = 初期値;
    //int i = 100;//整数型の変数

    //＋演算子に夜文字列結合
    //Debug.Log("i=" + i);

    //(↓$マークがついた文字列（文字列補間）)
    //Debug.Log($"i={i}");//https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/tokens/interpolated

    //上の文字列補間、実体はstring.Format()と同義
    //Debug.Log(string.Format("i={0}", i));
    //}
}
