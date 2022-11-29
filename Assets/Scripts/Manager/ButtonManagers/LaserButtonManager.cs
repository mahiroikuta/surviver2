using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserButtonManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        _gameState.laserButton.onClick.AddListener(laser);
    }

    void laser()
    {
        _gameEvent.useItem?.Invoke(ItemType.Laser);
    }
}
