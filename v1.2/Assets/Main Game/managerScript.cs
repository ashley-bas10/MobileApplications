using UnityEngine;
using System.Collections;

public class managerScript : MonoBehaviour {
	//For manipulating player if needed
	public GameObject player;

	//Whether or not we are in battle mode, true = battle, false = overworld
	public bool battleOrOverworld = false;

	//Can the player move?
	public bool canMove;

    //For the battle arena
    public GameObject arena;
    public Vector3 arenaLocation = new Vector3(-25, 0, 0);

    void Start () {
        //Spawn the battle arena
        Instantiate(arena, arenaLocation, Quaternion.identity);

        //Load the level that was selected
        this.GetComponent<LevelGen> ().loadLevel (PlayerPrefs.GetInt ("levelToPlay"));

		//Start the intro dialouge for this level
		this.GetComponent<dialouge> ().playIntro (PlayerPrefs.GetInt ("levelToPlay"));

        //Set the players head to the correct image
        player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("CharacterSelect/Heads/" + player.GetComponent<reindeer>().id);
    }

	void Update(){

        if (battleOrOverworld)
        {
            //Centre on arena in battle mode
            transform.position = arenaLocation + Vector3.forward * -10;
        }
        else
        {
            //Keep this (and the camera) on top of the player when not in battle mode
            transform.position = player.transform.position + Vector3.forward * -10;
        }
    }
}
