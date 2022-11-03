using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using NuGet.Protocol.Core.Types;
using ProjectCompanyServiceAPI.Models;

namespace ProjectCompanyServiceAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyServiceController : Controller
    {
        private readonly IRepositoryEmployee _repositoryEmployee;
        public CompanyServiceController(IRepositoryEmployee repositoryEmployee)
        {
            _repositoryEmployee = repositoryEmployee;
        }
        [HttpGet]
        public IEnumerable<Employee> getEmployeeList()
        {
            Console.WriteLine(_repositoryEmployee.getEmployeeList());
            return _repositoryEmployee.getEmployeeList();
        }
        [HttpPost]
        public void SaveEmployee([FromBody] Employee s)
        {
            _repositoryEmployee.SaveEmployee(s);
        }
        [HttpGet("{email}")]
        public JsonResult GetEmployee(string email)
        {
            if (_repositoryEmployee.checkEmployeeByEmail(email))
            {
                Employee employeeDetails = _repositoryEmployee.getEmployeeDetails(email);
                object emp =
              new
              {
                  employeeDetails.PUID,
                  employeeDetails.Address,
                  employeeDetails.phonenumber


              };
                return Json(emp);
            }
            else { return Json("NotFound"); 
            }

        }
      
    }
}
