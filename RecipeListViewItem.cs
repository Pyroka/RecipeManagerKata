using System.Windows.Forms;

namespace RecipeManager
{
    class RecipeListViewItem: ListViewItem
    {
        private readonly Recipe recipe;

        public RecipeListViewItem(Recipe recipe)
        {
            this.recipe = recipe;

            Text = recipe.Name;
            SubItems.Add(new ListViewSubItem(this, this.recipe.Size.ToString()));
        }

        public Recipe Recipe {
            get { return recipe; }
        }
    }
}
