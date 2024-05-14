using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 219, 165, 70, 173, 100, 168, 204, 154, 227, 175, 156, 110, 201, 207, 152, 67, 0, 116, 80, 12, 143, 70, 116, 211, 213, 31, 159, 224, 150, 248, 139, 138, 108, 60, 122, 28, 144, 23, 224, 102, 186, 153, 8, 109, 136, 232, 179, 135, 206, 16, 60, 84, 28, 94, 76, 39, 106, 135, 197, 7, 166, 137, 62, 57 }, new byte[] { 17, 34, 159, 1, 227, 147, 157, 90, 75, 28, 129, 208, 145, 57, 99, 174, 24, 148, 147, 26, 227, 119, 190, 159, 114, 128, 5, 109, 199, 212, 138, 72, 254, 91, 102, 150, 245, 19, 17, 71, 67, 73, 84, 120, 250, 120, 131, 21, 238, 65, 98, 6, 181, 129, 9, 245, 47, 21, 73, 18, 162, 87, 78, 112, 7, 91, 32, 220, 193, 201, 165, 51, 187, 111, 154, 54, 238, 184, 152, 147, 181, 148, 117, 218, 17, 251, 24, 75, 154, 51, 0, 109, 218, 186, 78, 48, 19, 241, 205, 66, 134, 87, 92, 21, 23, 41, 20, 69, 145, 174, 177, 147, 60, 130, 46, 210, 150, 42, 114, 204, 82, 147, 30, 250, 97, 60, 172, 72 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 115, 30, 231, 33, 74, 10, 17, 190, 207, 118, 180, 174, 65, 98, 199, 200, 249, 232, 24, 217, 165, 88, 53, 163, 128, 2, 175, 193, 196, 143, 63, 111, 111, 100, 11, 191, 181, 39, 163, 161, 154, 160, 60, 33, 161, 33, 124, 109, 46, 104, 130, 104, 108, 167, 59, 191, 103, 148, 40, 224, 29, 181, 172, 183 }, new byte[] { 51, 70, 82, 158, 239, 72, 26, 85, 225, 219, 138, 206, 72, 181, 192, 202, 39, 111, 180, 76, 107, 150, 184, 136, 155, 255, 165, 170, 78, 0, 47, 199, 174, 198, 17, 194, 104, 44, 83, 211, 209, 118, 44, 247, 243, 237, 34, 80, 138, 66, 148, 183, 62, 20, 137, 111, 203, 211, 80, 100, 158, 199, 201, 173, 130, 229, 234, 92, 102, 7, 57, 53, 185, 249, 68, 53, 187, 20, 251, 223, 47, 180, 138, 20, 238, 191, 225, 67, 187, 98, 32, 164, 217, 227, 72, 81, 24, 136, 106, 178, 37, 34, 165, 155, 224, 156, 91, 220, 90, 59, 56, 59, 71, 202, 123, 85, 75, 13, 32, 11, 28, 9, 83, 230, 137, 47, 147, 253 } });
        }
    }
}
