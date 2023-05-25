using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBookStore.Models;
using PagedList;
using PagedList.Mvc;

namespace MvcBookStore.Controllers
{
    public class BookStoreController : Controller
    {
        // Tạo một đối tượng chứa toàn booh CSDL từ dbQLBansach
        
            dbQLBansachDataContext data = new dbQLBansachDataContext();
        
        // GET: BookStore
        private List<SACH> Laysachmoi(int count)
        {
            //Sắp xếp giảm dần theo Ngaycapnhat, lấy count đòng đầu
            return data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index(int ? page)
        {
            //Tạo biến số trang
            int pageSize = (page ?? 1);


            //Lấy 5 quyển sách mới nhất
            var sachmoi = Laysachmoi(5);
            return View(sachmoi);
        }
        [ChildActionOnly]
        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult Nhaxuatban()
        {
            var nhaxuatban = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(nhaxuatban);
        }
        public ActionResult SPTheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult SPTheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach);
        }
        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes where s.Masach == id select s;
            return View(sach.Single());
        }
    }
}