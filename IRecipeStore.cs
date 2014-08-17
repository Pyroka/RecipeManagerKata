using System.Collections.Generic;

namespace RecipeManager
{
    public interface IRecipeStore
    {
        IEnumerable<Recipe> GetAllRecipes();
        void DeleteRecipeNamed(string name);
        void SaveRecipe(string name, string directions);
    }
}