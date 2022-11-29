using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;

        _gameState.startPanel.SetActive(true);
        _gameState.itemPanel.SetActive(false);
        _gameState.retryPanel.SetActive(false);
    }

    public void onUpdate()
    {
        if ( _gameState.gameStatus == GameStatus.ItemChoosing ) _gameState.itemPanel.SetActive(true);
        else if ( _gameState.gameStatus == GameStatus.GameOver ) _gameState.retryPanel.SetActive(true);
        else if ( _gameState.gameStatus == GameStatus.Ready ) _gameState.startPanel.SetActive(true);
    }

}
