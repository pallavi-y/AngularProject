using CarManagementServiceProject.BusinessLayer;
using CarManagementServiceProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace CarManagementServiceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CabServiceController : Controller
    {
       
        private readonly IBusinessRepository _businessRepository;

        public class ObjectBody
        {
            public string? Empid { get; set; }
            public string? pickup { get; set; }
            public string? drop { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public string? LandMark { get; set; }
            public string? CabId { get; set; }
            public string? DriverId { get; set; }
            public string? RideId { get; set; }
            public string? ExpectedTime { get; set; }
            public string? ActualTime { get; set; }
        }

        public CabServiceController(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;

        }
        [HttpGet("{email}")]
        public JsonResult VerifyEmail(string email)
        {
            String res = _businessRepository.VerifyEmployeeAndGetEmployee(email);
            res = res.Replace("{", "");
            res = res.Replace("}", "");
            object result;
            if (res == "\"NotFound\"" || res == "UnableToFetchCompanyService")
            {
                result = new { exists = false };
                return Json(result);
            }

            result = new { exists = true };
            return Json(result);
        }
        [HttpPost, Route("RegisteredEmployee")]
        public void RegisteredEmployee([FromBody] ObjectBody emp)
        {
            RegisteredEmployee employee = new RegisteredEmployee();
            String res = _businessRepository.VerifyEmployeeAndGetEmployee(emp.Email);
            res = res.Replace("{", "");
            res = res.Replace("}", "");
            string[] result = res.Split(",\"");

                 employee.EmailAddress=emp.Email;
                 employee.Password = emp.Password;
                 employee.LandMark=emp.LandMark;
            employee.EmployeeId = result[0].Substring(result[0].IndexOf(":") + 1).Replace("\"", "");
            employee.EmployeePhoneNumber = long.Parse(result[2].Substring(result[2].IndexOf(":") + 1));
            employee.EmployeeAddress = result[1].Substring(result[1].IndexOf(":") + 1).Replace("\"", "");
            _businessRepository.AddRegisteredEmployee(employee);
         }//should give email,password,landmark
        [HttpPatch,Route("LoginEmployee")]
        public JsonResult LoginEmployee([FromBody] ObjectBody resultobj)
        {

            string result= _businessRepository.LoginEmployee(resultobj.Email,resultobj.Password);
            object res;
            if (result == "")
            {
                res = new {verified=false};
            }
            else
            {
                string[] Details = result.Split("|");
                res = new { verified = true, PUID = Details[0] ,IsPickUp= bool.Parse(Details[1]),IsDrop = bool.Parse(Details[2]) };
            }

            return Json(res);//should enter email and password

        }
        [HttpPatch, Route("LoginDriver")]
        public JsonResult LoginDriver([FromBody] ObjectBody resultobj)
        {

            string result = _businessRepository.LoginDriver(resultobj.Email, resultobj.Password);
            object res;
          

            if (result == "")
            {
                res = new { verified = false };
            }
            else
            {
                string[] Details = result.Split("|");
                res = new { verified = true, Name = Details[0], Email = Details[1] };
            }

            return Json(res);//should enter email and password

        }
        [HttpPatch, Route("AddRide")]
        public void AddRide([FromBody]ObjectBody s)
        {
            // AssignedDriverAndCab a = new AssignedDriverAndCab();
            int a = int.Parse(s.CabId);
            int b = int.Parse(s.DriverId);
            //  public static int count = 0;

            _businessRepository.AddRide(a, b);
        }//should enter cabid and driverid
        [HttpPost,Route("DeleteRide")]
        public void DeleteRide([FromBody]ObjectBody obj)
        {
            int rideid= int.Parse(obj.RideId);
            _businessRepository.DeleteRide(rideid);
        }//should enter rideid
        [HttpGet,Route("GetAllRides")]
        public IEnumerable<AssignedDriverAndCab> GetAllRides()
        {
           return _businessRepository.GetAllDriverCabs();

        }//get all rides 
        [HttpGet,Route("UnassignedDrivers")]
        public IEnumerable<Driver> UnassignedDrivers()
        {
            return _businessRepository.GetAllUnassignedDrivers();
        }//gets all unassigned drivers
        [HttpGet,Route("UnassignedCabs")]
        public IEnumerable<Cab> UnassignedCabs()
        {
            return _businessRepository.GetAllUnassignedCabs();
        }//gets all unasignned cabs

        [HttpPatch, Route("EmployeePickUpStatus")]
        public void EmployeePickUpstatus( [FromBody] ObjectBody obj)
        {
            String Empid= obj.Empid;
            bool pickup = bool.Parse(obj.pickup);
           

            _businessRepository.SetPickUp(Empid, pickup);
        }//updates the registered employee pickupstatus
        [HttpPatch, Route("EmployeedropStatus")]
        public void EmployeeDropstatus([FromBody] ObjectBody obj)
        {
            String Empid = obj.Empid;
            bool drop = bool.Parse(obj.drop);

            _businessRepository.SetDrop(Empid, drop);
        }
        [HttpGet,Route("PickUpEnabledEmployees")]
        public IEnumerable<object> GetValuesPickUpEnabledEmployee()
        {
          return  _businessRepository.GetAllEmployeesOptedPickUp();
        }
        [HttpGet, Route("DropEnabledEmployees")]
        public IEnumerable<object> GetValuesDropEnabledEmployee()
        {
            return _businessRepository.GetAllEmployeesOptedDrop();
        }
        [HttpPatch, Route("setPickUpExpectedTime")]
        public void setPickUpExpectedTime([FromBody]  ObjectBody obj )
        {
            string puid = obj.Empid;

            _businessRepository.DriverAddingExpectedPickUpTime( puid,obj.ExpectedTime);
        }
        [HttpPatch, Route("setPickUpActualTime")]
        public void setPickUpActualTime([FromBody] ObjectBody obj)
        {

            string puid = obj.Empid;
            _businessRepository.DriverAddingActualPickUpTime(puid, obj.ActualTime);
        }
        [HttpPatch, Route("setDropActualTime")]
        public void setDropActualTime([FromBody] ObjectBody obj)
        {
             string puid = obj.Empid;
            _businessRepository.DriverAddingActualDropTime(puid, obj.ActualTime);
        }
        [HttpGet,Route("GetAllPickUpAvailableRides")]
        public IEnumerable<object> GetAllPickUpAvailableRides()
        {
          return  _businessRepository.GetAllPickUpAvailableRides();
        }
        [HttpGet,Route("GetAllDropAvailableRides")]
        public IEnumerable<object> GetAllDropAvailableRides()
        {
            return  _businessRepository.GetAllDropAvailableRides();
        }
        [HttpPatch,Route("AddEmployeePickUpDetails")]
        public void AddEmployeePickUpDetails([FromBody]ObjectBody obj)

        {
            string puid= obj.Empid;
            int Rideid = int.Parse(obj.RideId);
            _businessRepository.AddEmployeePickUpDetails(puid,Rideid);
        }//add employee to employeepickupdetails table
        [HttpPatch, Route("AddEmployeeDropDetails")]
        public void AddEmployeeDropDetails([FromBody] ObjectBody obj)
        {
            string puid = obj.Empid;
            int Rideid = int.Parse(obj.RideId);
            _businessRepository.AddEmployeeDropDetails(puid, Rideid);
        }//add employee to employeedropdetails table
        [HttpPatch,Route("PickUpsAssignedForDriver")]
        public IEnumerable<object> PickUpsAssignedForDriver([FromBody] ObjectBody obj)
        {
            string Driveremail = obj.Email;
            return _businessRepository.PickUpsAssignedForDriver(Driveremail);
        }
        [HttpPatch, Route("DropsAssignedForDriver")]
        public IEnumerable<object> DropsAssignedForDriver([FromBody]ObjectBody obj)
        {
            string Driveremail = obj.Email;
            return _businessRepository.DropsAssignedForDriver(Driveremail);
        }


        [HttpPost, Route("AddDriver")]
        public void AddDriver(Driver driver)
        {
            _businessRepository.AddDriver(driver);

        }
       
        [HttpPost, Route("AddCab")]
        public void AddCab([FromBody] Cab cab)
        {
            _businessRepository.AddCab(cab);
        }
        [HttpPatch,Route("CabDetailsAssignedForDriver")]
        public object CabDetailsAssignedForDriver([FromBody]ObjectBody obj)
        {
            string email=obj.Email;
            return _businessRepository.CarDetailsAssignedForDriver(email);
        }
       
        [HttpGet,Route("GetAllAssignedCarDriverPairs")]
        public IEnumerable<object> GetAllAssignedCarDriverPairs()
        {
            return _businessRepository.GetAllAssignedCarDriverPairs();
        }
        [HttpPatch,Route("GetEmployeePickUpCabDetails")]
        public object GetEmployeePickUpCabDetails([FromBody] ObjectBody obj)
        {
            string PUID=obj.Empid;
            return _businessRepository.GetEmployeePickUpCabDetails(PUID);

        }// employee will recive the pick up cab details
        [HttpPatch, Route("GetEmployeeDropCabDetails")]
        public object GetEmployeeDropCabDetails([FromBody] ObjectBody obj)
        {
            string PUID = obj.Empid;
            return _businessRepository.GetEmployeeDropCabDetails(PUID);

        }// employee will recive the drop cab details
        [HttpGet, Route("ResetData")]
        public void resetData()
        {
            _businessRepository.resetData();
        }


    }
}
