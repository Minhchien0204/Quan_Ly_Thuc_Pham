using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.Lop;
using DATN.Services.Lop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DATN.Controllers
{
    [Authorize]
    [ApiController]

    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        public ClassController(IClassService classService, IMapper mapper)
        {
            _classService = classService;
            _mapper = mapper;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateClass(Class lop)
        {
            try
            {
                await _classService.CreateClass(lop);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,GiaoVien")]
        [HttpGet]
        public async Task<IActionResult> GetAllClass()
        {
            var lop = await  _classService.GetAllClass();
            var lopDto = _mapper.Map<IList<ClassModel>>(lop);
            return Ok(lopDto);
        }

        [Authorize(Roles = "Admin,GiaoVien")]
        //[Authorize(Roles = Role.GiaoVien)]
        [HttpGet("{MaLop}/student")]
        public async Task<IActionResult> GetByIdClass(string Malop)
        {
            var hocsinhs = await _classService.GetByIdClass(Malop);
            if(hocsinhs == null)
            {
                return null;
            }
            var listhocsinh = _mapper.Map<IList<ListHocSinhModel>>(hocsinhs);
            return Ok(listhocsinh);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{MaLop}")]
        public async Task<IActionResult> PutClass(string MaLop, Class lop)
        {
            lop.MaLop = MaLop;
            await _classService.UpdateClass(lop);
            return Ok();
        }
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{malop}")]
        public async Task<IActionResult> DeleteClass(string malop)
        {
            await _classService.Delete(malop);
            return Ok();
        }
        [Authorize(Roles = "Admin,GiaoVien")]
        [HttpGet("{MaLop}")]
        public async Task<IActionResult> GetById(string MaLop)
        {
            var lop = await _classService.GetById(MaLop);
            if(lop.MaLop == null )
            {
                return BadRequest("ko tim lop");
            }
            return Ok(lop);
        }
    }
}
