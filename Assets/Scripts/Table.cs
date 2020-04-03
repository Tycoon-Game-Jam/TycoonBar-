using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public enum FurnitureType {
        OLD, MIDCLASS, MODERN
    };
    public FurnitureType type;
    public bool isTaken;
    void Start(){
        isTaken = false;
    }

}
