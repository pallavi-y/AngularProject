namespace CarManagementServiceProject.Models
{
    public class ConsumingCompanyService
    {
        public HttpClient Initial()
        {
            var Client=new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5049/");
            return Client;
        }
    }
}
