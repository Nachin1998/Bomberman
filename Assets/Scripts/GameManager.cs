using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static bool gameOver;
    void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        if (gameOver)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
