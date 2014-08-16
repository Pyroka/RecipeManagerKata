using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class Form1 : Form
    {
        private IRecipeStore RecipeStore { get; set; }

        public Form1()
        {
            InitializeComponent();

            RecipeStore = new FileSystemRecipeStore("./recipes");
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            PopulateList();
        }

        private void PopulateList()
        {
            listView1.Items.Clear();

            foreach (var recipe in RecipeStore.GetAllRecipies().ToList())
            {
                listView1.Items.Add(new RecipeListViewItem(recipe));
            }
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            foreach (RecipeListViewItem recipeListViewItem in listView1.SelectedItems)
            {
                var name = recipeListViewItem.Recipe.Name;
                RecipeStore.DeleteRecipeNamed(name);
            }
            PopulateList();

            NewClick(null, null);
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
            RecipeStore.SaveRecipe(name, directions);
            LoadRecipes();
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
