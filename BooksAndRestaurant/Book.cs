namespace BooksAndRestaurant
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Pages { get; set; }
        private int _qualification;

        public int Qualification 
        {
            get { return _qualification; }
            set 
            {
                //Esto es para verificar que la calificacion esta entre 0 y 10, si se pasa del limite se le asigna el extremo proximo
                if (value < 0)
                {
                    _qualification = 0;
                }
                else if (value > 10)
                {
                    _qualification = 10;
                }
                else
                {
                    _qualification = value;
                }
            }
        }

        public Book(string title, string author, int qualification, string pages)
        {
            Title = title;
            Author = author;
            Qualification = qualification;
            Pages = pages;
        }

        public override string ToString()
        {
            return string.Format("Titulo: {0}\nAutor: {1}\nPáginas: {2}\nCalificación: {3}", Title,Author,Pages, Qualification);
        }

    }
}
