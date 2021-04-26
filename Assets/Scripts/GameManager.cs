using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Cinemachine.CinemachineVirtualCamera cvc;
    public static GameManager instance;
    public GameObject queen;
    public AntsManager antManager;
    [SerializeField] global_selection selectionManager;
    public UIScript UIScript;
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
    private void OnEnable()
    {
        instance = this;
    }

    public void PlayGame()
    {
        if (gameState == GameState.GameScreen)
        {
            cvc.enabled = true;
            Time.timeScale = _prevTimeScale;
            selectionManager.enabled = true;
        }
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
        cvc.enabled = false;
        selectionManager.enabled = false;
        Time.timeScale = 0;
    }

    public enum GameState
    {
        MenuScreen,
        GameScreen,
    }

    public void Restart()
    {
        Time.timeScale = _prevTimeScale;
        Pool.pools = new Dictionary<PooledMonobehaviour, Pool>();
        SceneManager.LoadScene("SampleScene");
    }
}
