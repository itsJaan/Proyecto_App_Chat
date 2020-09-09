using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    theme = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    message = table.Column<string>(nullable: true),
                    user = table.Column<string>(nullable: true),
                    channelName = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    username = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
