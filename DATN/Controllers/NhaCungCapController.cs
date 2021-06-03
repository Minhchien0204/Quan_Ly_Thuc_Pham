using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.NhaCungCap;
using DATN.Services.NhaCungCapService;
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
    public class NhaCungCapController : ControllerBase
    {
        private readonly INhaCungCapService _nhaCungCapService;
        private readonly IMapper _mapper;

        public NhaCungCapController(INhaCungCapService nhaCungCapService, IMapper mapper)
        {
            _nhaCungCapService = nhaCungCapService;
            _mapper = mapper;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create(NhaCungCap nhacungcap)
        {
            try
            {
                await _nhaCungCapService.Create(nhacungcap);
                return Ok();
            }
            catch (Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet]
        public async Task<IActionResult> GetAlllNCC()
        {
            var ncc = await _nhaCungCapService.GetAllNhaCC();
            if(ncc == null)
            {
                return null;
            }
            var nccDto = _mapper.Map<IList<NhaCungCapModel>>(ncc);
            return Ok(nccDto);
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpGet("{MaNhaCungCap}")]
        public async Task<IActionResult> GetByIdNCC(string MaNhaCungCap)
        {
            var ncc = await _nhaCungCapService.GetByIdNhaCC(MaNhaCungCap);
            if (ncc == null)
            {
                return NotFound();
            }
            var nccDto = _mapper.Map<NhaCungCapModel>(ncc);
            return Ok(nccDto);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{MaNhaCungCap}")]
        public async Task<IActionResult> UpdateNCC(string MaNhaCungCap, NhaCungCap nhacungcap)
        {
            nhacungcap.MaNhaCungCap = MaNhaCungCap;
            await _nhaCungCapService.UpdateNhaCC(nhacungcap);
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{MaNhaCungCap}")]
        public async Task<IActionResult> DeleteNCC(string MaNhaCungCap)
        {
            await _nhaCungCapService.Delete(MaNhaCungCap);
            return Ok();
        }

    }
}
