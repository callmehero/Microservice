using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//IConfiguration configuration = new ConfigurationBuilder()
//                            .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true)
//                            .Build();

//builder.Services.AddOcelot(configuration);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

//builder.Configuration.AddJsonFile("ocelot.json");
//builder.Services.AddOcelot();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("CORSPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.UseOcelot();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();



app.UseAuthorization();

app.MapRazorPages();

app.Run();
