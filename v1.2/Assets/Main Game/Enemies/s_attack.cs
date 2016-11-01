using UnityEngine;
using System.Collections;

public class s_attack : MonoBehaviour
{
    public float size = 0;
    public float min_Size = 1;
    public float max_Size = 5;

    public float timer = 0.0f;
    public float explosion_timer = 5.0f;
    
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            growth();
            size++;
        }

        if (size == 5)
        {
            explosion();
        }

    }

    public void growth()
    {

        transform.localScale += new Vector3(0.5f, 0.5f, 0);
        timer = 1.0f;
    }

    public void explosion()
    {
        Destroy(gameObject);
    }

}
