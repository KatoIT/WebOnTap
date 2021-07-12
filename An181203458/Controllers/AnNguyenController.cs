using An181203458.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace An181203458.Controllers
{
    public class AnNguyenController : Controller
    {
        ModelQLHH db = new ModelQLHH();
        // GET: AnNguyen
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnNguyen
        public ActionResult RenderNav()
        {
            List<LoaiHang> listLH = db.LoaiHangs.ToList();
            return PartialView("_An_Header", listLH);
        }

        // GET: Ajax phân trang
        public ActionResult RenderProductById(int? id, int? page, String txtSearch)
        {
            // ------------------------------------- lấy danh sách sản phẩm theo yêu cầu -------------
            var listHangHoa = db.HangHoas.Where(s => s.Gia >= 100).ToList();
            if (id != null)
            {
                // lấy danh sách sản phẩm theo 'Mã loại'
                listHangHoa = db.HangHoas.Where(s => s.MaLoai == id).ToList();
            }
            if(txtSearch != null && txtSearch != "Search")
            {
                // lấy danh sách sản phẩm theo tên hàng được search
                listHangHoa = db.HangHoas.Where(s => s.TenHang.Contains(txtSearch)).ToList();
            }
            // --------- End ----------
            // -------------------------------------- Begin Phân trang -------------------------------------
            int pageSize = 3; // số sản phẩm hiển trị trên 1 trang
            if (page == null) // nếu ko truyền vào trang hiện tại thì đặt mặc định là trang 1
            { page = 1; }
            int start = (int)(page - 1) * pageSize; // số thứ tự trong list của sản phẩm đầu tiên trong trang
            ViewBag.pageCurrent = page; // trang hiện tại
            int numSize = (int)Math.Ceiling(listHangHoa.Count() / (float)pageSize); // convertTo int Số trang sẽ hiển thị
            ViewBag.numSize = numSize; // Số trang sẽ hiển thị
            var listHangHoa2 = listHangHoa.OrderBy(x => x.MaHang).Skip(start).Take(pageSize); // sắp xếp theo Mã hàng và lấy ra các sản phẩm cần hiển thị từ list[start] -> list[start + pageSize]
            // --------- End ----------
            return PartialView("_An_MainContent", listHangHoa2);
        }


        // GET: HangHoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // GET: HangHoas/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        // POST: HangHoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHang,MaLoai,TenHang,Gia,Anh")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hangHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }

        // GET: HangHoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }

        // POST: HangHoas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHang,MaLoai,TenHang,Gia,Anh")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangHoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }

        // GET: HangHoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // POST: HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HangHoa hangHoa = db.HangHoas.Find(id);
            db.HangHoas.Remove(hangHoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}