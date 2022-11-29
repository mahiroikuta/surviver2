using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedUpButtonManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        _gameState.bulletSpeedUpButton.onClick.AddListener(bulletSpeedUp);
    }

    void bulletSpeedUp()
    {
        _gameEvent.useItem?.Invoke(ItemType.BulletSpeedUp);
    }
}
