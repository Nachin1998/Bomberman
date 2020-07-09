using UnityEngine;

public class SideExplosions : MonoBehaviour
{
    float timer;
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 1.5)
        {
            Destroy(gameObject);
        }
    }
}
