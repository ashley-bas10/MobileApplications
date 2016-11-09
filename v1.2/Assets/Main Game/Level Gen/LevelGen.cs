using UnityEngine;
using System.Collections;

public class LevelGen: MonoBehaviour
{
    //All the things the level gen has to spawn.
	public GameObject Ground;
    public GameObject MrsClaus;
	GameObject Player;
    public GameObject End;
	public GameObject SmallRock;
    public GameObject Tree;
    public GameObject BigRock; 
//    public GameObject Snowman;
    public GameObject Spikes;
    public GameObject Pits;
//    public GameObject Ice;
    public GameObject Elf;
        /*public GameObject PolarBear;
        public GameObject Penguin;
        public GameObject GingerbreadMan;
        public GameObject Wolf;
        public GameObject Krampus;*/

    //These are set within the switch statement to be used after.
    GameObject toBeSpawned;
	Vector3 offset;

	void Start(){
		//Get player from manager
		Player = this.GetComponent<managerScript> ().player;
	}

	public void loadLevel(int _level)
	{
        //Get level.txt file
		TextAsset _textFile = (TextAsset)Resources.Load("Levels/" + _level.ToString());

        //Number of columns = length of line = position of first \n
		int _columns = _textFile.text.IndexOf ("\n");

		//This is to keep track of which symbol in the text file we are in, excluding \n's
		int _symbol = 0;

        //For each symbol in the text file (sadly including \n)
		for (int i = 0 ; i < _textFile.text.Length ; i++)
		{
			//The column of the current thing to be spawned is the remainder of the current symbol index divided by the length of the row (the number of columns)
			int _col = _symbol % _columns;

            //The row of the current thing to be spawned is the numberof times the total row length (the number of columns) divides the current symbols index
			int _row = _symbol / _columns;

            //Switch statement chooses the right object to instantiate and sets relevent offsets for each symbol.
			switch (_textFile.text.Substring(i, 1))
			{
            //Ground
			case "+":
				//This is the ground which is done for every symbol after this switch statement.
				toBeSpawned = Ground;
				offset = Vector3.zero;
				break;

            //Start
			case "S":
				//Put player on this point.
				Player.transform.position = new Vector3(_col, -_row, 0);
				break;

			//End
			case "E":
				toBeSpawned = End;
				offset = Vector3.zero;
//				//Put mrs clause nearby, wait to see how dialouge is implemented.
				break;

			//Mrs Claus
			case "M":
				toBeSpawned = MrsClaus;
				offset = Vector3.zero;
				break;

			//Small Rock
			case "r":
				toBeSpawned = SmallRock;
				offset = Vector3.zero;
				break;
			//Tree
			case "T":
				toBeSpawned = Tree;
				offset = new Vector3(0, 0.5f, 0);
				break;

			//Big Rock
			case "R":
				toBeSpawned = BigRock;
				offset = new Vector3(0.5f, 0.5f, 0);
				break;
			//Snowman



			//Spikes
			case "^":
				toBeSpawned = Spikes;
				offset = Vector3.zero;
				break;

			//Pits
			case "O":
				toBeSpawned = Pits;
				offset = Vector3.zero;
				break;
            //Elf
            case "1":
                toBeSpawned = Elf;
                offset = Vector3.zero;
                    //Ground cant be included with elf as elf moves
                    Instantiate(Ground, new Vector3(_col, -_row, 0) + offset, Quaternion.identity);
                break;



			//Used for catching \n's
			case "\n":
				toBeSpawned = null;
				//Remove 1 from symbol because symbol is keeping track without \n's
				_symbol--;
				break;
			default:
                toBeSpawned = null;
                break;
			}
            //Instantiate object
			if(toBeSpawned != null)
			{
				GameObject _spawned = Instantiate(toBeSpawned, new Vector3(_col, - _row, 0) + offset, Quaternion.identity) as GameObject;
				//This line makes the things lower in the level render above those in lines above when a sprite takes up more than one line, everything keeps same relative layers.
				_spawned.GetComponent<SpriteRenderer>().sortingOrder += _row;
			}
			//Add one to which symbol in the file (excluding \n) we are on. (This has already been subtracted if \n has happened)
			_symbol++;
		}
	}
}
