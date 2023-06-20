using WebApi.Controllers;
using WebApi.Helpers;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    services.AddCors();
    services.AddControllers();

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


    // configure DI for application services
    services.AddScoped<IUserService, UserService>();
    //services.AddScoped<UsersController>();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // custom jwt auth middleware

   // app.MapControllers();

    // mit kode...
    app.UseAuthentication();
    app.UseRouting();
    app.UseMiddleware<JwtMiddleware>();
    //app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
// jeg tror det er Run og ikke use her...
// det virker som det ikke kan instanciere det eller hvad sker der? der er ikke noget middlewear til den næste??
//
app.Run("http://localhost:4000");