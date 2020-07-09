using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public MapGenerator mapGenerator;

    [Space]

    public Enemy enemy;

    [Space]

    public int enemyAmount;

    public void InstantiateEnemies()
    {
        List<int> freeSpaces = new List<int>();
        for (int i = 0; i < mapGenerator.blockAmmount.Count; i++)
        {
            if (mapGenerator.blockAmmount[i] == null)
            {
                if (i != (1 * mapGenerator.mapDepth + 1) && i != (1 * mapGenerator.mapDepth + 2) && i != (2 * mapGenerator.mapDepth + 1))
                {
                    freeSpaces.Add(i);
                }
            }
        }
        if (freeSpaces.Count / 2 < enemyAmount)
        {
            enemyAmount = freeSpaces.Count / 2;
        }

        for (int i = 0; i < enemyAmount; i++)
        {
            int aux = Random.Range(0, freeSpaces.Count - 1);
            Instantiate(enemy, new Vector3((freeSpaces[aux] / mapGenerator.mapDepth), 0.1f, freeSpaces[aux] % mapGenerator.mapDepth) - new Vector3(0, 0.1f, 0), Quaternion.identity);
            freeSpaces.RemoveAt(aux);
        }
    }
}
