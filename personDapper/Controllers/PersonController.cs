using Microsoft.AspNetCore.Mvc;
using personDapper.Models;
using personDapper.Repository;

namespace personDapper.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IActionResult Index()
        {
            var persons = _personRepository.GetAll();
            return View(persons);
        }

        public IActionResult Details(int id)
        {
            var person = _personRepository.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepository.Insert(person);
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public IActionResult Update(int id)
        {
            var person = _personRepository.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        public IActionResult Update(int id, Person person)
        {
            if (id != person.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _personRepository.Update(person);
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public IActionResult Delete(int id)
        {
            var person = _personRepository.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _personRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }



}

