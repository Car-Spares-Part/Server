using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntitesRelatedProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_role",
                schema: "main",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "store_id",
                schema: "main",
                table: "customer_address",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "main",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    part_id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantities = table.Column<int>(type: "integer", nullable: false),
                    total_price = table.Column<decimal>(type: "numeric(12,3)", nullable: false),
                    order_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    order_status = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pricing",
                schema: "main",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<decimal>(type: "numeric(12,3)", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    spare_part_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pricing", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "spare_parts",
                schema: "main",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    model = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    made_in = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    is_suspended = table.Column<bool>(type: "boolean", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_spare_parts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                schema: "main",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rate = table.Column<int>(type: "integer", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stores", x => x.id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_customer_address_stores_store_id",
                schema: "main",
                table: "customer_address");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "main");

            migrationBuilder.DropTable(
                name: "pricing",
                schema: "main");

            migrationBuilder.DropTable(
                name: "spare_parts",
                schema: "main");

            migrationBuilder.DropTable(
                name: "stores",
                schema: "main");

            migrationBuilder.DropIndex(
                name: "ix_customer_address_store_id",
                schema: "main",
                table: "customer_address");

            migrationBuilder.DropColumn(
                name: "user_role",
                schema: "main",
                table: "user");

            migrationBuilder.DropColumn(
                name: "store_id",
                schema: "main",
                table: "customer_address");
        }
    }
}