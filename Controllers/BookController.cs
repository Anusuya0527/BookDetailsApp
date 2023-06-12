using BookDetailsApp.Interfaces;
using BookDetailsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BookDetailsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookAppService _bookAppService;
        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookAppService.GetAsync());
        }

        [HttpGet]
        [Route("details")]
        public IActionResult GetBookDetails()
        {
            return Ok(_bookAppService.GetBookDetailsAsync());
        }

        [HttpGet]
        [Route("total-Price")]
        public ActionResult GetTotalPriceOfAllBooks()
        {
            return Ok(_bookAppService.GetTotalPriceOfAllBooksAsync());
        }

        [HttpPost]
        [Route("search")]
        public ActionResult GetBookDetailsByFilters(BookDto input)
        {
            return Ok(_bookAppService.GetBookDetailsByFilters(input));
        }
    }
}
