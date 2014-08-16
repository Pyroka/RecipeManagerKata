using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecipeManager
{
    public class FileSystemRecipeStore
    {
        public FileSystemRecipeStore()
        {
        }

        public IEnumerable<Recipe> FS_GetAllRecipies()
        {
            return new DirectoryInfo(@"e:\portkata").GetFiles("*")
                .Select(fileInfo => new Recipe { Name = fileInfo.Name, Size = fileInfo.Length, Text = File.ReadAllText(fileInfo.FullName) });
        }

        public void FS_DeleteRecipeNamed(string name)
        {
            File.Delete(@"e:\portkata\" + name);
        }

        public void FS_CreateRecipe(string name, string directions)
        {
            File.WriteAllText(Path.Combine("e:\\portkata", name), directions);
        }
    }
}