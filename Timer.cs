using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerScript : MonoBehaviour
{
    // this script has timer that starts at a certain value and the time will go down.
public float startTime = 10;
    public float endTime = 0;
    public float currentTime;
    public TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }
    // Update is called once per frame
    void Update()
    {
        // stop timer when current time is <= 0
        if (currentTime <= endTime)
        {
            currentTime = 0;
            return;
        }
        currentTime = currentTime - Time.deltaTime;
        timerText.text = currentTime.ToString("0.0");
    }
}
