using UnityEngine;
using UnityEngine.UI;
public enum CellState
{

    Mine = -1,//地雷

    None,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
}
public class MCell : MonoBehaviour
{
    [SerializeField]//初期化されていないという警告を避けるためnullを代入
    private Text _view = null;
    [SerializeField]
    private GameObject image = null;
    private Text flugtext = null;
    Minesweeper minesweeper = null;
    [SerializeField]
    private CellState _cellState = CellState.None;
    int r = 0;
    int c = 0;
    bool flug = false;
    bool stateflug = false;
    bool openflug = false;
    public CellState CellState 
    { 
        get => _cellState; 
        set
        {
            _cellState = value;
            OnCellStateChanged();
        }
    }

    public bool Flug { get => flug; set => flug = value; }
    public bool StateFlug { get => stateflug; }

    public bool OpenFlug { get => openflug; }
    public int C { get => c; set => c = value; }
    public int R { get => r; set => r = value; }

    // Start is called before the first frame update
    private void Start()
    {
        minesweeper = GameObject.FindGameObjectWithTag("Minesweeper").GetComponent<Minesweeper>();
        flugtext = image.GetComponentInChildren<Text>();
        flugtext.enabled = false;
        OnCellStateChanged();
    }
    private void OnValidate()//OnValidate()にカーソルを合わせて
    {
        OnCellStateChanged();
    }
    private void OnCellStateChanged()
    {
        if(_view == null)
        {
            return;
        }
        if (_cellState == CellState.Mine)
        {
            _view.text = "X";
            _view.color = Color.red;
            stateflug = true;
        }
        else if (_cellState == CellState.None)
        {
            _view.text = "";
        }
        else
        {
            _view.text = ((int)_cellState).ToString();
            _view.color = Color.blue;
        }
    }
    public void Mineflug()
    {
        if(flug)
        {
            flugtext.enabled = true;
        }
        else
        {
            flugtext.enabled = false;
        }
    }

    public void Open()
    {
        if (stateflug)
        {
            Debug.Log("ここまで");
        }
        else
        {
            openflug = true;//開く
            if (image != null)
            {
                image.SetActive(false);
                if (_cellState != CellState.None)
                {
                    stateflug = true;
                }
                else
                {
                    minesweeper.CellOpen(r, c);
                }
            }
            
        }
    }
}
