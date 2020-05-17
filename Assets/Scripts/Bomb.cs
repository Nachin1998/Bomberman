using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //public GameObject explosion;
    public Material[] materials;
    public LayerMask layerMask;

    [HideInInspector]public int bombCounter;

    Renderer rend;
    float timer = 0;

    Color rayColor = Color.green;
    int rayDistance = 2;
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        bombCounter = 0;
    }

    void Update()
    {
        ActivateBomb();
    }
    public void ActivateBomb()
    {
        timer += Time.deltaTime;
        if (timer < 1)
        {
            rend.material = materials[0];
        }
        if (timer > 1 && timer < 2)
        {
            rend.material = materials[1];
        }
        if (timer > 2 && timer < 3)
        {
            rend.material = materials[2];
        }
        if (timer > 3 && timer < 3.1)
        {
            Explode();
        }
        if(timer > 3.1)
        {
            bombCounter--;
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        CanDestroyInDirection(Vector3.forward);
        CanDestroyInDirection(Vector3.back);
        CanDestroyInDirection(Vector3.right);
        CanDestroyInDirection(Vector3.left);
    }

    public void CanDestroyInDirection(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, rayDistance, layerMask))
        {
            Debug.DrawRay(transform.position, direction * hit.distance, rayColor);

            string layerHit = LayerMask.LayerToName(hit.transform.gameObject.layer);

            switch (layerHit)
            {
                case "Unbreakable":                    
                    break;

                case "Breakable":
                    Destroy(hit.transform.gameObject);
                    break;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, direction * rayDistance, rayColor);
        }
    }
}
