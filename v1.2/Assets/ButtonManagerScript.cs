using UnityEngine;
using System.Collections;

public class ButtonManagerScript : MonoBehaviour {

    int PlayedGameCheck = 0;

    public GameObject MainCanvas;
    public GameObject OptionsCanvas;

    public void StartGame ()
        {
           PlayedGameCheck = PlayerPrefs.GetInt("PlayedGameCheck");

           if (PlayedGameCheck == 0)
             {
                 Application.LoadLevel("CharSelect");

                PlayerPrefs.SetInt("PlayedGameCheck", 1);
             }
           else
             {
                Application.LoadLevel("LevelSelect");

                //PlayerPrefs.SetInt("PlayedGameCheck", 0);

             }
        }
    public void Options ()
    {
        MainCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }

    public void Shop ()
    {
        Application.LoadLevel("Shop");
    }

    public void backtomenu ()
    {
        MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }
}
