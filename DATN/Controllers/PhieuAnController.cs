using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.PhieuAn;
using DATN.Services.PhieuAnService;
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
    public class PhieuAnController : ControllerBase
    {
        private readonly IPhieuAnService _phieuanService;
        private readonly IMapper _mapper;

        public PhieuAnController( IPhieuAnService phieuAnService, IMapper mapper)
        {
            _mapper = mapper;
            _phieuanService = phieuAnService;
        }

        [Authorize(Roles = "Admin,GiaoVien")]
        [HttpPost]
        public async Task<IActionResult> Create(PhieuAn phieuan)
        {
            try
            {
                await _phieuanService.CreatePA(phieuan);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,GiaoVien,NhaBep")]
        [HttpGet]
        public async Task<IActionResult> GetAllPA()
        {
            var phieuans = await _phieuanService.GetAllPA();
            if(phieuans == null)
            {
                return null;
            }
            var paDto = _mapper.Map<IList<PhieuAnModel>>(phieuans);
            return Ok(paDto);
        }

        [Authorize(Roles = "Admin,GiaoVien,NhaBep")]
        [HttpGet("{sophieuan}")]
        public async Task<IActionResult> GetByIdPA(string sophieuan)
        {
            var phieuan = await _phieuanService.GetByIdPA(sophieuan);
            if(phieuan == null)
            {
                return NotFound();
            }
            var paDto = _mapper.Map<PhieuAnModel>(phieuan);
            return Ok(paDto);
        }

        [Authorize(Roles = "Admin,GiaoVien")]
        [HttpPut("{sophieuan}")]
        public async Task<IActionResult> UpdatePA(string sophieuan, PhieuAn phieuan)
        {
            phieuan.SophieuAn = sophieuan;
            await _phieuanService.UpdatePA(phieuan);
            return Ok();
        }


        [Authorize(Roles = "Admin,GiaoVien")]
        [HttpDelete("{sophieuan}")]
        public async Task<IActionResult> DeletePA(string sophieuan)
        {
            await _phieuanService.Delete(sophieuan);
            return Ok();
        }
    }
}
