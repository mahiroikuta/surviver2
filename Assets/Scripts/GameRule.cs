using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;

        _gameEvent.bulletHitEnemy += damageEnemy;

        _gameEvent.useItem += useItem;

        _gameEvent.enemyHitPlayer += damagePlayer;

        _gameEvent.retry += reset;
    }

    void damageEnemy(GameObject playerBullet, GameObject enemy)
    {
        Status pStatus = _gameState.player.GetComponent<Status>();
        Status eStatus = enemy.GetComponent<Status>();
        eStatus.hp -= pStatus.atk;
        _gameState.playerBullets.Remove(playerBullet);
        Destroy(playerBullet.gameObject);
        if ( eStatus.hp <= 0 )
        {
            _gameState.enemys.Remove(enemy);
            Destroy(enemy.gameObject);
            pStatus.exp += 1;
        }
    }

    void damagePlayer(GameObject enemy)
    {
        Status pStatus = _gameState.player.GetComponent<Status>();
        Status eStatus = enemy.GetComponent<Status>();
        pStatus.hp -= eStatus.atk;
        _gameState.enemys.Remove(enemy);
        Destroy(enemy.gameObject);
        if ( pStatus.hp <= 0 )
        {
            _gameState.gameStatus = GameStatus.GameOver;
        }
    }

    void useItem(ItemType itemType)
    {
        Status pStatus = _gameState.player.GetComponent<Status>();
        switch ( itemType )
        {
            case ItemType.Heal:
                pStatus.hp += pStatus.maxHp/3;
                if ( pStatus.hp > pStatus.maxHp ) pStatus.hp = pStatus.maxHp;
                break;
            case ItemType.Split:
                pStatus.splitLevel += 1;
                break;
            case ItemType.BulletSpeedUp:
                pStatus.bulletSpeed += 1;
                break;
            case ItemType.Laser:
                _gameState.laserOn = true;
                break;
        }
        _gameState.gameStatus = GameStatus.IsPlaying;
        _gameState.itemPanel.SetActive(false);
    }

    void reset()
    {
        int enemyCount = _gameState.enemys.Count;
        for ( int i=enemyCount-1 ; i>=0 ; i-- )
        {
            enemyCount = _gameState.enemys.Count;
            GameObject enemy = _gameState.enemys[i];
            _gameState.enemys.Remove(enemy);
            Destroy(enemy.gameObject);
        }
        int bulletCount = _gameState.playerBullets.Count;
        for ( int i=bulletCount-1 ; i>=0 ; i-- )
        {
            bulletCount = _gameState.playerBullets.Count;
            GameObject playerBullet = _gameState.playerBullets[i];
            _gameState.playerBullets.Remove(playerBullet);
            Destroy(playerBullet.gameObject);
        }
    }
}
