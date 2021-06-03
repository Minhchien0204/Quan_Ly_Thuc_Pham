using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using DATN.Services.HocSinhService;
using DATN.Entities;
using DATN.Models;
using AutoMapper;

namespace DATN.Controllers
{
    [Authorize]
    [ApiController]

    [Route("api/[controller]")]
    public class HocSinhController : ControllerBase
    {
        private readonly IHocSinhService _hocSinhService;
        private readonly IMapper _mapper;

        public HocSinhController(IHocSinhService hocSinhService, IMapper mapper)
        {
            _hocSinhService = hocSinhService;
            _mapper = mapper;
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateHs(HocSinh hocsinh)
        {
            try
            {
                await _hocSinhService.CreateHs(hocsinh);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAllHs()
        {
            var hocsinhs = await _hocSinhService.GetAllHs();
            var hsDto = _mapper.Map<IList<HocSinhModel>>(hocsinhs);
            return Ok(hsDto);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdHs(int id)
        {
            var hocsinh = await _hocSinhService.GetByIdHs(id);
            if (hocsinh == null)
            {
                return NotFound();
            }
            var hsDto = _mapper.Map<HocSinhModel>(hocsinh);
            return Ok(hsDto);
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHs(int id, HocSinhModel hocsinh)
        {
            if(id != hocsinh.Idhs)
            {
                return BadRequest("Not a valid hocsinh id");
            }
            var hsDto = _mapper.Map<HocSinh>(hocsinh);
            await _hocSinhService.UpdateHs(hsDto);
            return Ok();
        }
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHS(int id)
        {
            await _hocSinhService.DeleteHs(id);
            return Ok();
        }
    }
}
