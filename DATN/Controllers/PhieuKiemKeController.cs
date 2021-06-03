using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.PhieuKiemKe;
using DATN.Services.PhieuKiemKeService;
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
    public class PhieuKiemKeController : ControllerBase
    {
        private readonly IPhieuKiemKeService _phieukiemkeService;
        private readonly IMapper _mapper;
        public PhieuKiemKeController(IPhieuKiemKeService phieuKiemKeService, IMapper mapper)
        {
            _mapper = mapper;
            _phieukiemkeService = phieuKiemKeService;
        }
        [Authorize(Roles = "Admin,NhaBep")]
        [HttpPost]
        public async Task<IActionResult> CreatePKK(PhieuKiemKe phieukiemke)
        {
            try
            {
                await _phieukiemkeService.CreatePKK(phieukiemke);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,ThucPham,NhaBep")]
        [HttpGet]
        public async Task<IActionResult> GetAllPKK()
        {
            var pkks = await _phieukiemkeService.GetAllPKK();
            if (pkks == null)
            {
                return null;
            }
            var pkkDto = _mapper.Map<IList<PhieuKiemKeModel>>(pkks);
            return Ok(pkkDto);
        }

        [Authorize(Roles = "Admin,ThucPham,NhaBep")]
        [HttpGet("{sophieukiemke}")]
        public async Task<IActionResult> GetByIdPKK(string sophieukiemke)
        {
            var pkk = await _phieukiemkeService.GetByIdPKK(sophieukiemke);
            if (pkk == null)
            {
                return NotFound();
            }
            var pkkDto = _mapper.Map<PhieuKiemKeModel>(pkk);
            return Ok(pkkDto);
        }

        [Authorize(Roles = "Admin,ThucPham,NhaBep")]
        [HttpDelete("{sophieukiemke}")]
        public async Task<IActionResult> DeletePKK(string sophieukiemke)
        {
            await _phieukiemkeService.DeletePKK(sophieukiemke);
            return Ok();
        }

        [Authorize(Roles = "Admin,ThucPham,NhaBep")]
        [HttpGet("{sophieukiemke}/chitietphieu")]
        public async Task<IActionResult> GetDetailPKK(string sophieukiemke)
        {
            var ctkks = await _phieukiemkeService.GetDetailPKK(sophieukiemke);
            if (ctkks == null)
            {
                return null;
            }
            var ctkkDto = _mapper.Map<IList<ListChiTietKiemKeModel>>(ctkks);
            return Ok(ctkkDto);
        }
        [Authorize(Roles = "Admin,Nhabep")]
        [HttpPut("{sophieukiemke}")]
        public async Task<IActionResult> UpdatePKK(string sophieukiemke, PhieuKiemKe phieukiemke)
        {
            phieukiemke.SoPhieuKiemKe = sophieukiemke;
            await _phieukiemkeService.UpdatePKK(phieukiemke);
            return Ok();
        }

    }
}
