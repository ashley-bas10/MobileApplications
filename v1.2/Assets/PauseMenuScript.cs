using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {
    public GameObject PauseCanvas;

    public GameObject OptionsCanvas;

	// Use this for initialization

	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
        }
	}

    public void ReturnToGame()
    {
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
    }

    public void Options ()
    {
        PauseCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);

    }
    
    public void BackToMainMenu ()
    {
        SceneManager.LoadScene("Main Menu");
        
    }

  

    public void BackToPause()
    {
        PauseCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }
}
