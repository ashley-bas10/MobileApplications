using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dialouge : MonoBehaviour {

	bool Done = false;
	bool OutroBegun = false;

	public GameObject _textBox;
	public GameObject _background;
	public GameObject _speaker;
	managerScript manager;

	string[] _lines;
	int _currentline = 0;

	private void play(string _dialouge){
		//Get level.txt file
		TextAsset _textFile = (TextAsset)Resources.Load("Dialouge/" + _dialouge);

		//Marker for end of each text box, used by text.split
		char[] _lineEnd = {'\n'};

		//Seperate into lines, which is how we are seperating each text box.
		_lines = _textFile.text.Split (_lineEnd);

		//Reset the line counter for new dialouge.
		_currentline = 0;

		//Unhide the dialouge UI (this is only needed for the outro but it's fine here)
		HideDialouge (false);
	}

	void Start(){
		//Get manager
		manager = this.GetComponent<managerScript> ();

		//Set the correct speaker
		Sprite _letMeSpeak;

		//Correct for this level
		switch (PlayerPrefs.GetInt ("levelToPlay")) {
		case 25:
			_letMeSpeak = Resources.Load<Sprite>("Dialouge/Heads/Krampus");
			break;
		default:
			_letMeSpeak = (Sprite)Resources.Load<Sprite>("Dialouge/Heads/MrsClaus");
			break;
		}

		//Now actually set it
		_speaker.GetComponent<Image> ().sprite = _letMeSpeak;
	}

	void Update(){
		//Don't update until there is something to display
		if (_lines.Length != 0) {
			//Display the current line
			_textBox.GetComponent<Text>().text = _lines [_currentline];

			if (Input.GetMouseButtonDown(0)){
				//Check if still in text file. + 1 to check that the NEXT line exists or not.
				if (_currentline + 1 < _lines.Length) { 
					_currentline++;
				} else {
					HideDialouge (true);
				}
			}
		}
	}

	//For the start of the level
	public void playIntro(int _level){
		//Send the play function to the intro folder
		play ("Intro/" + _level.ToString ());
	}

	//For the end of the level
	public void playOutro(int _level){
		//Send the play button to the outro folder
		play ("Outro/" + _level.ToString ());
		OutroBegun = true;
	}

	private void HideDialouge(bool _hide){
		//When hiding un-enable everything and let the player move
		manager.canMove = _hide;
		Done = _hide;
		_background.GetComponent<Image> ().enabled = !(_hide);
		_textBox.GetComponent<Text> ().enabled =  !(_hide);
		_speaker.GetComponent<Image> ().enabled = !(_hide);

		//If we are hiding the outro finish the level
		if (OutroBegun && Done) {
            SceneManager.LoadScene("LevelSelect");
		}
	}
}
