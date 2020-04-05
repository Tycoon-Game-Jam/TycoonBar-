using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    Transform spawner;
    private int CltnsPassed;
    public int NumberOfClients;//ilosc klientow na dzis
    public GameObject cPrefab;

    void Start()
    {
        spawner = GetComponent<Transform>();
        NumberOfClients = 7; //DODAJAC 8 lub wiecej reszta staje na tym samym miejscu
    }

    void Update()
    {
        que();
    }
    public void que(){
        if (NumberOfClients>CltnsPassed) {
            GameObject gObject = Instantiate(cPrefab) as GameObject;
            gObject.transform.position = spawner.transform.position;
            CltnsPassed++;
        }
    }
}
