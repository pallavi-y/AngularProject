using CarManagementServiceProject.BusinessLayer;
using CarManagementServiceProject.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

var myorigins = "_myorigins";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CabServiceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myorigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();

        });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();//added
app.UseCors(myorigins);//added


app.UseAuthorization();

app.MapControllers();

app.Run();
