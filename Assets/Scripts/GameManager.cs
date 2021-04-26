using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject queen;
    public AntsManager antManager;

    float _prevTimeScale = 1;
    GameState gameState = GameState.MenuScreen;
    //public ants manager
    //pubilc enemies manager
    //public food manager
    //public scene manager

    private void Awake()
    {
        instance = this;
        PauseGame();
    }

    public void PlayGame()
    {
        if(gameState == GameState.GameScreen)
            Time.timeScale = _prevTimeScale;
    }

    public void SetMenuScreenGameState()
    {
        gameState = GameState.MenuScreen;
    }

    public void SetGameScreenGameState()
    {
        gameState = GameState.GameScreen;
    }

    public void PauseGame()
    {
        _prevTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public enum GameState
    {
        MenuScreen,
        GameScreen,
    }
}
