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
            Empobj.Registers.Update(r);
            int i = Empobj.SaveChanges();

            if (i > 0)
            {
                ViewData["a"] = "Update Successfully";
            }

            return View();
        }

        public ActionResult Markattendance()
        {

            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("uid");
            return View();
        }



    }
}
