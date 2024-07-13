using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject invenoty;
    private InventoryScript inventory;
    public GameObject recipie;
    private recipieScript rs;
    private GameManager gameManager;
    public void Start()
    {
        inventory = invenoty.GetComponent<InventoryScript>();
        rs = recipie.GetComponent<recipieScript>();
        gameManager = GameManager.instance;
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

    public void testSistemaReceta()
    {
        rs.anadeIngredienteReceta(gameManager.items["2"]);
        rs.anadeIngredienteReceta(gameManager.items["test"]);

        Recipie final = rs.hazPocion();

        Debug.Log(final.id);
    }
}
