using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitManager : MonoBehaviour
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
        bulletHitCheck();
    }

    void bulletHitCheck()
    {
        if ( _gameState.playerBullets.Count == 0 ) return;
        int count = _gameState.playerBullets.Count;
        Status pStatus = _gameState.player.GetComponent<Status>();
        for ( int i=count-1 ; i>=0 ; i-- )
        {
            count = _gameState.playerBullets.Count;
            GameObject playerBullet = _gameState.playerBullets[i];
            RaycastHit hit;
            Vector3 direction = playerBullet.transform.position - _gameState.player.transform.position;
            if ( Physics.SphereCast(playerBullet.transform.position, 0.5f, direction, out hit, 0.75f, LayerMask.GetMask("EnemyObject")) )
            {
                bulletHitEnemy(playerBullet, hit);
            }
            Debug.DrawRay(playerBullet.transform.position, direction, Color.red);
        }
    }

    void bulletHitEnemy(GameObject playerBullet, RaycastHit hit)
    {
        GameObject enemy;
        if ( hit.collider.gameObject.GetComponent<Status>() != null )
        {
            enemy = hit.collider.gameObject;
            if ( enemy != null )
            {
                _gameEvent.bulletHitEnemy?.Invoke(playerBullet, enemy);
            }
        }
        else
        {
            _gameState.playerBullets.Remove(playerBullet);
            Destroy(playerBullet.gameObject);
        }
    }
}
