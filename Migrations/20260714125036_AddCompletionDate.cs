using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletionDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "ResearchProjects",
                newName: "CompletionDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompletionDate",
                table: "ResearchProjects",
                newName: "EndDate");
        }
    }
}
