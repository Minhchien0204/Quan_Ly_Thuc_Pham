using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.ChiTietBanGiao;
using DATN.Services.ChiTietBanGiaoService;
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
    public class ChiTietBanGiaoController : ControllerBase
    {
        private readonly IChiTietBanGiaoService _chitietbangiaoService;
        private readonly IMapper _mapper;
        public ChiTietBanGiaoController(IChiTietBanGiaoService chiTietBanGiaoService, IMapper mapper)
        {
            _chitietbangiaoService = chiTietBanGiaoService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpPost]
        public async Task<IActionResult> CreateCTCC(ChiTietBanGiao chitietbg)
        {
            try
            {
                await _chitietbangiaoService.Create(chitietbg);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet]
        public async Task<IActionResult> GetAllCTBG()
        {
            var ctbgs = await _chitietbangiaoService.GetAllCTBG();
            if (ctbgs == null)
            {
                return null;
            }
            var ctbgDto = _mapper.Map<IList<ChiTietBanGiaoModel>>(ctbgs);
            return Ok(ctbgDto);
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCTBG(int id)
        {
            var ctbg = await _chitietbangiaoService.GetByIdCTBG(id);
            if (ctbg == null)
            {
                return NotFound();
            }
            var ctbgDto = _mapper.Map<ChiTietBanGiaoModel>(ctbg);
            return Ok(ctbgDto);
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCTBG(int id, ChiTietBanGiao chitietbg)
        {
            chitietbg.Id = id;
            await _chitietbangiaoService.UpdateCTBG(chitietbg);
            return Ok();
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCTBG(int id)
        {
            await _chitietbangiaoService.DeleteCTBG(id);
            return Ok();
        }

    }
}
