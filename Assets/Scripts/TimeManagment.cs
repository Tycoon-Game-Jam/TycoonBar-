using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagment : MonoBehaviour
{
    public GameTime timeScript;
    // Start is called before the first frame update
    void Start()
    {
        timeScript = GameObject.Find("GameObject").GetComponent<GameTime>();
    }

    // Update is called once per frame
   void Update()
    {
        // int hours= timeScript.GetHours();

        //Debug.Log(hours);
        Debug.Log(timeScript.GetMinutes());
        if(timeScript.GetDay()%7==0 && timeScript.GetDay() != 0)
        {
           if(timeScript.GetHours()==12 && timeScript.GetMinutes()==59)
            {
                Debug.Log("Płać podatki");
            }
        }

    }
}
