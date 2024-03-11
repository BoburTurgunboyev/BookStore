namespace BookStore.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }  
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
