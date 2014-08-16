using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeManager
{
    [TestClass]
    public class FileSystemRecipeStoreTests : RecipeStoreTests
    {
        protected override IRecipeStore CreateStore()
        {
            throw new NotImplementedException();
        }
    }
}
