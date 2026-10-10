using AutoMapper;
using LibrarySmallSystem.DTOs.Member;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.UnitOfWorkk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySmallSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _map;
        public MemberController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _map = mapper;
            _repo = unitOfWork;
        }

        [HttpPost]
        public IActionResult Create(CreateMemberDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("data not found");
            }
            var c = _map.Map<Member>(dto);
            _repo.member.AddAsync(c);
            _repo.save();
            return Ok();
        }

        [HttpGet("Top_Reader")]
        public IActionResult Top_Reader()
        {
            var x = _repo.member.Top_Reader();
            var c = _map.Map<List<MemberDTO>>(x);

            return Ok(c);
        }

        [HttpGet("Statitics")]
        public IActionResult Statitics(int Mid)
        {
            var x = _repo.member.Statistics(Mid);
            if (x == null)
            {
                return NotFound("Member not found");
            }
            return Ok(x);
        }
    }
}
