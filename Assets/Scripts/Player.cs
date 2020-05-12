using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private MapGeneration mapGeneration;
    private Rigidbody rb;
    private Transform myTransform;

    public GameObject bomb;
    int speed = 1;

    float t = 1;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        target = startPosition;
        myTransform = transform;
    }
    void Update()
    {
        t += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W))
        {
            //target = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            //transform.position = Vector3.Lerp(transform.position, target, t);
            target = transform.position + Vector3.forward;
            if (CanMove(target))
            {
                myTransform.position = target * speed;
                myTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            myTransform.position = transform.position + Vector3.left * speed;
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            myTransform.position = transform.position + Vector3.back * speed;
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            myTransform.position = transform.position + Vector3.right * speed;
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    public bool CanMove(Vector3 nextPosition)
    {
        if(mapGeneration.unbreakableWall.transform.position == nextPosition)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
