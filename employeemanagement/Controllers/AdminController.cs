using Microsoft.AspNetCore.Mvc;
using empclass;


namespace employeemanagement.Controllers
{
    public class AdminController : Controller
    {
        employeeContext Empobj = new employeeContext();

        Class1 obj = new Class1();
        public ActionResult Home()
        {
            //Employees count
            var count = (from t in Empobj.Registers
                         select t.Employeeid).Count();
            ViewData["Empcount"] = count;

            //Leaves count

            var ccount = (from t in Empobj.Leaves
                          select t.Leaveid ).Count();
            ViewData["TLeavecount"] = ccount;

            return View();
        }
        public ActionResult Employees()
        {
            var result = Empobj.Registers.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Register r)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var i = obj.addemp(r);
                    if (i > 0)
                    {
                        ViewData["a"] = "Employee Added Successfully";
                    }
                }
                catch (Exception error)
                {
                    ViewData["a"] = "Employee Already Exists";
                }
            }
            return View(); 
        }
        [HttpGet]
        public ActionResult UpdateEmp(int myempid)
        {
            var result = Empobj.Registers.ToList().Find(c => c.Employeeid == myempid);

            return View(result);

        }
        [HttpPost]
        public ActionResult UpdateEmp(Register r)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Empobj.Registers.Update(r);
                    int i = Empobj.SaveChanges();

                    if (i > 0)
                    {
                        ViewData["a"] = "Update Successfully";
                    }
                }
                catch (Exception error)
                {
                    ViewData["a"] = "error occured please try later";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteEmp(int myempid)
        {


            var result = Empobj.Registers.ToList().Find(c => c.Employeeid == myempid);

            return View(result);
        }


        [HttpPost]
        public ActionResult DeleteEmp(Register r, int myempid)
        {
            var result = Empobj.Registers.ToList().Find(c => c.Employeeid == myempid);
            Empobj.Registers.Remove(result);
            Empobj.SaveChanges();
            ViewData["n"] = "Sucessfully deleted!!";
            return View();

        }
        [HttpGet]
        public ActionResult Leave()
        {
            var result = obj.DisplayLeave();
            return View(result);

        }
        [HttpPost]
        public ActionResult Leave(int employeeid, int leaveid, String Button)

        {
            var i = obj.Leavebutton(employeeid, leaveid, Button);
            if (i > 0)
            {

                return RedirectToAction("Leave");

            }
            else
            {
                ViewData["Approve"] = "invalid result";
                return View();
            }

        }
        public ActionResult Attendence()
        {
            
            var result = from t in Empobj.Registers
                         from t1 in Empobj.Attendecees
                         where t.Employeeid == t1.Employeeid

                         select new { register = t, attendecee = t1 };
            return View(result);

        }
        public ActionResult Search(string tofind)
        {

           
                try
                {
                    if ( tofind != null)
                    {
                        List<Register> res = obj.displaySearch(tofind);
                        return View(res);
                    }

                }
                catch (Exception error)
                {
                    ViewData["a"] = "error occured please try later";
                }
           
            return View();
        }
       
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("uid");
            return RedirectToAction("Login", "emp");
        }

    }
}
