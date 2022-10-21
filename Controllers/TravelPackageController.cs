using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using System.Diagnostics;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class TravelPackageController : Controller
    {
        //private readonly ILogger<TravelPackageController> _logger;

        //public TravelPackageController(ILogger<TravelPackageController> logger)
        //{
        //    _logger = logger;
        //}

        private TravelAgencyContext _db;

        public TravelPackageController()
        {
            _db = new TravelAgencyContext();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(/*"Index", _db.TravelPackages.ToList()*/);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Show(int id)
        {
            //try
            //{
            //    TravelPackage toShow = _db.TravelPackages.Where(x => x.Id == id).FirstOrDefault();
            //    return View("Show", toShow);
            //}
            //catch
            //{
            //    return View("Error");
            //}
            return View(id);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelPackage formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", formData);
            }


            TravelPackage package = new TravelPackage();
            package = formData;

            _db.TravelPackages.Add(package);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EditForm(int id)
        {
            try
            {
                TravelPackage ToEdit = _db.TravelPackages.Where(x => x.Id == id).FirstOrDefault();
                if (ToEdit == null)
                {
                    return NotFound();
                }
                else
                {
                    TravelPackage package = new TravelPackage();
                    package = ToEdit;
                    return View(package);
                }
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TravelPackage dataForm)
        {
            if (!ModelState.IsValid)
            {
                return View("EditForm", dataForm);
            }

            TravelPackage editPackage = _db.TravelPackages.Where(package => package.Id == id).FirstOrDefault();

            editPackage.Name = dataForm.Name;
            editPackage.Description = dataForm.Description;
            editPackage.Photo = dataForm.Photo;
            editPackage.Price = dataForm.Price;
            editPackage.PeopleNumber = dataForm.PeopleNumber;
            editPackage.Duration = dataForm.Duration;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            TravelPackage toDelete = _db.TravelPackages.Where(x => x.Id == Id).First();

            if (toDelete != null)
            {
                _db.TravelPackages.Remove(toDelete);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}