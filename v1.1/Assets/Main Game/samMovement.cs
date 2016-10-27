/*using UnityEngine;
using System.Collections;

public class samMovement : MonoBehaviour
{
     //this is set to true while moving and reset to false once it reaches its destination.  
     bool check = false;

     //Stores the click/ touch position
     private Vector2 Destination;

    //This will be changed to the reindeers overworld/ underworld speed
    float Speed = 75.0f;


    void Update()
        {
            //Detects when the screen is touched / clicked  
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
                {
                    
                    RaycastHit hit;

                    //Create a Ray on the tapped / clicked position
                    Ray ray;

                    //Detects if playing in unity editor
                    #if UNITY_EDITOR
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    //Detects if playing on an android
                    #elif (UNITY_ANDROID)
                    ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    #endif

                    //Check if the ray hits any collider
                    if (Physics.Raycast(ray, out hit))
                        {
                            //Signals that the point that was touched/ clicked is a viable place to move
                            check = true;

                            //Gives "Destination" the coordinates of the tapped area
                            Destination = hit.point;
                
                         }

                }

            //Detects that the current location and the clicked location arent the same
            if (check && gameObject.transform.position.magnitude != Destination.magnitude)
                { 
                    //Moves the character
                    gameObject.transform.position = Vector2.Lerp(gameObject.transform.position,Destination, 1 / (Speed * (Vector2.Distance(gameObject.transform.position, Destination))));
                    
                    //Detects when the mouse button/ finger is no longer being held down
                    if (Input.GetMouseButtonUp(0) || Input.GetTouch(0).phase == TouchPhase.Ended)
                        {
                            //Stops the players movement once the button/finger is released
                            Destination = transform.position;
                        }
                }
            //Sets the "check" bool to false if the clicked position and current location are the same
            else if (check && gameObject.transform.position.magnitude == Destination.magnitude)
                {
                    check = false;
                }
        }
 }



 */