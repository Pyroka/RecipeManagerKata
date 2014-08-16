using System.Collections.Generic;
using System.Linq;

namespace RecipeManager
{
    public class InMemoryRecipeStore : IRecipeStore
    {
        private readonly List<Recipe> recipes = new List<Recipe>(); 

        public IEnumerable<Recipe> GetAllRecipies()
        {
            return recipes;
        }

        public void DeleteRecipeNamed(string name)
        {
            throw new System.NotImplementedException();
        }

        public void AddRecipe(string name, string directions)
        {
            recipes.Add(new Recipe
            {
                Name = name,
                Size = directions.Length,
                Text = directions
            });
        }
    }
}