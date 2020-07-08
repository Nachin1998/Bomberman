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
    float timer = 0;
    bool bombTimer;
    Color rayColor = Color.green;

    Vector3 target;

    bool isMoving;
    bool canPlaceBomb;
    bool isAlive;
    private void Start()
    {
        target = transform.position;
        canPlaceBomb = true;
        bombTimer = false;
    }

    void Update()
    {
        if (!gameObject)
        {
            Debug.Log("DED");
        }
        if (bombTimer)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
        if (timer >= 3)
        {
            bombTimer = false;
        }

        transform.position = Vector3.Lerp(transform.position, target, playerSpeed * Time.deltaTime);

        if (transform.position == target)
        {
            isMoving = false;
        }

        DetectEntity(Vector3.forward);
        DetectEntity(Vector3.back);
        DetectEntity(Vector3.right);
        DetectEntity(Vector3.left);
    }

    void DetectEntity(Vector3 direction)
    {
        Debug.DrawRay(transform.position, direction, rayColor);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, rayDistance, layerMask))
        {
            string layerHit = LayerMask.LayerToName(hit.transform.gameObject.layer);

            switch (layerHit)
            {
                case "Exit":
                case "Enemy":
                    //GameManager.gameOver = true;
                    break;

                default:
                    break;
            }
        }
    }

    private void LateUpdate()
    {
        if (!isMoving)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (CanMove(Vector3.forward))
                {
                    MoveToDirection(Vector3.forward, 0);
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (CanMove(Vector3.back))
                {
                    MoveToDirection(Vector3.back, 180);
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (CanMove(Vector3.right))
                {
                    MoveToDirection(Vector3.right, 90);
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (CanMove(Vector3.left))
                {
                    MoveToDirection(Vector3.left, 270);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timer == 0)
            {
                Instantiate(bomb, transform.position, bomb.transform.rotation);
                bombTimer = true;
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

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Bruh");
    }
}
