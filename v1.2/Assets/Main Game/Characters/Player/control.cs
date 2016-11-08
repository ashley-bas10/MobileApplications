using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour {
	//Set to prevent movement during dialouge. Starts false for intro dialouge.
	public bool canMove = false;

	//Radius from target destination to stop
	float stoppingRadius = 0.75f;

    //The current health of the reindeer
    float health;

	//The stats of the selected reindeer to be used
	reindeer stats;

    //The health bar UI
    public GameObject healthbar;

    //Where to put the player if they fall in a pit or finish a battle
    public Vector3 putMeBack;
	
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

        //Set the current health to the health stat of picked reindeer
        health = stats.gethealth();

        //Set width of health bar depending on health.
        healthbar.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(stats.gethealth() / 5.0f * 800, 100);

	}

	void Update ()
    {
        //display health
        healthbar.GetComponent<Image>().fillAmount = health / stats.gethealth();

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

    public void damageMe(float _dmg)
    {
        health -= _dmg;

        // if out of health game over
        if (health <= 0)
        {
            SceneManager.LoadScene("Died");
        }
    }

    void healMe (float _heal)
    {
        health += _heal;

        if (health > stats.gethealth())
        {
            health = stats.gethealth();
        }
    }

}
