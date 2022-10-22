using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hopital.DataLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cabinets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cabinets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "health_localities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_health_localities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "specializations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_specializations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    surmane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    health_locality_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patients", x => x.id);
                    table.ForeignKey(
                        name: "fk_patients_health_localities_health_locality_id",
                        column: x => x.health_locality_id,
                        principalTable: "health_localities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "local_doctors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cabinet_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    specialization_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    health_locality_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_local_doctors", x => x.id);
                    table.ForeignKey(
                        name: "fk_local_doctors_cabinets_cabinet_id",
                        column: x => x.cabinet_id,
                        principalTable: "cabinets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_local_doctors_health_localities_health_locality_id",
                        column: x => x.health_locality_id,
                        principalTable: "health_localities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_local_doctors_specializations_specialization_id",
                        column: x => x.specialization_id,
                        principalTable: "specializations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_local_doctors_cabinet_id",
                table: "local_doctors",
                column: "cabinet_id");

            migrationBuilder.CreateIndex(
                name: "ix_local_doctors_health_locality_id",
                table: "local_doctors",
                column: "health_locality_id");

            migrationBuilder.CreateIndex(
                name: "ix_local_doctors_specialization_id",
                table: "local_doctors",
                column: "specialization_id");

            migrationBuilder.CreateIndex(
                name: "ix_patients_health_locality_id",
                table: "patients",
                column: "health_locality_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "local_doctors");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "cabinets");

            migrationBuilder.DropTable(
                name: "specializations");

            migrationBuilder.DropTable(
                name: "health_localities");
        }
    }
}
