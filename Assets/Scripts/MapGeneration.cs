using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject unbreakableWall;
    public GameObject breakableWall;
    [Space]
    public int maxBlocksX;  
    public int maxBlocksY;
    [Space]
    public int spaceBetweenXBlocks;
    public int spaceBetweenYBlocks;

    int obstacleCant = Random.Range(5, 15);
    void Start()
    {
        for (int i = 0; i < maxBlocksY; i++)
        {
            for (int j = 0; j < maxBlocksX; j++)
            {
                Instantiate(unbreakableWall, new Vector3(i * spaceBetweenYBlocks, 0, j * spaceBetweenXBlocks), Quaternion.identity);

                if(i % spaceBetweenYBlocks != 0 && j % spaceBetweenXBlocks != 0)
                {
                    Instantiate(breakableWall, new Vector3(i, 0, j), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
