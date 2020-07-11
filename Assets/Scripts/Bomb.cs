using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explotion;
    public List<GameObject> sideExplosions;
    public GameObject sideExplotion;
    ParticleSystem[] explosionAmmount;

    [Space]

    public ParticleSystem sparks;
    public Light sparksLight;

    [Space]

    public LayerMask layerMask;

    ParticleSystem.MainModule mainModule;

    Color orange = new Color(1.0f, 0.47f, 0.0f);

    Vector3 horizontal;
    Vector3 vertical;

    int minExplosionH;
    int maxExplosionH;
    int minExplosionV;
    int maxExplosionV;

    float timer;

    bool isCreated;
    public bool hitPlayer = false;

    void Start()
    {
        mainModule = sparks.main;

        horizontal = Vector3.right;
        vertical = Vector3.forward;

        minExplosionH = -2;
        maxExplosionH = 2;
        minExplosionV = -2;
        maxExplosionV = 2;

        timer = 0;

        isCreated = false;
        hitPlayer = false;
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer < 1)
        {
            mainModule.startColor = Color.yellow;
            sparksLight.color = Color.yellow;
        }
        else if (timer > 1 && timer < 2)
        {
            mainModule.startColor = orange;
            sparksLight.color = orange;
        }
        else if (timer > 2 && timer < 3)
        {
            mainModule.startColor = Color.red;
            sparksLight.color = Color.red;
        }
        else if (timer > 3)
        {
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        DestroyInDirection(Vector3.forward);
        DestroyInDirection(Vector3.back);
        DestroyInDirection(Vector3.right);
        DestroyInDirection(Vector3.left);
        yield return new WaitForSeconds(0.1f);
        if (!isCreated)
        {
            Instantiate(explotion, transform.position, Quaternion.identity);
            InstantiateExplosions(horizontal, minExplosionH, maxExplosionH);
            InstantiateExplosions(vertical, minExplosionV, maxExplosionV);
            isCreated = true;
        }
        Destroy(gameObject);

    }

    void InstantiateExplosions(Vector3 direction, int min, int max)
    {
        for (int i = min; i <= max; i++)
        {
            if (i != 0)
            {
                Instantiate(sideExplotion, transform.position + direction * i, Quaternion.identity);
            }
        }
    }
    public void DestroyInDirection(Vector3 direction)
    {
        RaycastHit hit;
        int rayDistance = 2;
        Color rayColor = Color.green;

        if (Physics.Raycast(transform.position, direction, out hit, rayDistance, layerMask))
        {
            Debug.DrawRay(transform.position, direction * hit.distance, rayColor);
            string layerHit = LayerMask.LayerToName(hit.transform.gameObject.layer);

            Debug.Log((direction * hit.distance));

            switch (layerHit)
            {
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

                    if ((direction * hit.distance).x == -0.5f)           //No funca
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

                case "Breakable":
                case "Player":
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