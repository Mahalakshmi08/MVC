using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCDB1.Models
{
    public class DeptRepo : IDept
    {
        db1045Context db = new db1045Context();

        public void AddDept(Dept dept)
        {
            db.Depts.Add(dept);
            db.SaveChanges();
        }

        public void DeleteDept(int id)
        {
            Dept dept = db.Depts.Find(id);
            db.Depts.Remove(dept);
            db.SaveChanges();
        }

        public void EditDept(Dept dept)
        {
            Dept odept = db.Depts.Find(dept.Id);
            odept.Name = dept.Name;
            odept.Location = dept.Location;
            db.SaveChanges();
        }

        public Dept FindDept(int id)
        {
            var data = db.Depts.Find(id);
            return data;
        }


        public List<Dept> GetDepts()
        {
            var data = from dept in db.Depts select dept;
            return data.ToList();
        }
    }
}
