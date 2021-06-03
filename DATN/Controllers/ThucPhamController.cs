using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.ThucPham;
using DATN.Services.ThucPhamService;
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
    public class ThucPhamController : ControllerBase
    {
        private readonly IThucPhamService _thucphamService;
        private readonly IMapper _mapper;
        public ThucPhamController(IThucPhamService thucPhamService, IMapper mapper)
        {
            _thucphamService = thucPhamService;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin,NhaBep")]
        [HttpPost]
        public async Task<IActionResult> CreateTP(ThucPham thucpham)
        {
            try
            {
                await _thucphamService.CreateTP(thucpham);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,ThucPham,NhaBep")]
        [HttpGet]
        public async Task<IActionResult> GetAllTP()
        {
            var thucphams = await _thucphamService.GetAllTP();
            var tpDto = _mapper.Map<IList<ThucPhamModel>>(thucphams);
            return Ok(tpDto);
        }

        [Authorize(Roles = "Admin,ThucPham")]
        [HttpDelete("{mathucpham}")]
        public async Task<IActionResult> DeleteTP(string mathucpham)
        {
            await _thucphamService.Delete(mathucpham);
            return Ok();
        }

        [Authorize(Roles = "Admin,ThucPham,NhaBep")]
        [HttpGet("{mathucpham}")]
        public async Task<IActionResult> GetbyIdTP(string mathucpham)
        {
            var thupham = await _thucphamService.GetByteIdTP(mathucpham);
            if (thupham == null)
            {
                return NotFound();
            }
            var tpDto = _mapper.Map<ThucPhamModel>(thupham);
            return Ok(tpDto);
        }

        [Authorize(Roles = "Admin,ThucPham,NhaBep")]
        [HttpPut("{mathucpham}")]
        public async Task<IActionResult> PutTP(string mathucpham, [FromBody]ThucPhamModel thucpham)
        {
            thucpham.MaThucPham = mathucpham;
            var tpDto = _mapper.Map<ThucPham>(thucpham);
            if (mathucpham != thucpham.MaThucPham)
            {
                return BadRequest("not valid thucpham mathupham");
            }
            await _thucphamService.UpdateTP(tpDto);
            return Ok();
        }

    }
}
