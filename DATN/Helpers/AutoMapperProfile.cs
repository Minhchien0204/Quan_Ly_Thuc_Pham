using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Models.BoPhan;
using DATN.Models.ChiTietBanGiao;
using DATN.Models.ChiTietCungCap;
using DATN.Models.ChiTietGiao;
using DATN.Models.ChiTietKiemKe;
using DATN.Models.ChiTietYeuCau;
using DATN.Models.DinhLuonMonAn;
using DATN.Models.Lop;
using DATN.Models.MonAn;
using DATN.Models.NhaCungCap;
using DATN.Models.NhanVien;
using DATN.Models.PhieuAn;
using DATN.Models.PhieuBanGiao;
using DATN.Models.PhieuCungCap;
using DATN.Models.PhieuGiao;
using DATN.Models.PhieuKiemKe;
using DATN.Models.PhieuYeuCau;
using DATN.Models.ThucPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            //CreateMap<User, UserModel>();
            CreateMap<GiaoVien, GiaoVienModel>()
                .ForMember(d => d.Name, s => s.MapFrom(x => x.User.Name))
                .ForMember(d => d.DiaChi, s => s.MapFrom(x => x.User.DiaChi))
                .ForMember(d => d.DienThoai, s => s.MapFrom(x => x.User.DienThoai))
                .ForMember(d => d.NgaySinh, s => s.MapFrom(x => x.User.NgaySinh))
                .ForMember(d => d.MaLop, s => s.MapFrom(x => x.Class.MaLop));
            CreateMap<HocSinhModel, HocSinh>();
            CreateMap<HocSinh, HocSinhModel>();
            CreateMap<Class, ClassModel>()
                .ForMember(d => d.GiaoVien, s => s.MapFrom(x => x.GiaoVien.User.Name));
            CreateMap<HocSinh, ListHocSinhModel>();
            CreateMap<BoPhan, BoPhanModel>();
            CreateMap<BoPhanModel, BoPhan>();
            CreateMap<NhanVien, ListNhanVienModel>()
                .ForMember(d => d.UserId, s => s.MapFrom(x => x.UserId))
                .ForMember(d => d.HoTen, s => s.MapFrom(x => x.User.Name))
                .ForMember(d => d.NgaySinh, s => s.MapFrom(x => x.User.NgaySinh))
                .ForMember(d => d.GioiTinh, s => s.MapFrom(x => x.User.GioiTinh))
                .ForMember(d => d.DiaChi, s => s.MapFrom(x => x.User.DiaChi))
                .ForMember(d => d.DienThoai, s => s.MapFrom(x => x.User.DiaChi));
            CreateMap<NhanVien, NhanVienModel>()
                 .ForMember(d => d.Name, s => s.MapFrom(x => x.User.Name))
                .ForMember(d => d.DiaChi, s => s.MapFrom(x => x.User.DiaChi))
                .ForMember(d => d.DienThoai, s => s.MapFrom(x => x.User.DienThoai))
                .ForMember(d => d.NgaySinh, s => s.MapFrom(x => x.User.NgaySinh))
                .ForMember(d => d.TenBoPhan, s => s.MapFrom(x => x.BoPhan.TenBoPhan));
            /* CreateMap<UpdateNVModel, NhanVien>()
                 .ForPath(d => d.User.Role, s => s.MapFrom(x => x.Role));*/
            CreateMap<ThucPham, ThucPhamModel>();
            CreateMap<ThucPhamModel, ThucPham>();
            CreateMap<MonAn, MonAnModel>();
            CreateMap<DinhLuongMonAn, ListDinhLuongMAModel>()
                .ForMember(dlma => dlma.TenMonAn, s => s.MapFrom(x => x.MonAn.TenMonAn))
                .ForMember(dlma => dlma.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham));
            CreateMap<DinhLuongMonAn, DinhLuongMAModel>()
                .ForMember(dlma => dlma.TenMonAn, s => s.MapFrom(x => x.MonAn.TenMonAn))
                .ForMember(dlma => dlma.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham));
            CreateMap<PhieuAn, PhieuAnModel>()
                .ForMember(pa => pa.Name, s => s.MapFrom(x => x.GiaoVien.User.Name));
            CreateMap<PhieuYeuCau, PhieuYeuCauModel>()
                .ForMember(pyc => pyc.Name, s => s.MapFrom(x => x.NhanVien.User.Name));
            CreateMap<ChiTietYeuCau, ListChiTietPYC>()
                .ForMember(ctyc => ctyc.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham));
            CreateMap<NhaCungCap, NhaCungCapModel>();
            CreateMap<PhieuCungCap, PhieuCungCapModel>()
                .ForMember(pcc => pcc.Name, s => s.MapFrom(x => x.NhanVien.User.Name));
            CreateMap<ChiTietCungCap, ListChiTietPCC>()
                .ForMember(ctcc => ctcc.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham))
                .ForMember(ctcc => ctcc.TenNhaCungCap, s => s.MapFrom(x => x.NhaCungCap.TenNhaCungCap));
            CreateMap<PhieuGiao, PhieuGiaoModel>()
                .ForMember(pg => pg.Name, s => s.MapFrom(x => x.NhanVien.User.Name));
            CreateMap<ChiTietGiao, ListChiTietPGModel>()
               .ForMember(ctg => ctg.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham))
               .ForMember(ctg => ctg.TenNhaCungCap, s => s.MapFrom(x => x.NhaCungCap.TenNhaCungCap));
            CreateMap<PhieuBanGiao, PhieuBanGiaoModel>()
               .ForMember(pbg => pbg.Name, s => s.MapFrom(x => x.NhanVien.User.Name));
            CreateMap<ChiTietBanGiao, ListChiTietBanGiaoModel>()
                .ForMember(ctbg => ctbg.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham));
            CreateMap<PhieuKiemKe, PhieuKiemKeModel>()
              .ForMember(pbg => pbg.Name, s => s.MapFrom(x => x.NhanVien.User.Name));
            CreateMap<ChiTietKiemKe, ListChiTietKiemKeModel>()
               .ForMember(ctkk => ctkk.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham));
            CreateMap<ChiTietYeuCau, ChiTietYeuCauModel>()
               .ForMember(ctkk => ctkk.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham));
            CreateMap<ChiTietKiemKe, ChiTietKiemKeModel>()
              .ForMember(ctkk => ctkk.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham));
            CreateMap<ChiTietCungCap, ChiTietCungCapModel>()
                .ForMember(ctcc => ctcc.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham))
                .ForMember(ctcc => ctcc.TenNhaCungCap, s => s.MapFrom(x => x.NhaCungCap.TenNhaCungCap));
            CreateMap<ChiTietGiao, ChiTietGiaoModel>()
               .ForMember(ctg => ctg.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham))
               .ForMember(ctg => ctg.TenNhaCungCap, s => s.MapFrom(x => x.NhaCungCap.TenNhaCungCap));
            CreateMap<ChiTietBanGiao, ChiTietBanGiaoModel>()
               .ForMember(ctbg => ctbg.TenThucPham, s => s.MapFrom(x => x.ThucPham.TenThucPham));
        }
    }
}
