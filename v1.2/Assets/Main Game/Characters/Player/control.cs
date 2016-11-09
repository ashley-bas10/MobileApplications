using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour {
	//Set to prevent movement during dialouge. Starts false for intro dialouge.
	public bool canMove = false;

    //Bool for temp invinsibility after taking damage
    bool canBeDamaged = true;
    float invinsTime = 2.5f;
    float invisTimer = 0.0f;

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

        //Timer for damage invinsibility
        if(!canBeDamaged)
        {
            if(invisTimer >= invinsTime)
            {
                canBeDamaged = true;
                invisTimer = 0.0f;
                Color temp = this.GetComponent<SpriteRenderer>().color;
                temp.a = 1.0f;
                this.GetComponent<SpriteRenderer>().color = temp;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = temp;
            }
            invisTimer += Time.deltaTime;
        }

		//get canMove from the manager
		canMove = GameObject.Find ("Manager").GetComponent<managerScript> ().canMove;

		if (canMove && Input.GetMouseButton(0)) { //while not in dialouge and whilst finger is down do movement
			Vector3 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			target.z = 0;

			//Stay still if you are already near the target otherwise do movement
			if(Vector3.Distance(transform.position, target) > stoppingRadius){
                stats.rotateTowards(target);

                //Only move if we aren't moving into a wall.
                RaycastHit2D hit = Physics2D.Raycast(transform.position, this.GetComponent<reindeer>().forward, 1.0f);
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "walls")
                    { }
                    else
                    {
                        stats.moveFowards();
                    }
                }
                else
                {
                    stats.moveFowards();
                }
            }
		}

        

    }

    public void damageMe(float _dmg)
    {
        if (canBeDamaged)
        {
            health -= _dmg;

            //Make invinsible for a while
            canBeDamaged = false;
            Color temp = this.GetComponent<SpriteRenderer>().color;
            temp.a = 0.7f;
            this.GetComponent<SpriteRenderer>().color = temp;
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = temp;

            // if out of health game over
            if (health <= 0)
            {
                SceneManager.LoadScene("Died");
            }
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
