﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    int input;

    void Update()
    {    
        switch (input)
        { 
            case 2:
                transform.position = player.transform.position; //not complete
                break;
            case 1:
            default:
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z - 10);
                break;
        }

        transform.LookAt(player.transform);
    }
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            input = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            input = 2;
        }
    }
}
 