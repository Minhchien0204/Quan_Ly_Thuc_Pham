using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.NhanVien;
using DATN.Services.NhanVienService;
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
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanvienService;
        private readonly IMapper _mapper;
        public NhanVienController(INhanVienService nhanvienService, IMapper mapper)
        {
            _nhanvienService = nhanvienService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet]
        public async Task<IActionResult> GetAllNV()
        {
            var nhanviens = await _nhanvienService.GetAllNV();
            var nv = _mapper.Map<IList<NhanVienModel>>(nhanviens);
            return Ok(nv);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{MaNhanVien}")]
        public async Task<IActionResult> GetByIdNV(string MaNhanVien)
        {
            var nhanvien = await _nhanvienService.GetByIdNV(MaNhanVien);
            if(nhanvien != null)
            {
                var nvDto = _mapper.Map<NhanVienModel>(nhanvien);
                return Ok(nvDto);
            }
            return NotFound();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{MaNhanVien}")]
        public async Task<IActionResult> UpdateNV(string MaNhanVien, [FromBody]UpdateNVModel nhanvien)
        {
            if(MaNhanVien != nhanvien.MaNhanVien)
            {
                return BadRequest("Not a valid NhanVien id");
            }
            var nvDto = _mapper.Map<NhanVien>(nhanvien);
            await _nhanvienService.UpdateNV(nvDto);
            return NoContent();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{MaNhanVien}")]
        public async Task<IActionResult> DeleteNV(string MaNhanVien)
        {
            await _nhanvienService.DeleteNV(MaNhanVien);
            return Ok();
        }

    }
}
