using System.Collections.Generic;

namespace RecipeManager
{
    public interface IRecipeStore
    {
        IEnumerable<Recipe> GetAllRecipies();
        void DeleteRecipeNamed(string name);
        void CreateRecipe(string name, string directions);
    }
}