using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.ChiTietKiemKe;
using DATN.Services.ChiTietKiemKeService;
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
    public class ChiTietKiemKeController : ControllerBase
    {
        private readonly IChiTietKiemKeService _chitietkiemkeService;
        private readonly IMapper _mapper;
        public ChiTietKiemKeController(IChiTietKiemKeService chiTietKiemKeService, IMapper mapper)
        {
            _chitietkiemkeService = chiTietKiemKeService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpPost]
        public async Task<IActionResult> CreateCTKK(ChiTietKiemKe chitietkk)
        {
            try
            {
                await _chitietkiemkeService.Create(chitietkk);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet]
        public async Task<IActionResult> GetAllCTKK()
        {
            var ctkks = await _chitietkiemkeService.GetAllCTKK();
            if (ctkks == null)
            {
                return null;
            }
            var ctkkDto = _mapper.Map<IList<ChiTietKiemKeModel>>(ctkks);
            return Ok(ctkkDto);
        }
        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCTKK(int id)
        {
            var ctkk = await _chitietkiemkeService.GetCTKKById(id);
            if (ctkk == null)
            {
                return NotFound();
            }
            var ctkkDto = _mapper.Map<ChiTietKiemKeModel>(ctkk);
            return Ok(ctkkDto);
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCTKK(int id, ChiTietKiemKe chitietkk)
        {
            chitietkk.Id = id;
            await _chitietkiemkeService.UpdateCTKK(chitietkk);
            return Ok();
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCTKK(int id)
        {
            await _chitietkiemkeService.DeleteCTKK(id);
            return Ok();
        }
    }
}
