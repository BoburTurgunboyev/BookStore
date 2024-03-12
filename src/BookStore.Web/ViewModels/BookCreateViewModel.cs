using BookStore.Domain.Entities;

namespace BookStore.Web.ViewModels
{
    public class BookCreateViewModel
    {
        public Book Book { get; set; }
        public List<Author>? Authors { get; set; }
        public List<Genre>? Genres { get; set; }
    }
}
