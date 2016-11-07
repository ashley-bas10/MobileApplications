using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class LevelSelectManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
        {


            RaycastHit hit;
            Ray ray;
#if UNITY_EDITOR
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //for touch device
#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
   ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
#endif

            if (Physics.Raycast(ray, out hit))
            {
                
                
                    PlayerPrefs.SetInt("levelToPlay", int.Parse(hit.collider.name));

                    SceneManager.LoadScene("CharSelect");
                    
                
            }
        }
    }

}
