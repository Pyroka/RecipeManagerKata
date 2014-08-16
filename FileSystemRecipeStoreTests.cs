using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeManager
{
    [TestClass]
    public class FileSystemRecipeStoreTests : RecipeStoreTests
    {
        private const string TestDirectory = "./fileSystemTestDir";

        protected override IRecipeStore CreateStore()
        {
            return new FileSystemRecipeStore(TestDirectory);
        }

        [TestInitialize]
        public void ClearTestDirectory()
        {
            Directory.CreateDirectory(TestDirectory);
            // Deleting the contents of the folder
            // works better in some cases than deleting
            // and recreating the folder.
            var dirInfo = new DirectoryInfo(TestDirectory);
            foreach (var file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (var dir in dirInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
