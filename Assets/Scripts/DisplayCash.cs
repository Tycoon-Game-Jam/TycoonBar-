using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayCash : MonoBehaviour
{
    public Text cash; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cash.text = GameSingleton.instance.money.ToString();
    }
}
