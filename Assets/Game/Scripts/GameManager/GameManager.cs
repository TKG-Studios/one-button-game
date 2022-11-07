using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameStates currentState;
    private void Awake()
    {
        Instance = this;
    }

    public enum GameStates
    {
        Menu,
        Waiting,
        Draw,
        MatchSet,
        SetUp,
        MatchDecided
    }

    public void changeState(GameStates newState)
    {
        currentState = newState;
        
    }

}
