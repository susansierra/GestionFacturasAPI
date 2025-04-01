using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Factura_FacturaId",
                table: "DetalleFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factura",
                table: "Factura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleFactura",
                table: "DetalleFactura");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFactura_FacturaId",
                table: "DetalleFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "FacturaId",
                table: "DetalleFactura");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Producto",
                newName: "Productos");

            migrationBuilder.RenameTable(
                name: "Factura",
                newName: "Facturas");

            migrationBuilder.RenameTable(
                name: "DetalleFactura",
                newName: "DetalleFacturas");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Clientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facturas",
                table: "Facturas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleFacturas",
                table: "DetalleFacturas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IdCliente",
                table: "Facturas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IdVendedor",
                table: "Facturas",
                column: "IdVendedor");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_IdFactura",
                table: "DetalleFacturas",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_IdProducto",
                table: "DetalleFacturas",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioId",
                table: "Clientes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Usuarios_UsuarioId",
                table: "Clientes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFacturas_Facturas_IdFactura",
                table: "DetalleFacturas",
                column: "IdFactura",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFacturas_Productos_IdProducto",
                table: "DetalleFacturas",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_IdCliente",
                table: "Facturas",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Usuarios_IdVendedor",
                table: "Facturas",
                column: "IdVendedor",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_UsuarioId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFacturas_Facturas_IdFactura",
                table: "DetalleFacturas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFacturas_Productos_IdProducto",
                table: "DetalleFacturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_IdCliente",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Usuarios_IdVendedor",
                table: "Facturas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facturas",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_IdCliente",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_IdVendedor",
                table: "Facturas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleFacturas",
                table: "DetalleFacturas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFacturas_IdFactura",
                table: "DetalleFacturas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFacturas_IdProducto",
                table: "DetalleFacturas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_UsuarioId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Producto");

            migrationBuilder.RenameTable(
                name: "Facturas",
                newName: "Factura");

            migrationBuilder.RenameTable(
                name: "DetalleFacturas",
                newName: "DetalleFactura");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "FacturaId",
                table: "DetalleFactura",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factura",
                table: "Factura",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleFactura",
                table: "DetalleFactura",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_FacturaId",
                table: "DetalleFactura",
                column: "FacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Factura_FacturaId",
                table: "DetalleFactura",
                column: "FacturaId",
                principalTable: "Factura",
                principalColumn: "Id");
        }
    }
}
