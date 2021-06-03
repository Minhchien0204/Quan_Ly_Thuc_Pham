using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Services.GiaoVienService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DATN.Controllers
{
    [Authorize]
    [ApiController]

    [Route("api/[controller]")]
    public class GiaoVienController : ControllerBase
    {
        private readonly IGiaoVienService _giaoVienService;
        private readonly IMapper _mapper;
        public GiaoVienController(IGiaoVienService giaoVienService, IMapper mapper)
        {
            _giaoVienService = giaoVienService;
            _mapper = mapper;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{MaGV}")]
        public async Task<IActionResult> PutGiaoVien(string MaGV, GiaoVien giaovien)
        {
            if (MaGV != giaovien.MaGV)
            {
                return BadRequest("Not a valid giaovien id");
            }
            await _giaoVienService.UpdateGiaoVien(giaovien);
            return NoContent();
        }
        [Authorize(Roles = "Admin,GiaoVien")]
        [HttpGet]
        public async Task<IActionResult> GetAllGiaoviens()
        {
            var giaoviens = await _giaoVienService.GetAllGiaoViens();
            var gv = _mapper.Map<IList<GiaoVienModel>>(giaoviens);
            return Ok(gv);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{MaGV}")]
        public async Task<IActionResult> GetGVById(string MaGV)
        {
            var gv = await _giaoVienService.GetByIdGiaoVien(MaGV);
            if (gv != null)
            {
                var gvDto = _mapper.Map<GiaoVienModel>(gv);
                return Ok(gvDto);
            }
            return NotFound();
        }
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{MaGV}")]
       /* public IActionResult DeleteGV(int id)
        {
            _giaoVienService.DeleteGV(id);
            return Ok();
        }*/
       public async Task<IActionResult> DeleteGV(string MaGV)
        {
            await _giaoVienService.DeleteGV(MaGV);
            return Ok();
        }
    }
}
