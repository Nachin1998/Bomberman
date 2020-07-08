using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject ground;
    public GameObject breakableWall;
    public GameObject unbreakableWall;
    public GameObject exitDoor;

    [Space]

    public int mapWidth;
    public int mapDepth;

    bool doorCreated = false;

    [HideInInspector] public List<GameObject> blockAmmount = new List<GameObject>();

    public void InstantiateMap()
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapDepth; j++)
            {
                int blockState = Random.Range(1, 4);

                if ((i % 2 == 0 && (j + 1) % 2 != 0))
                {
                    blockState = 0;
                }
                else if (i % mapWidth == 0 || (i + 1) % mapWidth == 0 ||
                         j % mapDepth == 0 || (j + 1) % mapDepth == 0)
                {
                    blockState = 0;
                }

                if ((i == 1 && j == 1) || (i == 2 && j == 1) || i == 1 && j == 2)
                {
                    blockState = 2;
                }

                if (blockState == 1 && !doorCreated && Random.Range(0, 7) == 0)
                {
                    Instantiate(exitDoor, new Vector3(i, 0, j), Quaternion.identity, transform);
                    doorCreated = true;
                }

                switch (blockState)
                {
                    case 0:
                        blockAmmount.Add(Instantiate(unbreakableWall, new Vector3(i, 0, j), Quaternion.identity, transform));
                        break;
                    case 1:
                        blockAmmount.Add(Instantiate(breakableWall, new Vector3(i, 0, j), Quaternion.identity, transform));
                        break;
                    case 2:
                    case 3:
                        blockAmmount.Add(null);
                        break;
                }
            }
        }

        ground.transform.localScale = new Vector3(mapWidth - 1, 0.1f, mapDepth - 1);
        Instantiate(ground, new Vector3(mapWidth / 2, -0.5f, mapDepth / 2), Quaternion.identity, gameObject.transform);
    }
}