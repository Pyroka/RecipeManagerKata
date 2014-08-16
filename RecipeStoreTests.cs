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
    }
}
