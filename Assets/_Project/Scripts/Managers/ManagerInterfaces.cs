using System;
using UnityEngine;



public interface IInputData
{
    public Action<Vector2> OnInputReleased { get; set; }
}


public interface IRaycastable
{
    void Execute();
}





public interface ISceneChanger
{
    public void LoadLoadingScene();
    public void LoadMainMenuScene();
    public void LoadGameScene();
    public void LoadMainMenuSceneFromIntroScene();
    public void LoadGameSceneFromMainMenuScene();
    void LoadMainMenuSceneFromGameScene();
}




public interface ILevelCreator
{
    public void CreateLevel();
}

public interface ILevelChangeStatus
{
    public void LevelCompleted();
}


