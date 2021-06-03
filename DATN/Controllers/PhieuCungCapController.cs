using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.PhieuCungCap;
using DATN.Services.PhieuCungCapService;
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
    public class PhieuCungCapController : ControllerBase
    {
        private readonly IPhieuCungCapService _phieucungcapService;
        private readonly IMapper _mapper;
        public PhieuCungCapController(IPhieuCungCapService phieuCungCapService, IMapper mapper)
        {
            _mapper = mapper;
            _phieucungcapService = phieuCungCapService;
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpPost]
        public async Task<IActionResult> CreatePCC(PhieuCungCap phieucungcap)
        {
            try
            {
                await _phieucungcapService.CreatePCC(phieucungcap);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet]
        public async Task<IActionResult> GetAllPCC()
        {
            var pccs = await _phieucungcapService.GetAllPCC();
            if (pccs == null)
            {
                return null;
            }
            var pccDto = _mapper.Map<IList<PhieuCungCapModel>>(pccs);
            return Ok(pccDto);
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet("{sophieucungcap}")]
        public async Task<IActionResult> GetByIdPCC(string sophieucungcap)
        {
            var pcc = await _phieucungcapService.GetByIdPYC(sophieucungcap);
            if (pcc == null)
            {
                return NotFound();
            }
            var pycDto = _mapper.Map<PhieuCungCapModel>(pcc);
            return Ok(pycDto);
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpPut("{sophieucungcap}")]
        public async Task<IActionResult> UpdatePYC(string sophieucungcap, PhieuCungCap phieucungcap)
        {
            phieucungcap.SoPhieuCugCap = sophieucungcap;
            await _phieucungcapService.UpdatePYC(phieucungcap);
            return Ok();
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet("{sophieucungcap}/chitietphieu")]
        public async Task<IActionResult> GetDetailPYC(string sophieucungcap)
        {
            var ctccs = await _phieucungcapService.GetDetailPYC(sophieucungcap);
            if (ctccs == null)
            {
                return null;
            }
            var ctccDto = _mapper.Map<IList<ListChiTietPCC>>(ctccs);
            return Ok(ctccDto);
        }


        [Authorize(Roles = "Admin,ThucPham")]
        [HttpDelete("{sophieucungcap}")]
        public async Task<IActionResult> DeletePYC(string sophieucungcap)
        {
            await _phieucungcapService.DeletePCC(sophieucungcap);
            return Ok();
        }
    }
}
