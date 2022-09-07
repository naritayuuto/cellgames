using UnityEngine;
using UnityEngine.UI;

public class kadai : MonoBehaviour
{
    [SerializeField,Header("sellの個数")] int sellcount = 0;//sellsの要素の数
    [SerializeField,Header("選択中のsell")] int sellselect = 0;//選択中のsell
    GameObject[] sells;
    private void Start()
    {
        sells = new GameObject[sellcount];
        for (var i = 0; i < sells.Length; i++)
        {
            var obj = new GameObject($"Cell{i}");
            obj.transform.parent = transform;

            sells[i] = obj;

            var image = obj.AddComponent<Image>();
            if (sellselect == i) { image.color = Color.red; }
            else { image.color = Color.white; }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // 左キーを押した
        {
            if (sells[sellselect])//今sellを選択していたら
            {
                sells[sellselect].GetComponent<Image>().color = Color.white; //今選択しているsellを白に
            }
            for (int i = 0; i < sells.Length; i++)//for文を回す理由、消したsellにアクセスしないようにするため
            {
                if (sellselect == 0)//左端まで来たら
                {
                    sellselect = sells.Length;
                }
                sellselect--;//移動するために
                if (sells[sellselect])//移動先にsellがあったら
                {
                    sells[sellselect].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // 右キーを押した
        {
            if (sells[sellselect])
            {
                sells[sellselect].GetComponent<Image>().color = Color.white;
            }
            for (int i = 0; i < sells.Length; i++)//消した配列の要素の部分に接続してしまったときにその要素を飛ばすためのfor文
            {
                if (sellselect == sells.Length - 1)
                {
                    sellselect = -1;
                }
                sellselect++;
                if (sells[sellselect])
                {
                    sells[sellselect].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //   Destroy(sells[sellselect].gameObject);
        //}
        if (Input.GetButtonUp("Jump"))
        {
            Destroy(sells[sellselect].gameObject);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            foreach (var sell in sells)
            {
                Debug.Log(sell);
            }

            Debug.Log($"sellselect = {sellselect}");
        }
    }
}