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
        laserHitCheck();
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
            else if ( Physics.SphereCast(playerBullet.transform.position, 0.5f, direction, out hit, 0.75f, LayerMask.GetMask("Block")) )
            {
                bulletHitBlock(playerBullet, hit);
            }
            Debug.DrawRay(playerBullet.transform.position, direction*2, Color.red, 5);
        }
    }

    void laserHitCheck()
    {
        if ( _gameState.lasers.Count == 0 ) return;
        int count = _gameState.lasers.Count;
        for ( int i=count-1 ; i>=0 ; i-- )
        {
            count = _gameState.lasers.Count;
            GameObject laser = _gameState.lasers[i];
            RaycastHit hit;
            Vector3 direction = laser.transform.position - _gameState.player.transform.position;
            if ( Physics.SphereCast(_gameState.player.transform.position, _gameState.laserScaleY, direction, out hit, laser.transform.localScale.y, LayerMask.GetMask("EnemyObject")) )
            {
                laserHitEnemy(hit);
            }
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
    }

    void laserHitEnemy(RaycastHit hit)
    {
        GameObject enemy;
        if ( hit.collider.gameObject.GetComponent<Status>() != null )
        {
            enemy = hit.collider.gameObject;
            if ( enemy != null )
            {
                _gameEvent.laserHitEnemy?.Invoke(enemy);
            }
        }
    }

    void bulletHitBlock(GameObject playerBullet, RaycastHit hit)
    {
        _gameState.playerBullets.Remove(playerBullet);
        Destroy(playerBullet.gameObject);
    }
}
