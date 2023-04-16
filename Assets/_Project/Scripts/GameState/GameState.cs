using System;
using System.Collections;
using System.Collections.Generic;
using StateController;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState",menuName = "Managers/GameState")]
public class GameState : ScriptableObject,IState
{

    public Action OnGameStateStart;
    public Action OnGameStateUpdate;
    public Action OnGameStateExit;
    private string _stateName;


    public void Tick()
    {
        OnGameStateUpdate?.Invoke();
    }

    public void OnEnter()
    {
        OnGameStateStart?.Invoke();
    }

    public void OnExit()
    {
        OnGameStateExit?.Invoke();
    }
    
    
}
