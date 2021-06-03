using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.PhieuYeuCau;
using DATN.Services.PhieuYeuCauService;
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
    public class PhieuYeuCauController : ControllerBase
    {
        private readonly IPhieuYeuCauService _phieuyeucauService;
        private readonly IMapper _mapper;
        public PhieuYeuCauController(IPhieuYeuCauService phieuYeuCauService, IMapper mapper)
        {
            _phieuyeucauService = phieuYeuCauService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpPost]
        public async Task<IActionResult> CreatePYC(PhieuYeuCau phieuyeucau)
        {
            try
            {
                await _phieuyeucauService.CreatePYC(phieuyeucau);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet]
        public async Task<IActionResult> GetAllPYC()
        {
            var pycs = await _phieuyeucauService.GetAllPYC();
            if (pycs == null)
            {
                return null;
            }
            var pycDto = _mapper.Map<IList<PhieuYeuCauModel>>(pycs);
            return Ok(pycDto);
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet("{sophieuyeucau}")]
        public async Task<IActionResult> GetByIdPYC(string sophieuyeucau)
        {
            var pyc = await _phieuyeucauService.GetByIdPYC(sophieuyeucau);
            if (pyc == null)
            {
                return NotFound();
            }
            var pycDto = _mapper.Map<PhieuYeuCauModel>(pyc);
            return Ok(pycDto);
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpPut("{sophieuyeucau}")]
        public async Task<IActionResult> UpdatePYC( string sophieuyeucau, PhieuYeuCau phieuyeucau)
        {
            phieuyeucau.SoPhieuYeuCau = sophieuyeucau;
            await _phieuyeucauService.UpdatePYC(phieuyeucau);
            return Ok();
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet("{sophieuyeucau}/chitietphieu")]
        public async Task<IActionResult> GetDetailPYC(string sophieuyeucau)
        {
            var ctycs = await _phieuyeucauService.GetDetailPYC(sophieuyeucau);
            if(ctycs == null )
            {
                return null;
            }
            var ctycDto = _mapper.Map<IList<ListChiTietPYC>>(ctycs);
            return Ok(ctycDto);
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpDelete("{sophieuyeucau}")]
        public async Task<IActionResult> DeletePYC(string sophieuyeucau)
        {
            await _phieuyeucauService.DeletePYC(sophieuyeucau);
            return Ok();
        }
    }
}
