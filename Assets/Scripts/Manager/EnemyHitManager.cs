using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitManager : MonoBehaviour
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
        enemyHitCheck();
    }

    void enemyHitCheck()
    {
        if ( _gameState.enemys.Count == 0 ) return;
        int count = _gameState.enemys.Count;
        for ( int i=count-1 ; i>=0 ; i-- )
        {
            count = _gameState.enemys.Count;
            GameObject enemy = _gameState.enemys[i];
            RaycastHit hit;
            Vector3 direction = _gameState.player.transform.position - enemy.transform.position;
            if ( Physics.SphereCast(enemy.transform.position, 0.5f, direction, out hit, 0.75f, LayerMask.GetMask("PlayerObject")) )
            {

                Debug.Log("Hit");
                enemyHitPlayer(enemy, hit);
            }
            Debug.DrawRay(enemy.transform.position, direction, Color.red);
        }
    }

    void enemyHitPlayer(GameObject enemy, RaycastHit hit)
    {
        GameObject player;
        if ( hit.collider.gameObject.GetComponent<Status>() != null )
        {
            player = hit.collider.gameObject;
            if ( player != null )
            {
                _gameEvent.enemyHitPlayer?.Invoke(enemy);
            }
        }
    }
}
