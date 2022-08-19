using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDB1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCDB1.Controllers
{
    public class EmpController : Controller
    {
        db1045Context db=new db1045Context();
        public IActionResult List()
        {
            var empdata = db.Emps.Include("Dept").ToList();
            return View(empdata);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Deptid = new SelectList(db.Depts,"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Emp emp)
        {
            if(ModelState.IsValid)
            {
                db.Emps.Add(emp);   
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(emp);
        }
    }
}
