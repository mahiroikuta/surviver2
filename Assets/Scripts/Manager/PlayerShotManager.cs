using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotManager : MonoBehaviour
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
        if ( Input.GetMouseButtonDown(0) ) shot();
    }

    void shot()
    {
        if ( _gameState.isShooting ) return;
        Vector3 shotForward = getShotForward();

        _gameState.isShooting = true;
        StartCoroutine("shotDelay", shotForward);
    }

    IEnumerator shotDelay(Vector3 shotForward)
    {
        Status status = _gameState.player.GetComponent<Status>();
        float startAngle = getAngle(status.splitLevel);
        for ( int i=0 ; i<=status.splitLevel ; i++ )
        {
            Quaternion angle = Quaternion.Euler(0f, 0f, startAngle - (15*i));
            Vector3 splitForward = angle * shotForward;
            GameObject playerBullet = GameObject.Instantiate(_gameState.playerBullet, _gameState.player.transform.position, Quaternion.identity) as GameObject;
            _gameState.playerBullets.Add(playerBullet);
            Rigidbody rig = playerBullet.GetComponent<Rigidbody>();
            rig.velocity = splitForward * status.bulletSpeed;
        }
        yield return new WaitForSeconds(1f/(float)status.level);
        _gameState.isShooting = false;
    }

    Vector3 getShotForward()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 14.7f;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 shotForward = Vector3.Scale((mouseWorldPos - _gameState.player.transform.position), new Vector3(1, 1, 0)).normalized;
        return shotForward;
    }

    float getAngle(int splitLevel)
    {
        return 7.5f*(float)splitLevel;
    }
}
