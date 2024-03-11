namespace BookStore.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public IList<Book> Books { get; set; }

    }
}
