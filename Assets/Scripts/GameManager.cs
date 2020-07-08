using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public EnemyManager enemyManager;

    void Start()
    {
        mapGenerator.InstantiateMap();
        enemyManager.InstantiateEnemies();
    }
}