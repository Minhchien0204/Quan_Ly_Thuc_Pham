﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Models.PhieuYeuCau
{
    public class ListChiTietPYC
    {
        public int Id { get; set; }
        public string SoPhieuYeuCau { get; set; }
        public string MaThucPham { get; set; }
        public string TenThucPham { get; set; }
        public float SoLuong { get; set; }
    }
}
