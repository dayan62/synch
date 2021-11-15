using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Asynch.Controllers
{
    public class HomeController : Controller
    {
        SampleEntities1 db = new SampleEntities1();

        // GET: Home
        public  async Task<ActionResult> Index()
        {
            var List = await db.Employees.ToListAsync();

            return View(List);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employees employees)
        {
            if(ModelState.IsValid)
            {
                db.Employees.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}