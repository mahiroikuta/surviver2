using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;

        initializeStatus();
    }

    public void onUpdate()
    {
        levelUp();
    }

    void levelUp()
    {
        Status pStatus = _gameState.player.GetComponent<Status>();
        if ( pStatus.exp < pStatus.level*3 ) return;
        pStatus.level += 1;
        pStatus.maxHp += 50;
        pStatus.hp += 50;
        pStatus.atk += 5;
        pStatus.bulletSpeed += 2;
        pStatus.moveSpeed += 1;
        pStatus.exp = 0;
        _gameState.gameStatus = GameStatus.ItemChoosing;
    }

    void initializeStatus()
    {
        Status pStatus = _gameState.player.GetComponent<Status>();
        HpBar playerHpBar = _gameState.player.GetComponent<HpBar>();
        pStatus.level = 1;
        pStatus.maxHp = 50;
        pStatus.hp = 50;
        pStatus.atk = 5;
        pStatus.bulletSpeed = 5;
        pStatus.moveSpeed = 1;
        pStatus.exp = 0;
        playerHpBar.hpBar.value = 1;
    }
}
