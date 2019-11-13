using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
    // text that displays the timer
    public Text timerText;
    // string to hold the timer val
    static public string timeStr;
    // float to keep track of time
    float time = 0;

    // Update is called once per frame
	void Update () {
        // increment time
        time += Time.deltaTime;
        // get time in minutes
        float minutes = Mathf.Floor(time / 60);
        // get time in seconds
        float seconds = Mathf.RoundToInt(time % 60);
        // generate a string representation of the minutes
        string minStr = minutes.ToString();
        string secondsStr = "";
        // generate a string representation of the seconds
        if (Mathf.RoundToInt(seconds) < 10) 
        {
            secondsStr = "0"+(Mathf.RoundToInt(seconds).ToString());
        }
        else
        {
            secondsStr = Mathf.RoundToInt(seconds).ToString();
        }
        // format the time string that is displayed to the user
        timeStr = minStr + ":" + secondsStr;
        timerText.text = minStr + ":" + secondsStr;
    }
}
