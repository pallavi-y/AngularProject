using CarManagementServiceProject.Models;

namespace CarManagementServiceProject.BusinessLayer
{
    public interface IBusinessRepository
    {
        public string VerifyEmployeeAndGetEmployee(string email);
       public  IEnumerable<RegisteredEmployee> GetAllEmployeesRegisteredForCab();
       public  IEnumerable<Cab> GetAllCabs();
       public  IEnumerable<Driver> GetAllDrivers();
       public  IEnumerable<AssignedDriverAndCab> GetAllDriverCabs();
      public  IEnumerable<EmployeePickUpDetails> GetAllPickUpDetails(); //FetchAllPickUpInfo
       public  IEnumerable<EmployeeDropDetails> GetAllDropDetails();//FetchAllDropInfo
        public void AddDriver(Driver driver);
        public void AddCab(Cab cab);
        public void SetPickUp(string EmpID, bool enable);
        public bool getEmployeePickUp(string EmpID);
        public void SetDrop(string EmpID, bool enable);
        public bool getEmployeeDrop(string EmpID);
        public void AddRegisteredEmployee(RegisteredEmployee employee);

        public string LoginEmployee(string email, string password);
        public string LoginDriver(string email, string password);
        public void AddRide(int cabid, int driverid);
        public void DeleteRide(int rideid);

        public IEnumerable<Driver> GetAllUnassignedDrivers();
        public IEnumerable<Cab> GetAllUnassignedCabs();
        public IEnumerable<object> GetAllEmployeesOptedPickUp();
        public IEnumerable<object> GetAllEmployeesOptedDrop();
        public void DriverAddingExpectedPickUpTime(string puid, string Expectedtime);
        public void DriverAddingActualPickUpTime(string puid, string Expectedtime);
        public void DriverAddingActualDropTime(string puid, string Expectedtime);
        public IEnumerable<object> GetAllPickUpAvailableRides();
        public IEnumerable<object> GetAllDropAvailableRides();
        public void AddEmployeeDropDetails(string PUID, int RideId);
        public void AddEmployeePickUpDetails(string PUID, int RideId);
        public IEnumerable<object> PickUpsAssignedForDriver(string email);
        public IEnumerable<object> DropsAssignedForDriver(string email);
        public object CarDetailsAssignedForDriver(string email);
        public IEnumerable<object> GetAllAssignedCarDriverPairs();
        public Object GetEmployeePickUpCabDetails(string PUID);
        public Object GetEmployeeDropCabDetails(string PUID);
        public void resetData();
       // public Object GetEmployeePickUpCabDetails(int EmployeeId);
       

    }
}
