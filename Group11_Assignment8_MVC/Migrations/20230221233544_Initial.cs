using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Group11_Assignment8_MVC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(nullable: false),
                    Due_Date = table.Column<DateTime>(nullable: false),
                    Quadrant = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CategoryId", "Completed", "Due_Date", "Quadrant", "Task" },
                values: new object[] { 2, 1, false, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Clean the kitchen" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CategoryId", "Completed", "Due_Date", "Quadrant", "Task" },
                values: new object[] { 1, 2, false, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mission 8" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CategoryId", "Completed", "Due_Date", "Quadrant", "Task" },
                values: new object[] { 4, 3, false, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Go to work" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CategoryId", "Completed", "Due_Date", "Quadrant", "Task" },
                values: new object[] { 3, 4, false, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ministering" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryId",
                table: "Tasks",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
