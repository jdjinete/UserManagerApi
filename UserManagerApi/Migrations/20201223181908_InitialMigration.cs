using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagerApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<byte[]>(type: "binary(64)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Phone = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Age = table.Column<decimal>(type: "numeric(3,0)", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
