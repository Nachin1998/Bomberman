using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public MapGenerator mapGenerator;
    public EnemyManager enemyManager;
    bool win;
    bool lose;

    void Start()
    {
        mapGenerator.InstantiateMap();
        enemyManager.InstantiateEnemies();
        win = false;
        lose = false;
    }

    private void Update()
    {
        if (player.hitDoor)
        {
            win = true;
        }

        if (!player && !win)
        {
            lose = true;
        }

        if (win)
        {
            SceneManager.LoadScene(2);
        }

        if (lose)
        {
            SceneManager.LoadScene(3);
        }
    }
}