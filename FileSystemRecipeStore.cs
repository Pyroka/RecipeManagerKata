using System;
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
            try
            {
                Directory.CreateDirectory(RootDirectory);
            }
            catch (Exception ex)
            {
                throw new RecipeStoreException("Failed to create root directory: " + rootDirectory, ex);
            }
        }

        public IEnumerable<Recipe> GetAllRecipies()
        {
            return new DirectoryInfo(RootDirectory).GetFiles("*")
                .Select(fileInfo => new Recipe { Name = fileInfo.Name, Size = fileInfo.Length, Text = File.ReadAllText(fileInfo.FullName) });
        }

        public void DeleteRecipeNamed(string name)
        {
            var filePath = Path.Combine(RootDirectory, name);
            if (!File.Exists(filePath))
            {
                throw new RecipeStoreException("There is no recipe named: " + name);
            }
            File.Delete(filePath);
        }

        public void SaveRecipe(string name, string directions)
        {
            File.WriteAllText(Path.Combine(RootDirectory, name), directions);
        }
    }
}