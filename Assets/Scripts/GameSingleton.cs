using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton instance = null;
    public Text textM;
    public int money;
    public float REAL_SECONDS_PER_INGAME_DAY;
    public uint popularity; //mnoznik, ktory rosnie z czasem i razem z losową wartością od 0.5 do 2 okresli ile osob bedzie w barze
    public uint weeklyFees;
    public Queue<Table> tables;
    public Queue<Client> clients;
    public GameObject GameObjectTime;
    int weekOfLastPayment;
    GameTime time;


    private GameSingleton()
    {
        money = 5000; //przykladowa startowa wartosc;
        popularity = 2;
        weeklyFees = 200;
        REAL_SECONDS_PER_INGAME_DAY = 2F;
        tables = new Queue<Table>();
        clients = new Queue<Client>();
        weekOfLastPayment = -1;
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

    public void endGame()
    {
        if (money < 0) {
            Debug.Log("Game Over");
        }
    }

    public bool canYouBuyIt(int price)
    {
        return price < money;
    }

    public void virtualWaiter()
    {
        if (clients.Count != 0 && tables.Count != 0)
        {
            Client c = clients.Dequeue();
            Table t = tables.Dequeue();

            if (!t.isLeftTaken)
            {
                t.isLeftTaken = true;
                c.t = t;
                c.leftOrRight = Client.WhichSit.LEFT;
                c.actualState = Client.States.GOTOTABLE;
            }
            else if (!t.isRightTaken)
            {
                t.isRightTaken = true;

                c.t = t;
                c.leftOrRight = Client.WhichSit.RIGHT;
                c.actualState = Client.States.GOTOTABLE;
            }
            else
            {
                clients.Enqueue(c);
            }
            tables.Enqueue(t);
        }
    }

    void Start() {
        time = GameObjectTime.GetComponent<GameTime>();
    }

    void Update() {
        virtualWaiter();
        showMoney();
        endGame();
        payYourFees();
    }

    public void showMoney(){
        textM.text = money.ToString()+" $";
      }

    public void addMoney() {
        money = money + 50;
    }

    public void payYourFees() {
        if (time == null)
        {
            Debug.Log("NULL");
        }else if (weekOfLastPayment < time.GetWeek()) {
            weekOfLastPayment++;
            money = money - 1000;
            Debug.Log("-1000");
        }
    }
}
