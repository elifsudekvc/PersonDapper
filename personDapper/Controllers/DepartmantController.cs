using Microsoft.AspNetCore.Mvc;
using personDapper.Models;
using personDapper.Repository;
using System;

namespace personDapper.Controllers
{
    public class DepartmantController : Controller
    {
        private readonly IDepartmantRepository _departmantRepository;

        public DepartmantController(IDepartmantRepository departmantRepository)
        {
            _departmantRepository = departmantRepository;
        }

        public IActionResult Index()
        {
            var departmants = _departmantRepository.GetAll();
            return View(departmants);
        }

        public IActionResult Details(int DepartmantId)
        {
            var departmant = _departmantRepository.GetById(DepartmantId);
            if (departmant == null)
            {
                return NotFound();
            }


            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Departmant departmant)
        {
            if (ModelState.IsValid)
            {
                _departmantRepository.Insert(departmant);
                return RedirectToAction(nameof(Index));
            }
            return View(departmant);
        }

        public IActionResult Update(int DepartmantId)
        {
            var departmant = _departmantRepository.GetById(DepartmantId);
            if (departmant == null)
            {
                return NotFound();
            }

            return View(departmant);
        }

        [HttpPost]
        public IActionResult Update(int DepartmantId, Departmant departmant)
        {
            if (DepartmantId != departmant.DepartmantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _departmantRepository.Update(departmant);
                return RedirectToAction(nameof(Index));
            }
            return View(departmant);
        }

        public IActionResult Delete(int DepartmantId)
        {
            var departmant = _departmantRepository.GetById(DepartmantId);

            if (departmant == null)
            {
                return NotFound();
            }
            return View(departmant);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int DepartmantId)
        {
            _departmantRepository.Delete(DepartmantId);
            return RedirectToAction(nameof(Index));
        }
    }
}
