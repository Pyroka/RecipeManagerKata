using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeManager
{
    [TestClass]
    public class RecipeStoreTests
    {
        [TestMethod]
        public void GetAllRecipies_WithNoRecipies_ReturnsEmpty()
        {
            var store = new InMemoryRecipeStore();

            var result = store.GetAllRecipies();

            result.Should().BeEmpty();
        }

        [TestMethod]
        public void GetAllRecipies_AfterRecipeAdded_ReturnsSingleRecipe()
        {
            var store = new InMemoryRecipeStore();
            store.AddRecipe("TestRecipe", "Put the lime in the cocanut");

            var result = store.GetAllRecipies();

            var expected = new[]
            {
                new Recipe
                {
                    Name = "TestRecipe",
                    Size = 27,
                    Text = "Put the lime in the cocanut"
                }
            };
            result.ShouldAllBeEquivalentTo(expected);
        }
    }
}
