using System;

namespace RecipeManager
{
    public class RecipeStoreException : Exception
    {
        public RecipeStoreException(string message)
            : base(message)
        {
        }

        public RecipeStoreException(string message, Exception innException)
            : base(message, innException)
        {
        }
    }
}