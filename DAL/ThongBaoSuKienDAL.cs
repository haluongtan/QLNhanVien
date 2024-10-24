using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThongBaoSuKienDAL
    {
        private Model1 dbContext;

        public ThongBaoSuKienDAL()
        {
            dbContext = new Model1();
        }

        public List<ThongBaoSuKien> LayDanhSachSuKien()
        {
            return dbContext.ThongBaoSuKien.ToList();
        }

        public void ThemSuKien(ThongBaoSuKien suKien)
        {
            dbContext.ThongBaoSuKien.Add(suKien);
            dbContext.SaveChanges();
        }

        public ThongBaoSuKien LaySuKienTheoMa(int maSuKien)
        {
            return dbContext.ThongBaoSuKien.FirstOrDefault(s => s.MaSuKien == maSuKien);
        }
        public void XoaSuKien(int maSuKien)
        {
            var suKien = dbContext.ThongBaoSuKien.FirstOrDefault(s => s.MaSuKien == maSuKien);
            if (suKien != null)
            {
                dbContext.ThongBaoSuKien.Remove(suKien);
                dbContext.SaveChanges();
            }
        }

    }
}
