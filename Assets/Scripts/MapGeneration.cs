using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public enum MapSize{
        Small,
        Medium,
        Large
    };

    public MapSize mapSize = MapSize.Small;
    [Space]
    public GameObject player;
    [Space]
    public GameObject unbreakableWall;
    public GameObject breakableWall;
    [Space]
    public GameObject smallMap;
    public GameObject mediumMap;
    public GameObject largeMap;

    [HideInInspector] public GameObject actualMap;

    int spaceFix = 1;
    int maxBlocksX;
    int maxBlocksY;
    int spaceBetweenXBlocks = 2;
    int spaceBetweenYBlocks = 2;

    int obstacleCant;
    void Start()
    {
        switch (mapSize)
        {
            case MapSize.Small:
                maxBlocksX = 5;
                maxBlocksY = 9;
                obstacleCant = Random.Range(5, 10);
                actualMap = smallMap;
                break;

            case MapSize.Medium:
                maxBlocksX = 9;
                maxBlocksY = 13;
                obstacleCant = Random.Range(10, 15);
                actualMap = mediumMap;
                break;

            case MapSize.Large:
                maxBlocksX = 13;
                maxBlocksY = 17;
                obstacleCant = Random.Range(12, 20);
                actualMap = largeMap;
                break;

            default:
                break;
        }

        Instantiate(actualMap);

        for (int i = 0; i < maxBlocksY; i++)
        {
            for (int j = 0; j < maxBlocksX; j++)
            {
                if(j % 2 == 1 && i % 2 == 1)
                {
                    Instantiate(breakableWall, new Vector3((i * spaceBetweenYBlocks) - ((maxBlocksY * spaceBetweenYBlocks) / 2) + spaceFix, 0, (j * spaceBetweenXBlocks) - ((maxBlocksX * spaceBetweenXBlocks) / 2) + spaceFix), Quaternion.identity);
                }
                /*if(i % spaceBetweenYBlocks != 0 && j % spaceBetweenXBlocks != 0)
                {
                    for (int k = 0; k < obstacleCant; k++)
                    {
                        Instantiate(breakableWall, new Vector3(i, 0, j), Quaternion.identity);
                    }                   
                }*/
            }
        }
    }
}
