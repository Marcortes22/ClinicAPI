using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Migrations
{
    public static class DataSeeder
    {

  
        public static void SeedClinic(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO clinics (Name, Description, CellPhone, Address, Email) VALUES ('Hospital Metropolitano','first','4545', 'asfasdf', 'asdfasdf')");

        }


        public static void SeedClinicBranches(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO clinicBranches (Name, CellPhone, Address, Email, ClinicId) VALUES ('San José', '+506 2521-9595', '300 m sur del costado oeste del Parque La Merced. Calle 1.', 'correo1@example.com', 1)");
            migrationBuilder.Sql("INSERT INTO clinicBranches (Name, CellPhone, Address, Email, ClinicId) VALUES ('Lindora', '+506 4035-1212', 'Antiguo Lindora Medical Center. 300 m .', 'correo2@example.com', 1)");
            migrationBuilder.Sql("INSERT INTO clinicBranches (Name, CellPhone, Address, Email, ClinicId) VALUES ('LincoIl Plaza', '+506 2521-9595', 'San Vicente de Moravia, San Jo.', 'correo3@example.com', 1)");
        }
        
        public static void SeedAppointmentsTypes(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO appointmentTypes (Name) VALUES ('General medicine')");
            migrationBuilder.Sql("INSERT INTO appointmentTypes (Name) VALUES ('Dentistry')");
            migrationBuilder.Sql("INSERT INTO appointmentTypes (Name) VALUES ('Pediatrics')");
            migrationBuilder.Sql("INSERT INTO appointmentTypes (Name) VALUES ('Neurology')");

        }


        public static void SeedRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO roles (Name, Description) VALUES ('ADMIN','Have all access')");
            migrationBuilder.Sql("INSERT INTO roles (Name, Description) VALUES ('USER', 'Have limited access')");

        }

        public static void SeedUsers(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO users (Id, Name, Email, CellPhone, UserName, Password, clinicId) VALUES ('504420108','Marco','marcortes.stiven@gamil.com', '8848485', 'marcortes20', '1234', '1')");
      
        }

        public static void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO userRoles (RoleId, UserId ) VALUES ('1','504420108')");

        }

    }
}