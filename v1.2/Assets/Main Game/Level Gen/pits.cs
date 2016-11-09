using UnityEngine;
using System.Collections;

public class pits : MonoBehaviour {

    void OnTriggerStay2D(Collider2D _other)
    {
        if (_other.name == "Player" && !_other.GetComponent<control>().jumping)
        {
            _other.GetComponent<control>().inPit = true;
        }
    }
}
