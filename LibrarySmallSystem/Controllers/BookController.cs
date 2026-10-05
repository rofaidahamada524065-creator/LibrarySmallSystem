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

        [HttpGet("{t}")]
        public IActionResult GetAll(string t) 
        {

            var x = _repo.Book.Search(t);
            var list=_mapper.Map<List<BookDTO>>(x);
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Get(CreateBookDTO Dto)
        {
            if(Dto == null)
            {
                return BadRequest("Data Not Found");
            }
           var s=_mapper.Map<Book>(Dto);
            _repo.Book.Add(s);
            _repo.save();
            return Ok();

        }

        [HttpGet("highestPrice")]
        public IActionResult highestPrice()
        {
            var x = _repo.Book.HighestPrice();
           
            return Ok(x);
        }
    }
}
