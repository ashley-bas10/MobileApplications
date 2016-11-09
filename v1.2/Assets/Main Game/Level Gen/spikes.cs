using UnityEngine;
using System.Collections;

public class spikes : MonoBehaviour {

	void OnTriggerStay2D(Collider2D _other)
    {
        if (_other.name == "Player" && !_other.GetComponent<control>().jumping)
        {
            _other.GetComponent<control>().damageMe(0.1f);
        }
    }

}
