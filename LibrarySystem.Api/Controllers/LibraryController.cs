using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Api.Services;
using LibrarySystem.Api.Models;

namespace LibrarySystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryService _libraryService;

        public LibraryController(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        //// Borrow a book
        //[HttpPost("borrow")]
        //public IActionResult BorrowBook([FromBody] BorrowRequest request)
        //{
        //    try
        //    {
        //        _libraryService.BorrowBook(request.UserLibraryNumber, request.BookReferenceNumber);
        //        return Ok("Book borrowed successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //// Return a book
        //[HttpPost("return")]
        //public IActionResult ReturnBook([FromBody] ReturnRequest request)
        //{
        //    try
        //    {
        //        _libraryService.ReturnBook(request.UserLibraryNumber, request.BookReferenceNumber);
        //        return Ok("Book returned successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // Get all users
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            List<User> users = await _libraryService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
