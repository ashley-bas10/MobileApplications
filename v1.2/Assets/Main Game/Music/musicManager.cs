using UnityEngine;
using System.Collections;

public class musicManager : MonoBehaviour {

    public AudioClip[] songs;

    public AudioClip COTBStart;
    public AudioClip COTBLoop;
    public AudioClip COTBEnd;

    int unlocked;

    AudioSource output;

    int lastPlayed;

    void Start () {
        //TEMPORARY
        PlayerPrefs.SetInt("SongsUnlocked", 3);

        unlocked = PlayerPrefs.GetInt("SongsUnlocked");

        output = this.GetComponent<AudioSource>();

        lastPlayed = Random.Range(0, unlocked);

        output.clip = songs[lastPlayed];
        output.Play();

	}
	
	
	void Update () {
        if (PlayerPrefs.GetInt("levelToPlay") == 25)
        {

        }
        else
        {
            if(!output.isPlaying)
            {
                int rand = Random.Range(0, unlocked);
                while(rand == lastPlayed)
                {
                    rand = Random.Range(0, unlocked);
                }
                lastPlayed = rand;
                output.clip = songs[rand];
                output.Play();
            }
        }
	}
}
