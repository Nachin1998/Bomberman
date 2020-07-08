using UnityEngine;

public class Enemy : MonoBehaviour
{    public enum EnemyDirection
    {
        Forward,
        Right,
        Backward,
        Left,
        Search
    }

    public EnemyDirection enemyDirection;

    public float movementSpeed;
    public float rayDistance;
    public LayerMask layerMask;

    Rigidbody rb;
    Vector3 movement;

    Color rayColor;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        movement = Vector3.zero;

        enemyDirection = EnemyDirection.Forward;

        rayColor = Color.blue;
    }

    void FixedUpdate()
    {
        switch (enemyDirection)
        {
            case EnemyDirection.Forward:
                if (CanMove(Vector3.forward))
                {
                    MoveTowards(Vector3.forward);
                }
                else
                {
                    ChangeState();
                }
                break;
            case EnemyDirection.Right:
                if (CanMove(Vector3.right))
                {
                    MoveTowards(Vector3.right);
                }
                else
                {
                    ChangeState();
                }
                break;
            case EnemyDirection.Backward:
                if (CanMove(Vector3.back))
                {
                    MoveTowards(Vector3.back);
                }
                else
                {
                    ChangeState();
                }
                break;
            case EnemyDirection.Left:
                if (CanMove(Vector3.left))
                {
                    MoveTowards(Vector3.left);
                }
                else
                {
                    ChangeState();
                }
                break;
        }
    }

    public void MoveTowards(Vector3 direction)
    {
        transform.LookAt(transform.position + direction);
        movement = direction * movementSpeed * Time.deltaTime;
        rb.velocity += movement;
    }

    void ChangeState()
    {
        int randState;
        do
        {
            randState = Random.Range(0, (int)EnemyDirection.Search);
        }
        while (randState == (int)enemyDirection);

        randState = randState % ((int)EnemyDirection.Search);
        enemyDirection = ((EnemyDirection)randState);
    }

    bool CanMove(Vector3 direction)
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, direction, out hit, rayDistance, layerMask))
        {
            Debug.DrawRay(transform.position, direction * rayDistance, Color.green);
            return true;
        }
        else
        {
            rb.velocity = Vector3.zero;
            Debug.DrawRay(transform.position, direction * hit.distance, Color.red);
            return false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Destroy(col.gameObject);
        }
    }
}
