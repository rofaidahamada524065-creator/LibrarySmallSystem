using AutoMapper;
using LibrarySmallSystem.DTOs.Catigory;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.UnitOfWorkk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySmallSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatigoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CatigoryController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetAllWithNumberOfBook")]
        public IActionResult GetAllWithNumberOfBook()
        {
            var categories = _unitOfWork.catigory.CatigoryWithNumberOfBook();

            var x = categories.Select(c => new 
            {

                Id = c.Id,
                Name = c.Name,
                numberOfBook = c.Books.Count

            }).ToList();
            return Ok(x);
        }
        [HttpPost("AddCategory")]
        public IActionResult AddCategory(CreatecatigoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Data not found");
            }
            var category = _mapper.Map<Category>(categoryDTO);
            _unitOfWork.catigory.AddAsync(category);
            _unitOfWork.save();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _unitOfWork.catigory.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.catigory.DeleteAsync(id);
            _unitOfWork.save();
            return Ok();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var category = _unitOfWork.catigory.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return Ok(categoryDTO);
        }
    }
}
