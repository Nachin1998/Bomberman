using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public int enemyCurrentAmount = 0;
    public int enemyTargetAmount;

    GameObject map;

    void Start()
    {
        map = mapGenerator.GetComponent<GameObject>();
    }
    
    void InstantiateEnemies()
    {
        List<int> freeSpaces = new List<int>();
        for (int i = 0; i < mapGenerator.blockAmmount.Count; i++)
        {
            if (mapGenerator.blockAmmount[i] == null)
            {
                if (i != (1 * mapGenerator.mapDepth + 1) && i != (1 * mapGenerator.mapDepth + 2) && i != (2 * mapGenerator.mapDepth + 1))
                    freeSpaces.Add(i);
            }
        }
        if (freeSpaces.Count / 2 < enemyTargetAmount) enemyTargetAmount = freeSpaces.Count / 2;
        for (int i = 0; i < enemyTargetAmount; i++)
        {
            int aux = Random.Range(0, freeSpaces.Count - 1);
            GameObject go = Instantiate(gameObject, new Vector3(freeSpaces[aux] / mapGenerator.mapDepth, 1, (freeSpaces[aux] % mapGenerator.mapDepth) + 1), Quaternion.identity, map.transform);
            enemyCurrentAmount++;
            //go.GetComponent<Enemy>().updateEnemyAmount = SubtractEnemyAmount;
            freeSpaces.RemoveAt(aux);
        }
    }
}
