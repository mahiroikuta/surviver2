using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveManager : MonoBehaviour
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
        enemyMove();
    }

    void enemyMove()
    {
        if ( _gameState.enemys.Count == 0 ) return;
        int count = _gameState.enemys.Count;
        for ( int i=count-1 ; i>=0 ; i-- )
        {
            count = _gameState.enemys.Count;
            GameObject enemy = _gameState.enemys[i];
            Status eStatus = enemy.GetComponent<Status>();
            Rigidbody eRig = enemy.GetComponent<Rigidbody>();
            float speed = (float)eStatus.moveSpeed/3;
            // enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, _gameState.player.transform.position, speed);
            Vector3 vec = (_gameState.player.transform.position - enemy.transform.position).normalized;
            if ( _gameState.gameStatus == GameStatus.ItemChoosing )
            {
                eRig.velocity = vec * 0f;
                continue;
            }
            eRig.velocity = vec * speed;
        }
    }
}
