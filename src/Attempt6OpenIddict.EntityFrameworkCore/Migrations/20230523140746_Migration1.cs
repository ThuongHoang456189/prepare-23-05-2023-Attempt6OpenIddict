using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attempt6OpenIddict.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebsiteLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConferenceAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasDomainConflictConfirmed = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_ConferenceAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConferenceAccounts_AbpUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConferenceAccounts_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaperStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReviewsVisibleToAuthor = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_PaperStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaperStatuses_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmissionInstruction = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    SubmissionSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConflictSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CameraReadySubmissionSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectAreaRelevanceCoefficients = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceAccounts_AccountId",
                table: "ConferenceAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceAccounts_ConferenceId",
                table: "ConferenceAccounts",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperStatuses_ConferenceId",
                table: "PaperStatuses",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_ConferenceId",
                table: "Tracks",
                column: "ConferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConferenceAccounts");

            migrationBuilder.DropTable(
                name: "PaperStatuses");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Conferences");
        }
    }
}
