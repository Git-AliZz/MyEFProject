﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEFProject_DataAccess.Migrations
{
    public partial class InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categories Values('Category 1')");
            migrationBuilder.Sql("Insert into Categories Values('Category 2')");
            migrationBuilder.Sql("Insert into Categories Values('Category 3')");
            migrationBuilder.Sql("Insert into Categories Values('Category 4')");
            migrationBuilder.Sql("Insert into Categories Values('Category 5')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
