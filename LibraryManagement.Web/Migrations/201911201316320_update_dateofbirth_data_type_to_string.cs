namespace LibraryManagement.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_dateofbirth_data_type_to_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DateOfBirth", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime());
        }
    }
}
