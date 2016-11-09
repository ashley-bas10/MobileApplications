using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour {
    //The reindeer that is being displayed to the user and will be selected when play is pressed
    reindeer selected;

    //The head icon of the selected reindeer
    public GameObject head;

    //The text box of the selected reindeers name
    public GameObject charName;

    //The star images representing all the stats
    public GameObject overWorldSpeedStars;
    public GameObject battleSpeedStars;
    public GameObject turnabilityStars;
    public GameObject jumpStars;
    public GameObject damageStars;
    public GameObject defenceStars;
    public GameObject healthStars;

    void Start () {
        //Set selected, default to dasher
        selected = this.GetComponent<reindeer>();
        selected.setReindeer(selected.dasher);
    }
	
	//Display the current reindeer
	void Update () {
        //Display head using id and resources folder
        head.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("CharacterSelect/Heads/" + selected.id);

        //Display name using the id and a switch statement
        string _displayMe = "not been set";
        switch (selected.id)
        {
            case 0:
                _displayMe = "<color=orange>Dasher</color>";
                break;
            case 1:
                _displayMe = "<color=purple>Dancer</color>";
                break;
            case 2:
                _displayMe = "<color=green>Prancer</color>";
                break;
            case 3:
                _displayMe = "<color=white>Vixen</color>";
                break;
            case 4:
                _displayMe = "<color=lightblue>Comet</color>";
                break;
            case 5:
                _displayMe = "<color=fuchsia>Cupid</color>";
                break;
            case 6:
                _displayMe = "<color=grey>Donner</color>";
                break;
            case 7:
                _displayMe = "<color=yellow>Blitzen</color>";
                break;
            case 8:
                _displayMe = "<color=red>Rudolph</color>";
                break;
            default:
                break;
        }
        charName.GetComponent<Text>().text = _displayMe;
        //Display stats
        overWorldSpeedStars.GetComponent<Image>().fillAmount = selected.stars[0] / 5.0f;
        battleSpeedStars.GetComponent<Image>().fillAmount = selected.stars[1] / 5.0f;
        turnabilityStars.GetComponent<Image>().fillAmount = selected.stars[2] / 5.0f;
        jumpStars.GetComponent<Image>().fillAmount = selected.stars[3] / 5.0f;
        damageStars.GetComponent<Image>().fillAmount = selected.stars[4] / 5.0f;
        defenceStars.GetComponent<Image>().fillAmount = selected.stars[5] / 5.0f;
        healthStars.GetComponent<Image>().fillAmount = selected.stars[6] / 5.0f;
    }

    //Left button pressed, rotate selection back
    public void onLeftPress()
    {
        switch (selected.id)
        {
            case 0:
                selected.setReindeer(selected.rudolph);
                break;
            case 1:
                selected.setReindeer(selected.dasher);
                break;
            case 2:
                selected.setReindeer(selected.dancer);
                break;
            case 3:
                selected.setReindeer(selected.prancer);
                break;
            case 4:
                selected.setReindeer(selected.vixen);
                break;
            case 5:
                selected.setReindeer(selected.comet);
                break;
            case 6:
                selected.setReindeer(selected.cupid);
                break;
            case 7:
                selected.setReindeer(selected.donner);
                break;
            case 8:
                selected.setReindeer(selected.blitzen);
                break;
            default:
                break;
        }
    }

    //Right button pressed, rotate selection forward
    public void onRightPress()
    {
        switch (selected.id)
        {
            case 0:
                selected.setReindeer(selected.dancer);
                break;
            case 1:
                selected.setReindeer(selected.prancer);
                break;
            case 2:
                selected.setReindeer(selected.vixen);
                break;
            case 3:
                selected.setReindeer(selected.comet);
                break;
            case 4:
                selected.setReindeer(selected.cupid);
                break;
            case 5:
                selected.setReindeer(selected.donner);
                break;
            case 6:
                selected.setReindeer(selected.blitzen);
                break;
            case 7:
                selected.setReindeer(selected.rudolph);
                break;
            case 8:
                selected.setReindeer(selected.dasher);
                break;
            default:
                break;
        }
    }

    //Play pressed, set player prefab of selected reindeer, open the level scene.
    public void play()
    {
        //Set the reindeer playerpref. Load level.
        switch (selected.id)
        {

            case 0:
                PlayerPrefs.SetString("reindeerForPlayer", "dasher");
                break;
            case 1:
                PlayerPrefs.SetString("reindeerForPlayer", "dancer");
                break;
            case 2:
                PlayerPrefs.SetString("reindeerForPlayer", "prancer");
                break;
            case 3:
                PlayerPrefs.SetString("reindeerForPlayer", "vixen");
                break;
            case 4:
                PlayerPrefs.SetString("reindeerForPlayer", "comet");
                break;
            case 5:
                PlayerPrefs.SetString("reindeerForPlayer", "cupid");
                break;
            case 6:
                PlayerPrefs.SetString("reindeerForPlayer", "donner");
                break;
            case 7:
                PlayerPrefs.SetString("reindeerForPlayer", "blitzen");
                break;
            case 8:
                PlayerPrefs.SetString("reindeerForPlayer", "rudolph");
                break;
            default:
                break;
        }
        SceneManager.LoadScene("Levels");
    }

    //Back pressed, return to level select
    public void back()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
