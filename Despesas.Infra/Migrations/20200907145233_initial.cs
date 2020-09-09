using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Despesas.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MembroFamiliar",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome_NomeSocial = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Nome_Sobrenome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email_Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ChaveDeAcesso = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembroFamiliar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FormaPagamento = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    PagamentoId = table.Column<Guid>(nullable: true),
                    TipoDepesa = table.Column<int>(nullable: false),
                    MembroFamiliarId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesa_MembroFamiliar_MembroFamiliarId",
                        column: x => x.MembroFamiliarId,
                        principalTable: "MembroFamiliar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Despesa_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_MembroFamiliarId",
                table: "Despesa",
                column: "MembroFamiliarId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_PagamentoId",
                table: "Despesa",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MembroFamiliar_ChaveDeAcesso",
                table: "MembroFamiliar",
                column: "ChaveDeAcesso");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_Id",
                table: "Pagamento",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesa");

            migrationBuilder.DropTable(
                name: "MembroFamiliar");

            migrationBuilder.DropTable(
                name: "Pagamento");
        }
    }
}
