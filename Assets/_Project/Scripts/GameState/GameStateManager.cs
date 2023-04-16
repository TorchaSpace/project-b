using System;
using UnityEngine;
using IState = StateController.IState;
using StateMachine = StateController.StateMachine;

namespace Managers
{
    public class GameStateManager : MonoBehaviour,ICurrentStateHolder,IGameStateChanger
    {
        public IState CurrentState {
            get => currentState;
            set => currentState = (GameState)value;
        }

        [SerializeField] private GameStateChangeDatas data;
        [SerializeField] private GameState currentState;

        #region States

        [Space] 
        [SerializeField] private GameState introSceneState;
        [SerializeField] private GameState mainMenuState;
        [SerializeField] private GameState gameLoadingState;
        [SerializeField] private GameState beforePlayState;
        [SerializeField] private GameState inGameState;
        [SerializeField] private GameState levelEndState;
        
        
        #endregion
        private StateMachine _stateMachine;


        private void Start()
        {
            SetStateMachine();
        }
        

        private void Update()
        {
           _stateMachine.Tick();
        }


        
        
        
        private void SetStateMachine()
        {
            _stateMachine = new StateMachine(this);
            
            _stateMachine.AddTransition(gameLoadingState,mainMenuState,IsMainMenuActive());
            _stateMachine.AddTransition(gameLoadingState,beforePlayState,IsGameLoadedAndNotStarted());
            _stateMachine.AddTransition(beforePlayState,inGameState,IsGameStarted());

            _stateMachine.AddAnyTransition(gameLoadingState,IsLoading());
            
            _stateMachine.SetState(currentState);


            Func<bool> IsGameStarted() => () => data.isLevelLoaded && data.isLevelStarted;

            Func<bool> IsLoading() => () => data.isLoading;
            Func<bool> IsMainMenuActive() => () => data.mainMenuSceneActive;
            Func<bool> IsGameLoadedAndNotStarted() => () => data.isLevelLoaded && !data.isLevelStarted;
        }


        #region IGameStateChanger

        public void StartLoadingState()
        {
            data.isLoading = true;
            data.mainMenuSceneActive = false;
            data.isLevelLoaded = false;
            data.isLevelStarted = false;
        }

        public void StartMainMenuState()
        {
            data.isLoading = false;
            data.mainMenuSceneActive = true;
        }

        public void StartBeforePlayingState()
        {
            data.isLoading = false;
            data.mainMenuSceneActive = false;
            data.isLevelLoaded = true;
            data.isLevelStarted = false;
        }

        public void StartInGameState()
        {
            data.isLoading = false;
            data.mainMenuSceneActive = false;
            data.isLevelLoaded = true;
            data.isLevelStarted = true;
        }

        public void StartLevelEndState()
        {
        }

        #endregion
    }
}
