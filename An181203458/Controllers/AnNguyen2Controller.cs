using An181203458.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace An181203458.Controllers
{
    public class AnNguyen2Controller : Controller
    {
        ModelQLHH db = new ModelQLHH(); // Khai báo Model
        // GET: AnNguyen2
        public ActionResult Index()
        {
            return View();
        }

        // GET: truyền loại hàng lên thanh NAV trong Name_Header.cshtml
        public ActionResult RenderNav()
        {
            List<LoaiHang> listLH = db.LoaiHangs.ToList();
            return PartialView("_An_Header", listLH);
        }
        // GET: Ajax hiển thị theo loại hàng
        public ActionResult RenderProductById(int? id)
        {
            var listHangHoa = db.HangHoas.Where(s => s.Gia >= 100).ToList();
            if (id != null)
            {
                listHangHoa = db.HangHoas.Where(s => s.MaLoai == id).ToList();
            }
            var listHangHoa2 = listHangHoa.OrderBy(x => x.MaHang); //Sắp xếp theo mã hàng
            return PartialView("_An_MainContent2", listHangHoa2);
        }
    }
}