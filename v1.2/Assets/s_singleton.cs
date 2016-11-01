using UnityEngine;
using System.Collections;

public class s_singleton : MonoBehaviour
{

    private static s_singleton instance = null;

    public static s_singleton Instance
    {
        get { return instance; }
    }


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}