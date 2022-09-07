using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LifeGame : MonoBehaviour, IPointerClickHandler
{
    [SerializeField, Range(5, 30)]
    private int _row = 10;
    [SerializeField, Range(5, 30)]
    private int _columns = 10;
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;
    [SerializeField]
    private LCell _cellPrefab = null;
    LCell[,] _cells;
    [SerializeField,Range(0.1f,1f)]
    float interval = 1;
    [SerializeField]
    Text text = null;
    int Ngeneration = 0;
    float timer = 0;
    int _count = 0;
    int generationCount = 0;
    bool oneGenerationFlug = false;
    bool regularIntervalsFlug = false;
    bool nGenerationFlug = false;
    bool changeflug = false;
    bool[,] cellchange;

    public bool NGenerationFlug { get => nGenerationFlug; set => nGenerationFlug = value; }
    public bool OneGenerationFlug { get => oneGenerationFlug; set => oneGenerationFlug = value; }
    public bool RegularIntervalsFlug { get => regularIntervalsFlug; set => regularIntervalsFlug = value; }
    public bool Changeflug { get => changeflug; set => changeflug = value; }
    public int GenerationCount { get => generationCount; set => generationCount = value; }
    public float Interval { get => interval; set => interval = value; }
    public int Ngeneration1 { get => Ngeneration; set => Ngeneration = value; }
    // Start is called before the first frame update
    void Start()
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _columns;

        cellchange = new bool[_row, _columns];
        _cells = new LCell[_row, _columns];
        for (int r = 0; r < _row; r++)
        {
            for (int c = 0; c < _columns; c++)
            {
                var cell = Instantiate(_cellPrefab, _gridLayoutGroup.transform);
                _cells[r, c] = cell;
                _cells[r, c].Row = r;
                _cells[r, c].Colums = c;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (oneGenerationFlug)//àÍâÒÇ≤Ç∆
        {
            Change();
            Reflect();
            generationCount++;
            oneGenerationFlug = false;
        }
        if (regularIntervalsFlug)//àÍíËä‘äu
        {
            if (timer > interval)
            {
                Change();
                Reflect();
                generationCount++;
                timer = 0;
            }
        }
        if(nGenerationFlug)
        {
            for(int i = 0; i < Ngeneration; i++)
            {
                Change();
                Reflect();
                generationCount++;
                nGenerationFlug = false;
            }
        }
        text.text = generationCount + "ê¢ë„";
    }
    public void Resetcell()
    {
        for(int r = 0; r < _row; r++)
        {
            for(int c = 0; c < _columns; c++)
            {
                _cells[r, c].Cellstate = Cellstate.Dead;
            }
        }
        generationCount = 0;
        oneGenerationFlug = false;
        regularIntervalsFlug = false;
        nGenerationFlug = false;
    }
    public void NChange(InputField input)
    {
        string str = input.text;
        int num = int.Parse(str);
        Ngeneration = num;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var obj = eventData.pointerCurrentRaycast.gameObject;

        var cell = obj.GetComponent<LCell>();
        var image = obj.GetComponent<Image>();
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            cell.Cellstate = cell.Cellstate == Cellstate.Dead ? Cellstate.Life : Cellstate.Dead;
        }
    }
    public void Change()
    {
        for (int r = 0; r < _row; r++)
        {
            for (int c = 0; c < _columns; c++)
            {
                CheakCount(r, c);
            }
        }
    }
    public void CheakCount(int r, int c)
    {  
        if (c > 0)
        {
            if (_cells[r, c - 1].Cellstate == Cellstate.Life)//ç∂
            {
                _count++;
            }
        }
        if (c < _columns - 1)
        {
            if (_cells[r, c + 1].Cellstate == Cellstate.Life)//âE
            {
                _count++;
            }
        }
        if (r < _row - 1)
        {
            if (_cells[r + 1, c].Cellstate == Cellstate.Life)//â∫
            {
                _count++;
            }
        }
        if (r > 0)
        {
            if (_cells[r - 1, c].Cellstate == Cellstate.Life)//è„
            {
                _count++;
            }
        }
        if (r < _row - 1 && c > 0)
        {
            if (_cells[r + 1, c - 1].Cellstate == Cellstate.Life)//ç∂â∫
            {
                _count++;
            }
        }
        if (r < _row - 1 && c < _columns - 1)
        {
            if (_cells[r + 1, c + 1].Cellstate == Cellstate.Life)//âEâ∫
            {
                _count++;
            }
        }
        if (r > 0 && c < _columns - 1)
        {
            if (_cells[r - 1, c + 1].Cellstate == Cellstate.Life)//âEè„
            {
                _count++;
            }
        }
        if (r > 0 && c > 0)
        {
            if (_cells[r - 1, c - 1].Cellstate == Cellstate.Life)//ç∂è„
            {
                _count++;
            }
        }
        Judge(r, c, _count, _cells[r, c].Cellstate);
    }
    public void Judge(int r, int c, int count,Cellstate state)
    {
        if (state == Cellstate.Life)//ê∂Ç´ÇƒÇ¢ÇΩÇÁ
        {
            if (2 <= count && count <= 3)//é¸ÇËÇ…ê∂Ç´ÇƒÇ¢ÇÈÉZÉãÇ™2à»è„ÇRà»â∫Ç¢ÇÈèÍçá
            {
                cellchange[r, c] = false;
            }
            else//ÇPà»â∫Ç‹ÇΩÇÕ4à»è„ÇÃèÍçáÇÕéÄ
            {
                cellchange[r, c] = true;
            }
        }
        else//éÄÇÒÇ≈Ç¢ÇΩÇÁ
        {
            if (count == 3)//é¸ÇËÇ…ê∂Ç´ÇƒÇ¢ÇÈÉZÉãÇ™ÇøÇÂÇ§Ç«3å¬Ç¢ÇΩèÍçá
            {
                cellchange[r, c] = true;
            }
            else
            {
                cellchange[r, c] = false;
            }
        }
        _count = 0;
    }

    public void Reflect()
    {
        for(int r = 0; r < _row; r++)
        {
            for(int c = 0; c < _columns; c++)
            {
                if(cellchange[r,c])
                {
                    _cells[r,c].Cellstate = _cells[r, c].Cellstate == Cellstate.Dead ? Cellstate.Life : Cellstate.Dead;
                }
            }
        }
    }
}
