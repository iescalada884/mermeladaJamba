public class recipieScript : MonoBehaviour {
        public List<Recipie> recipies = new List<Recipie>();
        private Dictionary<Item, Integer> ingredients = new Dictionary<Item, Integer> ();

        /**
        * Guarda el ingrediente que se esta mezclando y va dejando una lista de posibles recetas
        * No se verifica la cantidad de ingredientes que lleva la receta(Posible pero no lo se todavia)
        **/
        public void anadeIngredienteReceta (Item ing) {
            anadeIngrediente(ing);

            filtraReceta(ing);
        }

        private anadeIngrediente(Item ing) {
            int count = 0;
            if (ingredients.ContainsKey(ing)) {
                ingredients[ing] += 1;
                
            } else {
                ingredients.Add(ing, 1);
            }
        }

        private void filtraReceta(Item ing) {
            //For each // filter list ing contains
        }
}
