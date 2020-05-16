using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //public GameObject explosion;
    public Material[] materials;
    Renderer rend;
    float timer = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = materials[1];
    }

    void Update()
    {
        timer += Time.deltaTime;
        
    }
    public void ActivateBomb()
    {
        Debug.Log("Timer: " + timer);
        if (timer > 3)
        {
            Destroy(gameObject);
        }

        /*if(timer < 1)
        {
            rend.sharedMaterial = materials[1];
        }
        if (timer > 1 && timer < 2)
        {
            rend.sharedMaterial = materials[2];
        }
        if (timer > 2)
        {
            rend.sharedMaterial = materials[3];
        }
        if (timer > 3)
        {
            Destroy(gameObject);
        }*/
    }
}
