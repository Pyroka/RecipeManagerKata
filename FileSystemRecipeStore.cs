using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecipeManager
{
    public class FileSystemRecipeStore : IRecipeStore
    {
        private string RootDirectory { get; set; }

        public FileSystemRecipeStore(string rootDirectory)
        {
            RootDirectory = rootDirectory;
        }

        public IEnumerable<Recipe> GetAllRecipies()
        {
            return new DirectoryInfo(RootDirectory).GetFiles("*")
                .Select(fileInfo => new Recipe { Name = fileInfo.Name, Size = fileInfo.Length, Text = File.ReadAllText(fileInfo.FullName) });
        }

        public void DeleteRecipeNamed(string name)
        {
            File.Delete(Path.Combine(RootDirectory, name));
        }

        public void SaveRecipe(string name, string directions)
        {
            File.WriteAllText(Path.Combine(RootDirectory, name), directions);
        }
    }
}