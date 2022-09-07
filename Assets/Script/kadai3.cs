using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class kadai3 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] int _row = 5;
    [SerializeField] int _column = 5;
    GameObject[,] objs;
    float time = 0;
    static int count = 0;
    int limit = 0;
    bool clear = false;

    public static int Count { get => count; set => count = value; }

    private void Start()
    {
        GetComponent<GridLayoutGroup>().constraintCount = _column;
        objs = new GameObject[_row, _column];
        for (var r = 0; r < _row; r++)
        {
            for (var c = 0; c < _column; c++)
            {
                var cell = new GameObject($"Cell({r}, {c})");
                cell.transform.parent = transform;
                cell.AddComponent<Image>();
                int randam = Random.Range(0, 2);
                if (randam == 0 && limit < _row * _column - 6)
                {
                    cell.GetComponent<Image>().color = Color.white;
                    limit++;
                }
                else
                {
                    cell.GetComponent<Image>().color = Color.black;
                }
                objs[r, c] = cell;
            }
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        count++;
        if (clear == true)
        {
            return;
        }
        var cell = eventData.pointerCurrentRaycast.gameObject;
        var image = cell.GetComponent<Image>();
        if (image.color == Color.white)
        {
            image.color = Color.black;
        }
        else
        {
            image.color = Color.white;
        }
        int r = -1;
        int c = -1;
        for (int i = 0; i < _row; i++)
        {
            for (int j = 0; j < _column; j++)
            {
                if (this.objs[i, j] == cell)
                {
                    r = i;
                    c = j;
                    break;
                }
            }
        }
        if (r < 0 && c < 0) return;
        if (r > 0)
        {
            if (objs[r - 1, c].GetComponent<Image>().color != Color.black)
            {
                objs[r - 1, c].GetComponent<Image>().color = Color.black;
            }
            else
            {
                objs[r - 1, c].GetComponent<Image>().color = Color.white;
            }
        }
        if (r < _row - 1)
        {
            if (objs[r + 1, c].GetComponent<Image>().color != Color.black)
            {
                objs[r + 1, c].GetComponent<Image>().color = Color.black;
            }
            else
            {
                objs[r + 1, c].GetComponent<Image>().color = Color.white;
            }
        }
        if (c > 0)
        {
            if (objs[r, c - 1].GetComponent<Image>().color != Color.black)
            {
                objs[r, c - 1].GetComponent<Image>().color = Color.black;
            }
            else
            {
                objs[r, c - 1].GetComponent<Image>().color = Color.white;
            }
        }
        if (c < _column - 1)
        {
            if (objs[r, c + 1].GetComponent<Image>().color != Color.black)
            {
                objs[r, c + 1].GetComponent<Image>().color = Color.black;
            }
            else
            {
                objs[r, c + 1].GetComponent<Image>().color = Color.white;
            }
        }
        for (int i = 0; i < _row; i++)
        {
            for (int j = 0; j < _column; j++)
            {
                if (this.objs[i, j].GetComponent<Image>().color == Color.black)
                {
                    return;
                }
            }
        }
        Debug.Log("CLEAR!!   éËêî  " + count + "éË  éûä‘  " + Mathf.Floor(time) + "ïb");
        clear = true;
    }
}