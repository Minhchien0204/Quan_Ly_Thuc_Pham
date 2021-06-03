using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.PhieuBanGiao;
using DATN.Services.PhieuBanGiaoService;
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
    public class PhieuBanGiaoController : ControllerBase
    {
        private readonly IPhieuBanGiaoService _phieubangiaoService;
        private readonly IMapper _mapper;

        public PhieuBanGiaoController(IPhieuBanGiaoService phieuBanGiaoService, IMapper mapper)
        {
            _mapper = mapper;
            _phieubangiaoService = phieuBanGiaoService;
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpPost]
        public async Task<IActionResult> CreatePG(PhieuBanGiao phieubangiao)
        {
            try
            {
                await _phieubangiaoService.CreatePBG(phieubangiao);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet]
        public async Task<IActionResult> GetAllPBG()
        {
            var pbgs = await _phieubangiaoService.GetAllPBG();
            if (pbgs == null)
            {
                return null;
            }
            var pbgDto = _mapper.Map<IList<PhieuBanGiaoModel>>(pbgs);
            return Ok(pbgDto);
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet("{sophieubangiao}")]
        public async Task<IActionResult> GetByIdPBG(string sophieubangiao)
        {
            var pbg = await _phieubangiaoService.GetByIdPBG(sophieubangiao);
            if (pbg == null)
            {
                return NotFound();
            }
            var pbgDto = _mapper.Map<PhieuBanGiaoModel>(pbg);
            return Ok(pbgDto);
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpDelete("{sophieubangiao}")]
        public async Task<IActionResult> DeletePBG(string sophieubangiao)
        {
            await _phieubangiaoService.DeletePBG(sophieubangiao);
            return Ok();
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet("{sophieubangiao}/chitietphieu")]
        public async Task<IActionResult> GetDetailPBG(string sophieubangiao)
        {
            var ctbgs = await _phieubangiaoService.GetDetailPBG(sophieubangiao);
            if (ctbgs == null)
            {
                return null;
            }
            var ctbgDto = _mapper.Map<IList<ListChiTietBanGiaoModel>>(ctbgs);
            return Ok(ctbgDto);
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpPut("{sophieubangiao}")]
        public async Task<IActionResult> UpdatePYC(string sophieubangiao, PhieuBanGiao phieubangiao)
        {
            phieubangiao.SoPhieuBanGiao = sophieubangiao;
            await _phieubangiaoService.UpdatePBG(phieubangiao);
            return Ok();
        }
    }
}
