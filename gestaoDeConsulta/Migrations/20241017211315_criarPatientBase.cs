using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestaoDeConsulta.Migrations
{
    /// <inheritdoc />
    public partial class criarPatientBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                    table: "Patients",
                    columns: new[] { "Id", "Name", "Email", "DateOfBirth", "CPF", "Address", "Phone" },
                    values: new object[] { "84e72d2c-b1f9-41e0-a5ac-62b80f73ed14", "Vanderson Oliveira", "vanderson@gmail.com", "2001-06-25 14:30:00", "000.000.000-00", "Tv. Diana, 90", "85990909090" }
             );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
