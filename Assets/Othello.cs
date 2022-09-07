using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Othello : MonoBehaviour
{
    private int _row = 8;
    private int _columns = 8;
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;
    [SerializeField]
    private Reverse _reversePrefab = null;
    Reverse[,] reverses;
    bool judge = false;
    // Start is called before the first frame update
    void Start()
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _columns;
        reverses = new Reverse[_row, _columns];
        for(int r = 0; r < _row; r++)
        {
            for(int c = 0; c < _columns; c++)
            {
                var reverse = Instantiate(_reversePrefab, _gridLayoutGroup.transform);
                reverses[r, c] = reverse;
                //if (r == 3 && c == 3 || r ==4 && c == 4)
                //{
                //    reverses[r, c].ReverseState = ReverseState.black;
                //}
                //else if(r == 4 && c == 3 || r == 3 && c == 4)
                //{
                //    reverses[r, c].ReverseState = ReverseState.white;
                //}
                //else
                //{
                //    reverses[r, c].ReverseState = ReverseState.None;
                //}
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var obj = eventData.pointerCurrentRaycast.gameObject;
        var reverse = obj.GetComponent<Reverse>();
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (reverse.ReverseState == ReverseState.None)
            {
                if (judge)
                {
                    reverse.ReverseState = ReverseState.black;
                }
                else
                {
                    reverse.ReverseState = ReverseState.white;
                }
                obj.SetActive(true);
            }
        }
    }

}
