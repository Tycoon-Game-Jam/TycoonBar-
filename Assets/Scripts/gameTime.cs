using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    // Start is called before the first frame update\
    private float day;
    private float week;

    //public Text timeText;
    string hoursString;
    string minutesString;
    float dayNormalized;
    float minutesPerHour = 60f;
    float hoursPerDay = 24f;
    float newweeks;
   

    private const float REAL_SECONDS_PER_INGAME_DAY = 5F;
    private const float REAL_SECONDS_PER_INGAME_WEEK = REAL_SECONDS_PER_INGAME_DAY * 7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setGameTime();
    }
    public void setGameTime()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;
        week += Time.deltaTime / REAL_SECONDS_PER_INGAME_WEEK;
        float dayNormalized = day % 1f;
        int singleWeek = (int)week;
        
       // Debug.Log(dayNormalized);
        string dayString = Mathf.Floor(day).ToString();
            
        hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString();
        
        minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");
       // Debug.Log((int)day);
    }
    public int GetHours()
    {
        return int.Parse(hoursString);
    }
    public int GetMinutes()
    {
       return  int.Parse(minutesString);
    }
    public int GetWeek()
    {
        return (int)week;
    }
    public int GetDay()
    {
        return (int)day;
    }
    public void setTimerMinutes(int now)
    {
        TimeSpan mints = TimeSpan.FromSeconds(300);
        mints = mints.Subtract(TimeSpan.FromSeconds(int.Parse(minutesString)));
        if (mints.Seconds == 0)
        {
           // Debug.Log("End");
        }
           
    }
    public void setTimer(int now)
    {
        TimeSpan end = new TimeSpan(22, 0, 0);
        
        TimeSpan ts = new TimeSpan(int.Parse(hoursString), 0,0);

    }
    
}
