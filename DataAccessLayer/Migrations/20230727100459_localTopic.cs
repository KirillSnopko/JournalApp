using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class localTopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonTopic");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocalTopic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LessonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalTopic_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_TopicId",
                table: "Lesson",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalTopic_LessonId",
                table: "LocalTopic",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Topic_TopicId",
                table: "Lesson",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Topic_TopicId",
                table: "Lesson");

            migrationBuilder.DropTable(
                name: "LocalTopic");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_TopicId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Lesson");

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
    }
}
