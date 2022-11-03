namespace ProjectCompanyServiceAPI.Models
{
    public interface IRepositoryEmployee
    {
        public IEnumerable<Employee> getEmployeeList();

        public void SaveEmployee(Employee s);
        public bool checkEmployeeByEmail(string email);

        public object getEmployeeByEmail(string emailid); // using linq query

        public Employee getEmployeeDetails(string emailid); 
    }
}
