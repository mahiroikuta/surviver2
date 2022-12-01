using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
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
        if ( Input.GetMouseButtonUp(0) )
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 14.7f;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
            _gameState.target.transform.position = mouseWorldPos;
        }
    }
}
