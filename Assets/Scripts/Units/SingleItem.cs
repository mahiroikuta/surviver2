using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Single", menuName="Item/Single")]
public class SingleItem : Item
{
    public override void useItem(GameEvent _gameEvent)
    {
        _gameEvent.useItem?.Invoke(itemType);
    }
}
