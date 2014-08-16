using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class Form1 : Form
    {
        private List<Recipe> recipes = new List<Recipe>(); 

        public Form1()
        {
            InitializeComponent();

            LoadRecipes();
        }

        private void LoadRecipes()
        {
            recipes = FS_GetAllRecipies().ToList();

            PopulateList();
        }

        private IEnumerable<Recipe> FS_GetAllRecipies()
        {
            return new DirectoryInfo(@"e:\portkata").GetFiles("*")
                .Select(fileInfo => new Recipe { Name = fileInfo.Name, Size = fileInfo.Length, Text = File.ReadAllText(fileInfo.FullName) });
        }

        private void PopulateList()
        {
            listView1.Items.Clear();

            foreach (Recipe recipe in recipes)
            {
                listView1.Items.Add(new RecipeListViewItem(recipe));
            }
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            foreach (RecipeListViewItem recipeListViewItem in listView1.SelectedItems)
            {
                recipes.Remove(recipeListViewItem.Recipe);
                var name = recipeListViewItem.Recipe.Name;
                FS_DeleteRecipeNamed(name);
            }
            PopulateList();

            NewClick(null, null);
        }

        private void FS_DeleteRecipeNamed(string name)
        {
            File.Delete(@"e:\portkata\" + name);
        }

        private void NewClick(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxObjectData.Text = "";
        }

        private void SaveClick(object sender, EventArgs e)
        {
            var name = textBoxName.Text;
            var directions = textBoxObjectData.Text;
            FS_CreateRecipe(name, directions);
            LoadRecipes();
        }

        private void FS_CreateRecipe(string name, string directions)
        {
            File.WriteAllText(Path.Combine("e:\\portkata", name), directions);
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (RecipeListViewItem recipeListViewItem in listView1.SelectedItems)
            {
                textBoxName.Text = recipeListViewItem.Recipe.Name;
                textBoxObjectData.Text = recipeListViewItem.Recipe.Text;
                break;
            }
        }
    }
}
