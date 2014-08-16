using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeManager
{
    public class InMemoryRecipeStore : IRecipeStore
    {
        private readonly List<Recipe> recipes = new List<Recipe>(); 

        public IEnumerable<Recipe> GetAllRecipies()
        {
            return recipes.Select(CloneRecipe);
        }

        public void DeleteRecipeNamed(string name)
        {
            var recipeToDelete = FindRecipeByName(name);
            if (recipeToDelete == null)
            {
                throw new RecipeStoreException("There is no recipe named: " + name);
            }
            recipes.Remove(recipeToDelete);
        }

        public void SaveRecipe(string name, string directions)
        {
            var existingRecipe = FindRecipeByName(name);
            if (existingRecipe != null)
            {
                existingRecipe.Text = directions;
                existingRecipe.Size = directions.Length;
            }
            else
            {
                recipes.Add(new Recipe
                {
                    Name = name,
                    Size = directions.Length,
                    Text = directions
                });
            }
        }

        private static Recipe CloneRecipe(Recipe original)
        {
            return new Recipe
            {
                Name = original.Name,
                Size = original.Size,
                Text = original.Text
            };
        }

        private Recipe FindRecipeByName(string name)
        {
            return recipes.FirstOrDefault(recipe => string.Equals(recipe.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}