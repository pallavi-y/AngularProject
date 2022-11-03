using ProjectCompanyServiceAPI.DataAccessLayer;

namespace ProjectCompanyServiceAPI.Models
{
   
    public class BusinessLayer : IRepositoryEmployee
    {
       
        private readonly EmployeeDbContext _context;

        public BusinessLayer(EmployeeDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> getEmployeeList()
        {
            var query = from emp in _context.EmployeesTable.ToList<Employee>()

                        select emp;
            return query;

        }
       
        public   void SaveEmployee(Employee s)
        {
           
            _context.EmployeesTable.Add(s);
            _context.SaveChanges();
            s.PUID = "EITS" + s.EmpId.ToString();
            _context.SaveChanges();

        }
        public bool checkEmployeeByEmail(string emailid)
        {
            var query = from emp in _context.EmployeesTable.ToList<Employee>()
                        where emp.Email == emailid
                        select emp;
            if (query.Count() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public object getEmployeeByEmail(string emailid) ///using linq
        {
           
            var query = from emp in _context.EmployeesTable
                        where emp.Email == emailid
                        select new { 
                        Emailid=emp.Email,
                        PhoneNumber=emp.phonenumber,
                        Address=emp.Address

                        
                        };


            return (object)query.First();
            }
        public Employee getEmployeeDetails(string emailid)
        {
            var query = from emp in _context.EmployeesTable
                         where emp.Email == emailid
                         select emp;
            return (Employee)query.First();

        }
    }
    }

