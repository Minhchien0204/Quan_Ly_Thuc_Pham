using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.ChiTietCungCap;
using DATN.Services.ChiTietCungCapService;
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
    public class ChiTietCungCapController : ControllerBase
    {
        private readonly IChiTietCungCapService _chitietcungcapService;
        private readonly IMapper _mapper;
        public ChiTietCungCapController(IChiTietCungCapService chiTietCungCapService, IMapper mapper)
        {
            _chitietcungcapService = chiTietCungCapService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpPost]
        public async Task<IActionResult> CreateCTCC(ChiTietCungCap chitietcc)
        {
            try
            {
                await _chitietcungcapService.Create(chitietcc);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet]
        public async Task<IActionResult> GetAllCTCC()
        {
            var ctccs = await _chitietcungcapService.GetAllCTCC();
            if (ctccs == null)
            {
                return null;
            }
            var ctccDto = _mapper.Map<IList<ChiTietCungCapModel>>(ctccs);
            return Ok(ctccDto);
        }

        [Authorize(Roles = "Admin,NhaBep,ThucPham")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCTCC(int id)
        {
            var ctcc = await _chitietcungcapService.GetByIdCTCC(id);
            if (ctcc == null)
            {
                return NotFound();
            }
            var ctccDto = _mapper.Map<ChiTietCungCapModel>(ctcc);
            return Ok(ctccDto);
        }


        [Authorize(Roles = "Admin,ThucPham")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCTCC(int id, ChiTietCungCap chitietcc)
        {
            chitietcc.Id = id;
            await _chitietcungcapService.UpdateCTCC(chitietcc);
            return Ok();
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCTCC(int id)
        {
            await _chitietcungcapService.DeleteCTCC(id);
            return Ok();
        }
    }
}
