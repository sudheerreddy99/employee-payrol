namespace empclass
{
    public class Class1
    {
        employeeContext Emp = new employeeContext();

        public int Login(int rad, string uname, string pwd)
        {
            if (rad == 0)
            {

                var res = (from t in Emp.Registers
                           where t.Email == uname & t.Passwords == pwd
                           select t).Count();

                return res;

            }

            else if (rad == 1)
            {
                if (uname == "admin" && pwd == "india")
                {
                    var res = 1;
                    return res;
                }
                else
                {
                    var res = 0;
                    return res;

                }


            }
            else
            {
                var res = 0;
                return res;

            }
        }

        public int employeeid(string user)
        {

            var res = (from t in Emp.Registers
                       where t.Email == user
                       select t.Employeeid).FirstOrDefault();
            return res;

        }
        public int Apply(Leave l)
        {

            Emp.Leaves.Add(l);
            int i = Emp.SaveChanges();
            return i;

        }
        public List<Register> DisplayEmp()
        {
            var result = Emp.Registers.ToList();
            return result;

        }
        public int addemp(Register r)
        {

            Emp.Registers.Add(r);
            int i = Emp.SaveChanges();
            return i;

        }
        public List<Register> EmpProfile(string user)
        {
            var result = (from t in Emp.Registers
                          where t.Email == user
                          select t).ToList();
            return result;

        }
        public int attendancecheck(int id)
        {
            var result = (from t in Emp.Attendecees
                          where t.Employeeid == id & t.Pdate == DateTime.Today
                          select t).Count();
            return result;
        }
        public int Empattend(Attendecee a)
        {

            Emp.Attendecees.Add(a);
            int res = Emp.SaveChanges();
            return res;

        }
        public List<Leave> Leavecheck(int id)
        {
            var res = (from t in Emp.Leaves
                       where t.Employeeid == id
                       select t).ToList();
            return res;

        }
        public List<Leave> DisplayLeave()
        {
            var result = (from t in Emp.Leaves where t.Status == null select t).ToList();
            return result;

        }
        public int Leavebutton(int employeeid, int leaveid, String Button)
        {
            var result = (from t in Emp.Leaves
                          where t.Leaveid == leaveid && t.Employeeid == employeeid
                          select t).FirstOrDefault();
            result.Status = Button;

            int res = Emp.SaveChanges();

            return res;
        }
        public List<Register> displaySearch(string tofind)
        {

            var res = (from t in Emp.Registers
                                  where t.Email.Contains(tofind)
                                  select t).ToList();
            return res;
        }
        
       
    }
}