using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpGradEMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpeakerName",
                table: "Speakers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SessionTitle",
                table: "Sessions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionUrl",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_EventId",
                table: "Sessions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SpeakerId",
                table: "Sessions",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantEvents_EventId",
                table: "ParticipantEvents",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantEvents_Events_EventId",
                table: "ParticipantEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Events_EventId",
                table: "Sessions",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Speakers_SpeakerId",
                table: "Sessions",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantEvents_Events_EventId",
                table: "ParticipantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Events_EventId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Speakers_SpeakerId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_EventId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_SpeakerId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_ParticipantEvents_EventId",
                table: "ParticipantEvents");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SessionUrl",
                table: "Sessions");

            migrationBuilder.AlterColumn<string>(
                name: "SpeakerName",
                table: "Speakers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SessionTitle",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
