using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanVien
{
    public class User
    {
        [Key] // Chỉ định đây là khóa chính
        [Column("UserId")] // Tên cột trong cơ sở dữ liệu nếu không phải là "Id"
        public int UserId { get; set; } // Tên cột khóa chính trong CSDL

        [Required]
        [StringLength(100)]
        public string Username { get; set; }    

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }
    }

}
