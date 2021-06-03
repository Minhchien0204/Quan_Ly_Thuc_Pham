﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Models.PhieuYeuCau
{
    public class PhieuYeuCauModel
    {
        public string SoPhieuYeuCau { get; set; }
        public string MaNhanVien { get; set; }
        public string Name { get; set; }
        public DateTime NgayLap { get; set; }
        public bool TrangThai { get; set; }
        public string GhiChu { get; set; }
    }
}
