using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour {
    // ref to game manager
    public GameManager gameManager;


	// Update is called once per frame
	void Update () {
        // move conveyer belt according to its speed
        transform.position += new Vector3(gameManager.beltSpeed, 0, 0);

        // resets conveyer belt lines to give the illusion
        // of animation
        if(transform.position.x >= 8.05){
            ResetLine();
        }
	}

    // resets conveyer belt line to the beginning of the belt
    void ResetLine(){
        transform.position = new Vector3(-8.04f, -1.82f, 0f);
    }
}
