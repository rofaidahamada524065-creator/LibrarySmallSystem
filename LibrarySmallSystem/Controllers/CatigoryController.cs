using AutoMapper;
using LibrarySmallSystem.DTOs.Catigory;
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
        //[HttpGet("GetAllWithNumberOfBook")]
        //public IActionResult GetAllWithNumberOfBook()
        //{
        //    var categories = _unitOfWork.Category.GetAllWithNumberOfBook();
        //    var x= _mapper.Map<ICollection<CategoryDTO>>(categories);
        //    x.Select(c => new CategoryDTO
        //    {
             
        //        Name = c.Name
               
        //    }).ToList();
        //    return Ok(x);
        //}
        [HttpPost("AddCategory")]
        public IActionResult AddCategory(CreatecatigoryDTO categoryDTO)
        {
            var category = _mapper.Map<LibrarySmallSystem.Model.Category>(categoryDTO);
            _unitOfWork.Category.Add(category);
            _unitOfWork.save();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _unitOfWork.Category.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Delete(id);
            _unitOfWork.save();
            return Ok();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var category = _unitOfWork.Category.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return Ok(categoryDTO);
        }
    }
}
