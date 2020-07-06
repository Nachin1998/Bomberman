using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public MapGenerator mapGenerator;
    public Enemy enemy;
    public static bool gameOver;

    void Start()
    {
        gameOver = false;
        Instantiate(mapGenerator);
        mapGenerator.InstantiateMap();
    }

    void Update()
    {
        if (gameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
