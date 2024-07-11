using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEditor.Progress;

public class Item
{
    public string id;
    public string name;
    public string descripcion;
    public bool esFinal;
}

public static class DataLoader 
{
    public static Dictionary<string, Item> cargaItems(string nombre)
    {
        TextAsset exel = Resources.Load<TextAsset>(nombre);

        StringReader strReader = new StringReader(exel.text);

        bool endOfFile = false;

        // Skip header line
        strReader.ReadLine();

        Dictionary<string, Item> items = new Dictionary<string, Item>();

        while (!endOfFile)
        {
            string data_String = strReader.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            var row_values = data_String.Split(';');
            if (row_values.Length > 0)
            {
                Item item = new Item();
                item.id = row_values[0]; // entero = int.Parse(row_values[0]);
                item.esFinal = row_values[1].ToLower() == "FALSO";
                item.descripcion = row_values[2];

                items.Add(item.id, item);
            }
        }

        return items;
    }
}

