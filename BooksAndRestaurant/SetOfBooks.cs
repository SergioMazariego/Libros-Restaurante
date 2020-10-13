namespace BooksAndRestaurant
{
    class SetOfBooks
    {
        public Book[] BooksCollection { get; set; }

        //Iniciar la cantidad de libros para maximo 5 elementos tipo libro
        public SetOfBooks()
        {
            BooksCollection = new Book[5];
        }
    }
}
