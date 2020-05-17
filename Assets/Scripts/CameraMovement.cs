using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float camVelocity = 60;
    Vector3 newPos;
    int objectNumber;

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            objectNumber = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            objectNumber = 2;
        }

        switch (objectNumber)
        {
            case 1:
                offset.y = player.transform.position.y - 10;
                offset.z = player.transform.position.z + 10;
                break;

            case 2:
                break;

            default:
                offset.y = player.transform.position.y - 10;
                offset.z = player.transform.position.z + 10;
                break;
        }

        newPos = player.transform.position - offset;
        //transform.position = newPos;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z - 10);
        transform.LookAt(player.transform);
        
        //transform.position = Vector3.Lerp(transform.position, newPos, camVelocity * Time.deltaTime);
    }
    void LateUpdate()
    {
        
    }
}
 