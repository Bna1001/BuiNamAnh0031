using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BuiNamAnh0031.Models
{
    public class BNASinhVien
    {
        [Key]
        [Display(Name ="Mã Sinh Viên")]
        public string BNASinhVienMaSinhVien { get; set; }
        [Display(Name ="Họ tên")]
        public string BNAHoTen { get; set; }
        [Display(Name ="Mã lớp")]
        public string BNAMaLop { get; set; }
        [ForeignKey("BNAMaLop")]
        public BNALopHoc? BNALopHoc { get; set; }
    }
}