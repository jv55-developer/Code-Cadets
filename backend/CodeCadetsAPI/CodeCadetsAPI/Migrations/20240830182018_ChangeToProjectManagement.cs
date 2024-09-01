using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCadetsAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToProjectManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectManagement_Works_WorkId",
                table: "ProjectManagement");

            migrationBuilder.RenameColumn(
                name: "WorkId",
                table: "ProjectManagement",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectManagement_WorkId",
                table: "ProjectManagement",
                newName: "IX_ProjectManagement_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectManagement_Projects_ProjectId",
                table: "ProjectManagement",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectManagement_Projects_ProjectId",
                table: "ProjectManagement");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectManagement",
                newName: "WorkId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectManagement_ProjectId",
                table: "ProjectManagement",
                newName: "IX_ProjectManagement_WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectManagement_Works_WorkId",
                table: "ProjectManagement",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
