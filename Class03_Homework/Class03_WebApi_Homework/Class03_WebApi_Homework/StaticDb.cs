using Class03_WebApi_Homework.Models;

namespace Class03_WebApi_Homework
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book()
            {
                Author = "J. Robert Oppenheimer",
                Title = "Uncommon Sense",
            },

            new Book()
            {
                Author = "Brian Griffin",
                Title = "Faster Than The Speed Of Love",
            },

            new Book()
            {
                Author = "William Shakespeare",
                Title = "Hamlet",
            },

            new Book()
            {
                Author = "Adolf Hitler",
                Title = "Mein Kampf",
            }
        };
    }
}
