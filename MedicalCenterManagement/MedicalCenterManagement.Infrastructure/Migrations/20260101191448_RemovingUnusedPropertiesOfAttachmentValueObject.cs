using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCenterManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovingUnusedPropertiesOfAttachmentValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Patients_Attachments");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Patients_Attachments");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Doctors_Attachments");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Doctors_Attachments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Patients_Attachments",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Doctors_Attachments",
                newName: "Path");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Patients_Attachments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Doctors_Attachments",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Patients_Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "Patients_Attachments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Doctors_Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "Doctors_Attachments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
