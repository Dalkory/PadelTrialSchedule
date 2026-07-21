using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PadelTrialSchedule.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "coaches",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    short_bio = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: false),
                    accent_color = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_coaches", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clubs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    city_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    address = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clubs", x => x.id);
                    table.ForeignKey(
                        name: "fk_clubs_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trial_sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    coach_id = table.Column<Guid>(type: "uuid", nullable: false),
                    club_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    type = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    level = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    starts_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    duration_minutes = table.Column<int>(type: "integer", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    booked_spots = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trial_sessions", x => x.id);
                    table.ForeignKey(
                        name: "fk_trial_sessions_clubs_club_id",
                        column: x => x.club_id,
                        principalTable: "clubs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_trial_sessions_coaches_coach_id",
                        column: x => x.coach_id,
                        principalTable: "coaches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cities_name",
                table: "cities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_clubs_city_id_name",
                table: "clubs",
                columns: new[] { "city_id", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_coaches_full_name",
                table: "coaches",
                column: "full_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_trial_sessions_club_id_starts_at",
                table: "trial_sessions",
                columns: new[] { "club_id", "starts_at" });

            migrationBuilder.CreateIndex(
                name: "ix_trial_sessions_coach_id_starts_at",
                table: "trial_sessions",
                columns: new[] { "coach_id", "starts_at" });

            migrationBuilder.CreateIndex(
                name: "ix_trial_sessions_starts_at",
                table: "trial_sessions",
                column: "starts_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trial_sessions");

            migrationBuilder.DropTable(
                name: "clubs");

            migrationBuilder.DropTable(
                name: "coaches");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
