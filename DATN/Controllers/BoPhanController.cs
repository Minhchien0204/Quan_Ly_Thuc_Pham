using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.BoPhan;
using DATN.Services.BoPhanService;
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
    public class BoPhanController : ControllerBase
    {
        private readonly IBoPhanServive _bophanService;
        private readonly IMapper _mapper;
        public BoPhanController(IBoPhanServive bophanService, IMapper mapper)
        {
            _bophanService = bophanService;
            _mapper = mapper;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateBP(BoPhan bophan)
        {
            try
            {
                await _bophanService.CreateBoPhan(bophan);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{MaBoPhan}")]
        public async Task<IActionResult> DeleteBP(string MaBoPhan)
        {
            await _bophanService.Delete(MaBoPhan);
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAllBP()
        {
            var bophan = await _bophanService.GetBoPhans();
            var bpDto = _mapper.Map<IList<BoPhanModel>>(bophan);
            return Ok(bpDto);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{MaBoPhan}/nhanvien")]
        public async Task<IActionResult> GetBPNhanVien(string MaBoPhan)
        {
            var nhanviens = await _bophanService.GetBoPhanDetail(MaBoPhan);
            if(nhanviens == null)
            {
                return null;
            }
            var nvDto = _mapper.Map<IList<ListNhanVienModel>>(nhanviens);
            return Ok(nvDto);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{mabophan}")]
        public async Task<IActionResult> GetByIdBP(string mabophan)
        {
            var bp = await _bophanService.GetByIdBP(mabophan);
            if(bp == null)
            {
                return NotFound();
            }
            var bpDto = _mapper.Map<BoPhanModel>(bp);
            return Ok(bpDto);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{mabophan}")]
        public async Task<IActionResult> UpdateBP(string mabophan, [FromBody]BoPhanModel boPhan)
        {
            boPhan.MaBoPhan = mabophan;
            var bpDto = _mapper.Map<BoPhan>(boPhan);
            await _bophanService.UpdateBP(bpDto);
            return Ok();
        }
    }
}
