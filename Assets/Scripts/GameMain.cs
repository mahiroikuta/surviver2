using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField]
    public GameState _gameState;

    public GameEvent _gameEvent;
    public GameRule _gameRule;

    public PlayerSponeManager playerSponeManager;
    public PlayerShotManager playerShotManager;
    public AttackHitManager attackHitManager;
    public HpBarManager hpBarManager;
    public EnemySponeManager enemySponeManager;
    public EnemyMoveManager enemyMoveManager;
    public EnemyHitManager enemyHitManager;
    public UIManager UIManager;
    public StatusManager statusManager;

    public StartButtonManager startButtonManager;
    public RetryButtonManager retryButtonManager;

    public HealButtonManager healButtonManager;
    public SplitButtonManager splitButtonManager;
    public BulletSpeedUpButtonManager bulletSpeedUpButtonManager;
    public LaserButtonManager laserButtonManager;
    public TargetManager targetManager;

    void Awake()
    {
        _gameState.laserOn = false;
        _gameState.charge = false;
        playerSponeManager.setUp(_gameState, _gameEvent);
        _gameRule.setUp(_gameState, _gameEvent);

        startButtonManager.setUp(_gameState, _gameEvent);
        retryButtonManager.setUp(_gameState, _gameEvent);

        healButtonManager.setUp(_gameState, _gameEvent);
        splitButtonManager.setUp(_gameState, _gameEvent);
        bulletSpeedUpButtonManager.setUp(_gameState, _gameEvent);
        laserButtonManager.setUp(_gameState, _gameEvent);
        targetManager.setUp(_gameState, _gameEvent);
    }

    void Start()
    {
        _gameState.isShooting = false;
        _gameState.gameStatus = GameStatus.Ready;
        playerShotManager.setUp(_gameState, _gameEvent);
        attackHitManager.setUp(_gameState, _gameEvent);
        hpBarManager.setUp(_gameState, _gameEvent);
        enemySponeManager.setUp(_gameState, _gameEvent);
        enemyMoveManager.setUp(_gameState, _gameEvent);
        UIManager.setUp(_gameState, _gameEvent);
        statusManager.setUp(_gameState, _gameEvent);
        enemyHitManager.setUp(_gameState, _gameEvent);
    }

    void Update()
    {
        UIManager.onUpdate();
        attackHitManager.onUpdate();
        enemyHitManager.onUpdate();
        enemyMoveManager.onUpdate();
        hpBarManager.onUpdate();
        targetManager.onUpdate();
        if ( _gameState.gameStatus == GameStatus.Retry )
        {
            Start();
            statusManager.setUp(_gameState, _gameEvent);
        }
        if ( _gameState.gameStatus != GameStatus.IsPlaying ) return;
        playerShotManager.onUpdate();
        enemySponeManager.onUpdate();
        statusManager.onUpdate();
    }
}
