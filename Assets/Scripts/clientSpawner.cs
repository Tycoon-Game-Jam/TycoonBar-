using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    Transform spawner;
    int CltnsPassed;
    int NumberOfClients;//ilosc klientow na dzis
    public GameObject cPrefab;
    public GameTime gameTime;

    void Start()
    {
        CltnsPassed = 1;
        spawner = GetComponent<Transform>();
        NumberOfClients = 5; 
        gameTime = GameObject.Find("TimeManager").GetComponent<GameTime>();
    }

    void Update()
    {
        que();
        //reset klientow na nastepny dzien
        if (gameTime.GetHours() == 23 && gameTime.GetMinutes() > 50) {
            CltnsPassed = 0;
        }
    }
    public void que(){
        if (GameObject.FindGameObjectsWithTag("Client").Length <= (GameObject.FindGameObjectsWithTag("Table").Length*2))
        {
            if (NumberOfClients > CltnsPassed)
            {
                if (gameTime.GetHours() == (CltnsPassed * 24 / NumberOfClients))
                {
                    GameObject gObject = Instantiate(cPrefab) as GameObject;
                    gObject.transform.position = spawner.transform.position;
                    CltnsPassed++;
                }
            }
        }
        else {
            Debug.Log("Za dużo");
        }
    }
}
