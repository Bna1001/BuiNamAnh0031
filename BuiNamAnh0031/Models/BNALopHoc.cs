using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BuiNamAnh0031.Models
{
    public class BNALopHoc
    {
        [Key]
        [Display(Name ="Mã Lớp Học")]
        public string BNAMaLop { get; set; }
        [Display(Name ="Tên Lớp")]
        public string BNATenLop { get; set; }
    }
}