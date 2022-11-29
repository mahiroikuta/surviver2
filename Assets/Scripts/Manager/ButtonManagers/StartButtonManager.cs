using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        _gameState.startButton.onClick.AddListener(startGame);
    }

    void startGame()
    {
        _gameState.gameStatus = GameStatus.IsPlaying;
        _gameState.startPanel.SetActive(false);
    }
}
