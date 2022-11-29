using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitButtonManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        _gameState.splitButton.onClick.AddListener(split);
    }

    void split()
    {
        _gameEvent.useItem?.Invoke(ItemType.Split);
    }
}
