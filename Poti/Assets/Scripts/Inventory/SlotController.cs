using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public GameObject slot;
    public TextMeshProUGUI amount;
    public GameObject itemDisplay;


    public int count;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    public void initSlot(string itemID)
    {
        setItem(itemID);
        slot.SetActive(true);
    }
    public void resetSlot() {
        slot.SetActive (false);
        amount.text = "0";
        itemDisplay.GetComponent<Image>().sprite = null;

    }

    public void setItem(string item)
    {
        itemDisplay.GetComponent<Image>().sprite = Resources.Load<Sprite>(String.Format("Items/{0}", item));
    }

    public bool restaItem(int cantidad)
    {
        if (count - cantidad < 0) return false;

        count -= cantidad;

        actualizaCuenta();
        return true;
    }
    
    //TODO cambiar a bool
    public void sumaItem(int cantidad)
    {

        count += cantidad;

        actualizaCuenta();
        //return true;
    }

    public void actualizaCuenta()
    {
        amount.text = count.ToString();
    }
}
