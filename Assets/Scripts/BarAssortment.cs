using UnityEngine;

public class BarAssortment : MonoBehaviour
{
    Sprite texture;
    string nam;
    uint price;

    public BarAssortment(string pathname) {
        nam = pathname;
        //pobiera prosty plik z nazwą i ceną i ewentualnie tez nazwa pliku z tekstura;
    }
}
