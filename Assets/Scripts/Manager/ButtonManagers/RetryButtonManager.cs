using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButtonManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        _gameState.retryButton.onClick.AddListener(retry);
    }

    void retry()
    {
        _gameState.gameStatus = GameStatus.Retry;
        _gameEvent.retry?.Invoke();
        _gameState.retryPanel.SetActive(false);
    }
}
