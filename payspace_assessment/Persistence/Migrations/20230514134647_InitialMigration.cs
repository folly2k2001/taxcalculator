using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculatedTaxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    AnnualIncome = table.Column<double>(type: "float", nullable: false),
                    TaxRate = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatedTaxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostalCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCalculationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCalculationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostalCode_TaxCalculationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCodeId = table.Column<int>(type: "int", nullable: false),
                    TaxCalculationTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCode_TaxCalculationType", x => new { x.Id, x.TaxCalculationTypeId, x.PostalCodeId });
                    table.ForeignKey(
                        name: "FK_PostalCode_TaxCalculationType_PostalCodes_PostalCodeId",
                        column: x => x.PostalCodeId,
                        principalTable: "PostalCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostalCode_TaxCalculationType_TaxCalculationType_TaxCalculationTypeId",
                        column: x => x.TaxCalculationTypeId,
                        principalTable: "TaxCalculationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    From = table.Column<double>(type: "float", nullable: false),
                    To = table.Column<double>(type: "float", nullable: false),
                    FlatValue = table.Column<double>(type: "float", nullable: false),
                    isFlate = table.Column<bool>(type: "bit", nullable: false),
                    CalculationTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRates_TaxCalculationType_CalculationTypeId",
                        column: x => x.CalculationTypeId,
                        principalTable: "TaxCalculationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PostalCodes",
                columns: new[] { "Id", "Code", "DateCreated", "DateModified" },
                values: new object[,]
                {
                    { 1, "7441", new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(9768), new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(9772) },
                    { 2, "A100", new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(9774), new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(9774) },
                    { 3, "7000", new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(9775), new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(9776) },
                    { 4, "1000", new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(9777), new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(9777) }
                });

            migrationBuilder.InsertData(
                table: "TaxCalculationType",
                columns: new[] { "Id", "DateCreated", "DateModified", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(1015), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(1017), "Progressive" },
                    { 2, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(1019), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(1020), "Flat Value" },
                    { 3, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(1021), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(1021), "Flat Rate" }
                });

            migrationBuilder.InsertData(
                table: "PostalCode_TaxCalculationType",
                columns: new[] { "Id", "PostalCodeId", "TaxCalculationTypeId", "DateCreated", "DateModified" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(4296), new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(4312) },
                    { 2, 2, 2, new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(4314), new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(4314) },
                    { 3, 3, 3, new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(4315), new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(4316) },
                    { 4, 4, 1, new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(4317), new DateTime(2023, 5, 14, 15, 46, 47, 855, DateTimeKind.Local).AddTicks(4318) }
                });

            migrationBuilder.InsertData(
                table: "TaxRates",
                columns: new[] { "Id", "CalculationTypeId", "DateCreated", "DateModified", "FlatValue", "From", "Rate", "To", "isFlate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2623), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2627), 0.0, 0.0, 0.10000000000000001, 8350.0, false },
                    { 2, 1, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2629), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2630), 0.0, 8351.0, 0.14999999999999999, 33950.0, false },
                    { 3, 1, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2656), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2656), 0.0, 33951.0, 0.25, 82250.0, false },
                    { 4, 1, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2660), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2661), 0.0, 82251.0, 0.28000000000000003, 171550.0, false },
                    { 5, 1, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2663), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2664), 0.0, 171551.0, 0.33000000000000002, 372950.0, false },
                    { 6, 1, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2666), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2667), 0.0, 372951.0, 0.34999999999999998, 1.7976931348623157E+308, false },
                    { 7, 2, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2670), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2670), 10000.0, 200000.0, 0.0, 1.7976931348623157E+308, true },
                    { 8, 2, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2674), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2674), 0.0, 0.0, 0.050000000000000003, 199999.0, true },
                    { 9, 3, new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2676), new DateTime(2023, 5, 14, 15, 46, 47, 856, DateTimeKind.Local).AddTicks(2677), 0.0, 0.0, 0.17499999999999999, 0.0, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostalCode_TaxCalculationType_PostalCodeId",
                table: "PostalCode_TaxCalculationType",
                column: "PostalCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCode_TaxCalculationType_TaxCalculationTypeId",
                table: "PostalCode_TaxCalculationType",
                column: "TaxCalculationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRates_CalculationTypeId",
                table: "TaxRates",
                column: "CalculationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatedTaxes");

            migrationBuilder.DropTable(
                name: "PostalCode_TaxCalculationType");

            migrationBuilder.DropTable(
                name: "TaxRates");

            migrationBuilder.DropTable(
                name: "PostalCodes");

            migrationBuilder.DropTable(
                name: "TaxCalculationType");
        }
    }
}
