using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IGameStateChanger
{
    public void StartLoadingState();
    public void StartMainMenuState();
    public void StartBeforePlayingState();
    public void StartInGameState();
    public void StartLevelEndState();
}

