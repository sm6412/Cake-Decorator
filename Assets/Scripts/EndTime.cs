using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTime : MonoBehaviour {
    // the player's score time
    public Text finalTime;
    // the sound that plays when the player loses
    public AudioClip loseSound;
    private AudioSource source;

    private void Start()
    {
        // set the final time equal to the
        // time the gameplay kept running for
        finalTime.text = timer.timeStr;
        // play sound effect
        source.PlayOneShot(loseSound);
    }

    void Awake()
    {
        // get audio source component
        source = GetComponent<AudioSource>();

    }


}
