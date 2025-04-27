using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workout.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Excercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    MuscleGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Equipment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Reps = table.Column<int>(type: "int", nullable: true),
                    Sets = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutLog_Excercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Excercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutLog_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Excercise",
                columns: new[] { "Id", "Duration", "Equipment", "MuscleGroup", "Name", "Reps", "Sets", "Type", "Weight" },
                values: new object[,]
                {
                    { 1, null, "", "Chest", "Push Up", 10, 3, 1, null },
                    { 2, null, "", "Hamstrings", "Legs", 15, 3, 1, null },
                    { 3, null, "", "Crunch", "Abs", 100, 3, 1, null },
                    { 4, null, "", "Curl", "Arms", 10, 3, 1, null },
                    { 5, 120, "", "All", "Speed Walking", null, null, 0, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "jackfrost@frosty.com", "Jack Frost" },
                    { 2, "juniebjones@jones.com", "Junie B Jones" },
                    { 3, "cookiemonster@cookie.com", "Cookie Monster" }
                });

            migrationBuilder.InsertData(
                table: "WorkoutLog",
                columns: new[] { "Id", "Date", "ExerciseId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 1, 1 },
                    { 2, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLog_ExerciseId",
                table: "WorkoutLog",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLog_UserId",
                table: "WorkoutLog",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutLog");

            migrationBuilder.DropTable(
                name: "Excercise");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
