using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class topic_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Topic_TopicId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_TopicId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Lesson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_TopicId",
                table: "Lesson",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Topic_TopicId",
                table: "Lesson",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id");
        }
    }
}
