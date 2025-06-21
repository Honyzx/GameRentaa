using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBank.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseYear = table.Column<int>(type: "INTEGER", nullable: false),
                    DailyRentalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalCopies = table.Column<int>(type: "INTEGER", nullable: false),
                    AvailableCopies = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Games_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlannedReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualReturnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    DepositPaid = table.Column<decimal>(type: "TEXT", nullable: false),
                    DepositReturned = table.Column<decimal>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_Rentals_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    FineID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    RentalID = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.FineID);
                    table.ForeignKey(
                        name: "FK_Fines_Rentals_RentalID",
                        column: x => x.RentalID,
                        principalTable: "Rentals",
                        principalColumn: "RentalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    RentalID = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentMethods = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentTypes = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionID = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Rentals_RentalID",
                        column: x => x.RentalID,
                        principalTable: "Rentals",
                        principalColumn: "RentalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalItems",
                columns: table => new
                {
                    RentalItemID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    RentalID = table.Column<int>(type: "INTEGER", nullable: false),
                    GameID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalItems", x => x.RentalItemID);
                    table.ForeignKey(
                        name: "FK_RentalItems_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalItems_Rentals_RentalID",
                        column: x => x.RentalID,
                        principalTable: "Rentals",
                        principalColumn: "RentalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fines_RentalID",
                table: "Fines",
                column: "RentalID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CategoryId",
                table: "Games",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RentalID",
                table: "Payments",
                column: "RentalID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalItems_GameID",
                table: "RentalItems",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalItems_RentalID",
                table: "RentalItems",
                column: "RentalID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserID",
                table: "Rentals",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RentalItems");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
