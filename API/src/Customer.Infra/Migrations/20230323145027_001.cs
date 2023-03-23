using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer.Infra.Migrations
{
    /// <inheritdoc />
    public partial class _001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(1000)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(1000)", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Address = table.Column<string>(type: "varchar(1000)", nullable: false),
                    State = table.Column<string>(type: "varchar(1000)", nullable: false),
                    City = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
