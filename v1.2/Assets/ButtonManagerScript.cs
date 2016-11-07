using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour {

    int PlayedGameCheck = 0;

    public GameObject MainCanvas;
    public GameObject OptionsCanvas;

    public void StartGame ()
        {
           PlayedGameCheck = PlayerPrefs.GetInt("PlayedGameCheck");

           if (PlayedGameCheck == 0)
             {
                SceneManager.LoadScene("CharSelect");
              

                PlayerPrefs.SetInt("PlayedGameCheck", 1);
             }
           else
             {
                SceneManager.LoadScene("LevelSelect");

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
        SceneManager.LoadScene("Shop");
       
    }

    public void backtomenu ()
    {
        MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }
}
