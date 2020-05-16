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
    public LayerMask layerMask;

    float t = 1;
    int rayDistance = 1;
    Color rayColor = Color.green;

    Vector3 goForward = Vector3.forward;
    Vector3 goBack = Vector3.back;
    Vector3 goRight = Vector3.right;
    Vector3 goLeft = Vector3.left;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myTransform = transform;
    }
    void Update()
    {
        t += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.W))
        {
            if (CanMove(goForward))
            {
                myTransform.position = transform.position + goForward;
                myTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (CanMove(goBack))
            {
                myTransform.position = transform.position + goBack;
                myTransform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (CanMove(goRight))
            {
                myTransform.position = transform.position + goRight;
                myTransform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (CanMove(goLeft))
            {
                myTransform.position = transform.position + goLeft;
                myTransform.rotation = Quaternion.Euler(0, 270, 0);
            }
        }        

        Debug.DrawRay(transform.position, Vector3.forward, rayColor);
        Debug.DrawRay(transform.position, Vector3.right, rayColor);
        Debug.DrawRay(transform.position, Vector3.left, rayColor);
        Debug.DrawRay(transform.position, Vector3.back, rayColor);
    }

    public bool CanMove(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, rayDistance, layerMask))
        {
            string layerHit = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHit == "Unbreakable" ||
                layerHit == "Edge")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }
}
