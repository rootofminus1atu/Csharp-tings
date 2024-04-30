namespace code_first_db_v4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_desc : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "Desc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Desc", c => c.String());
        }
    }
}
