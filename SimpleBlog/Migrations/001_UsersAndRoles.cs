﻿using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SimpleBlog.Migrations
{
    [Migration(2)]
    public class _001_UsersAndRoles : Migration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("username").AsString(128)
                .WithColumn("email").AsCustom("VARCHAR(256)")
                .WithColumn("password_hash").AsString(128);

            Create.Table("roles")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(128);

            Create.Table("role_users")
                .WithColumn("user_id").AsInt32().ForeignKey("users", "id").OnDelete(Rule.Cascade)
                .WithColumn("role_id").AsInt32().ForeignKey("roles", "id").OnDelete(Rule.Cascade);

        }

        public override void Down()
        {
            Delete.Table("roles_users"); //must be first to not throw an exception to the following deletes
            Delete.Table("users");
            Delete.Table("roles");
        }

    }
}