using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        // get the mouse position
        Vector3 mousePos = Input.mousePosition;
        // set the z axis of the mouse
        mousePos.z = 10;

        // grab the mouse pos with regards to the screen
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        // use raycasting to see if the player clicks on a game object
        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);
        if (hit && Input.GetMouseButtonDown(0))
        {
            // if the user clicks on the start 
            // button start the gameplay scene
            if(hit.collider.tag == "start")
            {
               SceneManager.LoadScene("Gameplay");
            }
        }
    }
}
