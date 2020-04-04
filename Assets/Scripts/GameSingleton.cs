using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton instance = null;

    public int money;
    public uint time; //seconds
    public uint popularity; //mnoznik, ktory rosnie z czasem i razem z losową wartością od 0.5 do 2 okresli ile osob bedzie w barze
    public uint weeklyFees;
   

    private GameSingleton() {
        money = 5000; //przykladowa startowa wartosc;
        time = 88; //godzina 7:00 przy zalożeniu ze doba trwa 5 minut
        popularity = 2;
        weeklyFees = 200;
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
     
    /*// Start is called before the first frame update
    void Start(){}
    // Update is called once per frame
    void Update(){}*/
}
