using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public static int MAX_CAPACITY;

    private List<GameObject> freeSlots = new List<GameObject> ();

    private Dictionary<string, GameObject> ocupedSlotos = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform child in transform)
        {
            freeSlots.Add (child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sumaItem(string item_id, int amount)
    {
        GameObject slot;

        if (!ocupedSlotos.ContainsKey(item_id))
        {
            if (freeSlots.Count < 0) throw new System.Exception("LLenos");

            slot = freeSlots[0];
            freeSlots.Remove(slot);

            slot.GetComponent<SlotController>().initSlot(item_id);

            ocupedSlotos.Add(item_id, slot);
        } else
        {
            slot = ocupedSlotos[item_id];
        }
           

        slot.GetComponent<SlotController>().sumaItem(amount);
    }

    public void restaItem(string item_id, int amount)
    {
        GameObject slot;

        if (!ocupedSlotos.ContainsKey(item_id))
            throw new System.Exception("No existe");

        slot = ocupedSlotos[item_id];

        slot.GetComponent<SlotController>().restaItem(amount);
    }
}
