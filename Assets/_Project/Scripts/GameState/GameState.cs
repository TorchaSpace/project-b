using System;
using System.Collections;
using System.Collections.Generic;
using StateController;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState",menuName = "Managers/GameState")]
public class GameState : ScriptableObject,IState
{

    public Action onGameStateStart;
    public Action onGameStateUpdate;
    public Action onGameStateExit;
    private string _stateName;


    public void Tick()
    {
        onGameStateUpdate?.Invoke();
    }

    public void OnEnter()
    {
        onGameStateStart?.Invoke();
    }

    public void OnExit()
    {
        onGameStateExit?.Invoke();
    }
    
    
}
