using FoodDelivery.Data;
using FoodDelivery.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{

}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IResturantRepository,ResturantRepository>();
builder.Services.AddTransient<IMenuItemsRepository,MenuItemsRepository>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    using (var scope=app.Services.CreateScope())
    {
      var context=scope.ServiceProvider.GetRequiredService<AppDbContext>();
      var userManager=scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
      var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roleNames = { "Admin", "User" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExists= await roleManager.RoleExistsAsync(roleName);
            if(!roleExists)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
        //Creating Default Admin
        var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com"
            };
            await userManager.CreateAsync(adminUser, "Admin@123");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

    }

}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

app.Run();
