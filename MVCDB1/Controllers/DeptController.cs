using Microsoft.AspNetCore.Mvc;
using MVCDB1.Models;


namespace MVCDB1.Controllers
{
    public class DeptController : Controller
    {
        IDept repos; //object for injection

        public DeptController(IDept _repost)
        {
            repos = _repost;
        }

        public IActionResult List()
        {
            var data = repos.GetDepts();
            return View(data);
        }

        //how to pass an ID to controller
        //we created an 

        public IActionResult Display(int id)
        {
            var data = repos.FindDept(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Dept dept)
        {
            if(ModelState.IsValid)//to check for errors
            {
                repos.AddDept(dept);
                return RedirectToAction("List");
            }
            return View(dept);// no errors save the data and go back to the list
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = repos.FindDept(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Dept dept)
        {
            if(ModelState.IsValid)
            {
                repos.EditDept(dept);
                return RedirectToAction("List");
            }
            return View(dept);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = repos.FindDept(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Dept dept)
        {
            repos.DeleteDept(dept.Id);
            return RedirectToAction("List");
        }
    }
}
