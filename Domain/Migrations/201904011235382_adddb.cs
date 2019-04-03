namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Slary = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.LoaiThanhVien_Quyen",
                c => new
                    {
                        MaLoaiTV = c.Int(nullable: false),
                        MaQuyen = c.Int(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => new { t.MaLoaiTV, t.MaQuyen })
                .ForeignKey("dbo.LoaiThanhViens", t => t.MaLoaiTV, cascadeDelete: true)
                .ForeignKey("dbo.Quyens", t => t.MaQuyen, cascadeDelete: true)
                .Index(t => t.MaLoaiTV)
                .Index(t => t.MaQuyen);
            
            CreateTable(
                "dbo.LoaiThanhViens",
                c => new
                    {
                        MaLoaiTV = c.Int(nullable: false, identity: true),
                        TenLoaiTV = c.String(),
                        UuDai = c.String(),
                    })
                .PrimaryKey(t => t.MaLoaiTV);
            
            CreateTable(
                "dbo.ThanhViens",
                c => new
                    {
                        MaThanhVien = c.Int(nullable: false, identity: true),
                        TaiKhoan = c.String(),
                        MatKhau = c.String(),
                        MaLoaiTV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaThanhVien)
                .ForeignKey("dbo.LoaiThanhViens", t => t.MaLoaiTV, cascadeDelete: true)
                .Index(t => t.MaLoaiTV);
            
            CreateTable(
                "dbo.Quyens",
                c => new
                    {
                        MaQuyen = c.Int(nullable: false, identity: true),
                        TenQuyen = c.String(),
                    })
                .PrimaryKey(t => t.MaQuyen);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoaiThanhVien_Quyen", "MaQuyen", "dbo.Quyens");
            DropForeignKey("dbo.LoaiThanhVien_Quyen", "MaLoaiTV", "dbo.LoaiThanhViens");
            DropForeignKey("dbo.ThanhViens", "MaLoaiTV", "dbo.LoaiThanhViens");
            DropIndex("dbo.ThanhViens", new[] { "MaLoaiTV" });
            DropIndex("dbo.LoaiThanhVien_Quyen", new[] { "MaQuyen" });
            DropIndex("dbo.LoaiThanhVien_Quyen", new[] { "MaLoaiTV" });
            DropTable("dbo.Quyens");
            DropTable("dbo.ThanhViens");
            DropTable("dbo.LoaiThanhViens");
            DropTable("dbo.LoaiThanhVien_Quyen");
            DropTable("dbo.Employees");
        }
    }
}
