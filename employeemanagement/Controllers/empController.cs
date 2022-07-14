using Microsoft.AspNetCore.Mvc;
using empclass;

namespace employeemanagement.Controllers
{
    public class empController : Controller
    {
        employeeContext Empobj=new employeeContext();
        Class1 obj = new Class1();
        public IActionResult Home()
        {
            return View();

        }
        public ActionResult LeaveApply()
        {

            return View();
        }
        [HttpPost]
        public ActionResult LeaveApply(Leave l)
        {
            try
            {

                if (HttpContext.Session.GetString("uid") == null)
                {
                    return RedirectToAction("Login");

                }
                else
                {

                    string user = HttpContext.Session.GetString("uid");
                    int id = obj.employeeid(user);

                    l.Employeeid = id;

                    int i = obj.Apply(l);
                    if (i > 0)
                    {
                        ViewData["a"] = "Leave Applied Successfully";
                    }
                    else
                    {
                        ViewData["a"] = "Try again";
                    }
                    return View();
                }
            }
            catch (Exception error)
            {
                ViewData["a"] = " error occured Try again later";
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(int rad, string uname, string pwd)
        {

            try
            {

                var res = obj.Login(rad, uname, pwd);
            if (res > 0 && rad == 0)
            {
                HttpContext.Session.SetString("uid", uname);

                return RedirectToAction("Home");

            }

            else if (res > 0 && rad == 1)
            {
                HttpContext.Session.SetString("uid", uname);
                return RedirectToAction("Home", "Admin");
            }
            else
            {
                ViewData["a"] = "Invalid username or password";
                return View();
            }
            }
            catch (Exception error)
            {
                ViewData["a"] = " error occured Try again later";
                return View();
            }

        }
        public ActionResult Profile()
        {
            string user = HttpContext.Session.GetString("uid");

            var result = obj.EmpProfile (user);
            return View(result);

        }
        [HttpGet]
        public ActionResult DetailsUpdate(int myempid1)
        {
            var result = Empobj.Registers.ToList().Find(c => c.Employeeid == myempid1);

            return View(result);

        }
        [HttpPost]
        public ActionResult DetailsUpdate(Register r)
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
                    ViewData["a"] = "Error Occured please try again Later";
                }
            }
            return View();
        }

        public ActionResult Markattendance()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Markattendance(Attendecee a)
        {

            string user = HttpContext.Session.GetString("uid");
            int id = obj.employeeid(user);
            
            a.Employeeid = id;
            a.Mail = user;
            a.Pdate = DateTime.Today;
            a.Astatus = "Present";
            if (ModelState.IsValid)
            {
                try
                {

                    var res = obj.attendancecheck(id);
                    if (res > 0)
                    {
                        ViewData["a"] = "Attendece already applied";
                        
                    }
                    else
                    {
                        var result = obj.Empattend(a);
                        if (result > 0)
                        {
                            ViewData["a"] = "Attendece Submitted Successfully";
                        }
                    }
                }
                catch (Exception e)
                {
                    ViewData["a"] = "Attendence Already Marked Today";
                }
            }
            return View();
        }
        public ActionResult Status()
        {
            string user = HttpContext.Session.GetString("uid");
            int id = obj.employeeid(user);
            var result = obj.Leavecheck(id);
            return View(result);


        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("uid");
            return View();
        }



    }
}
