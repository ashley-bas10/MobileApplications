using UnityEngine;
using System.Collections;

public class s_spawnSnow : MonoBehaviour {

    public float timer;
    public GameObject snow; //prefab it
    public float snowCounter = 1;

    // Use this for initialization
    void Start()
    {
        timer = 3.0f;
    }

    // Update is called once per frame
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Vector3 position = new Vector3(Random.Range(-45.0f, -35.0f), -23.0f, 0f);
            Instantiate(snow, position, Quaternion.identity);
            timer = 3 - (snowCounter *0.1f);
            snowCounter++;
            
        }
    }
}
