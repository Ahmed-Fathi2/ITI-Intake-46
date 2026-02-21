using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CrsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrsName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CrsDuration = table.Column<int>(type: "int", nullable: true),
                    TopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CrsId);
                    table.ForeignKey(
                        name: "FK_Courses_Topics_TopId",
                        column: x => x.TopId,
                        principalTable: "Topics",
                        principalColumn: "TopId");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeptDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeptLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ManagerHireDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeptManager = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Instractors",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsDegree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instractors", x => x.InsId);
                    table.ForeignKey(
                        name: "FK_Instractors_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    StSuper = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StId);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DeptId");
                    table.ForeignKey(
                        name: "FK_Students_Students_StSuper",
                        column: x => x.StSuper,
                        principalTable: "Students",
                        principalColumn: "StId");
                });

            migrationBuilder.CreateTable(
                name: "InstCourses",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false),
                    CrsId = table.Column<int>(type: "int", nullable: false),
                    Evaluation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstCourses", x => new { x.InsId, x.CrsId });
                    table.ForeignKey(
                        name: "FK_InstCourses_Courses_CrsId",
                        column: x => x.CrsId,
                        principalTable: "Courses",
                        principalColumn: "CrsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstCourses_Instractors_InsId",
                        column: x => x.InsId,
                        principalTable: "Instractors",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudCourses",
                columns: table => new
                {
                    CrsId = table.Column<int>(type: "int", nullable: false),
                    StId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudCourses", x => new { x.StId, x.CrsId });
                    table.ForeignKey(
                        name: "FK_StudCourses_Courses_CrsId",
                        column: x => x.CrsId,
                        principalTable: "Courses",
                        principalColumn: "CrsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudCourses_Students_StId",
                        column: x => x.StId,
                        principalTable: "Students",
                        principalColumn: "StId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TopId",
                table: "Courses",
                column: "TopId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DeptManager",
                table: "Departments",
                column: "DeptManager");

            migrationBuilder.CreateIndex(
                name: "IX_InstCourses_CrsId",
                table: "InstCourses",
                column: "CrsId");

            migrationBuilder.CreateIndex(
                name: "IX_Instractors_DeptId",
                table: "Instractors",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_StudCourses_CrsId",
                table: "StudCourses",
                column: "CrsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StSuper",
                table: "Students",
                column: "StSuper");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instractors_DeptManager",
                table: "Departments",
                column: "DeptManager",
                principalTable: "Instractors",
                principalColumn: "InsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instractors_DeptManager",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "InstCourses");

            migrationBuilder.DropTable(
                name: "StudCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Instractors");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
