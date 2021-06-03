using DATN.Data;
using DATN.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.UserService
{
    public class AuthRepository : IAuthoRepository
    {
        private readonly DataContext _context;
        private DataTable nvMod;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // kiem tra password
            if(password == null)
            {
                throw new ArgumentException("password");
            }
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password khong duoc trong hoac khoang trong", "password");
            }
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if(password == null)
            {
                throw new ArgumentException("password");
            }
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password khong duoc trong hoac khoang trong");
            }
            //kiem tra do dai 
            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordSalt");
            }
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }


        public string MaGiaoVien()
        {
            string connString = @"Data Source=DESKTOP-FO8QLMB;Initial Catalog=QLThucPham;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = @"SELECT * FROM GiaoViens ";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "GV001";
            }
            else
            {
                int k;
                ma = "GV";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                {
                    ma = ma + "00";
                }
                else if (k < 100)
                {
                    ma = ma + "0";
                }
                ma = ma + k.ToString();
            }
            return ma;
        }

        public string MaNhanVien()
        {
            string connString = @"Data Source=DESKTOP-FO8QLMB;Initial Catalog=QLThucPham;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = @"SELECT * FROM NhanViens ";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "NV001";
            }
            else
            {
                int k;
                ma = "NV";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                {
                    ma = ma + "00";
                }
                else if (k < 100)
                {
                    ma = ma + "0";
                }
                ma = ma + k.ToString();
            }
            return ma;
        }
        public User Login(string UserName, string Password)
        {
            if(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                return null;
            }
            User user = _context.Users.SingleOrDefault(x => x.UserName == UserName);
            if(user == null)
            {
                return null;
            }
            if(!VerifyPasswordHash(Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        public bool UserExists(string UserName)
        {
            if (_context.Users.Any(x => x.UserName.ToLower() == UserName.ToLower()))
            {
                return true;
            }
            return false;
        }

        public User CreateUser(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password is required");
            }

            if (_context.Users.Any(x => x.UserName == user.UserName))
            {
                throw new ArgumentException("Username \"" + user.UserName + "\" is already taken");
            }
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // tao giao vien khi role la giao vien
            var giaovien = new GiaoVien();
            var nhanvien = new NhanVien();
            if (user.Role == "GiaoVien")
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                giaovien.UserId = user.Id;
                giaovien.MaGV = MaGiaoVien();
                _context.GiaoViens.Add(giaovien);
                _context.SaveChanges();
            }
            else if (user.Role == "NhaBep" || user.Role == "ThucPham")
            {
                // tao nhan vien khi role la Nha bep hoac thuc pham
                _context.Users.Add(user);
                _context.SaveChanges();
                nhanvien.UserId = user.Id;
                nhanvien.MaNhanVien = MaNhanVien();
                if(user.Role == "NhaBep")
                {
                    nhanvien.MaBoPhan = "NB";
                }
                else
                {
                    nhanvien.MaBoPhan = "TP";
                }
                _context.NhanViens.Add(nhanvien);
                _context.SaveChanges();
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            /*{
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            // tao nhan vien khi role la Nha bep hoac thuc pham
            var nhanvien = new NhanVien();
            if( user.Role == "NhaBep" || user.Role == "ThucPham")
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                nhanvien.UserId = user.Id;
                *//*Guid guid = Guid.NewGuid();
                nhanvien.MaNhanVien = guid.ToString();*//*
                _context.NhanViens.Add(nhanvien);
                _context.SaveChanges();
            }*/

            return user;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void UpdateUser(User user, string password = null)
        {
            var currentUser = _context.Users.Find(user.Id);
            var _giaovien = _context.GiaoViens.Where(e => e.UserId == user.Id).SingleOrDefault();
            if(currentUser == null)
            {
                throw new ArgumentException("Khong tim thay user");
            }

            if(user.Id != currentUser.Id)
            {
                if(_context.Users.Any(x => x.Id == user.Id))
                {
                    throw new ArgumentException("Username " + user.Id + "is already taken");
                }
            }

            // update user
            currentUser.Name = user.Name;
            currentUser.GioiTinh = user.GioiTinh;
            currentUser.NgaySinh = user.NgaySinh;
            currentUser.DienThoai = user.DienThoai;
            currentUser.DiaChi = user.DiaChi;
            currentUser.Role = user.Role;

            // update password neu co
            if(!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                currentUser.PasswordHash = passwordHash;
                currentUser.PasswordSalt = passwordSalt;
            }
            _context.Users.Update(currentUser);
            _context.SaveChanges();
        }
       /* public void UpdateGV(GiaoVien giaovien)
        {
            var _giaovien = _context.GiaoViens.Find(giaovien.MaGV);

        }*/
        public void DeleteUser(int id)
        {
            User user = _context.Users.Find(id);

            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();

            }
        }
    }
}
