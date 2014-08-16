using System.Collections.Generic;

namespace RecipeManager
{
    public class InMemoryRecipeStore : IRecipeStore
    {
        public IEnumerable<Recipe> GetAllRecipies()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteRecipeNamed(string name)
        {
            throw new System.NotImplementedException();
        }

        public void CreateRecipe(string name, string directions)
        {
            throw new System.NotImplementedException();
        }
    }
}