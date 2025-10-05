using System.ComponentModel.DataAnnotations;

namespace SolarK64.Models.Entities
{
    public class PhanHoi
    {
        [Key]
        public int Uid { get; set; }
        public string AnhDaiDien { get; set; } = "";
        public string HoVaTen { get; set; } = "";
        public int DiemDanhGia { get; set; }
        public string NhanXet { get; set; } = "";
        public string MaKieuPhanHoi { get; set; } = "";
    }
}
