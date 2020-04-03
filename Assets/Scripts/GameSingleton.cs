using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton instance = null;

    public int money;
    public uint time; //seconds
    public uint popularity; //mnoznik, ktory rosnie z czasem i razem z losową wartością od 0.5 do 2 okresli ile osob bedzie w barze
    public uint weeklyFees;
    public int NumberOfClients;//ilosc klientow na dzis




    private GameSingleton() {
        money = 5000; //przykladowa startowa wartosc;
        time = 88; //godzina 7:00 przy zalożeniu ze doba trwa 5 minut
        popularity = 2;
        weeklyFees = 200;
        NumberOfClients = 2;
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

        public bool bankruptcy() {
        return money<-2000;
        //lub zmiana na void i wyswietlenie ekranu z napisem Game Over
    }

    public void win() {
        
    }

    public bool canYouBuyIt(int price) {
        return price < money;
    }

    public void virtualWaiter() { //wybiera najbliszy wolny stolik przy ktorym powinien usiasc klient
       /* GameObject gObject = Instantiate(client) as GameObject;
        if (NumberOfClients > 0) {
            if()
            clients[0].t = tables[i];
            NumberOfClients--;
        }*/
    }

     
    /*// Start is called before the first frame update
    void Start(){}
    // Update is called once per frame
    void Update(){}*/
}
