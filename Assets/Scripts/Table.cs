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
    public Table() {
        isTaken = false;
    }
}
