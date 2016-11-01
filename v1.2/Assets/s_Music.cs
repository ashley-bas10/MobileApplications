using UnityEngine;
using System.Collections;

public class s_Music : MonoBehaviour
{

    static bool AudioPlaying = false;
    public bool mute = false; //used for muting


    public AudioSource source;
    void Awake()
    {
        if (!AudioPlaying)
        {
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioPlaying = true;
        }
    }

    public void VolumeUP()
    {
        source.volume += 0.1f;
        for (int i = 0; i < 5; i++)
        {
            source.volume += 0.1f;
        }

    }

    public void VolumeDOWN()
    {
        source.volume -= 0.1f;
        for (int i = 0; i < 5; i++)
        {
            source.volume -= 0.1f; //vol control
        }

    }

    public void MuteMusic()
    {
        if (source.mute)
        {
            for (int i = 0; i < 5; i++)
            {
                source.mute = false; //mute
                source.mute = false;
            }
        }

        else
        {
            for (int i = 0; i < 5; i++)
            {
                source.mute = true;
                source.mute = true;
            }
        }
    }
}
