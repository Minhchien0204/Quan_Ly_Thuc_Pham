using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.MonAn;
using DATN.Services.MonAnService;
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
    public class MonAnController : ControllerBase
    {
        private readonly IMonAnServiece _monanService;
        private readonly IMapper _mapper;

        public MonAnController(IMonAnServiece monanService, IMapper mapper)
        {
            _monanService = monanService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpPost]
        public async Task<IActionResult> CreateMA(MonAn monan)
        {
            try
            {
                await _monanService.CreateMA(monan);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpGet]
        public async Task<IActionResult> GetAllMA()
        {
            var monan = await _monanService.GetAllMA();
            var maDtos = _mapper.Map<IList<MonAnModel>>(monan);
            return Ok(maDtos);
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpGet("{MaMonAn}")]
        public async Task<IActionResult> GetByIdMA(string MaMonAn)
        {
            var monan = await _monanService.GetById(MaMonAn);
            var maDto = _mapper.Map<MonAnModel>(monan);
            return Ok(maDto);
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpGet("{MaMonAn}/dinhluong")]
        public async Task<IActionResult> GetDetailMA(string MaMonAn)
        {
            var dlma = await _monanService.GetDetalMA(MaMonAn);
            if(dlma == null)
            {
                return null;
            }
            var dlmaDto = _mapper.Map<IList<ListDinhLuongMAModel>>(dlma);
            return Ok(dlmaDto);
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpPut("{MaMonAn}")]
        public async Task<IActionResult> UpdateMA(string MaMonAn, MonAn monan)
        {
            monan.MaMonAn = MaMonAn;
            await _monanService.UpdateMA(monan);
            return Ok();
        }

        [Authorize(Roles = "Admin,NhaBep")]
        [HttpDelete("{MaMonAn}")]
        public async Task<IActionResult> DeleteMA(string MaMonAn)
        {
            await _monanService.DeleteMA(MaMonAn);
            return Ok();
        }

    }
}
