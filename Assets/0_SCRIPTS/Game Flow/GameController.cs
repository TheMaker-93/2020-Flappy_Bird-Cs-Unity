using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameState currentGameState;
    [SerializeField] private bool isPaused;

    [SerializeField] private UnityEvent OnGameStart;
    [SerializeField] private UnityEvent OnGameplayStart;
    [SerializeField] private UnityEvent OnGameEndDefeat;
    [SerializeField] private UnityEvent OnGameEndSucces;


    private void Awake()
    {
        StartGame();
    }


    public void EndGameSucces()
    {
        SetGameState(GameState.END_BRIEFING);
        OnGameEndSucces?.Invoke();
    }
    public void EndGameInDefeat()
    {
        SetGameState(GameState.END_BRIEFING);
        OnGameEndDefeat?.Invoke();
    }

    public void StartGame ()
    {
        SetGameState(GameState.START_BRIEFING);
        OnGameStart?.Invoke();
    }
    public void StartGameplay()
    {
        SetGameState(GameState.GAMEPLAY);
        OnGameplayStart?.Invoke();
    }

    private void SetPauseState (bool _newPausedState)
    {
        this.isPaused = _newPausedState;
        if (isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    private void SetGameState (GameState _newGameState)
    {
        GameState previousGameState = currentGameState;

        switch (previousGameState)
        {
            case GameState.START_BRIEFING:

                break;
            case GameState.GAMEPLAY:


                break;
            case GameState.END_BRIEFING:


                break;
        }

        currentGameState = _newGameState;

        switch (currentGameState)
        {
            case GameState.START_BRIEFING:

                SetPauseState(false);

                break;
            case GameState.GAMEPLAY:
       
                SetPauseState(false);

                break;
            case GameState.END_BRIEFING:

                SetPauseState(true);

                break;
        }
    }



}

public enum GameState
{
    START_BRIEFING,
    GAMEPLAY,
    END_BRIEFING
}
