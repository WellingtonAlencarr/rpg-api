using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 80, 124, 105, 154, 38, 203, 134, 99, 5, 17, 172, 110, 156, 95, 197, 2, 67, 106, 0, 242, 130, 57, 213, 253, 77, 163, 57, 93, 45, 66, 36, 190, 19, 195, 6, 111, 174, 169, 12, 3, 8, 243, 158, 243, 117, 102, 19, 55, 126, 51, 214, 75, 84, 193, 122, 167, 93, 249, 93, 158, 96, 89, 37, 90 }, new byte[] { 59, 103, 130, 244, 244, 41, 222, 159, 61, 19, 192, 238, 92, 93, 164, 65, 201, 244, 71, 20, 7, 119, 34, 119, 76, 231, 222, 123, 12, 121, 47, 208, 88, 26, 61, 233, 75, 207, 133, 9, 171, 83, 168, 144, 255, 184, 101, 128, 3, 195, 203, 39, 206, 80, 65, 137, 124, 69, 160, 136, 227, 4, 190, 34, 27, 242, 191, 34, 6, 156, 27, 115, 9, 158, 13, 94, 123, 106, 220, 194, 165, 166, 137, 94, 251, 91, 215, 87, 188, 109, 147, 55, 205, 81, 146, 18, 101, 24, 12, 48, 105, 99, 97, 247, 2, 205, 169, 21, 33, 137, 131, 210, 171, 146, 150, 194, 229, 51, 6, 105, 176, 58, 152, 10, 138, 238, 151, 103 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 219, 165, 70, 173, 100, 168, 204, 154, 227, 175, 156, 110, 201, 207, 152, 67, 0, 116, 80, 12, 143, 70, 116, 211, 213, 31, 159, 224, 150, 248, 139, 138, 108, 60, 122, 28, 144, 23, 224, 102, 186, 153, 8, 109, 136, 232, 179, 135, 206, 16, 60, 84, 28, 94, 76, 39, 106, 135, 197, 7, 166, 137, 62, 57 }, new byte[] { 17, 34, 159, 1, 227, 147, 157, 90, 75, 28, 129, 208, 145, 57, 99, 174, 24, 148, 147, 26, 227, 119, 190, 159, 114, 128, 5, 109, 199, 212, 138, 72, 254, 91, 102, 150, 245, 19, 17, 71, 67, 73, 84, 120, 250, 120, 131, 21, 238, 65, 98, 6, 181, 129, 9, 245, 47, 21, 73, 18, 162, 87, 78, 112, 7, 91, 32, 220, 193, 201, 165, 51, 187, 111, 154, 54, 238, 184, 152, 147, 181, 148, 117, 218, 17, 251, 24, 75, 154, 51, 0, 109, 218, 186, 78, 48, 19, 241, 205, 66, 134, 87, 92, 21, 23, 41, 20, 69, 145, 174, 177, 147, 60, 130, 46, 210, 150, 42, 114, 204, 82, 147, 30, 250, 97, 60, 172, 72 } });
        }
    }
}
