using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class bookconfirm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "BookingConfirmation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BookingConfirmation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookingConfirmation_EventId",
                table: "BookingConfirmation",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingConfirmation_UserId",
                table: "BookingConfirmation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingConfirmation_Event_EventId",
                table: "BookingConfirmation",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingConfirmation_Users_UserId",
                table: "BookingConfirmation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingConfirmation_Event_EventId",
                table: "BookingConfirmation");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingConfirmation_Users_UserId",
                table: "BookingConfirmation");

            migrationBuilder.DropIndex(
                name: "IX_BookingConfirmation_EventId",
                table: "BookingConfirmation");

            migrationBuilder.DropIndex(
                name: "IX_BookingConfirmation_UserId",
                table: "BookingConfirmation");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "BookingConfirmation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookingConfirmation");
        }
    }
}
