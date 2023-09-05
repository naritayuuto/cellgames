using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
public class Minesweeper : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int _rows = 10;//横
    [SerializeField]
    private int _columns = 10;//縦
    [SerializeField]
    private GameObject minesweeper = null;
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;
    [SerializeField]
    private MCell _cellPrefab = null;
    [SerializeField, Range(0, 99)]
    private int _minecount = 10;
    [SerializeField, Header("時間表示")]
    private Text timeText = null;
    [SerializeField, Header("クリア時間表示")]
    private Text cleartimeText = null;
    [SerializeField, Header("クリア表示用")]
    private Text clearText = null;
    [SerializeField, Header("ゲームオーバー表示用")]
    private Text gameoverText = null;

    private MCell[,] _cells;
    bool start = false;
    int opencount = 0;
    int notopencount = 0;
    private float seconds = 0;
    private int minute = 0;
    private float secondstime = 0;
    private int minutetime = 0;
    [Tooltip("上下左右を調べるために使用")]
    const int _one = 1;
    [Tooltip("秒数の最大値")]
    const float _sixty = 60f;

    // Start is called before the first frame update
    private void Start()
    {
        clearText.enabled = false;
        gameoverText.enabled = false;
        cleartimeText.enabled = false;
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _columns;

        _cells = new MCell[_rows, _columns];

        for (var r = 0; r < _rows; r++)
        {
            for (var c = 0; c < _columns; c++)
            {
                var cell = Instantiate(_cellPrefab, _gridLayoutGroup.transform);
                _cells[r, c] = cell;
                _cells[r, c].C = c;
                _cells[r, c].R = r;
            }
        }
    }
    private void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= _sixty)
        {
            minute++;
            seconds = seconds - _sixty;
        }
        timeText.text = minute.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
    }

    void Mine(MCell NotMinecell)
    {
        //地雷配置
        for (var i = 0; i < _minecount;)
        {
            var r = Random.Range(0, _rows);
            var c = Random.Range(0, _columns);
            var cell = _cells[r, c];
            if (cell == NotMinecell)
            {

            }
            else if (cell.CellState != CellState.Mine)
            {
                cell.CellState = CellState.Mine;
                i++;
            }
        }
    }
    void MineCheck()
    {
        //周りに地雷がいくつあるか
        for (var r = 0; r < _rows; r++)
        {
            for (var c = 0; c < _columns; c++)
            {
                if (_cells[r, c].CellState == CellState.Mine)
                {
                    continue;
                }
                else
                {
                    if (r < _rows - _one)//範囲外かどうか
                    {
                        if (!_cells[r + _one, c])
                        {
                            Debug.Log("何もなし");//下
                        }
                        else if (_cells[r + _one, c].CellState == CellState.Mine)
                        {
                            _cells[r, c].CellState++;
                        }
                    }
                    if (r < _rows - _one && c < _columns - _one)
                    {
                        if (!_cells[r + _one, c + _one]) Debug.Log("何もなし");//右斜め下
                        else if (_cells[r + _one, c + _one].CellState == CellState.Mine) _cells[r, c].CellState++;
                    }
                    if (c < _columns - _one)
                    {
                        if (!_cells[r, c + _one]) Debug.Log("何もなし");//右
                        else if (_cells[r, c + _one].CellState == CellState.Mine) _cells[r, c].CellState++;
                    }
                    if (r > 0 && c < _columns - _one)
                    {
                        if (!_cells[r - _one, c + _one]) Debug.Log("何もなし");//右斜め上
                        else if (_cells[r - _one, c + _one].CellState == CellState.Mine) _cells[r, c].CellState++;
                    }
                    if (r > 0)
                    {
                        if (!_cells[r - _one, c]) Debug.Log("何もなし");//上
                        else if (_cells[r - _one, c].CellState == CellState.Mine) _cells[r, c].CellState++;
                    }
                    if (r > 0 && c > 0)
                    {
                        if (!_cells[r - _one, c - _one]) Debug.Log("何もなし");//左斜め上
                        else if (_cells[r - _one, c - _one].CellState == CellState.Mine) _cells[r, c].CellState++;
                    }
                    if (c > 0)
                    {
                        if (!_cells[r, c - _one]) Debug.Log("何もなし");//左
                        else if (_cells[r, c - _one].CellState == CellState.Mine) _cells[r, c].CellState++;
                    }
                    if (r < _rows - _one && c > 0)
                    {
                        if (!_cells[r + _one, c - _one]) Debug.Log("何もなし");//左斜め下
                        else if (_cells[r + _one, c - _one].CellState == CellState.Mine) _cells[r, c].CellState++;
                    }
                }
            }
        }
    }
    public void CellOpen(int r, int c)
    {
        if (r < _rows - _one && r >= 0)//範囲内かどうか
        {
            if (!_cells[r + _one, c].OpenFlug)//下
            {
                _cells[r + _one, c].Open();
            }
        }
        if (r < _rows - _one && c < _columns - _one)
        {
            if (!_cells[r + _one, c + _one].OpenFlug) _cells[r + _one, c + _one].Open();//右斜め下
        }
        if (c < _columns - _one && c >= 0)
        {
            if (!_cells[r, c + _one].OpenFlug) _cells[r, c + _one].Open();//右
        }
        if (r > 0 && c < _columns - _one)
        {
            if (!_cells[r - _one, c + _one].OpenFlug) _cells[r - _one, c + _one].Open();//右斜め上
        }
        if (r > 0)
        {
            if (!_cells[r - _one, c].OpenFlug) _cells[r - _one, c].Open();//上
        }
        if (r > 0 && c > 0)
        {
            if (!_cells[r - _one, c - _one].OpenFlug) _cells[r - _one, c - _one].Open();//左斜め上
        }
        if (c > 0)
        {
            if (!_cells[r, c - _one].OpenFlug) _cells[r, c - _one].Open();//左
        }
        if (r < _rows - _one && c > 0)
        {
            if (!_cells[r + _one, c - _one].OpenFlug) _cells[r + _one, c - _one].Open();//左斜め下
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var obj = eventData.pointerCurrentRaycast.gameObject;
        int r = -1;
        int c = -1;
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                if (_cells[i, j] == obj)
                {
                    r = i;
                    c = j;
                    break;
                }
            }
        }
        var cell = obj.GetComponent<MCell>();
        if (!start)
        {
            Mine(cell);
            MineCheck();
            start = true;
        }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (cell != null)//cellはあるのか
            {
                if (!cell.Flug)//地雷の目印がついているのか
                {
                    if (!cell.OpenFlug)//開いているかどうか
                    {
                        cell.Open();
                        if (!cell.StateFlug)//CellState.Noneかどうか
                        {
                            CellOpen(r, c);
                        }
                    }
                    if (cell.CellState == CellState.Mine)
                    {
                        //GameOver
                        timeText.enabled = false;
                        minesweeper.SetActive(false);
                        gameoverText.enabled = true;
                    }
                    for(int i = 0; i < _rows; i++)
                    {
                        for(int j = 0; j < _columns; j++)
                        {
                            if(_cells[i,j].OpenFlug)
                            {
                                opencount++;
                            }
                            else
                            {
                                notopencount++;
                                if(notopencount > _minecount)
                                {
                                    continue;
                                }
                            }
                            if (opencount == ((_rows * _columns) - _minecount))
                            {
                                //GameClear
                                timeText.enabled = false;
                                minesweeper.SetActive(false);
                                clearText.enabled = true;
                                minutetime = minute;
                                secondstime = seconds;
                                cleartimeText.text = minutetime.ToString("00") + ":" + Mathf.Floor(secondstime).ToString("00");
                                cleartimeText.enabled = true;
                            }
                        }
                    }
                    opencount = 0;
                    notopencount = 0;
                }
            }
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (!cell.Flug)
            {
                cell.Flug = true;
                cell.Mineflug();
            }
            else
            {
                cell.Flug = false;
                cell.Mineflug();
            }
        }
    }
}
