using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageEmployees.API.Migrations
{
    /// <inheritdoc />
    public partial class AfterRemoveRequiredForignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 28, 9, 13, 53, 781, DateTimeKind.Local).AddTicks(7807),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 25, 20, 6, 1, 363, DateTimeKind.Local).AddTicks(3282));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Contract",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 28, 9, 13, 53, 782, DateTimeKind.Local).AddTicks(1441),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 25, 20, 6, 1, 363, DateTimeKind.Local).AddTicks(7085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Contract",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 28, 9, 13, 53, 782, DateTimeKind.Local).AddTicks(1890),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 25, 20, 6, 1, 363, DateTimeKind.Local).AddTicks(7588));

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Contract",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 25, 20, 6, 1, 363, DateTimeKind.Local).AddTicks(3282),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 28, 9, 13, 53, 781, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Contract",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 25, 20, 6, 1, 363, DateTimeKind.Local).AddTicks(7085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 28, 9, 13, 53, 782, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Contract",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 25, 20, 6, 1, 363, DateTimeKind.Local).AddTicks(7588),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 28, 9, 13, 53, 782, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
