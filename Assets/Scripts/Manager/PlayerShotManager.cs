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
        if ( _gameState.laserOn ) shotLaser();
        else
        {
            if ( Input.GetMouseButtonDown(0) ) shot();
            _gameState.useLaserTime -= Time.deltaTime;
            if ( _gameState.useLaserTime <= 0 ) _gameState.laserOn = false;
        }
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

    void shotLaser()
    {
        if ( _gameState.isLasering ) return;
        if ( Input.GetMouseButton(0) && _gameState.chargeTime <= 3 )
        {
            _gameState.charge = true;
            _gameState.chargeTime += Time.deltaTime;
        }
        else if ( _gameState.charge )
        {
            _gameState.isLasering = true;
            GameObject laserCenter = GameObject.Instantiate(_gameState.laserCenter, _gameState.player.transform.position, Quaternion.identity) as GameObject;
            GameObject laser = laserCenter.transform.Find("Laser").gameObject;
            laserScale(laser, _gameState.chargeTime);
            laserPosition(laser, _gameState.chargeTime);
            laserCenter.gameObject.transform.LookAt(_gameState.target.transform);
            _gameState.lasers.Add(laser);
            StartCoroutine(lasering(_gameState.laseringTime, laser));
            _gameState.chargeTime = 0;
            _gameState.charge = false;
        }
    }

    void laserScale(GameObject laser, float chargeTime)
    {
        _gameState.laserScaleY = chargeTime * 5;
        laser.transform.localScale =  new Vector3(0.8f, _gameState.laserScaleY, 0.8f);
    }

    void laserPosition(GameObject laser, float chargeTime)
    {
        float laserPosZ = chargeTime * 5 + 1;
        laser.transform.position =  new Vector3(0f, 0f, laserPosZ);
    }

    IEnumerator lasering(float time, GameObject laser)
    {
        yield return new WaitForSeconds(time);
        _gameState.lasers.Remove(laser);
        Destroy(laser.gameObject);
        _gameState.isLasering = false;
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
