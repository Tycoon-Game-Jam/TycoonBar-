using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public enum FurnitureType {
        RED, WOODEN, GREY
    };
    public FurnitureType type;
    public bool isLeftTaken; //nie jestem pewny co do tego rozwiazania
    public bool isRightTaken;
    public SpriteRenderer s;

    void Start(){
        isLeftTaken = false;
        isRightTaken = false;
        s = GetComponent<SpriteRenderer>();
    }

}
