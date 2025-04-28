using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace informatic_asp_mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ADM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADM_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADM_PERMISSION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADM_PASS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ADM_ID);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    AD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AD_TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AD_DESCRIB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AD_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DOC_ID = table.Column<int>(type: "int", nullable: false),
                    TARGET_YEAR = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.AD_ID);
                });

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    CLS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTENDANCE_FILE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.CLS_ID);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DOC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOC_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOC_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOC_DEPT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NUM_PROJECT = table.Column<int>(type: "int", nullable: true),
                    ADMIN_POSI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOC_PASS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DOC_ID);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    LEC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LEC_FILE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LEC_TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LEC_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SUB_ID = table.Column<int>(type: "int", nullable: false),
                    LEC_NOTE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LEC_DATE = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.LEC_ID);
                });

            migrationBuilder.CreateTable(
                name: "ObjectionOrders",
                columns: table => new
                {
                    OBJ_ORDER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STU_ID = table.Column<int>(type: "int", nullable: false),
                    SUB_ID = table.Column<int>(type: "int", nullable: false),
                    ORDER_REASON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBJ_ORDER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DEG_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBJECTION_RESAULT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADM_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectionOrders", x => x.OBJ_ORDER_ID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PST_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PST_TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PST_DESCRIB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PST_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DOC_ID = table.Column<int>(type: "int", nullable: false),
                    STU_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PST_ID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    PRO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRO_TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRO_DESCRIB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRO_TOOL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRO_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOC_ID = table.Column<int>(type: "int", nullable: false),
                    PRO_DOCUMENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRO_STATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EXEC_YEAR = table.Column<int>(type: "int", nullable: true),
                    PRO_DEG = table.Column<double>(type: "float", nullable: true),
                    ADM_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.PRO_ID);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QU_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QU_TEXT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ANSR_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ANSR_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ANSR_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ANSR_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RIGHT_ANSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SUB_ID = table.Column<int>(type: "int", nullable: false),
                    DOC_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QU_ID);
                });

            migrationBuilder.CreateTable(
                name: "RepracOrders",
                columns: table => new
                {
                    REPRAC_ORDER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STU_ID = table.Column<int>(type: "int", nullable: false),
                    SUB_ID = table.Column<int>(type: "int", nullable: false),
                    RE_ORDER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RE_ORDER_RESON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ORDER_STATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADM_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepracOrders", x => x.REPRAC_ORDER_ID);
                });

            migrationBuilder.CreateTable(
                name: "Stu_Sub",
                columns: table => new
                {
                    STU_SUB_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STU_ID = table.Column<int>(type: "int", nullable: false),
                    SUB_ID = table.Column<int>(type: "int", nullable: false),
                    PRACTICE_DEG = table.Column<double>(type: "float", nullable: true),
                    THEORIC_DEG = table.Column<double>(type: "float", nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stu_Sub", x => x.STU_SUB_ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    STU_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STU_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STU_FTHR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STU_MTHR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STU_NICK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STU_BRTH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JOIN_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STU_GENDER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COMPAR_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NATIONALITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BAC_AVG = table.Column<double>(type: "float", nullable: false),
                    STU_PASS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STU_STATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STU_YEAR = table.Column<int>(type: "int", nullable: false),
                    CLS_ID = table.Column<int>(type: "int", nullable: false),
                    NATIONAL_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.STU_ID);
                });

            migrationBuilder.CreateTable(
                name: "StuPros",
                columns: table => new
                {
                    STU_PRO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STU_ID = table.Column<int>(type: "int", nullable: false),
                    PRO_ID = table.Column<int>(type: "int", nullable: false),
                    STU_PRO_STATE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StuPros", x => x.STU_PRO_ID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SUB_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SUB_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SUB_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOC_ID = table.Column<int>(type: "int", nullable: false),
                    ACAD_DESCRIB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COURSE_EXAMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SUB_YEAR = table.Column<int>(type: "int", nullable: true),
                    SUB_SEMESTER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EXAM_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SUB_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "ObjectionOrders");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "RepracOrders");

            migrationBuilder.DropTable(
                name: "Stu_Sub");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StuPros");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
