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
            var recipeToDelete = recipes.FirstOrDefault(recipe => recipe.Name == name);
            if (recipeToDelete == null)
            {
                throw new RecipeStoreException("There is no recipe named: " + name);
            }
            recipes.Remove(recipeToDelete);
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