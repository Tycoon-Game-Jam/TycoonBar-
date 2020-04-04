using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    Transform spawner;
    public int NumberOfClients;//ilosc klientow na dzis
    public GameObject cPrefab;

    void Start()
    {
        spawner = GetComponent<Transform>();
        NumberOfClients = 5;
        virtualWaiter();
    }

    void Update()
    {
        
    }
    public void virtualWaiter()
    { //trzeba dodac by wybieral najbliszy wolny stolik przy ktorym powinien usiasc klient
        GameObject gObject = Instantiate(cPrefab) as GameObject;
        gObject.transform.position = spawner.transform.position;
    }
}
