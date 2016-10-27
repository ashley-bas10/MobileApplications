using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {
	//Set to prevent movement during dialouge. Starts false for intro dialouge.
	public bool canMove = false;

	//Radius from target destination to stop
	float stoppingRadius = 0.75f;

	//The stats of the selected reindeer to be used
	reindeer stats;
	
	void Start(){
		//Set stats to the selected reindeer
		stats = this.GetComponent<reindeer> ();

		//Doing this incase there is a capitalisation typo somewhere
		string _setToMe = PlayerPrefs.GetString ("reindeerForPlayer").ToLower ();

		//Switch statement picks the right one
		switch (_setToMe) {
		case "dasher":
			stats.setReindeer (stats.dasher);
			break;
		case "dancer":
			stats.setReindeer (stats.dancer);
			break;
		case "prancer":
			stats.setReindeer (stats.prancer);
			break;
		case "vixen":
			stats.setReindeer (stats.vixen);
			break;
		case "comet":
			stats.setReindeer (stats.comet);
			break;
		case "cupid":
			stats.setReindeer (stats.cupid);
			break;
		case "donner":
			stats.setReindeer (stats.donner);
			break;
		case "blitzen":
			stats.setReindeer (stats.blitzen);
			break;
		case "rudolph":
			stats.setReindeer (stats.rudolph);
			break;
		default:
			break;
		}
	}

	void Update ()
    {
		//get canMove from the manager
		canMove = GameObject.Find ("Manager").GetComponent<managerScript> ().canMove;

		if (canMove && Input.GetMouseButton(0)) { //while not in dialouge and whilst finger is down do movement
			Vector3 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			target.z = 0;

			//Stay still if you are already near the target otherwise do movement
			if(Vector3.Distance(transform.position, target) > stoppingRadius){
				stats.moveFowards();
				stats.rotateTowards(target);
			}
		}


    }

}
