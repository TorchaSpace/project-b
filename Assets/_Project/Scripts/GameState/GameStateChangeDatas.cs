using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStateChangeData",menuName = "Managers/GameStateChangeData")]
public class GameStateChangeDatas : ScriptableObject
{
    public bool isLoading;
    public bool mainMenuSceneActive;
    public bool isLevelLoaded;
    public bool isLevelStarted;


#if UNITY_EDITOR
    private void OnDisable()
    {
        mainMenuSceneActive = false;
        isLoading = false;
        isLevelLoaded = false;
        isLevelStarted = false;
    }
    
    
    #endif
}
