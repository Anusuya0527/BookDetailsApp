using BookDetailsApp.Models;

namespace BookDetailsApp.Interfaces
{
    public interface IBookAppService
    {
        List<BookDto> GetAsync();

        List<BookDto> GetBookDetailsAsync();

        decimal GetTotalPriceOfAllBooksAsync();

        List<BookDto> GetBookDetailsByFilters(BookDto input);
    }
}
