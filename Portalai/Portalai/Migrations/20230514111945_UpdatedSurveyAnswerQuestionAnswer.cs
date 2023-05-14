using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class UpdatedSurveyAnswerQuestionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestionOptions_QuestionAnswers_QuestionAnswerId",
                table: "SurveyQuestionOptions");

            migrationBuilder.DropIndex(
                name: "IX_SurveyQuestionOptions_QuestionAnswerId",
                table: "SurveyQuestionOptions");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerId",
                table: "SurveyQuestionOptions");

            migrationBuilder.AddColumn<int>(
                name: "SurveyAnswerId",
                table: "QuestionAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuestionAnswerSurveyQuestionOption",
                columns: table => new
                {
                    QuestionAnswersId = table.Column<int>(type: "int", nullable: false),
                    SurveyQuestionOptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswerSurveyQuestionOption", x => new { x.QuestionAnswersId, x.SurveyQuestionOptionsId });
                    table.ForeignKey(
                        name: "FK_QuestionAnswerSurveyQuestionOption_QuestionAnswers_QuestionAnswersId",
                        column: x => x.QuestionAnswersId,
                        principalTable: "QuestionAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswerSurveyQuestionOption_SurveyQuestionOptions_SurveyQuestionOptionsId",
                        column: x => x.SurveyQuestionOptionsId,
                        principalTable: "SurveyQuestionOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_SurveyAnswerId",
                table: "QuestionAnswers",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerSurveyQuestionOption_SurveyQuestionOptionsId",
                table: "QuestionAnswerSurveyQuestionOption",
                column: "SurveyQuestionOptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_SurveyAnswers_SurveyAnswerId",
                table: "QuestionAnswers",
                column: "SurveyAnswerId",
                principalTable: "SurveyAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_SurveyAnswers_SurveyAnswerId",
                table: "QuestionAnswers");

            migrationBuilder.DropTable(
                name: "QuestionAnswerSurveyQuestionOption");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_SurveyAnswerId",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "SurveyAnswerId",
                table: "QuestionAnswers");

            migrationBuilder.AddColumn<int>(
                name: "QuestionAnswerId",
                table: "SurveyQuestionOptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionOptions_QuestionAnswerId",
                table: "SurveyQuestionOptions",
                column: "QuestionAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionOptions_QuestionAnswers_QuestionAnswerId",
                table: "SurveyQuestionOptions",
                column: "QuestionAnswerId",
                principalTable: "QuestionAnswers",
                principalColumn: "Id");
        }
    }
}
