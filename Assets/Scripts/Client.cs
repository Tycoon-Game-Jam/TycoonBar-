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

    void Start()
    {
        GameObject.Find("ImmortalObject").GetComponent<GameSingleton>().clients.Enqueue(this);
        moveSpeed = 100f;
        actualState = States.WAITING;
        myRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        StartCoroutine(actions());
    }

    private IEnumerator actions() {
        if (actualState == States.GOTOTABLE) {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            if (leftOrRight == WhichSit.LEFT)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                myRigid.velocity = new Vector2(-moveSpeed, 0);
                //miejsce przy stoliku po lewej
                if (t.transform.position.x - (t.s.bounds.size.x / 2) >= transform.position.x - transform.GetComponent<SpriteRenderer>().bounds.size.x / 2)
                {
                    myRigid.velocity = Vector2.zero;
                    actualState = States.DRINKING;
                }
            }
            if (leftOrRight == WhichSit.RIGHT)
            {
                myRigid.velocity = new Vector2(-moveSpeed, 0);
                //miejsce przy stoliku po prawej
                if (t.transform.position.x + (t.s.bounds.size.x / 2) >= transform.position.x + transform.GetComponent<SpriteRenderer>().bounds.size.x / 2)
                {
                    myRigid.velocity = Vector2.zero;
                    actualState = States.DRINKING;
                }
            }
            yield return new WaitForSeconds(0);
        }
        if (actualState == States.DRINKING) {
            if (leftOrRight == WhichSit.LEFT) transform.localRotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Animator>().enabled=false;
            yield return new WaitForSeconds(20);
            actualState = States.GOHOME;
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
            yield return new WaitForSeconds(0);
        }
    }
}
