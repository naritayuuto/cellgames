using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Kadaikotae : MonoBehaviour
{
    [SerializeField]
    int _count = 0;
    private GameObject[] _cells;
    private int _selectedIndex;
    private void Start()
    {
        _cells = new GameObject[_count];
        for (var i = 0; i < _cells.Length; i++)
        {
            var obj = new GameObject($"Cell{i}");
            obj.transform.parent = transform;
            obj.AddComponent<Image>();
            _cells[i] = obj;
        }
    }

    private void Update()
    {
        var v =
            (Input.GetKeyDown(KeyCode.LeftArrow) ? -1 : 0) +
            (Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0);

        if(v!= 0)
        {
            _selectedIndex += v;
            OnSelectedChanged();
        }


        //if (Input.GetKeyDown(KeyCode.LeftArrow)) // 左キーを押した
        //{
        //    _selectedIndex--;
        //    OnSelectedChanged();
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow)) // 右キーを押した
        //{
        //    _selectedIndex++;
        //    OnSelectedChanged();
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(_cells[_selectedIndex]);
        }
    }
    private void OnSelectedChanged()
    {
        for (var i = 0; i < _cells.Length; i++)
        {
            var cell = _cells[i];
            if (!cell)
            {
                continue;
            }
            var image = cell.GetComponent<Image>();

            if (i == _selectedIndex)
            {
                image.color = Color.red;
            }
            else
            {
                image.color = Color.white;
            }
        }
    }
}