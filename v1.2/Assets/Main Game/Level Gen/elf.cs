using UnityEngine;
using System.Collections;

public class elf : MonoBehaviour {

    //Manager for checking whether in battle or overworld for movement functions
    managerScript Manager;

    Vector3 origin;
    float angle = 0.0f;
    float speed = 1.5f;
    float halfrange = -2.0f;

    public GameObject battleMode;

	// Use this for initialization
	void Start () {
        origin = this.transform.position;

        Manager = GameObject.Find("Manager").GetComponent<managerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        angle += Time.deltaTime;

        float offset = Mathf.Sin(angle * speed) * halfrange;

        this.transform.position = origin + Vector3.up * offset;
	}

    void OnCollisionEnter2D(Collision2D _other)
    {
        if(_other.gameObject.name == "Player")
        {
            //Save the players return position

            //Change to battlemode
            Manager.battleOrOverworld = true;

            //Move player
            _other.transform.position = Manager.arenaLocation - 1.5f * Vector3.up;

            //Spawn elf in battlemode
            Instantiate(battleMode, Manager.arenaLocation + 1.5f * Vector3.up, Quaternion.identity);
        }
    }
}
