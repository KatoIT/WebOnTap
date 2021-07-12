using An181203458.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace An181203458.Controllers
{
    public class AnNguyen3Controller : Controller
    {
        ModelQLHH db = new ModelQLHH();

        // GET: AnNguyen3
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
        // GET: Ajax phân trang
        public ActionResult RenderProductById(int? id, int? idPro, int? page)
        {
            int pageSize = 3;
            var listHangHoa = db.HangHoas.Where(s => s.Gia >= 100).ToList();
            if (id != null)
            {
                listHangHoa = db.HangHoas.Where(s => s.MaLoai == id).ToList();
            }
            if (page > 0)
            {
                page = page + 0;
            }
            else
            {
                page = 1;
            }
            int start = (int)(page - 1) * pageSize;
            ViewBag.pageCurrent = page;
            int totalPage = listHangHoa.Count();
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            var listHangHoa2 = listHangHoa.OrderBy(x => x.MaHang).Skip(start).Take(pageSize);
            return PartialView("_An_MainContent3", listHangHoa2);
        }

    }
}