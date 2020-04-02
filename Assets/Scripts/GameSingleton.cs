using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSingleton{
    private static GameSingleton instance = null;

    public Scene currentScene;
    public int money;
    public uint time; //seconds
    public uint popularity; //mnoznik, ktory rosnie z czasem i razem z losową wartością od 0.5 do 2 okresli ile osob bedzie w barze
    public uint weeklyFees;
    public BarAssortment[] FoodNDrinks;



    private GameSingleton() {
        currentScene = SceneManager.CreateScene("menu"); //nie wiem na ile to przydatne ale moze powinien przechowywac aktualna scene
        money = 5000; //przykladowa startowa wartosc;
        time = 88; //godzina 7:00 przy zalożeniu ze doba trwa 5 minut
        popularity = 2;
        weeklyFees = 200;
        FoodNDrinks = new BarAssortment[50];
    }
    public static GameSingleton getInstance() {
        if (instance == null) {
            instance = new GameSingleton();
        }
        return instance;
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
