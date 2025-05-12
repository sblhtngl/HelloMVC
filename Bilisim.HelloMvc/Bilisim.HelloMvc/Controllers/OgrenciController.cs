using Bilisim.HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bilisim.HelloMvc.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly OkulDbContext _context;

        public OgrenciController(OkulDbContext context)
        {
            _context = context;
        }

        // 1. Öğrenci listeleme
        public ViewResult OgrenciListe()
        {
            var lst = _context.Ogrenciler.ToList();
            return View(lst);
        }

        // 2. Öğrenci detay (sadece öğrenci ile)
        [HttpGet]
        public IActionResult OgrenciDetay(int id)
        {
            var ogrenci = _context.Ogrenciler.FirstOrDefault(o => o.Ogrenciid == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci); // DTO yok, sadece öğrenci
        }

        // 3. Öğrenci güncelleme (POST)
        [HttpPost]
        public IActionResult OgrenciGuncelle(Ogrenci ogr)
        {
            var ogrenci = _context.Ogrenciler.FirstOrDefault(o => o.Ogrenciid == ogr.Ogrenciid);
            if (ogrenci != null)
            {
                ogrenci.Ad = ogr.Ad;
                ogrenci.Soyad = ogr.Soyad;
                _context.SaveChanges();
            }
            return RedirectToAction("OgrenciListe");
        }

        // 4. Yeni öğrenci ekleme (GET)
        [HttpGet]
        public ViewResult OgrenciEkle()
        {
            return View();
        }

        // 5. Yeni öğrenci ekleme (POST)
        [HttpPost]
        public IActionResult OgrenciEkle(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _context.Ogrenciler.Add(ogrenci);
                _context.SaveChanges();
                return RedirectToAction("OgrenciListe");
            }
            return View();
        }

        // 6. Öğrenci silme
        [HttpPost]
        public IActionResult OgrenciSil(int ogrenciId)
        {
            var ogrenci = _context.Ogrenciler.FirstOrDefault(o => o.Ogrenciid == ogrenciId);
            if (ogrenci != null)
            {
                _context.Ogrenciler.Remove(ogrenci);
                _context.SaveChanges();
            }
            return RedirectToAction("OgrenciListe");
        }
    }
}
