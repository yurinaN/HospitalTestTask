using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hopital.DataLayer.Migrations
{
    public partial class RenameLocalDoctorToDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "local_doctors");

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cabinet_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    specialization_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    health_locality_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doctors", x => x.id);
                    table.ForeignKey(
                        name: "fk_doctors_cabinets_cabinet_id",
                        column: x => x.cabinet_id,
                        principalTable: "cabinets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doctors_health_localities_health_locality_id",
                        column: x => x.health_locality_id,
                        principalTable: "health_localities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_doctors_specializations_specialization_id",
                        column: x => x.specialization_id,
                        principalTable: "specializations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_doctors_cabinet_id",
                table: "doctors",
                column: "cabinet_id");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_health_locality_id",
                table: "doctors",
                column: "health_locality_id");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_specialization_id",
                table: "doctors",
                column: "specialization_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.CreateTable(
                name: "local_doctors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cabinet_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    health_locality_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    specialization_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
        }
    }
}
