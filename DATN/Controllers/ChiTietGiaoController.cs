using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.ChiTietGiao;
using DATN.Services.ChiTietGiaoService;
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
    public class ChiTietGiaoController : ControllerBase
    {
        private readonly IChiTietGiaoService _chitietgiaoService;
        private readonly IMapper _mapper;
        public ChiTietGiaoController(IChiTietGiaoService chiTietGiaoService, IMapper mapper)
        {
            _chitietgiaoService = chiTietGiaoService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpPost]
        public async Task<IActionResult> CreateCTCC(ChiTietGiao chitietg)
        {
            try
            {
                await _chitietgiaoService.Create(chitietg);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet]
        public async Task<IActionResult> GetAllCTG()
        {
            var ctgs = await _chitietgiaoService.GetAllCTG();
            if (ctgs == null)
            {
                return null;
            }
            var ctgDto = _mapper.Map<IList<ChiTietGiaoModel>>(ctgs);
            return Ok(ctgDto);
        }
        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCTG(int id)
        {
            var ctg = await _chitietgiaoService.GetByIdCTG(id);
            if (ctg == null)
            {
                return NotFound();
            }
            var ctgDto = _mapper.Map<ChiTietGiaoModel>(ctg);
            return Ok(ctgDto);
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCTG(int id, ChiTietGiao chitietg)
        {
            chitietg.Id = id;
            await _chitietgiaoService.UpdateCTG(chitietg);
            return Ok();
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCTG(int id)
        {
            await _chitietgiaoService.DeleteCTG(id);
            return Ok();
        }
    }
}
