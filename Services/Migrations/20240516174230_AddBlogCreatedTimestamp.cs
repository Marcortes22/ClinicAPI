using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogCreatedTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointmentTypes_appointments_appointmentId",
                table: "appointmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_appointmentTypes_appointmentId",
                table: "appointmentTypes");

            migrationBuilder.AlterColumn<int>(
                name: "appointmentId",
                table: "appointmentTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "appointmentTypeId",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_appointmentTypes_appointmentId",
                table: "appointmentTypes",
                column: "appointmentId",
                unique: true,
                filter: "[appointmentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_appointmentTypes_appointments_appointmentId",
                table: "appointmentTypes",
                column: "appointmentId",
                principalTable: "appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointmentTypes_appointments_appointmentId",
                table: "appointmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_appointmentTypes_appointmentId",
                table: "appointmentTypes");

            migrationBuilder.DropColumn(
                name: "appointmentTypeId",
                table: "appointments");

            migrationBuilder.AlterColumn<int>(
                name: "appointmentId",
                table: "appointmentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointmentTypes_appointmentId",
                table: "appointmentTypes",
                column: "appointmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_appointmentTypes_appointments_appointmentId",
                table: "appointmentTypes",
                column: "appointmentId",
                principalTable: "appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
