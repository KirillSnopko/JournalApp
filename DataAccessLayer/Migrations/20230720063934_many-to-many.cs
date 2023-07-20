using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class manytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Lesson_LessonId",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_LessonId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Topic");

            migrationBuilder.CreateTable(
                name: "LessonTopic",
                columns: table => new
                {
                    LessonsId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTopic", x => new { x.LessonsId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_LessonTopic_Lesson_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonTopic_Topic_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTopic_TopicsId",
                table: "LessonTopic",
                column: "TopicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonTopic");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Topic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topic_LessonId",
                table: "Topic",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Lesson_LessonId",
                table: "Topic",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id");
        }
    }
}
