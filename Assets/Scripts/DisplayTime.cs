﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    public Text datetimeText;
    private GameTime timeScript;
    // Start is called before the first frame update
    void Awake()
    {
        timeScript = GameObject.Find("TimeManager").GetComponent<GameTime>();
    }

    // Update is called once per frame
    void Update()
    {
        datetimeText.text = timeScript.GetWeek().ToString()+" weeks, " + timeScript.GetDay().ToString() +"  days, " + " time: " + timeScript.GetHours().ToString() + ":" + timeScript.GetMinutes().ToString();
    }
}
