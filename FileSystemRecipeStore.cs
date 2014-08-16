using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecipeManager
{
    public class FileSystemRecipeStore : IRecipeStore
    {
        public FileSystemRecipeStore(string rootDirectory)
        {
        }

        public IEnumerable<Recipe> GetAllRecipies()
        {
            return new DirectoryInfo(@"e:\portkata").GetFiles("*")
                .Select(fileInfo => new Recipe { Name = fileInfo.Name, Size = fileInfo.Length, Text = File.ReadAllText(fileInfo.FullName) });
        }

        public void DeleteRecipeNamed(string name)
        {
            File.Delete(@"e:\portkata\" + name);
        }

        public void SaveRecipe(string name, string directions)
        {
            File.WriteAllText(Path.Combine("e:\\portkata", name), directions);
        }
    }
}