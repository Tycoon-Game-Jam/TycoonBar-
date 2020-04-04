using System.Collections;
using UnityEngine;

public class Client : MonoBehaviour
{
    public enum States{
        GOTOTABLE, DRINKING, GOHOME
    }
    public enum WalkDirection { 
        LEFT, RIGHT,
        UP, DOWN//(te sa nieistotne dla modeli graficznych)
    }

    public Table t;
    float moveSpeed;
    private States actualState;
    private Rigidbody2D myRigid;

    void Start()
    {
        t = GameObject.Find("table").GetComponent<Table>();
        moveSpeed = 100f;
        actualState = States.GOTOTABLE;
        myRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        StartCoroutine(actions());
    }

    private IEnumerator actions() {
        if (actualState == States.GOTOTABLE) {
            myRigid.velocity = new Vector2(-moveSpeed,0);
            //miejsce przy stoliku po lewej
            if (t.transform.position.x-(t.s.bounds.size.x/2)>=transform.position.x-transform.GetComponent<SpriteRenderer>().bounds.size.x/2){
                myRigid.velocity = Vector2.zero;
                actualState = States.DRINKING;
            }
            yield return new WaitForSeconds(0);
        }
        if (actualState == States.DRINKING) {
            yield return new WaitForSeconds(5);
            actualState = States.GOHOME;
        }
        if (actualState == States.GOHOME){
            t.isLeftTaken = false; //tu do poprawy
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
