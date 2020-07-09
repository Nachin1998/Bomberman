using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    ParticleSystem[] particles;
    void Start()
    {
        particles = GetComponentsInChildren<ParticleSystem>();

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < particles.Length; i++)
            {
                    particles[i].Play();                
            }
        }
        StartCoroutine(testing(3));
    }

    IEnumerator testing(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Bruh");
        yield return new WaitForSeconds(time);
        Debug.Log("Bruhx2");
        yield return new WaitForSeconds(time);
        Debug.Log("Bruhx3");
    }
}
