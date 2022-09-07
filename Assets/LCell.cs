using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Cellstate
{
    Life,
    Dead
}

public class LCell : MonoBehaviour
{
    private int row = 0;
    private int columns = 0;
    [SerializeField]
    Cellstate _cellstate = Cellstate.Dead;
    [SerializeField]
    private Image image = null;
    LifeGame lifegame = null;
    public int Row { get => row; set => row = value; }
    public int Colums { get => columns; set => columns = value; }
    public Cellstate Cellstate 
    {
        get => _cellstate;
        set
        {
            _cellstate = value;
            CellstateChange();
        }
    }
    //Start is called before the first frame update
    void Start()
    {
        lifegame = GameObject.FindGameObjectWithTag("LifeGame").GetComponent<LifeGame>();
        CellstateChange();
    }
    private void OnValidate()
    {
        CellstateChange();
    }
    private void CellstateChange()
    {
        if (_cellstate == Cellstate.Dead)
        {
            image.color = Color.white;
        }
        else
        {
            image.color = Color.black;
        }
    }
}
