using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attempt6OpenIddict.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConferenceRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsPC = table.Column<bool>(type: "bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incumbents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConferenceAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConferenceRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incumbents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incumbents_ConferenceAccounts_ConferenceAccountId",
                        column: x => x.ConferenceAccountId,
                        principalTable: "ConferenceAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incumbents_ConferenceRoles_ConferenceRoleId",
                        column: x => x.ConferenceRoleId,
                        principalTable: "ConferenceRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incumbents_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incumbents_ConferenceAccountId",
                table: "Incumbents",
                column: "ConferenceAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Incumbents_ConferenceRoleId",
                table: "Incumbents",
                column: "ConferenceRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Incumbents_TrackId",
                table: "Incumbents",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incumbents");

            migrationBuilder.DropTable(
                name: "ConferenceRoles");
        }
    }
}
