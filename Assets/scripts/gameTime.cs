using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameTime : MonoBehaviour
{
    // Start is called before the first frame update\
    private float day;

    public Text timeText;

    private const float REAL_SECONDS_PER_INGAME_DAY = 1000F;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;
        float dayNormalized = day % 1f;
        float hoursPerDay = 24f;
        string dayString = Mathf.Floor(day).ToString();
        float minutesPerHour = 60f;
        string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString();
       
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");
        timeText.text = hoursString + ":" + minutesString + " day: " + dayString ;
        



    }
}
