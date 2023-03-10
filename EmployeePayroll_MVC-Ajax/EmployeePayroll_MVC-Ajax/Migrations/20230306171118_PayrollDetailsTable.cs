using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePayroll_MVC_Ajax.Migrations
{
    public partial class PayrollDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayrollDetails",
                columns: table => new
                {
                    EmpID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(nullable: false),
                    ProfileImg = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollDetails", x => x.EmpID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayrollDetails");
        }
    }
}
