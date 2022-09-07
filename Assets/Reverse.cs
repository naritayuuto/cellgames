using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReverseState
{
    None,
    black,
    white
}
public class Reverse : MonoBehaviour
{
    Animator anim = null;
    [SerializeField]
    ReverseState reverseState = ReverseState.black;
    public ReverseState ReverseState
    {
        get => reverseState;
        set
        {
            reverseState = value;
            Reversal();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnValidate()
    {
        Reversal();
    }
    public void Reversal()
    {
        if(reverseState == ReverseState.black)
        {
           // gameObject.SetActive(true);
            //anim.Play("Wreverse");
        }
        else if(reverseState == ReverseState.white)
        {
           // gameObject.SetActive(true);
            //anim.Play("Breverse");
        }
        else
        {
            //gameObject.SetActive(false);
        }
    }
}
