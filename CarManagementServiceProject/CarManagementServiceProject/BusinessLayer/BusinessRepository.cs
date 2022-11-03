using CarManagementServiceProject.DataAccessLayer;
using CarManagementServiceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CarManagementServiceProject.BusinessLayer
{

    public class BusinessRepository : IBusinessRepository
    {
        ConsumingCompanyService _api = new ConsumingCompanyService();


        private readonly CabServiceDbContext _dbContext;

        public BusinessRepository(CabServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string VerifyEmployeeAndGetEmployee(string email)
        {


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:11732/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"api/CompanyService/{email}").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                return data;
            }
            else
            {

                return "UnableToFetchCompanyService";
            }


        }

        public IEnumerable<RegisteredEmployee> GetAllEmployeesRegisteredForCab()
        {
            return _dbContext.RegisteredEmployees.AsEnumerable();
        }

        public IEnumerable<Cab> GetAllCabs()
        {
            return _dbContext.CabsTable.AsEnumerable();
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            return _dbContext.DriversTable.AsEnumerable();
        }

        public IEnumerable<AssignedDriverAndCab> GetAllDriverCabs()
        {
            //var ridesquery= from ride in _dbContext.AssignedDriverAndCabs

            return _dbContext.AssignedDriverAndCabs.AsEnumerable();
        }

        public IEnumerable<EmployeePickUpDetails> GetAllPickUpDetails()//all pickups
        {
            return _dbContext.EmployeePickUpDetailsTable.AsEnumerable();
        }

        public IEnumerable<EmployeeDropDetails> GetAllDropDetails()//all drops
        {
            return _dbContext.EmployeeDropDetailsTable.AsEnumerable();
        }
        public void AddDriver(Driver driver)
        {
            _dbContext.DriversTable.Add(driver);
            _dbContext.SaveChanges();
        }
        public void AddCab(Cab cab)
        {
            _dbContext.CabsTable.Add(cab);
            _dbContext.SaveChanges();
        }
        public List<RegisteredEmployee> GetEmployeeByLandMarkPickUp(string Landmark) //employees based on landmark drop
        {
            var DropLandmarkquery = (from emp in _dbContext.RegisteredEmployees
                                     where emp.LandMark == Landmark && emp.DropStatus == true
                                     select emp).ToList();
            return DropLandmarkquery;
        }
        public List<RegisteredEmployee> GetEmployeeByLandMarkDrop(string Landmark) //employees based on landmark pickup
        {
            var PickUpLandmarkquery = (from emp in _dbContext.RegisteredEmployees
                                       where emp.LandMark == Landmark && emp.PickUpStatus == true
                                       select emp).ToList();
            return PickUpLandmarkquery;
        }

        public void AddRide(int cabid, int driverid)
        {

            AssignedDriverAndCab assignedride = new AssignedDriverAndCab();


            int rideid = (cabid * 100) + driverid;
            using (var ride = _dbContext)
            {

                ride.AssignedDriverAndCabs.Add(new AssignedDriverAndCab { RideId = rideid, CabId = cabid, DriverId = driverid, IsAssigned = false });
                ride.SaveChanges();
            }


        }
        public void DeleteRide(int rideid)
        {
            var deletequery = (from ride in _dbContext.AssignedDriverAndCabs.AsEnumerable()
                               where ride.RaidKey == rideid
                               select ride).SingleOrDefault();

            if (deletequery != null)
            {


                AssignedDriverAndCab assignedDriverAndCab = deletequery;
                _dbContext.AssignedDriverAndCabs.Remove(assignedDriverAndCab);
                _dbContext.SaveChanges();
            }

        }

        //public void PickUpAssign(string EmpId, string rideNo)
        //{
        //    EmployeePickUpDetails employeePickUp = new EmployeePickUpDetails();
        //    using (var pickUp = _dbContext)
        //    {
        //        pickUp.EmployeePickUpDetailsTable.Add(new EmployeePickUpDetails { EmployeeID = EmpId, ActualPickUp = , RideId = rideNo, })
        //    }

        //}
        public void SetPickUp(string EmpID, bool enable)   //update pickUp status
        {


            var setpickupquery = (from emp in _dbContext.RegisteredEmployees
                                  where emp.EmployeeId == EmpID
                                  select emp).SingleOrDefault();

            Console.WriteLine(setpickupquery);

            RegisteredEmployee employee = setpickupquery;
            if (employee != null)
            {
                employee.PickUpStatus = enable;
                _dbContext.SaveChanges();
            }

        }
        public bool getEmployeePickUp(string EmpID)
        {
            var getpickupquery = (from emp in _dbContext.RegisteredEmployees
                                  where emp.EmployeeId == EmpID
                                  select emp.PickUpStatus).SingleOrDefault();
            return getpickupquery;

        }
        public void SetDrop(string EmpID, bool enable)    //update drop status
        {
            var setdropquery = (from emp in _dbContext.RegisteredEmployees
                                where emp.EmployeeId == EmpID
                                select emp).SingleOrDefault();

            Console.WriteLine(setdropquery);

            RegisteredEmployee employee = setdropquery;
            if (employee != null)
            {
                employee.DropStatus = enable;
                _dbContext.SaveChanges();

            }

        }
        public bool getEmployeeDrop(string EmpID)
        {
            var getpickupquery = (from emp in _dbContext.RegisteredEmployees
                                  where emp.EmployeeId == EmpID
                                  select emp.DropStatus).SingleOrDefault();
            return getpickupquery;

        }

        public void AddRegisteredEmployee(RegisteredEmployee employee)
        {
            _dbContext.RegisteredEmployees.Add(employee);
            _dbContext.SaveChanges();
        }
        public string LoginEmployee(string email, string password)
        {
            var loginquery = (from emp in _dbContext.RegisteredEmployees
                              where emp.EmailAddress == email && emp.Password == password
                              select new
                              {
                                  Details = emp.EmployeeId + "|" + emp.PickUpStatus.ToString() + "|" + emp.DropStatus.ToString()
                                  //PUID = emp.EmployeeId,
                                  //PickUpStatus=emp.PickUpStatus.ToString(),
                                  //DropStatus=emp.DropStatus.ToString()

                              }).ToList();
            string res = loginquery[0].Details;
            if (loginquery != null)
            {
                return res;
            }
            else
            {
                return "";
            }
        }
        public string LoginDriver(string email, string password)
        {
            var loginquery = (from driver in _dbContext.DriversTable
                              where driver.EmailAddress == email && driver.Password == password
                              select new
                              {
                                  Name = driver.DriverName,
                                  EmailId=driver.EmailAddress

                              }).SingleOrDefault();
            if (loginquery != null)
            {
                return loginquery.Name+"|"+loginquery.EmailId;
            }
            else
            {
                return "";
            }
        }
        public IEnumerable<Driver> GetAllUnassignedDrivers()
        {
            var query = (from driver in _dbContext.AssignedDriverAndCabs
                         select driver).ToList();
            var Unassingedquery = (from driver1 in _dbContext.DriversTable
                                   select driver1).ToList();

            var list = Unassingedquery.Where(p => query.All(p2 => p2.DriverId != p.DriverId));

            return list;


        }
        public IEnumerable<Cab> GetAllUnassignedCabs()
        {
            var query = (from cab in _dbContext.AssignedDriverAndCabs
                         select cab).ToList();
            var Unassingedquery = (from cab1 in _dbContext.CabsTable
                                   select cab1).ToList();

            var list = Unassingedquery.Where(p => query.All(p2 => p2.CabId != p.CabId));

            return list;


        }
        public IEnumerable<object> GetAllEmployeesOptedPickUp()
        {
            var query = (from emp in _dbContext.RegisteredEmployees
                         where emp.PickUpStatus == true
                         orderby emp.LandMark
                         select new
                         {
                             PUID = emp.EmployeeId,
                             Email = emp.EmailAddress,
                             PhoneNumber = emp.EmployeePhoneNumber,
                             LandMark = emp.LandMark,
                             Assigned_ride_no=(from ar in _dbContext.EmployeePickUpDetailsTable 
                                              where ar.EmployeeId == emp.Key select ar.RideId).SingleOrDefault()
                         }).ToList();
           
            return query;
        }
        public IEnumerable<object> GetAllEmployeesOptedDrop()
        {
            var query = (from emp in _dbContext.RegisteredEmployees
                         where emp.DropStatus == true
                         orderby emp.LandMark
                         select new
                         {
                             PUID = emp.EmployeeId,
                             Email = emp.EmailAddress,
                             PhoneNumber = emp.EmployeePhoneNumber,
                             LandMark = emp.LandMark,
                             Assigned_ride_no = (from ar in _dbContext.EmployeeDropDetailsTable
                                                 where ar.EmployeeId == emp.Key
                                                 select ar.RaidId).SingleOrDefault()
                         }).ToList();
            return query;
        }
        public void DriverAddingExpectedPickUpTime(string puid, string Expectedime)
        {
            //string hr = Expectedime.Split(":")[0];
            int hr = int.Parse(Expectedime.Split(":")[0]);
            //string mm=Expectedime.Split(":")[1];
            int mm = int.Parse(Expectedime.Split(":")[1]);
            TimeSpan time = new TimeSpan(hr, mm, 0);
            var ridequery = (from emp in _dbContext.RegisteredEmployees
                             where emp.EmployeeId == puid
                             select emp.Key).SingleOrDefault();
            var query = (from pickupdetail in _dbContext.EmployeePickUpDetailsTable
                         where pickupdetail.EmployeeId == ridequery
                         select pickupdetail).SingleOrDefault();
            EmployeePickUpDetails employee;
            // TimeSpan timeSpan = time.ToTimeSpan();
            // TimeSpan time1 = time;
            if (query != null)
            {
                employee = (EmployeePickUpDetails)query;
                employee.ExpectedPickUp = time;
                
                _dbContext.SaveChanges();
            }

        }
        public void DriverAddingActualPickUpTime(string puid, string Actualtime)
        {
            //string hr = Expectedime.Split(":")[0];
            int hr = int.Parse(Actualtime.Split(":")[0]);
            //string mm=Expectedime.Split(":")[1];
            int mm = int.Parse(Actualtime.Split(":")[1]);
            TimeSpan time = new TimeSpan(hr, mm, 0);
            var ridequery = (from emp in _dbContext.RegisteredEmployees
                             where emp.EmployeeId == puid
                             select emp.Key).SingleOrDefault();
            var query = (from pickupdetail in _dbContext.EmployeePickUpDetailsTable
                         where pickupdetail.EmployeeId == ridequery
                         select pickupdetail).SingleOrDefault();
            EmployeePickUpDetails employee;
            // TimeSpan timeSpan = time.ToTimeSpan();
            // TimeSpan time1 = time;
            if (query != null)
            {
                employee = (EmployeePickUpDetails)query;
                employee.ActualPickUp = time;
                _dbContext.SaveChanges();
            }

        }
        public void DriverAddingActualDropTime(string puid, string Actualtime)
        {
            //string hr = Expectedime.Split(":")[0];
            int hr = int.Parse(Actualtime.Split(":")[0]);
            //string mm=Expectedime.Split(":")[1];
            int mm = int.Parse(Actualtime.Split(":")[1]);
            TimeSpan time = new TimeSpan(hr, mm, 0);
            var ridequery = (from emp in _dbContext.RegisteredEmployees
                             where emp.EmployeeId == puid
                             select emp.Key).SingleOrDefault();
            var query = (from pickupdetail in _dbContext.EmployeeDropDetailsTable
                         where pickupdetail.EmployeeId == ridequery
                         select pickupdetail).SingleOrDefault();
            EmployeeDropDetails employee;
            // TimeSpan timeSpan = time.ToTimeSpan();
            // TimeSpan time1 = time;
            if (query != null)
            {
                employee = (EmployeeDropDetails)query;
                employee.ActualDrop = time;
                _dbContext.SaveChanges();
            }

        }
        public IEnumerable<object> GetAllPickUpAvailableRides()
        {
            var CarSeats = (from r in _dbContext.AssignedDriverAndCabs
                            join c in _dbContext.CabsTable on r.CabId equals c.CabId
                            select new
                            {
                                totalseats = c.No_of_Seats,
                                RideId = r.RaidKey

                            }).ToList();
            var filledSeats = (from r in CarSeats
                              join p in _dbContext.EmployeePickUpDetailsTable on r.RideId equals p.RideId
                              group p by p.RideId into ridegroup
                              select new
                              {
                                  RideId = ridegroup.Key,
                                  SeatsCount = ridegroup.Count()
                              }).ToList();

            var avaliblerides = (from r in CarSeats
                                join p in filledSeats on r.RideId equals p.RideId
                                where p.SeatsCount < r.totalseats
                                orderby r.RideId
                                select new
                                {
                                    RideId = r.RideId,
                                    seats = p.SeatsCount,
                                    TotalSeats=r.totalseats
                                }).ToList();
            var fullavaliblerides = (from r in CarSeats
                                 join p in filledSeats on r.RideId equals p.RideId
                                 where p.SeatsCount == r.totalseats
                                 orderby r.RideId
                                 select new
                                 {
                                     RideId = r.RideId,
                                     seats = p.SeatsCount,
                                     TotalSeats = r.totalseats
                                 }).ToList();


            var list = CarSeats.Where(p => avaliblerides.All(p2 => p2.RideId != p.RideId));
            var finallist = list.Where(p => fullavaliblerides.All(p2 => p2.RideId != p.RideId));
            var listObj = (from l in finallist
                          select new
                          {
                              RideId = l.RideId,
                              seats = 0,
                              TotalSeats = l.totalseats
                          }).ToList();
            var combined = avaliblerides.Concat(listObj);
            return combined;
        }
        public IEnumerable<object> GetAllDropAvailableRides()
        {
            var CarSeats = (from r in _dbContext.AssignedDriverAndCabs
                            join c in _dbContext.CabsTable on r.CabId equals c.CabId
                            select new
                            {
                                totalseats = c.No_of_Seats,
                                RideId = r.RaidKey

                            }).ToList();
            var filledSeats = (from r in CarSeats
                              join p in _dbContext.EmployeeDropDetailsTable on r.RideId equals p.RaidId
                              group p by p.RaidId into ridegroup
                              select new
                              {
                                  RideId = ridegroup.Key,
                                  SeatsCount = ridegroup.Count()
                              }).ToList();

            var avaliblerides = (from r in CarSeats
                                join p in filledSeats on r.RideId equals p.RideId
                                where p.SeatsCount < r.totalseats
                                orderby r.RideId
                                select new
                                {
                                    RideId = r.RideId,
                                    seats = p.SeatsCount,
                                    TotalSeats = r.totalseats
                                }).ToList();

            var fullavaliblerides = (from r in CarSeats
                                     join p in filledSeats on r.RideId equals p.RideId
                                     where p.SeatsCount == r.totalseats
                                     orderby r.RideId
                                     select new
                                     {
                                         RideId = r.RideId,
                                         seats = p.SeatsCount,
                                         TotalSeats = r.totalseats
                                     }).ToList();


            var list = CarSeats.Where(p => avaliblerides.All(p2 => p2.RideId != p.RideId));
            var finallist = list.Where(p => fullavaliblerides.All(p2 => p2.RideId != p.RideId));
            var listObj = (from l in finallist
                           select new
                           {
                               RideId = l.RideId,
                               seats = 0,
                               TotalSeats = l.totalseats
                           }).ToList();
            var combined = avaliblerides.Concat(listObj);
            return combined;
        }
        public void AddEmployeePickUpDetails(string PUID, int RideId)
        {
            EmployeePickUpDetails p = new EmployeePickUpDetails();
            var query = (from emp in _dbContext.RegisteredEmployees
                         where emp.EmployeeId == PUID
                         select emp.Key).SingleOrDefault();
            p.EmployeeId = query;
            p.ActualPickUp = new TimeSpan(0, 0, 0);
            p.ExpectedPickUp = new TimeSpan(0, 0, 0);
            p.RideId = RideId;
            using (var db = _dbContext)
            {

                db.EmployeePickUpDetailsTable.Add(p);
                db.SaveChanges();
            }

        }
        public void AddEmployeeDropDetails(string PUID, int RideId)
        {
            EmployeeDropDetails p = new EmployeeDropDetails();
            var query = (from emp in _dbContext.RegisteredEmployees
                         where emp.EmployeeId == PUID
                         select emp.Key).SingleOrDefault();
            p.EmployeeId = query;
            p.ActualDrop = new TimeSpan(0, 0, 0);
            p.RaidId = RideId;
            using (var db = _dbContext)
            {

                db.EmployeeDropDetailsTable.Add(p);
                db.SaveChanges();
            }

        }
        public IEnumerable<object> PickUpsAssignedForDriver(string email)
        {
            var rideId = (from d in _dbContext.DriversTable
                          join r in _dbContext.AssignedDriverAndCabs
                       on d.DriverId equals r.DriverId
                          where d.EmailAddress == email
                          select r.RaidKey).SingleOrDefault();
            var query = (from e in _dbContext.EmployeePickUpDetailsTable
                         where e.RideId == rideId
                         select e).ToList();
            var res = (from e in query
                       join emp in _dbContext.RegisteredEmployees
                       on e.EmployeeId equals emp.Key
                       select new
                       {
                           empId = emp.Key,
                           PUID = emp.EmployeeId,
                           PhoneNum = emp.EmployeePhoneNumber,
                           Landmark = emp.LandMark,
                           ActualTime=e.ActualPickUp,
                           ExpectedTime=e.ExpectedPickUp
                       }).ToList();
            return res;

        }
        public IEnumerable<object> DropsAssignedForDriver(string email)
        {
            var rideId = (from d in _dbContext.DriversTable
                          join r in _dbContext.AssignedDriverAndCabs
                       on d.DriverId equals r.DriverId
                          where d.EmailAddress == email
                          select r.RaidKey).SingleOrDefault();
            var query = (from e in _dbContext.EmployeeDropDetailsTable
                         where e.RaidId == rideId
                         select e).ToList();
            var res = (from e in query
                       join emp in _dbContext.RegisteredEmployees
                       on e.EmployeeId equals emp.Key
                       select new
                       {
                           empId = emp.Key,
                           PUID = emp.EmployeeId,
                           PhoneNum = emp.EmployeePhoneNumber,
                           Landmark = emp.LandMark,
                           ActualTime = e.ActualDrop
                       }).ToList();
            return res;

        }
        public object CarDetailsAssignedForDriver(string email)
        {
            var query = (from d in _dbContext.DriversTable
                         join r in _dbContext.AssignedDriverAndCabs on d.DriverId equals r.DriverId
                         where d.EmailAddress == email
                         select r.CabId).SingleOrDefault();
            var cab = (from c in _dbContext.CabsTable
                       where c.CabId == query
                       select c).SingleOrDefault();
            if (cab == null)
            {
                object obj = new
                {
                    CabId = "-",
                    CabNumber = "-",
                    CabName = "-",
                    No_of_Seats = "-",
                    Engine_Type = "-",
                    Fuelled = "-",
                    Vehicle_Status = "-"
                };
                return obj;
            }
            return cab;

        }
        public IEnumerable<object> GetAllAssignedCarDriverPairs()
        {
            var query = (from r in _dbContext.AssignedDriverAndCabs
                         join c in _dbContext.CabsTable on r.CabId equals c.CabId
                         join d in _dbContext.DriversTable on r.DriverId equals d.DriverId
                         select new
                         {
                             rideId = r.RaidKey,
                             cabNum = c.CabNumber,
                             carName = c.CabName,
                             driverName = d.DriverName,
                             driverPhone = d.PhoneNumber
                         }).ToList();
            return query;
        }
        public Object GetEmployeePickUpCabDetails(string PUID)
        {
            var EmployeeId = (from emp in _dbContext.RegisteredEmployees
                              where emp.EmployeeId == PUID
                              select emp.Key).SingleOrDefault();
            var query = (from driver in _dbContext.DriversTable
                         join ride in _dbContext.AssignedDriverAndCabs
                         on driver.DriverId equals ride.DriverId
                         join cab in _dbContext.CabsTable
                         on ride.CabId equals cab.CabId
                         join pickup in _dbContext.EmployeePickUpDetailsTable
                         on ride.RaidKey equals pickup.RideId
                         where pickup.EmployeeId == EmployeeId
                         select new
                         {
                             CabNumber = cab.CabNumber,
                             DriverName = driver.DriverName,
                             DriverContactNumber = driver.PhoneNumber,
                             DriverAltContactNumber = driver.Alt_PhoneNumber,
                             ExpectedPickUpTime = (from q in _dbContext.EmployeePickUpDetailsTable
                                                   where q.EmployeeId == EmployeeId
                                                   select q.ExpectedPickUp).ToList()[0].ToString()
                         }).SingleOrDefault();
            if (query == null)
            {
                object obj = new
                {
                    CabNumber = "-",
                    DriverName = "-",
                    DriverContactNumber = "-",
                    DriverAltContactNumber = "-",
                    ExpectedPickUpTime = "-"
                };
                return obj;
            }
            return query;


        }
        public Object GetEmployeeDropCabDetails(string PUID)
        {
            var EmployeeId = (from emp in _dbContext.RegisteredEmployees
                              where emp.EmployeeId == PUID
                              select emp.Key).SingleOrDefault();
            var query = (from driver in _dbContext.DriversTable
                         join ride in _dbContext.AssignedDriverAndCabs
                         on driver.DriverId equals ride.DriverId
                         join cab in _dbContext.CabsTable
                         on ride.CabId equals cab.CabId
                         join drop in _dbContext.EmployeeDropDetailsTable
                         on ride.RaidKey equals drop.RaidId
                         where drop.EmployeeId == EmployeeId
                         select new
                         {
                             CabNumber = cab.CabNumber,
                             DriverName = driver.DriverName,
                             DriverContactNumber = driver.PhoneNumber,
                             DriverAltContactNumber = driver.Alt_PhoneNumber
                         }).SingleOrDefault();
            if (query == null)
            {
                object obj = new
                {
                    CabNumber = "-",
                    DriverName = "-",
                    DriverContactNumber = "-",
                    DriverAltContactNumber = "-"
                };
                return obj;
            }
            return query;


        }
        //public Object GetEmployeePickUpCabDetails(string PUID)
        //{
        //    var empquery = (from emp in _dbContext.RegisteredEmployees
        //                 where emp.EmployeeId == PUID
        //                 select emp.Key).SingleOrDefault();
        //    var query = (from driver in _dbContext.DriversTable
        //                 join ride in _dbContext.AssignedDriverAndCabs
        //                 on driver.DriverId equals ride.DriverId
        //                 join cab in _dbContext.CabsTable
        //                 on ride.CabId equals cab.CabId
        //                 select new
        //                 {
        //                     CabNumber = cab.CabNumber,
        //                     DriverName = driver.DriverName,
        //                     DriverContactNumber = driver.PhoneNumber,
        //                     DriverAltContactNumber = driver.Alt_PhoneNumber,
        //                     ExpectedPickUpTime = (from q in _dbContext.EmployeePickUpDetailsTable
        //                                           where q.EmployeeId == empquery
        //                                           select q.ExpectedPickUp).ToList()[0].ToString()
        //                 }).FirstOrDefault();


        //    return query;
        //}
        //public Object GetEmployeeDropCabDetails(string PUID)
        //{
        //    var empquery = (from emp in _dbContext.RegisteredEmployees
        //                    where emp.EmployeeId == PUID
        //                    select emp.Key).SingleOrDefault();
        //    var query = (from driver in _dbContext.DriversTable
        //                 join ride in _dbContext.AssignedDriverAndCabs
        //                 on driver.DriverId equals ride.DriverId
        //                 join cab in _dbContext.CabsTable
        //                 on ride.CabId equals cab.CabId
        //                 select new
        //                 {
        //                     CabNumber = cab.CabNumber,
        //                     DriverName = driver.DriverName,
        //                     DriverContactNumber = driver.PhoneNumber,
        //                     DriverAltContactNumber = driver.Alt_PhoneNumber,
        //                     ExpectedPickUpTime = (from q in _dbContext.EmployeeDropDetailsTable
        //                                           where q.EmployeeId == empquery
        //                                           select q.ExpectedPickU).ToList()[0].ToString()
        //                 }).FirstOrDefault();


        //    return query;
        //}

        public void resetData()
        {
            var pick = (from obj in _dbContext.EmployeeDropDetailsTable select obj).ToList();
            _dbContext.EmployeeDropDetailsTable.RemoveRange(pick);
            var drop = (from obj in _dbContext.EmployeePickUpDetailsTable select obj).ToList();
            _dbContext.EmployeePickUpDetailsTable.RemoveRange(drop);
            _dbContext.SaveChanges();

        }
    }
}

