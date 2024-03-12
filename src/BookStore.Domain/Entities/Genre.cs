namespace BookStore.Domain.Entities
{
    public class Genre
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IList<Book>? Books { get;}
    }
}
