using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BUS
{
    public class UserBUS
    {

        private UserDAL userDAL;

        public UserBUS()
        {
            userDAL = new UserDAL();
        }

        public Users CheckUserLogin(string username, string password)
        {
            return userDAL.GetUserByUsernameAndPassword(username, password);
        }
        public List<Users> LayDanhSachTaiKhoan()
        {
            return userDAL.LayDanhSachTaiKhoan();
        }
        public void ThemTaiKhoan(Users taiKhoan)
        {
            userDAL.ThemTaiKhoan(taiKhoan);
        }
        public void SuaTaiKhoan(Users taiKhoan)
        {
            userDAL.SuaTaiKhoan(taiKhoan);
        }
        public void XoaTaiKhoan(string username)
        {
            userDAL.XoaTaiKhoan(username);
        }
       

    }
}

