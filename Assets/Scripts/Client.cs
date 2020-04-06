using System.Collections;
using UnityEngine;

public class Client : MonoBehaviour
{
    public enum States{
        WAITING, GOTOTABLE, DRINKING, GOHOME
    }
    public enum WalkDirection { 
        LEFT, RIGHT,
        UP, DOWN//(te sa nieistotne dla modeli graficznych)
    }

    public enum WhichSit { 
        LEFT, RIGHT
    }

    public Table t;
    float moveSpeed;
    public States actualState;
    private Rigidbody2D myRigid;
    public WhichSit leftOrRight;
    bool billIsPaid;

    void Start()
    {
        GameObject.Find("ImmortalObject").GetComponent<GameSingleton>().clients.Enqueue(this);
        moveSpeed = 100f;
        actualState = States.WAITING;
        myRigid = GetComponent<Rigidbody2D>();
        billIsPaid = false;
    }

    void Update()
    {
        StartCoroutine(actions());
    }

    private IEnumerator actions() {
        float x = 0, y = 0;
        if (actualState == States.GOTOTABLE) {
            x = -moveSpeed * Random.Range(0.5F, 1.7F);
            transform.localRotation = Quaternion.Euler(0, 180, 0);

            if (leftOrRight == WhichSit.LEFT)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                //miejsce przy stoliku po lewej
                if (t.transform.position.x - (t.s.bounds.size.x / 2) >= transform.position.x - transform.GetComponent<SpriteRenderer>().bounds.size.x / 2)
                {
                    x = 0;
                }
            }
            if (leftOrRight == WhichSit.RIGHT)
            {
                //miejsce przy stoliku po prawej
                if (t.transform.position.x + (t.s.bounds.size.x / 2) >= transform.position.x + transform.GetComponent<SpriteRenderer>().bounds.size.x / 2)
                {
                    x = 0;
                }
            }

            if (t.transform.position.y + (t.s.bounds.size.y / 2) <= transform.position.y+5)
            {
                y = -(moveSpeed/Random.Range(2,6));
            }
            else {
                y = 0;
            }


            myRigid.velocity = new Vector2(x, y);
            if (x == 0 && y == 0) {
                actualState = States.DRINKING;
            }
        }
        if (actualState == States.DRINKING) {
            if (leftOrRight == WhichSit.LEFT) transform.localRotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Animator>().enabled=false;
            yield return new WaitForSeconds(20);
            actualState = States.GOHOME;
            if (!billIsPaid)
            {
                billIsPaid = true;
                GameObject.Find("ImmortalObject").GetComponent<GameSingleton>().addMoney();
            }
        }
        if (actualState == States.GOHOME){
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Animator>().enabled = true;

            if (leftOrRight==WhichSit.LEFT) t.isLeftTaken = false;
            else if(leftOrRight == WhichSit.RIGHT) t.isRightTaken = false;
            myRigid.velocity = new Vector2(moveSpeed, 0);
            //granica obrazu
            if (2*(Camera.main.orthographicSize * Screen.width / Screen.height) <= transform.position.x){
                Destroy(myRigid);
                Destroy(gameObject);
                Destroy(this);
            }
        }
    }
}
