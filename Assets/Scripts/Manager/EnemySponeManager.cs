using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySponeManager : MonoBehaviour
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
        _gameState.elapsedTime += Time.deltaTime;
        if ( _gameState.elapsedTime >= _gameState.enemySponeTime )
        {
            enemySpone();
            _gameState.elapsedTime = 0;
        }
    }

    public void enemySpone()
    {
        Vector3 sponePos = getSponePos();
        GameObject enemy = GameObject.Instantiate(_gameState.enemy, sponePos, Quaternion.identity) as GameObject;
        Status eStatus = enemy.GetComponent<Status>();
        makeStatus(eStatus);
        _gameState.enemys.Add(enemy);
    }

    Vector3 getSponePos()
    {
        int num = Random.Range(1,5);
        float x = 0f;
        float y = 0f;
        float z = 0f;
        switch ( num )
        {
            case 1:
                x = 14f;
                y = Random.Range(-8f, 8f);
                break;
            case 2:
                x = -14f;
                y = Random.Range(-8f, 8f);
                break;
            case 3:
                x = Random.Range(-14f, 14f);
                y = 8f;
                break;
            case 4:
                x = Random.Range(-14f, 14f);
                y = -8f;
                break;
        }
        Vector3 pos = new Vector3(x, y, z);
        return pos;
    }

    void makeStatus(Status eStatus)
    {
        Status pStatus = _gameState.player.GetComponent<Status>();
        int level = Random.Range(1, System.Math.Min(3, pStatus.level)+1);
        switch ( level )
        {
            case 1:
                eStatus.level = level;
                eStatus.maxHp = 10;
                eStatus.hp = eStatus.maxHp;
                eStatus.atk = 5;
                eStatus.bulletSpeed = 1;
                eStatus.moveSpeed = 1;
                break;
            case 2:
                eStatus.level = level;
                eStatus.maxHp = 45;
                eStatus.hp = eStatus.maxHp;
                eStatus.atk = 10;
                eStatus.bulletSpeed = 2;
                eStatus.moveSpeed = 2;
                break;
            case 3:
                eStatus.level = level;
                eStatus.maxHp = 135;
                eStatus.hp = eStatus.maxHp;
                eStatus.atk = 15;
                eStatus.bulletSpeed = 14;
                eStatus.moveSpeed = 1;
                break;
        }
    }
}
