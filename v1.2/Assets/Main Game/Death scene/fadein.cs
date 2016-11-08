using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fadein : MonoBehaviour {

    Color temp;
    float counter = 0.0f;

    // Use this for initialization
    void Start () {
        temp = this.GetComponent<Text>().color;
        temp.a = 0.0f;
        this.GetComponent<Text>().color = temp;
    }
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime / 2.5f;
        temp.a = counter - 2.5f;
        this.GetComponent<Text>().color = temp;

        if(counter >= 4.5f)
        {
            SceneManager.LoadScene("Main Menu");
        }

    }
}
