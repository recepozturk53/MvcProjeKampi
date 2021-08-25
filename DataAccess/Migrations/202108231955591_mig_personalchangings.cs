namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_personalchangings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personals", "Skill", c => c.String(maxLength: 20));
            AddColumn("dbo.Personals", "SkillPoint", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Skill2", c => c.String(maxLength: 20));
            AddColumn("dbo.Personals", "SkillPoint2", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Skill3", c => c.String(maxLength: 20));
            AddColumn("dbo.Personals", "SkillPoint3", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Skill4", c => c.String(maxLength: 20));
            AddColumn("dbo.Personals", "SkillPoint4", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Skill5", c => c.String(maxLength: 20));
            AddColumn("dbo.Personals", "SkillPoint5", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Skill6", c => c.String(maxLength: 20));
            AddColumn("dbo.Personals", "SkillPoint6", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Skill7", c => c.String(maxLength: 20));
            AddColumn("dbo.Personals", "SkillPoint7", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Skill8", c => c.String(maxLength: 20));
            AddColumn("dbo.Personals", "SkillPoint8", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Skill9", c => c.String(maxLength: 20));
            AddColumn("dbo.Personals", "SkillPoint9", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Skill10", c => c.String(maxLength: 20));
            AddColumn("dbo.Personals", "SkillPoint10", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Image", c => c.String(maxLength: 250));
            DropColumn("dbo.Personals", "Sikill1");
            DropColumn("dbo.Personals", "Sikill2");
            DropColumn("dbo.Personals", "Sikill3");
            DropColumn("dbo.Personals", "Sikill4");
            DropColumn("dbo.Personals", "Sikill5");
            DropColumn("dbo.Personals", "Sikill6");
            DropColumn("dbo.Personals", "Sikill7");
            DropColumn("dbo.Personals", "Sikill8");
            DropColumn("dbo.Personals", "Sikill9");
            DropColumn("dbo.Personals", "Sikill10");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personals", "Sikill10", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Sikill9", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Sikill8", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Sikill7", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Sikill6", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Sikill5", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Sikill4", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Sikill3", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Sikill2", c => c.Int(nullable: false));
            AddColumn("dbo.Personals", "Sikill1", c => c.Int(nullable: false));
            DropColumn("dbo.Personals", "Image");
            DropColumn("dbo.Personals", "SkillPoint10");
            DropColumn("dbo.Personals", "Skill10");
            DropColumn("dbo.Personals", "SkillPoint9");
            DropColumn("dbo.Personals", "Skill9");
            DropColumn("dbo.Personals", "SkillPoint8");
            DropColumn("dbo.Personals", "Skill8");
            DropColumn("dbo.Personals", "SkillPoint7");
            DropColumn("dbo.Personals", "Skill7");
            DropColumn("dbo.Personals", "SkillPoint6");
            DropColumn("dbo.Personals", "Skill6");
            DropColumn("dbo.Personals", "SkillPoint5");
            DropColumn("dbo.Personals", "Skill5");
            DropColumn("dbo.Personals", "SkillPoint4");
            DropColumn("dbo.Personals", "Skill4");
            DropColumn("dbo.Personals", "SkillPoint3");
            DropColumn("dbo.Personals", "Skill3");
            DropColumn("dbo.Personals", "SkillPoint2");
            DropColumn("dbo.Personals", "Skill2");
            DropColumn("dbo.Personals", "SkillPoint");
            DropColumn("dbo.Personals", "Skill");
        }
    }
}
