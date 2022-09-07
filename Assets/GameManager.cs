using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager
{
    static private GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;

    LifeGame _lifegame = null;
    public void SetLifeGame(LifeGame lifegame) 
    { 
        _lifegame = lifegame; 
    }
    // Start is called before the first frame update
    static public LifeGame LifeGame => _instance._lifegame;
}
