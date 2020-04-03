using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public enum FurnitureType {
        RED, WOODEN, GREY
    };
    public FurnitureType type;
    public bool isTaken;
    public SpriteRenderer s;

    void Start(){
        isTaken = false;
        s= GetComponent<SpriteRenderer>();
    }

}
