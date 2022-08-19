using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDB1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDB1.ViewModel;


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


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var empdata = db.Emps.Find(id);
            ViewBag.Deptid = new SelectList(db.Depts,"Id","Name");
            return View(empdata);
        }

        [HttpPost]
        public IActionResult Edit(Emp emp)
        {
            if(ModelState.IsValid)
            {
                var odata = db.Emps.Find(emp.Id);
                odata.Name = emp.Name;
                odata.Salary = emp.Salary;
                odata.Email = emp.Email;
                odata.Deptid = emp.Deptid;
                odata.Dob = emp.Dob;
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(emp);
        }

        public JsonResult EmailCheck(string Email)
        {
            bool yesno=db.Emps.Any(e => e.Email == Email);  
            return Json(!yesno); 
        }


        public IActionResult ShowBonus()
        {
            List<Emp> emps = db.Emps.Include("Dept").ToList();
            List<EmpDept> empDepts = new List<EmpDept>();
            EmpDept ed = new EmpDept();

            foreach(var data in emps)
            {
                ed.Id = data.Id;
                ed.Name = data.Name;
                ed.DeptName = data.Dept.Name;
                ed.Location = data.Dept.Location;
                ed.Salary = data.Salary;
                if (data.Salary > 70000) ed.Bonus = 7000;
                else if (data.Salary > 40000) ed.Bonus = 4000;
                else ed.Bonus = 2000;
                empDepts.Add(ed);
            }
            return View(empDepts);
        }
    }
}
