using UnityEngine;
using System.Collections;

public class reindeer : MonoBehaviour {
	//Manager for checking whether in battle or overworld for movement functions
	managerScript Manager;

	void Start () {
		Manager = GameObject.Find ("Manager").GetComponent<managerScript>();
	}
    //Used to display stars in character select
    public int[] stars = new int[8];

    //The stats    
	float overworldSpeed;
	float battleSpeed;
	float turnability;
	float jump;
	float damage;
	float defense;
	float health;
    public int id;

    //Arrays that store particular values of our 5 level system. 
    float[] OverworldSpeeds = {3.0f, 3.5f, 4.0f, 7.0f, 10.0f};
	float[] BattleSpeeds    = {1.0f, 2.0f, 3.0f, 4.0f, 5.0f};
	float[] Turnabilitys    = {1.0f, 2.0f, 3.0f, 4.0f, 50.0f};
	float[] Jumps           = {1.0f, 2.0f, 3.0f, 4.0f, 5.0f};
	float[] Damages         = {1.0f, 2.0f, 3.0f, 4.0f, 5.0f};
	float[] Defences        = {1.0f, 2.0f, 3.0f, 4.0f, 5.0f};
	float[] Healths         = {1.0f, 2.0f, 3.0f, 4.0f, 5.0f};

	//Set stats of a reindeer using an array
	public void setReindeer(int[] _stats){
		overworldSpeed = OverworldSpeeds[_stats[0] - 1];
		battleSpeed = BattleSpeeds[_stats[1] - 1];
		turnability = Turnabilitys[_stats[2] - 1];
		jump = Jumps[_stats[3] - 1];
		damage = Damages[_stats[4] - 1];
		defense = Defences[_stats[5] - 1];
		health = Healths[_stats[6] - 1];
        id = _stats[7];

        stars = _stats;
    }

	//The 9 reindeer
	public int[] dasher  = {5, 4, 2, 3, 3, 3, 3, 0};
	public int[] dancer  = {4, 5, 4, 4, 2, 2, 4, 1};
	public int[] prancer = {3, 4, 5, 5, 2, 3, 3, 2};
	public int[] vixen   = {3, 3, 3, 3, 3, 4, 4, 3};
	public int[] comet   = {3, 3, 1, 4, 4, 5, 1, 4};
	public int[] cupid   = {3, 3, 3, 3, 2, 1, 5, 5};
	public int[] donner  = {3, 3, 3, 3, 3, 3, 3, 6};
	public int[] blitzen = {5, 5, 5, 5, 5, 5, 5, 7};
	public int[] rudolph = {1, 1, 1, 1, 1, 1, 1, 8};

	//for debugging
	public void printMe(){
		print (overworldSpeed + ", " + battleSpeed + ", " + turnability + ", " + jump + ", " + damage + ", " + defense + ", " + health + ", " + id);
	}

	//Movement
	
	//Forward direction used by movement
	Vector3 forward = Vector3.right;

    //Needed on uni computers but not at home ???????
    bool flipped = false;

    //Direction the player wants to face
    Vector2 faceMe;
    public void Update()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            //THIS IS JUST A TEST FOR COMBAT
            transform.position = new Vector3(-40, -13, 0);
        }
        //if (Input.GetKey(KeyCode.E))
       // {
        //    Camera.main.gameObject.transform.position = new Vector3(this.transform.position.x, Camera.main.transform.position.y, -10f);
        //}



    }
    public void moveFowards(){
		//Move forwards (to the right) at the correct speed for the current mode
		float speedToUse = Manager.battleOrOverworld ? battleSpeed : overworldSpeed;

        //Needed at uni not at home =(
        if (flipped) { transform.Translate(new Vector3(-forward.x, forward.y, 0) * speedToUse * Time.deltaTime); }
        else { transform.Translate(forward * speedToUse * Time.deltaTime); }
       
        //Make sure body faces right direction
        transform.localScale = (forward.x < 0) ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        
        //Needed at uni not home.
        flipped = (forward.x < 0);
    }

    public void rotateTowards(Vector2 _target){
		//Player position in 2d
		Vector2 player = new Vector2(this.transform.position.x, this.transform.position.y);

		//In front of the player in 2d
		Vector2 playRight = new Vector3 (forward.x, forward.y);
			//new Vector2 (this.transform.right.x, this.transform.right.y);

		//Direction the player wants to face
		faceMe = (_target - player);
		faceMe.Normalize ();

		//Get angle needed to rotate by to face target
		float angle = Vector2.Angle (playRight, faceMe);

		//Always positive. Sort that out with this bit of maths
		angle *= Mathf.Sign (Vector3.Dot (Vector3.forward, Vector3.Cross (playRight, faceMe)));

		//Do the actual rotation
		forward = Quaternion.Euler (0, 0, angle * turnability * Time.deltaTime) * forward;

		//Point head where you want to go
		if (faceMe.x >= 0) 
		{
			transform.GetChild(0).transform.right = faceMe;
            if (flipped) { transform.GetChild(0).transform.right = new Vector3(faceMe.x, -faceMe.y, 0); }
        } 
		else 
		{
			transform.GetChild(0).transform.right = new Vector3(-faceMe.x, faceMe.y, 0);
            if (flipped) { transform.GetChild(0).transform.right = new Vector3(-faceMe.x, -faceMe.y, 0); }
		}
	}

    public float gethealth()
    {
        return health;
    }
}
