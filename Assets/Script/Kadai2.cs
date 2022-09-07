using UnityEngine;
using UnityEngine.UI;

public class Kadai2 : MonoBehaviour
{
    GameObject[,] cells;
    [SerializeField] int tate = 0;
    [SerializeField] int yoko = 0;
    int selecttate = 0;
    int selectyoko = 0;
    private void Start()
    {
        cells = new GameObject[tate, yoko];
        for (var r = 0; r < tate; r++)
        {
            for (var c = 0; c < yoko; c++)
            {
                var obj = new GameObject($"Cell({r}, {c})");
                obj.transform.parent = transform;
                cells[r,c] = obj;
                
                var image = obj.AddComponent<Image>();
                if (r == selecttate && c == selectyoko) { image.color = Color.red; }
                else { image.color = Color.white; }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // 左キーを押した
        {
            if (cells[selecttate, selectyoko])//今sellを選択していたら
            {
                cells[selecttate, selectyoko].GetComponent<Image>().color = Color.white; //今選択しているsellを白に
            }
            for (int i = 0; i < yoko; i++)//for文を回す理由、消したsellにアクセスしないようにするため
            {
                if (selectyoko == 0)//端まで来たら
                {
                    selectyoko = yoko;
                }
                selectyoko--;//移動するために
                if (cells[selecttate, selectyoko].GetComponent<Image>().enabled == true)//移動先にsellがあったら
                {
                    cells[selecttate, selectyoko].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // 右キーを押した
        {
            if (cells[selecttate, selectyoko])//今sellを選択していたら
            {
                cells[selecttate, selectyoko].GetComponent<Image>().color = Color.white; //今選択しているsellを白に
            }
            for (int i = 0; i < yoko; i++)//for文を回す理由、消したsellにアクセスしないようにするため
            {
                if (selectyoko == yoko-1)//端まで来たら
                {
                    selectyoko = -1;
                }
                selectyoko++;//移動するために
                if (cells[selecttate, selectyoko].GetComponent<Image>().enabled == true)//移動先にsellがあったら
                {
                    cells[selecttate, selectyoko].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) // 上キーを押した
        {
            if (cells[selecttate, selectyoko])//今sellを選択していたら
            {
                cells[selecttate, selectyoko].GetComponent<Image>().color = Color.white; //今選択しているsellを白に
            }
            for (int i = 0; i < tate; i++)//for文を回す理由、消したsellにアクセスしないようにするため
            {
                if (selecttate == 0)//端まで来たら
                {
                    selecttate = tate;
                }
                selecttate--;//移動するために
                if (cells[selecttate, selectyoko].GetComponent<Image>().enabled == true)//移動先にsellがあったら
                {
                    cells[selecttate, selectyoko].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) // 下キーを押した
        {
            if (cells[selecttate, selectyoko])//今sellを選択していたら
            {
                cells[selecttate, selectyoko].GetComponent<Image>().color = Color.white; //今選択しているsellを白に
            }
            for (int i = 0; i < tate; i++)//for文を回す理由、消したsellにアクセスしないようにするため
            {
                if (selecttate == tate-1)//端まで来たら
                {
                    selecttate = -1;
                }
                selecttate++;//移動するために
                if (cells[selecttate, selectyoko].GetComponent<Image>().enabled == true)//移動先にsellがあったら
                {
                    cells[selecttate, selectyoko].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            cells[selecttate, selectyoko].GetComponent<Image>().enabled = false;
        }
    }
}