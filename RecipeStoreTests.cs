﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeManager
{
    [TestClass]
    public class RecipeStoreTests
    {
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
            var store = new InMemoryRecipeStore();

            var result = store.GetAllRecipies();

            result.Should().BeEmpty();
        }

        [TestMethod]
        public void GetAllRecipies_AfterRecipesAdded_ReturnsRecipes()
        {
            var store = new InMemoryRecipeStore();
            store.AddRecipe("TestRecipe1", "Put the lime in the cocanut");
            store.AddRecipe("TestRecipe2", "Get green eggs, add ham");

            var result = store.GetAllRecipies();

            var expected = new[]
            {
                CreateRecipe("TestRecipe1", 27, "Put the lime in the cocanut"),
                CreateRecipe("TestRecipe2", 23, "Get green eggs, add ham")
            };
            result.ShouldAllBeEquivalentTo(expected);
        }
    }
}
