using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using static UnityEditor.Progress;



public class Item
{
    public string id;
    public string descripcion;
    public bool esFinal;
}

public class DataLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void cargaItems() { 
    
    }


    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    Dictionary<string, Item> cargaItems(string filePath)
    {
        StreamReader strReader = new StreamReader(filePath);
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
                item.esFinal = row_values[1].ToLower() == "verdadero";
                item.descripcion = row_values[3];

                items.Add(item.id, item);
            }
        }

        return items;
    }
}

