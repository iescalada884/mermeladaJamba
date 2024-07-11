using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject invenoty;
    private InventoryScript inventory;

    public void Start()
    {
        inventory = invenoty.GetComponent<InventoryScript>();
    }

    public void sumaC(int cantidad)
    {
        inventory.sumaItem("coqui", cantidad);
    }
    public void restaC(int cantidad)
    {
        inventory.restaItem("coqui", cantidad);
    }

    public void suma2(int cantidad)
    {
        inventory.sumaItem("test", cantidad);
    }
    public void rest2(int cantidad)
    {
        inventory.restaItem("test", cantidad);
    }
}
