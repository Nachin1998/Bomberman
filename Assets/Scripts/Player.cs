using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bomb bomb;
    private MapGenerator mapGenerator;
    public float playerSpeed;

    public LayerMask layerMask;

    int rayDistance = 1;
    Color rayColor = Color.green;

    Vector3 target;
    Vector3 forward = Vector3.forward;
    Vector3 back = Vector3.back;
    Vector3 right = Vector3.right;
    Vector3 left = Vector3.left;
    
    bool isMoving;

    private void Start()
    {
        target = transform.position;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, playerSpeed * Time.deltaTime);

        if (transform.position == target)
        {
            isMoving = false;
        }

        Debug.DrawRay(transform.position, forward, rayColor);
        Debug.DrawRay(transform.position, right, rayColor);
        Debug.DrawRay(transform.position, left, rayColor);
        Debug.DrawRay(transform.position, back, rayColor);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, forward, out hit, rayDistance, layerMask) ||
            Physics.Raycast(transform.position, back, out hit, rayDistance, layerMask) ||
            Physics.Raycast(transform.position, right, out hit, rayDistance, layerMask) ||
            Physics.Raycast(transform.position, left, out hit, rayDistance, layerMask))
        {
            string layerHit = LayerMask.LayerToName(hit.transform.gameObject.layer);

            switch (layerHit)
            {
                case "Exit":
                    GameManager.gameOver = true;
                    break;

                default:
                    break;
            }
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (!isMoving)
            {
                if (CanMove(forward))
                {
                    MoveToDirection(forward, 0);
                }
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (!isMoving)
            {
                if (CanMove(back))
                {
                    MoveToDirection(back, 180);
                }
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!isMoving)
            {
                if (CanMove(right))
                {
                    MoveToDirection(right, 90);
                }
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (!isMoving)
            {
                if (CanMove(left))
                {
                    MoveToDirection(left, 270);
                }
            }
        }

        if(Bomb.bombCounter < 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bomb, Vector3Int.RoundToInt(transform.position), Quaternion.identity);
                Bomb.bombCounter += 1;
            }
        }
        
    }

    void MoveToDirection(Vector3 direction, float rotation)
    {
        target = transform.position + direction;
        transform.rotation = Quaternion.Euler(0, rotation, 0);
        isMoving = true;
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
