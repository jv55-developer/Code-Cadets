using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCadetsAPI.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagement_UserId",
                table: "ProjectManagement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagement_WorkId",
                table: "ProjectManagement",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserID",
                table: "Logs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_WorkID",
                table: "Logs",
                column: "WorkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Users_UserID",
                table: "Logs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Works_WorkID",
                table: "Logs",
                column: "WorkID",
                principalTable: "Works",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectManagement_Logs_LogId",
                table: "ProjectManagement",
                column: "LogId",
                principalTable: "Logs",
                principalColumn: "LogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectManagement_Users_UserId",
                table: "ProjectManagement",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectManagement_Works_WorkId",
                table: "ProjectManagement",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Users_UserID",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Works_WorkID",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectManagement_Logs_LogId",
                table: "ProjectManagement");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectManagement_Users_UserId",
                table: "ProjectManagement");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectManagement_Works_WorkId",
                table: "ProjectManagement");

            migrationBuilder.DropIndex(
                name: "IX_ProjectManagement_UserId",
                table: "ProjectManagement");

            migrationBuilder.DropIndex(
                name: "IX_ProjectManagement_WorkId",
                table: "ProjectManagement");

            migrationBuilder.DropIndex(
                name: "IX_Logs_UserID",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_WorkID",
                table: "Logs");
        }
    }
}
