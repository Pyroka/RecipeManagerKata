using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeManager
{
    [TestClass]
    public abstract class RecipeStoreTests
    {
        protected abstract IRecipeStore CreateStore();

        // --------------------------------------------------------------------

        private static Recipe CreateRecipe(string name, int size, string text)
        {
            return new Recipe
            {
                Name = name,
                Size = size,
                Text = text
            };
        }

        // --------------------------------------------------------------------

        [TestMethod]
        public void GetAllRecipies_WithNoRecipies_ReturnsEmpty()
        {
            var store = CreateStore();

            var result = store.GetAllRecipes();

            result.Should().BeEmpty();
        }

        [TestMethod]
        public void GetAllRecipies_AfterRecipesAdded_ReturnsRecipes()
        {
            var store = CreateStore();
            store.SaveRecipe("TestRecipe1", "Put the lime in the cocanut");
            store.SaveRecipe("TestRecipe2", "Get green eggs, add ham");

            var result = store.GetAllRecipes();

            var expected = new[]
            {
                CreateRecipe("TestRecipe1", 27, "Put the lime in the cocanut"),
                CreateRecipe("TestRecipe2", 23, "Get green eggs, add ham")
            };
            result.ShouldAllBeEquivalentTo(expected);
        }

        [TestMethod]
        public void GetAllRecipies_AfterRecipesDeleted_ReturnsRemainingRecipes()
        {
            var store = CreateStore();
            store.SaveRecipe("TestRecipe1", "Put the lime in the cocanut");
            store.SaveRecipe("TestRecipe2", "Get green eggs, add ham");
            store.DeleteRecipeNamed("TestRecipe1");

            var result = store.GetAllRecipes();

            var expected = new[]
            {
                CreateRecipe("TestRecipe2", 23, "Get green eggs, add ham")
            };
            result.ShouldAllBeEquivalentTo(expected);
        }

        [TestMethod]
        public void GetAllRecipies_WhenInvokedTwice_ReturnsEnumerablesContainingDifferentInstances()
        {
            var store = CreateStore();
            store.SaveRecipe("TestRecipe1", "Put the lime in the cocanut");

            const int index = 0;
            var firstResult = store.GetAllRecipes().ElementAt(index);
            var secondResult = store.GetAllRecipes().ElementAt(index);

            firstResult.Should().NotBeSameAs(secondResult);
        }

        // --------------------------------------------------------------------

        [TestMethod]
        public void DeleteRecipeNamed_WithNoRecipeOfThatName_ThrowsException()
        {
            var store = CreateStore();

            Action deleteAction = () => store.DeleteRecipeNamed("IncorrectName");

            deleteAction.ShouldThrow<RecipeStoreException>()
                .WithMessage("There is no recipe named: IncorrectName");
        }

        [TestMethod]
        public void DeleteRecipeNamed_WithNameOfExistingRecipeInDifferentCase_DeletesRecipe()
        {
            var store = CreateStore();
            store.SaveRecipe("Test Recipe Name", "Some directions");
            
            store.DeleteRecipeNamed("tEsT rEcIpE nAmE");

            store.GetAllRecipes().Should().BeEmpty();
        }

        // --------------------------------------------------------------------

        [TestMethod]
        public void SaveRecipe_CalledTwiceWithSameNameButDifferentDirections_UpdatesDirections()
        {
            var store = CreateStore();
            store.SaveRecipe("Recipe1", "Inital directions");

            store.SaveRecipe("Recipe1", "Much better directions");

            var expected = new[]
            {
                CreateRecipe("Recipe1", 22, "Much better directions")
            };
            store.GetAllRecipes().ShouldAllBeEquivalentTo(expected);
        }
    }
}
