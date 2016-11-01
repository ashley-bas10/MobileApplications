using UnityEngine;
using System.Collections;

public class s_snow : MonoBehaviour
{
    public float timer;


	// Use this for initialization
	void Start ()
    {
        timer = 5.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            destruction();
        }
    }

    public void destruction()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Player" || Col.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
      
    }
}
