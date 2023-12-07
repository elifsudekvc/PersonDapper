using Microsoft.AspNetCore.Mvc;
using personDapper.Models;
using personDapper.Repository;
using System;
using System.Reflection;

namespace personDapper.Controllers
{
    public class VKIController : Controller
    {
        private readonly IVKIRepository _vkiRepository;

        public VKIController(IVKIRepository vkiRepository)
        {
            _vkiRepository = vkiRepository;
        }



        public IActionResult Index()
        {
            var vkis = _vkiRepository.GetAll("");
            return View(vkis);


        }
        public IActionResult Details(int vkiID)
        {
            var vkis = _vkiRepository.GetById("where vkiID=@vkiID", new { vkiID });

            if (vkis == null)
            {
                return NotFound();
            }

            return View(vkis);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VKI vki)
        {


                    float Boy = vki.boy / 100; // Boyu metreye çevir
                    // BMI hesaplaması
                    float bmi = vki.kilo / (Boy*Boy);

                    if (bmi < 19)
                    {
                vki.vkiSonuc = $"Beden Kitle İndeksi (BMI): {bmi:F2} . Zayıfsınız.";
                    }
                    else if (bmi >= 19 && bmi < 25)
                    {
                vki.vkiSonuc = $"Beden Kitle İndeksi (BMI): {bmi:F2} . Kilonuz normal.";
                    }
                    else if (bmi >= 25 && bmi < 30)
                    {
                vki.vkiSonuc = $"Beden Kitle İndeksi (BMI): {bmi:F2} . kilonuz fazla.";
                    }
                    else if (bmi >= 30 && bmi < 35)
                    {
                vki.vkiSonuc = $"Beden Kitle İndeksi (BMI): {bmi:F2} . kilonuz çok fazla.";
                    }
                    else if (bmi >= 35)
                    {
                vki.vkiSonuc = $"Beden Kitle İndeksi (BMI): {bmi:F2} . obez.";
                    }


                    _vkiRepository.Insert(vki);


                    return RedirectToAction("Index");
 
            return View(vki);
        }

        //aşağıdaki Delete classı silinmek istenilen verileri delete sayfasına gönderip görmemizi sağlıyor.

        public IActionResult Delete(int vkiID)
        {

             var vkis = _vkiRepository.GetById("where vkiID=@vkiID", new { vkiID = vkiID });

            if (vkis == null)
            {
                return NotFound();
            }

            return View(vkis);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed( int vkiID)
        {
            _vkiRepository.Delete("where vkiID=@vkiID", new { vkiID = vkiID });
            return RedirectToAction(nameof(Index));
        }



    }

}
