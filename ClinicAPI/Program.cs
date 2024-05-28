
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Services.Users;
using Services.Clinics;
using Services.ClinicBranches;
using Services.Roles;
using Services.UserRoles;
using Services.Appointments;
using Services.AppointmentTypes;
using Services.sendMails;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ISvUsers, SvUsers>();
builder.Services.AddScoped<ISvClinics, SvClinics>();
builder.Services.AddScoped<ISvRoles, SvRoles>();
builder.Services.AddScoped<ISvUserRoles, SvUserRoles>();
builder.Services.AddScoped<ISvClinicBranches, SvClinicBranches>();
builder.Services.AddScoped<ISvAppointmet, SvAppointment>();
builder.Services.AddScoped<ISvAppointmentType, SvAppointmentType>();
builder.Services.AddScoped<ISvEmailSender, SvEmailSender>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(x =>
 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options => {
    options.AddPolicy("ReactApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(cfg => {
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("ApplicationSettings:JWT_Secret").Value)
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero,
        NameClaimType = "Name",
        RoleClaimType = "Role"
    };
});

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

app.UseCors("ReactApp");

app.Run();
