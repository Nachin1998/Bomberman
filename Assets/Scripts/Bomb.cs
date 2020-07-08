using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    public GameObject sideExplosions;
    
    [Space]

    public ParticleSystem sparks;    
    public Light sparksLight;  
    
    [Space]

    public LayerMask layerMask;

    Color orange = new Color(1.0f, 0.47f, 0.0f);
    Renderer rend;
    float timer = 0;

    Color rayColor = Color.green;    

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        sparks.startColor = Color.yellow;
        sparksLight.color = Color.yellow;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1 && timer < 2)
        {
            sparks.startColor = orange;
            sparksLight.color = orange;
        }        
        if (timer > 2 && timer < 3)
        {
            sparks.startColor = Color.red;
            sparksLight.color = Color.red;
        }
        if (timer > 3 && timer < 3.1)
        {
            Explode();
        }
        if (timer > 3.1)
        {
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        DestroyInDirection(Vector3.forward);
        DestroyInDirection(Vector3.back);
        DestroyInDirection(Vector3.right);
        DestroyInDirection(Vector3.left);

        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(sideExplosions, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);      //
        Instantiate(sideExplosions, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.identity);      //
        Instantiate(sideExplosions, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);      //
        Instantiate(sideExplosions, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), Quaternion.identity);      //
        Instantiate(sideExplosions, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);      //Bruh
        Instantiate(sideExplosions, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), Quaternion.identity);      //
        Instantiate(sideExplosions, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);      //
        Instantiate(sideExplosions, new Vector3(transform.position.x, transform.position.y, transform.position.z - 2), Quaternion.identity);      //
    }

    public void DestroyInDirection(Vector3 direction)
    {
        RaycastHit hit;
        int rayDistance = 2;

        if (Physics.Raycast(transform.position, direction, out hit, rayDistance, layerMask))
        {
            Debug.DrawRay(transform.position, direction * hit.distance, rayColor);
            string layerHit = LayerMask.LayerToName(hit.transform.gameObject.layer);

            switch (layerHit)
            {
                case "Breakable":
                    Destroy(hit.transform.gameObject);
                    break;

                case "Player":
                    //GameManager.gameOver = true;
                    break;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, direction * rayDistance, rayColor);
        }
    }
}
