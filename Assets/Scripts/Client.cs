using UnityEngine;

public class Client : MonoBehaviour
{
    public enum States{
        GOTOTABLE, DRINKING, GOHOME
    }
    public enum walkDirection { 
        LEFT, RIGHT,
        UP, DOWN//(te sa nieistotne dla modeli graficznych)
    }

    public Table t;
    float moveSpeed;
    States actualState;
    private Rigidbody2D myRigid;

    void Start()
    {
        //t = null;
        moveSpeed = 100f;
        actualState = States.GOTOTABLE;
        myRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        actions();
    }

    private void actions() {
        if (actualState == States.GOTOTABLE) {
            //t.isTaken = true;
            myRigid.velocity = new Vector2(-moveSpeed,0);
            if (t.transform.position.x==transform.position.x){
                myRigid.velocity = Vector2.zero;
                actualState = States.DRINKING;
            }
        }
        if (actualState == States.DRINKING) { 
        
        }
        if (actualState == States.GOHOME) { 
        
        }
    }
}
