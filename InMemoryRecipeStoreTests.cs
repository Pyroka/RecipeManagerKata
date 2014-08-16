using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeManager
{
    [TestClass]
    public class InMemoryRecipeStoreTests : RecipeStoreTests
    {
        protected override IRecipeStore CreateStore()
        {
            return new InMemoryRecipeStore();
        }
    }
}
