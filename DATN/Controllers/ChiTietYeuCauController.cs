using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.ChiTietYeuCau;
using DATN.Services.ChiTietYeuCauService;
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
    public class ChiTietYeuCauController : ControllerBase
    {
        private readonly IChiTietYCService _chitietycService;
        private readonly IMapper _mapper;
        public ChiTietYeuCauController(IChiTietYCService chiTietYCService, IMapper mapper)
        {
            _chitietycService = chiTietYCService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpPost]
        public async Task<IActionResult> CreateCTYC(ChiTietYeuCau chitietyc)
        {
            try
            {
                await _chitietycService.Create(chitietyc);
                return Ok();
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet]
        public async Task<IActionResult> GetAllCTYC()
        {
            var ctycs = await _chitietycService.GetAllCTYC();
            if(ctycs == null)
            {
                return null;
            }
            var ctycDto = _mapper.Map<IList<ChiTietYeuCauModel>>(ctycs);
            return Ok(ctycDto);
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCTYC(int id)
        {
            var ctyc = await _chitietycService.GetCTYCById(id);
            if(ctyc == null )
            {
                return NotFound();
            }
            var ctycDto = _mapper.Map<ChiTietYeuCauModel>(ctyc);
            return Ok(ctycDto);
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCTYC(int id, ChiTietYeuCau chitietyc)
        {
            chitietyc.Id = id;
            await _chitietycService.UpdateCTYC(chitietyc);
            return Ok();
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCTYC(int id)
        {
            await _chitietycService.DeleteCTYC(id);
            return Ok();
        }
    }
}
