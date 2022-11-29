using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Heal,
    Split,
    BulletSpeedUp,
    Laser,
}

public abstract class Item : ScriptableObject
{
    public ItemType itemType;
    public abstract void useItem(GameEvent _gameEvent);
}
