using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Run4Cause.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "editions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    location = table.Column<string>(type: "text", nullable: true),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true),
                    headline = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_editions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "runs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_runs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    total_distance_covered = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "waypoints",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_waypoints", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "edition_run",
                columns: table => new
                {
                    editions_id = table.Column<int>(type: "integer", nullable: false),
                    runs_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_edition_run", x => new { x.editions_id, x.runs_id });
                    table.ForeignKey(
                        name: "fk_edition_run_editions_editions_id",
                        column: x => x.editions_id,
                        principalTable: "editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_edition_run_runs_runs_id",
                        column: x => x.runs_id,
                        principalTable: "runs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    register = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    run_id = table.Column<int>(type: "integer", nullable: false),
                    edition_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_entries", x => x.id);
                    table.ForeignKey(
                        name: "fk_entries_editions_edition_id",
                        column: x => x.edition_id,
                        principalTable: "editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_entries_runs_run_id",
                        column: x => x.run_id,
                        principalTable: "runs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_entries_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sponsorships",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    amount_per_kilometer = table.Column<float>(type: "real", nullable: false),
                    sponsor_id = table.Column<int>(type: "integer", nullable: true),
                    performer_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sponsorships", x => x.id);
                    table.ForeignKey(
                        name: "fk_sponsorships_users_performer_id",
                        column: x => x.performer_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_sponsorships_users_sponsor_id",
                        column: x => x.sponsor_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "run_waypoints",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    instant = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    run_id = table.Column<int>(type: "integer", nullable: false),
                    waypoint_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_run_waypoints", x => x.id);
                    table.ForeignKey(
                        name: "fk_run_waypoints_runs_run_id",
                        column: x => x.run_id,
                        principalTable: "runs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_run_waypoints_waypoints_waypoint_id",
                        column: x => x.waypoint_id,
                        principalTable: "waypoints",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trackings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    instant = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    waypoint_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trackings", x => x.id);
                    table.ForeignKey(
                        name: "fk_trackings_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trackings_waypoints_waypoint_id",
                        column: x => x.waypoint_id,
                        principalTable: "waypoints",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_edition_run_runs_id",
                table: "edition_run",
                column: "runs_id");

            migrationBuilder.CreateIndex(
                name: "ix_entries_edition_id",
                table: "entries",
                column: "edition_id");

            migrationBuilder.CreateIndex(
                name: "ix_entries_run_id",
                table: "entries",
                column: "run_id");

            migrationBuilder.CreateIndex(
                name: "ix_entries_user_id",
                table: "entries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_run_waypoints_run_id",
                table: "run_waypoints",
                column: "run_id");

            migrationBuilder.CreateIndex(
                name: "ix_run_waypoints_waypoint_id",
                table: "run_waypoints",
                column: "waypoint_id");

            migrationBuilder.CreateIndex(
                name: "ix_sponsorships_performer_id",
                table: "sponsorships",
                column: "performer_id");

            migrationBuilder.CreateIndex(
                name: "ix_sponsorships_sponsor_id",
                table: "sponsorships",
                column: "sponsor_id");

            migrationBuilder.CreateIndex(
                name: "ix_trackings_user_id",
                table: "trackings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_trackings_waypoint_id",
                table: "trackings",
                column: "waypoint_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "edition_run");

            migrationBuilder.DropTable(
                name: "entries");

            migrationBuilder.DropTable(
                name: "run_waypoints");

            migrationBuilder.DropTable(
                name: "sponsorships");

            migrationBuilder.DropTable(
                name: "trackings");

            migrationBuilder.DropTable(
                name: "editions");

            migrationBuilder.DropTable(
                name: "runs");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "waypoints");
        }
    }
}
