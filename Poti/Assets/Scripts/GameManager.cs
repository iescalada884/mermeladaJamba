using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Dictionary<string, Item> items;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        items = DataLoader.cargaItems("Ejemplo");

        /*foreach (var item in items.Values)
        {
            Debug.Log(String.Format("{0} {1} {2}",item.id , item.descripcion, item.esFinal.ToString()));
        }*/
    }

    // Add your game management methods here
    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
