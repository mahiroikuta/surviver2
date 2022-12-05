using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStatus
{
    Ready,
    IsPlaying,
    ItemChoosing,
    GameOver,
    Retry,
}

[System.Serializable]
public class GameState
{
    public GameObject player;
    public GameObject playerBullet;
    public GameObject laserCenter;
    public GameObject target;

    public GameObject enemy;
    public GameObject splitEnemy;
    public GameObject splitChild;

    public int enemySponeTime;
    public float elapsedTime;
    public float chargeTime;
    public float laseringTime;
    public float useLaserTime;

    public float laserScaleY;

    public Button healButton;
    public Button splitButton;
    public Button bulletSpeedUpButton;
    public Button laserButton;
    public Button homingButton;

    public Button startButton;
    public Button retryButton;

    public GameObject startPanel;
    public GameObject itemPanel;
    public GameObject retryPanel;

    [System.NonSerialized]
    public GameStatus gameStatus;
    [System.NonSerialized]
    public bool isShooting;
    [System.NonSerialized]
    public bool isLasering;
    [System.NonSerialized]
    public bool laserOn;
    [System.NonSerialized]
    public bool charge;
    [System.NonSerialized]
    public bool splited;


    [System.NonSerialized]
    public List<GameObject> playerBullets = new List<GameObject>();

    [System.NonSerialized]
    public List<GameObject> lasers = new List<GameObject>();

    [System.NonSerialized]
    public List<GameObject> enemys = new List<GameObject>();

    [System.NonSerialized]
    public List<GameObject> splitEnemys = new List<GameObject>();
}
