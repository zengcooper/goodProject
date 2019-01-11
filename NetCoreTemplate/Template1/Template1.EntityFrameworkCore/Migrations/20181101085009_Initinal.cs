using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template1.EntityFrameworkCore.Migrations
{
    public partial class Initinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Microservice",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    ServiceCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    SortNo = table.Column<int>(nullable: false),
                    ServiceAliasName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ServiceChineseName = table.Column<string>(type: "nvarchar(400)", nullable: true),
                    ServiceCategory = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Dependencies = table.Column<string>(type: "nvarchar(800)", nullable: true),
                    CodingLanguage = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ResponsibleTeam = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ProductOwner = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    TechniqueOwner = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ScrumMaster = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Developers = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ServiceConfluenceUrl = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    RepositoryName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    AzureResourceType = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microservice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDefinition",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    ServiceCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    SortNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDefinition", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Microservice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ServiceDefinition",
                schema: "dbo");
        }
    }
}
