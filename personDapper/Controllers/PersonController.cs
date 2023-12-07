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
            var persons = _personRepository.GetAll("");
            return View(persons);
        }

        public IActionResult Details(int id)
        {
            var person = _personRepository.GetById("WHERE id=@id", new {id});

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
        //aşağıdaki Update classı update edilmek istenilen verileri update sayfasına gönderip tekrardan yazmamamızı sağlıyor.
        public IActionResult Update(int id)
        {
            var person = _personRepository.GetById("where id=@id", new {id});

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        public IActionResult Update( Person person)
        {
            
            if (person.id != person.id)
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

        //aşağıdaki Delete classı silinmek istenilen verileri delete sayfasına gönderip görmemizi sağlıyor.

        public IActionResult Delete(int id)
        {
            var person = _personRepository.GetById("where id=@id", new {id});

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _personRepository.Delete("where id=@id", new { id });
            return RedirectToAction(nameof(Index));
        }
    }



}

