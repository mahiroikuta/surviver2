using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
    }

    public void onUpdate()
    {
        playerHpBar();
        enemyHpBar();
    }

    public void playerHpBar()
    {
        HpBar playerHpBar = _gameState.player.GetComponent<HpBar>();
        Status status = _gameState.player.GetComponent<Status>();
        playerHpBar.hpBar.value = (float)status.hp / (float)status.maxHp;
    }

    public void enemyHpBar()
    {
        if ( _gameState.enemys.Count == 0 ) return;
        int count = _gameState.enemys.Count;
        Status pStatus = _gameState.player.GetComponent<Status>();
        for ( int i=count-1 ; i>=0 ; i-- )
        {
            count = _gameState.enemys.Count;
            GameObject enemy = _gameState.enemys[i];
            HpBar enemyHpBar = enemy.GetComponent<HpBar>();
            Status eStatus = enemy.GetComponent<Status>();
            enemyHpBar.hpBar.value = (float)eStatus.hp / (float)eStatus.maxHp;
        }
    }

}
