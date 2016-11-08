using UnityEngine;
using System.Collections;

public class s_spawn : MonoBehaviour
{
    public s_elf elf;

    public float timer;
    public GameObject gift; //prefab it
	// Use this for initialization
	void Start ()
    {
        timer = 6.0f;
        elf = this.GetComponent<s_elf>();
	}

    // Update is called once per frame
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            
            Vector3 position = new Vector3(Random.Range(-39.0f, 14.0f), Random.Range(-31.0f, 14.0f), 0f);
            Instantiate(gift, position, Quaternion.identity);
            timer = 6.0f;
            if (elf.elf_health < 20)
            {
                timer = 2.0f;
            }
        }
    }
}
