using AutoMapper;
using LibrarySmallSystem.DTOs.Borrowing;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.UnitOfWorkk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySmallSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BorrowingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateBorrowingDTO dto)
        {
            var x = _unitOfWork.member.GetByIdAsync(dto.MemberId);
            if (x == null)
            {
                return NotFound("Member Not Found");
            }
            var c = _unitOfWork.Book.GetByIdAsync(dto.BookId);
            if (c == null)
            {
                return NotFound("Book Not found");
            }
            if (c.IsAvailable == false)
            {
                return BadRequest("The Book is not Available");
            }
             c.IsAvailable = false;
            var b = _mapper.Map<Borrowing>(dto);
            _unitOfWork.borow.AddAsync(b);
            //_unitOfWork.Book.Update(c, id);
            _unitOfWork.save();
            return Ok();
        }

        [HttpGet]
        public IActionResult Getall()
        {
            var x = _unitOfWork.borow.Details();
            var list = x.Select(a => new
            {
                BorrowingID = a.Id,
                Title = a.Book.Title,
                memberName = a.Member.Name,
                a.BorrowedDate,
                a.ReturnedDate,

            }).ToList();
            return Ok(list);
        }


        [HttpPut]
        public IActionResult Update(int id)
        {
            var c = _unitOfWork.borow.Updateee(id);
            if (c== null)
            {
                return NotFound();
            }

            
            _unitOfWork.save();
            return Ok();


        }
    }
}
