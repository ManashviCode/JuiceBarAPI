using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuiceBarAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cutomers",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cutomers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodItemId);
                });

            migrationBuilder.CreateTable(
                name: "OrderMaster",
                columns: table => new
                {
                    OrderMasterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerId1 = table.Column<long>(type: "bigint", nullable: false),
                    PMethod = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    GTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMaster", x => x.OrderMasterId);
                    table.ForeignKey(
                        name: "FK_OrderMaster_Cutomers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Cutomers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderMasterId = table.Column<long>(type: "bigint", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    FoodItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "FoodItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_OrderMaster_OrderMasterId",
                        column: x => x.OrderMasterId,
                        principalTable: "OrderMaster",
                        principalColumn: "OrderMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_FoodItemId",
                table: "OrderDetail",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderMasterId",
                table: "OrderDetail",
                column: "OrderMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMaster_CustomerId1",
                table: "OrderMaster",
                column: "CustomerId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "OrderMaster");

            migrationBuilder.DropTable(
                name: "Cutomers");
        }
    }
}
