using Microsoft.EntityFrameworkCore;
using SolarK64.Models.EF;
using SolarK64.Models.Entities;

namespace SolarK64.Services
{
    public class SolarServices : ISolarServices
    {
        private readonly ApplicationDbContext _context;
        public SolarServices(ApplicationDbContext context) { 
            _context = context;
        }

        public List<PhanHoi> GetListPhanHoi(string maKPH)
        {
            try
            {
                return _context.PhanHoi.AsNoTracking().Where(t => t.MaKieuPhanHoi == maKPH).ToList();
            }
            catch (Exception ex) {
                return new List<PhanHoi>();
            }
        }

        public TaiKhoan Login(string username, string password) {
            try
            {
                return _context.TaiKhoan.SingleOrDefault(t => t.TenDangNhap==username.ToLower().Trim() && t.MatKhau==password.ToLower().Trim());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
