using Microsoft.EntityFrameworkCore.Migrations;

namespace MMO.Data.Migrations
{
    public partial class mmo_default_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimpleValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value1 = table.Column<string>(nullable: true),
                    Value2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clan_User_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Class = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    Mana = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    ClanId = table.Column<int>(nullable: true),
                    PosX = table.Column<int>(nullable: false),
                    PosY = table.Column<int>(nullable: false),
                    PosZ = table.Column<int>(nullable: false),
                    RotationYaw = table.Column<float>(nullable: false),
                    EquipHead = table.Column<string>(nullable: true),
                    EquipChest = table.Column<string>(nullable: true),
                    EquipHands = table.Column<string>(nullable: true),
                    EquipLegs = table.Column<string>(nullable: true),
                    EquipFeet = table.Column<string>(nullable: true),
                    Hotbar0 = table.Column<string>(nullable: true),
                    Hotbar1 = table.Column<string>(nullable: true),
                    Hotbar2 = table.Column<string>(nullable: true),
                    Hotbar3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Clan_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActiveLogin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    SessionKey = table.Column<string>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveLogin_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActiveLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(nullable: true),
                    Slot = table.Column<int>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Ammount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(nullable: true),
                    QuestName = table.Column<string>(nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    Task1 = table.Column<int>(nullable: false),
                    Task2 = table.Column<int>(nullable: false),
                    Task3 = table.Column<int>(nullable: false),
                    Task4 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quest_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveLogin_CharacterId",
                table: "ActiveLogin",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveLogin_UserId",
                table: "ActiveLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_ClanId",
                table: "Character",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clan_LeaderId",
                table: "Clan",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CharacterId",
                table: "Inventory",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Quest_CharacterId",
                table: "Quest",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveLogin");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Quest");

            migrationBuilder.DropTable(
                name: "SimpleValues");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
