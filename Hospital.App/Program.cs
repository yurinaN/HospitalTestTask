using Hopital.DataLayer.Context;
using Hopital.DataLayer.Entities;
using Hopital.DataLayer.Repositories;
using Hospital.App;
using Hospital.App.Models.Patients;
using Hospital.Core.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HospitalContext>();
builder.Services.AddScoped<IReadDbContext<IHospitalEntity>>(options =>
{
    return new DefaultReadDbContext<IHospitalEntity>(new HospitalContext(builder.Configuration));
});
builder.Services.AddScoped<IWriteDbContext<IHospitalEntity>>(options =>
{
    return new DefaultWriteDbContext<IHospitalEntity>(new HospitalContext(builder.Configuration));
});

builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IHealthLocalityRepository, HealthLocalityRepository>();

builder.Services.AddScoped<IPatientModelBuilder, PatientModelBuilder>();
builder.Services.AddScoped<IPatientModelHandler, PatientModelHandler>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
