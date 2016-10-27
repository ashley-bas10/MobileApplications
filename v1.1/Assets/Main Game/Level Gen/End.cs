using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {

	GameObject Manager;

	void Start () {
		Manager = GameObject.Find ("Manager");
	}
	
	void OnTriggerEnter2D(Collider2D _other){
		//If the player has entered this trigger
		if (_other.name == "Player") {
			//Play outro
			Manager.GetComponent<dialouge>().playOutro(PlayerPrefs.GetInt ("levelToPlay"));
		}
	}
}
