using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        private Model1 dbContext;

        public UserDAL()
        {
            dbContext = new Model1();
        }

        public Users GetUserByUsernameAndPassword(string username, string password)
        {
            return dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
        public List<Users> LayDanhSachTaiKhoan()
        {
            return dbContext.Users.ToList();
        }
        public void ThemTaiKhoan(Users taiKhoan)
        {
            dbContext.Users.Add(taiKhoan);
            dbContext.SaveChanges();
        }
        public void SuaTaiKhoan(Users taiKhoan)
        {
            var existingTaiKhoan = dbContext.Users.SingleOrDefault(tk => tk.Username == taiKhoan.Username);
            if (existingTaiKhoan != null)
            {
                existingTaiKhoan.Password = taiKhoan.Password;
                existingTaiKhoan.Role = taiKhoan.Role;

                dbContext.SaveChanges(); 
            }
        }
        public void XoaTaiKhoan(string username)
        {
            var taiKhoan = dbContext.Users.SingleOrDefault(tk => tk.Username == username);
            if (taiKhoan != null)
            {
                dbContext.Users.Remove(taiKhoan);
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
        public int LayUserIdTheoUsername(string username)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Username == username);
            return user != null ? user.UserId : 0;
        }


    }
}
