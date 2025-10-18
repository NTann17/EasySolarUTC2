using SolarK64.Models.Entities;

namespace SolarK64.Services
{
    public interface ISolarServices
    {
        List<PhanHoi> GetListPhanHoi(string maKPH);
        TaiKhoan Login(string username, string password);
    }
}
