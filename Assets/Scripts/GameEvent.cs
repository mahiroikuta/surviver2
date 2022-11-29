using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public Action<GameObject, GameObject> bulletHitEnemy;
    public Action<GameObject> enemyHitPlayer;
    public Action<ItemType> useItem;
}
