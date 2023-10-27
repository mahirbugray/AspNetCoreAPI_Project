using AspNetCoreAPI_Intro.Data;
using AspNetCoreAPI_Intro.Interfaces;
using AspNetCoreAPI_Intro.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<CityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"))
);

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddCors(cors => cors.AddDefaultPolicy(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));  //API veya diðer web projelerimizin farklý originlerden yapýlacak taleplere cevap vermesini saðlar.

/*builder.Services.AddCors(cors => cors.AddPolicy("corsPolicy", cors => cors.WithOrigins("www.example1.com", "www.example2.com").AllowAnyHeader().AllowAnyMethod()));*/  //Belirtilen domainlerden gelen taleplere izin verir.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
//app.UseCors("corsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
