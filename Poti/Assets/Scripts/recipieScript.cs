using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class recipieScript : MonoBehaviour {
        public List<Recipie> recipies = new List<Recipie>();
        private Dictionary<Item, int> ingredients = new Dictionary<Item, int> ();

     GameManager gameManager;

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>(); ;
        if (gameManager == null)
        {
            Debug.LogError("GameManager no encontrado");
        } else
        {
            vaciaIng();
        }
        

    }
    /**
    * Guarda el ingrediente que se esta mezclando y va dejando una lista de posibles recetas
    * No se verifica la cantidad de ingredientes que lleva la receta(Posible pero no lo se todavia)
    **/
    public void anadeIngredienteReceta (Item ing) {

            filtraReceta(ing);
            anadeIngrediente(ing);
    }

        private void anadeIngrediente(Item ing) {

            if (ingredients.ContainsKey(ing)) {
                ingredients[ing] += 1;
                
            } else {
                ingredients.Add(ing, 1);
            }
        }

        public void vaciaIng()
    {
        ingredients.Clear();


        recipies = gameManager.recipies.ToList();
    }
    private void filtraReceta(Item ing)
    {

        List<Recipie> toRemove = recipies.FindAll(r =>
        {
            if (r == null)
            {
                throw new ArgumentNullException(nameof(r), "A recipie in the list is null.");
            }
            if (r.ingredientes == null)
            {
                throw new ArgumentNullException(nameof(r.ingredientes), "The ingredientes dictionary in a recipie is null.");
            }
            return !r.ingredientes.ContainsKey(ing.id);
        });

        recipies.RemoveAll(x => toRemove.Contains(x));

    }


    public Recipie hazPocion()
    { 
        Recipie finalRep = recipies.Find(r =>
        {
            //Miro que tenga la cantidad correcta de cada ingrediente
            foreach (var item in ingredients)
            {
                if (r.ingredientes[item.Key.id] != item.Value)
                    return false;
            }

            return true;
        });

        return finalRep;
    }
}
