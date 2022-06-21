using Microsoft.AspNetCore.Mvc;
using empclass;


namespace employeemanagement.Controllers
{
    public class AdminController : Controller
    {
       Class1 obj = new Class1();
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Employees()
        {
            var result = obj.DisplayEmp();
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
         
            return View();
        }
        public ActionResult Leave()
        {
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("uid");
            return RedirectToAction("Login", "emp");
        }

    }
}
