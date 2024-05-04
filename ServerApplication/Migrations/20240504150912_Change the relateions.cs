using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerApplication.Migrations
{
    /// <inheritdoc />
    public partial class Changetherelateions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_customer_address_stores_store_id",
                schema: "main",
                table: "customer_address");

            migrationBuilder.DropIndex(
                name: "ix_customer_address_store_id",
                schema: "main",
                table: "customer_address");

            migrationBuilder.AddColumn<bool>(
                name: "is_accepted",
                schema: "main",
                table: "stores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "ix_customer_address_store_id",
                schema: "main",
                table: "customer_address",
                column: "store_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_customer_address_stores_store_id",
                schema: "main",
                table: "customer_address",
                column: "store_id",
                principalSchema: "main",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_customer_address_stores_store_id",
                schema: "main",
                table: "customer_address");

            migrationBuilder.DropIndex(
                name: "ix_customer_address_store_id",
                schema: "main",
                table: "customer_address");

            migrationBuilder.DropColumn(
                name: "is_accepted",
                schema: "main",
                table: "stores");

            migrationBuilder.CreateIndex(
                name: "ix_customer_address_store_id",
                schema: "main",
                table: "customer_address",
                column: "store_id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_address_stores_store_id",
                schema: "main",
                table: "customer_address",
                column: "store_id",
                principalSchema: "main",
                principalTable: "stores",
                principalColumn: "id");
        }
    }
}
