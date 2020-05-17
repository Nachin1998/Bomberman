using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool gameOver;
    void Start()
    {
        gameOver = false;
        Instantiate(player, new Vector3(0, 0, -1), Quaternion.identity);
    }

    void Update()
    {
        if (gameOver)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
