using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("UngLuong")]
    public class UngLuong
    {
        [Key]
        public int Id { get; set; }  // Khoá chính

        public int MaNhanVien { get; set; }

        [Required]
        public DateTime NgayUng { get; set; }

        [Required]
        public decimal SoTienUng { get; set; }

        [ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanVien { get; set; }
    }
}
