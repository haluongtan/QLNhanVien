using DAL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThongBaoSuKienBUS
    {
        private ThongBaoSuKienDAL thongBaoSuKienDAL;
        private NhanVienDAL nhanVienDAL;

        public ThongBaoSuKienBUS()
        {
            thongBaoSuKienDAL = new ThongBaoSuKienDAL();
            nhanVienDAL = new NhanVienDAL();
        }

        public List<ThongBaoSuKien> LayDanhSachSuKien()
        {
            return thongBaoSuKienDAL.LayDanhSachSuKien();
        }

        public void ThemSuKien(ThongBaoSuKien suKien)
        {
            thongBaoSuKienDAL.ThemSuKien(suKien);
        }

        public void GuiThongBaoQuaEmail(int maNhanVien, string tieuDe, string noiDung)
        {
            var nhanVien = nhanVienDAL.LayNhanVienTheoMa(maNhanVien);
            if (nhanVien == null || string.IsNullOrEmpty(nhanVien.Email))
            {
                throw new System.Exception("Không tìm thấy nhân viên hoặc nhân viên chưa có email.");
            }

            string emailNhanVien = nhanVien.Email;
            GuiEmail(emailNhanVien, tieuDe, noiDung);
        }

        private void GuiEmail(string emailNhanVien, string tieuDe, string noiDung)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("vovantamlun11@gmail.com");
                mail.To.Add(emailNhanVien);
                mail.Subject = tieuDe;
                mail.Body = noiDung;

                smtpServer.Port = 587; 
                smtpServer.Credentials = new System.Net.NetworkCredential("vovantamlun11@gmail.com", "wiuy dckl vdwv hmhj"); 
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Có lỗi xảy ra khi gửi email: " + ex.Message);
            }
        }

        public void XoaSuKien(int maSuKien)
        {
            thongBaoSuKienDAL.XoaSuKien(maSuKien);
        }

    }
}
