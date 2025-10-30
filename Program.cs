using Microsoft.EntityFrameworkCore;
using VeilingApi.Data;
using VeilingApi.Services; // als je services gebruikt

var builder = WebApplication.CreateBuilder(args);

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// >>> DB: SQL Server i.p.v. Sqlite
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// >>> Services registreren (laat dit staan als je de service-laag gebruikt)
builder.Services.AddScoped<IAanmeldingService, AanmeldingService>();
builder.Services.AddScoped<IAanvoerderService, AanvoerderService>();
builder.Services.AddScoped<IGebruikerService, GebruikerService>();
builder.Services.AddScoped<IVeilingService, VeilingService>();
builder.Services.AddScoped<IVeilingProductService, VeilingProductService>();
builder.Services.AddScoped<IBiedingService, BiedingService>();
builder.Services.AddScoped<IToewijzingService, ToewijzingService>();

var app = builder.Build();

// Swagger in dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// >>> Automatisch migreren bij startup (zorgt dat DB & tabellen bestaan)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    Console.WriteLine("DB ConnString = " + db.Database.GetDbConnection().ConnectionString);
    db.Database.Migrate();
}

app.UseHttpsRedirection();
app.MapControllers();

// Optioneel: redirect root naar swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
