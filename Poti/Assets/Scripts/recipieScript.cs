using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class recipieScript : MonoBehaviour {
        public List<Recipie> recipies = new List<Recipie>();
        private Dictionary<Item, int> ingredients = new Dictionary<Item, int> ();

    GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.instance; 
    }
    /**
    * Guarda el ingrediente que se esta mezclando y va dejando una lista de posibles recetas
    * No se verifica la cantidad de ingredientes que lleva la receta(Posible pero no lo se todavia)
    **/
    public void anadeIngredienteReceta (Item ing) {

            filtraReceta(ing);
            anadeIngrediente(ing);

        foreach (var item in recipies)
        {
            Debug.Log(item.id);
        }
    }

        private void anadeIngrediente(Item ing) {

            if (ingredients.ContainsKey(ing)) {
                ingredients[ing] += 1;
                
            } else {
                ingredients.Add(ing, 1);
            }
        }

        private void vaciaIng()
    {
        ingredients.Clear();


        recipies = gameManager.recipies.ToList();
        
    }
    private void filtraReceta(Item ing)
    {
        List<Recipie> toRemove = recipies.FindAll(r => !r.ingredientes.ContainsKey(ing.id));

        recipies.RemoveAll(x => toRemove.Contains(x));

    }


    public Recipie hazPocion()
    { 
        Recipie finalRep = recipies.Find(r =>
        {
            //Miro que tenga la cantidad correcta de cada ingrediente
            foreach (var item in ingredients)
            {
                Debug.Log(item.Key);
                Debug.Log(item.Value);
                if (r.ingredientes[item.Key.id] != item.Value)
                    return false;
            }

            return true;
        });

        return finalRep;
    }
}
