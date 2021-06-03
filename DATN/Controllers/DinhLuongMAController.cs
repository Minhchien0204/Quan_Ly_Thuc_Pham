using AutoMapper;
using DATN.Entities;
using DATN.Models.DinhLuonMonAn;
using DATN.Services.DinhLuongMonAnService;
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
    public class DinhLuongMAController : ControllerBase
    {
        private readonly IDinhLuongMAService _dinhluongMAService;
        private readonly IMapper _mapper;

        public DinhLuongMAController(IDinhLuongMAService dinhLuongMAService, IMapper mapper)
        {
            _dinhluongMAService = dinhLuongMAService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpPost]
        public async Task<IActionResult> CreateDLMA(DinhLuongMonAn dinhluongma)
        {
            try
            {
                await _dinhluongMAService.CreateDLMA(dinhluongma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpGet]
        public async Task<IActionResult> GetAllDLMA()
        {
            var dlmas = await _dinhluongMAService.GetAllDLMA();
            var dlmaDto = _mapper.Map<IList<DinhLuongMAModel>>(dlmas);
            return Ok(dlmaDto);
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dlma = await _dinhluongMAService.GetById(id);
            if(dlma == null)
            {
                return NotFound();
            }
            var dlmaDto = _mapper.Map<DinhLuongMAModel>(dlma);
            return Ok(dlmaDto);
        }


        [Authorize(Roles = "Admin,NhaBep")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDLMA(int id,  DinhLuongMonAn dinhluongma)
        {
            dinhluongma.Id = id;
            await _dinhluongMAService.UpdateDLMA(dinhluongma);
            return Ok();
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaDMLMA(int id)
        {
            await _dinhluongMAService.DeleteDLMA(id);
            return Ok();
        }

    }
}
