using System.Collections.Generic;
using System.Linq;

namespace RecipeManager
{
    public class InMemoryRecipeStore : IRecipeStore
    {
        public IEnumerable<Recipe> GetAllRecipies()
        {
            return Enumerable.Empty<Recipe>();
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