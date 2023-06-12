using BookDetailsApp.Interfaces;
using BookDetailsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BookDetailsApp.Services
{
    public class BookAppService : IBookAppService
    {
        private readonly BookDetailsDbContext _dbContext;
        public BookAppService(BookDetailsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookDto> GetAsync()
        {
            var bookDetails = _dbContext.CallStoredProcedure<BookDto>("dbo.sp_GetBooks");
            return bookDetails;
        }

        public List<BookDto> GetBookDetailsAsync()
        {
            var bookDetails = _dbContext.CallStoredProcedure<BookDto>("dbo.sp_GetBookDetails");
            return bookDetails;
        }

        public decimal GetTotalPriceOfAllBooksAsync()
        {
            var totalPrice = _dbContext.ExecuteScalar("dbo.sp_GetBooksTotalPrice");
            return totalPrice;
        }

        public List<BookDto> GetBookDetailsByFilters(BookDto input)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(input.Title))
            {
                sqlParameters.Add(new SqlParameter("@Title", SqlDbType.VarChar)
                {
                    Value = input.Title
                });
            }

            if (!string.IsNullOrEmpty(input.Publisher))
            {
                sqlParameters.Add(new SqlParameter("@Publisher", SqlDbType.VarChar)
                {
                    Value = input.Publisher
                });
            }

            if (!string.IsNullOrEmpty(input.AuthorFirstName))
            {
                sqlParameters.Add(new SqlParameter("@AuthorFirstName", SqlDbType.VarChar)
                {
                    Value = input.AuthorFirstName
                });
            }

            if (!string.IsNullOrEmpty(input.AuthorLastName))
            {
                sqlParameters.Add(new SqlParameter("@AuthorLastName", SqlDbType.VarChar)
                {
                    Value = input.AuthorLastName
                });
            }

            if (input.Year > 0)
            {
                sqlParameters.Add(new SqlParameter("@Year", SqlDbType.Int)
                {
                    Value = input.Year
                });
            }

            if (!string.IsNullOrEmpty(input.ISBN))
            {
                sqlParameters.Add(new SqlParameter("@ISBN", SqlDbType.VarChar)
                {
                    Value = input.ISBN
                });
            }

            SqlParameter[] sqlParamsArray = sqlParameters.ToArray();

            var bookDetails = _dbContext.CallStoredProcedure<BookDto>("dbo.sp_GetBookDetailsByFilters", sqlParamsArray);
            return bookDetails;
        }
}
}
