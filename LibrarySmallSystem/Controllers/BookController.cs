using AutoMapper;
using LibrarySmallSystem.DTOs.Books;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.UnitOfWorkk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySmallSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;
        public BookController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateBookDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Data not valide");
            }

            var  c =  _mapper.Map<Book>(dto);

             _repo.Book.AddAsync(c);

            _repo.save();

            return Ok();
        }

        [HttpGet("Search")]
        public IActionResult Search(string word)
        {
            if (word == null)
            {
                return  BadRequest("invalid data");
            }
            var x = _repo.Book.Search(word);
            if (x == null)
            {
                return null;
            }
            var c = x.Select(a => new
            {
                a.Id,
                a.Author,
                a.Title,
                a.Price

            }).ToList();
            return Ok(c);
        }

        [HttpGet("Most_Expensive")]

        public IActionResult Most_Expensive()
        {
            var s = _repo.Book.BookWithHighstPrice();
           
            var c = _mapper.Map<BookDTO>(s);
            return Ok(c);
        }


    }
}
