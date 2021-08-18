namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addtable_personal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        PersonalID = c.Int(nullable: false, identity: true),
                        PersonalName = c.String(maxLength: 50),
                        PersonalSurname = c.String(maxLength: 50),
                        PersonalJob = c.String(maxLength: 50),
                        Sikill1 = c.Int(nullable: false),
                        Sikill2 = c.Int(nullable: false),
                        Sikill3 = c.Int(nullable: false),
                        Sikill4 = c.Int(nullable: false),
                        Sikill5 = c.Int(nullable: false),
                        Sikill6 = c.Int(nullable: false),
                        Sikill7 = c.Int(nullable: false),
                        Sikill8 = c.Int(nullable: false),
                        Sikill9 = c.Int(nullable: false),
                        Sikill10 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonalID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personals");
        }
    }
}
