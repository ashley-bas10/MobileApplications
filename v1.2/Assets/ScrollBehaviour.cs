using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollBehaviour : MonoBehaviour {
    public Scrollbar scrollbar1;
    public Scrollbar scrollbar2;
    // Use this for initialization
    public Vector3 StartPoint1, EndPoint1;
    Vector3 StartPoint2;
    public Vector3 EndPoint2;
    float move;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void movecameraHorizontal ()
    {
        move = scrollbar1.value;
        Camera.main.transform.position = Vector3.Lerp(StartPoint1, EndPoint1, move);
    }
    public void movecameraVertical ()
    {
        StartPoint2 = Camera.main.transform.position;
        move = scrollbar2.value;
        Camera.main.transform.position = Vector3.Lerp(StartPoint2, EndPoint2, move);
    }
}
