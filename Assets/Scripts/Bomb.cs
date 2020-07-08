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

    ParticleSystem.MainModule mainModule;
    Color orange = new Color(1.0f, 0.47f, 0.0f);
    Renderer rend;
    float timer = 0;

    Color rayColor = Color.green;
    Vector3 horizontal;
    Vector3 vertical;

    int minExplosionH;
    int maxExplosionH;
    int minExplosionV;
    int maxExplosionV;
    bool isCreated;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        mainModule = sparks.main;
        mainModule.startColor = Color.yellow;
        sparksLight.color = Color.yellow;

        horizontal = Vector3.right;
        vertical = Vector3.forward;

        minExplosionH = -2;
        maxExplosionH = 2;
        minExplosionV = -2;
        maxExplosionV = 2;

        isCreated = false;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1 && timer < 2)
        {
            mainModule.startColor = orange;
            sparksLight.color = orange;
        }        
        if (timer > 2 && timer < 3)
        {
            mainModule.startColor = Color.red;
            sparksLight.color = Color.red;
        }
        if (timer > 3 && timer < 3.02)
        {
            StartCoroutine(Explodex());
        }
    }

    IEnumerator Explodex()
    {
        DestroyInDirection(Vector3.forward);
        DestroyInDirection(Vector3.back);
        DestroyInDirection(Vector3.right);
        DestroyInDirection(Vector3.left);

        if (!isCreated)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            PlaceSideExplosions(horizontal, minExplosionH, maxExplosionH);
            PlaceSideExplosions(vertical, minExplosionV, maxExplosionV);
            isCreated = true;
        }        

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }

    void PlaceSideExplosions(Vector3 direction, int min, int max)
    {
        for (int i = min; i <= max; i++)
        {
            if(i != 0)
            {
                Instantiate(sideExplosions,transform.position + direction * i, Quaternion.identity);
            }            
        }        
    }
    public void DestroyInDirection(Vector3 direction)
    {
        RaycastHit hit;
        int rayDistance = 2;

        if (Physics.Raycast(transform.position, direction, out hit, rayDistance, layerMask))
        {
            Debug.DrawRay(transform.position, direction * hit.distance, rayColor);
            string layerHit = LayerMask.LayerToName(hit.transform.gameObject.layer);
            Debug.Log((direction * hit.distance));
            

            switch (layerHit)
            {
                case "Breakable":
                    Destroy(hit.transform.gameObject);
                    break;

                case "Unbreakable":
                    if ((direction * hit.distance).z == -0.5f)
                    {
                        minExplosionV = 0;
                    }
                    if ((direction * hit.distance).z == 0.5f)
                    {
                        maxExplosionV = 0;
                    }
                    if ((direction * hit.distance).z == -1.5f)
                    {
                        minExplosionV = -1;
                    }
                    if ((direction * hit.distance).z == 1.5f)
                    {
                        maxExplosionV = 1;
                    }

                    if ((direction * hit.distance).x == -0.5f)
                    {
                        minExplosionH = 0;
                    }
                    if ((direction * hit.distance).x == 0.5f)
                    {
                        maxExplosionH = 0;
                    }
                    if ((direction * hit.distance).x == -1.5f)
                    {
                        minExplosionH = -1;
                    }
                    if ((direction * hit.distance).x == 1.5f)
                    {
                        maxExplosionH = 1;
                    }
                    break;

                case "Player":
                    //GameManager.gameOver = true;
                    break;
                case "Enemy":
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
