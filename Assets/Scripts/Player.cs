using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Bomb bomb;
    private MapGeneration mapGeneration;
    private Rigidbody rb;
    private Transform myTransform;

    public LayerMask layerMask;

    int rayDistance = 1;
    Color rayColor = Color.green;

    Vector3 forward = Vector3.forward;
    Vector3 back = Vector3.back;
    Vector3 right = Vector3.right;
    Vector3 left = Vector3.left;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myTransform = transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (CanMove(forward))
            {
                myTransform.position = transform.position + forward;
                myTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (CanMove(back))
            {
                myTransform.position = transform.position + back;
                myTransform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (CanMove(right))
            {
                myTransform.position = transform.position + right;
                myTransform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (CanMove(left))
            {
                myTransform.position = transform.position + left;
                myTransform.rotation = Quaternion.Euler(0, 270, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
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

            switch (layerHit)
            {
                case "Unbreakable":
                case "Breakable":
                case "Edge":
                case "Bomb":
                    return false;

                default:
                    return true;
            }
        }
        else
        {
            return true;
        }
    }
}
