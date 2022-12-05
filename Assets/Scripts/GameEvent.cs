using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public Action<GameObject, GameObject> bulletHitEnemy;
    public Action<GameObject, GameObject> bulletHitSplitEnemy;
    public Action<GameObject> laserHitEnemy;
    public Action<GameObject> enemyHitPlayer;
    public Action<ItemType> useItem;

    public Action retry;
}
