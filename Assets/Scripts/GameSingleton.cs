using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton instance = null;

    public int money;
    public float REAL_SECONDS_PER_INGAME_DAY;
    public uint time; //seconds
    public uint popularity; //mnoznik, ktory rosnie z czasem i razem z losową wartością od 0.5 do 2 okresli ile osob bedzie w barze
    public uint weeklyFees;
    public Queue<Table> tables;
    public Queue<Client> clients;
    public ClientSpawner cSpawner;

    private GameSingleton()
    {
        money = 5000; //przykladowa startowa wartosc;
        time = 88; //godzina 7:00 przy zalożeniu ze doba trwa 5 minut
        popularity = 2;
        weeklyFees = 200;
        REAL_SECONDS_PER_INGAME_DAY = 2F;
        tables = new Queue<Table>();
        clients = new Queue<Client>();
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

    public bool bankruptcy()
    {
        return money < -2000;
        //lub zmiana na void i wyswietlenie ekranu z napisem Game Over
    }

    public void win()
    {

    }

    public bool canYouBuyIt(int price)
    {
        return price < money;
    }

    public void virtualWaiter()
    {
        if (clients.Count != 0) {
            Client c = clients.Dequeue();
            if (tables.Count == 0)
            {
                Destroy(c);
                Destroy(c.gameObject);
            }
            else
            {
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
    }

    void Start(){
        cSpawner = GameObject.Find("ClientSpawner").GetComponent<ClientSpawner>();
    }

    void Update(){
        virtualWaiter();
    }
}
