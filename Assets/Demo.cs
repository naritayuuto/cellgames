using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    [SerializeField, Range(5, 30)]
    private int _row = 10;
    [SerializeField, Range(5, 30)]
    private int _columns = 10;
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;
    [SerializeField]
    private GameObject _cellPrefab = null;
    GameObject[,] _cells;
    // Start is called before the first frame update
    void Start()
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _columns;

        _cells = new GameObject[_row, _columns];
        for (int r = 0; r < _row; r++)
        {
            for (int c = 0; c < _columns; c++)
            {
                var cell = Instantiate(_cellPrefab, _gridLayoutGroup.transform);
                _cells[r, c] = cell;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
