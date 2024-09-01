using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCadetsAPI.Migrations
{
    /// <inheritdoc />
    public partial class FewDeletions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectManagement");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Works",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "HoursWorked",
                table: "Works",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Works_UserId",
                table: "Works",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Users_UserId",
                table: "Works",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Users_UserId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_UserId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Works",
                newName: "Duration");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Works",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkID = table.Column<int>(type: "INTEGER", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoursWorked = table.Column<int>(type: "INTEGER", nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_Works_WorkID",
                        column: x => x.WorkID,
                        principalTable: "Works",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Budget = table.Column<double>(type: "REAL", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectManagement",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectRole = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectManagement", x => new { x.LogId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ProjectManagement_Logs_LogId",
                        column: x => x.LogId,
                        principalTable: "Logs",
                        principalColumn: "LogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectManagement_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectManagement_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserID",
                table: "Logs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_WorkID",
                table: "Logs",
                column: "WorkID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagement_ProjectId",
                table: "ProjectManagement",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagement_UserId",
                table: "ProjectManagement",
                column: "UserId");
        }
    }
}
