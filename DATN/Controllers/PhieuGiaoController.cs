using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.PhieuGiao;
using DATN.Services.PhieuGiaoService;
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
    public class PhieuGiaoController : ControllerBase
    {
        private readonly IPhieuGiaoService _phieuGiaoService;
        private readonly IMapper _mapper;
        public PhieuGiaoController(IPhieuGiaoService phieuGiaoService, IMapper mapper)
        {
            _mapper = mapper;
            _phieuGiaoService = phieuGiaoService;
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpPost]
        public async Task<IActionResult> CreatePG(PhieuGiao phieugiao)
        {
            try
            {
                await _phieuGiaoService.CreatePG(phieugiao);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet]
        public async Task<IActionResult> GetAllPG()
        {
            var pgs = await _phieuGiaoService.GetAllPG();
            if (pgs == null)
            {
                return null;
            }
            var pgDto = _mapper.Map<IList<PhieuGiaoModel>>(pgs);
            return Ok(pgDto);
        }


        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet("{sophieugiao}")]
        public async Task<IActionResult> GetByIdPG(string sophieugiao)
        {
            var pg = await _phieuGiaoService.GetByIdPG(sophieugiao);
            if (pg == null)
            {
                return NotFound();
            }
            var pgDto = _mapper.Map<PhieuGiaoModel>(pg);
            return Ok(pgDto);
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpDelete("{sophieugiao}")]
        public async Task<IActionResult> DeletePG(string sophieugiao)
        {
            await _phieuGiaoService.DeletePG(sophieugiao);
            return Ok();
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet("{sophieugiao}/chitietphieu")]
        public async Task<IActionResult> GetDetailPG(string sophieugiao)
        {
            var ctgs = await _phieuGiaoService.GetDetailPG(sophieugiao);
            if (ctgs == null)
            {
                return null;
            }
            var ctgDto = _mapper.Map<IList<ListChiTietPGModel>>(ctgs);
            return Ok(ctgDto);
        }
        [Authorize(Roles = "Admin,ThucPham")]
        [HttpPut("{sophieugiao}")]
        public async Task<IActionResult> UpdatePYC(string sophieugiao, PhieuGiao phieugiao)
        {
            phieugiao.SoPhieuGiao = sophieugiao;
            await _phieuGiaoService.UpdatePG(phieugiao);
            return Ok();
        }

    }
}
