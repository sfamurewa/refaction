namespace refactor_me.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdtheproductstructure : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.ProductOption",
            //    c => new
            //        {
            //            Id = c.Guid(nullable: false),
            //            ProductId = c.Guid(nullable: false),
            //            Name = c.String(),
            //            Description = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
            //    .Index(t => t.ProductId);

            //CreateTable(
            //    "dbo.Product",
            //    c => new
            //        {
            //            Id = c.Guid(nullable: false),
            //            Name = c.String(),
            //            Description = c.String(),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            DeliveryPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //.PrimaryKey(t => t.Id);
            DropForeignKey("dbo.ProductOption", "ProductId", "dbo.Product");
            //DropForeignKey()
            //AddForeignKey("dbo.ProductOption", "ProductId", "dbo.Product", cascadeDelete: true);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOption", "ProductId", "dbo.Product");
            //DropIndex("dbo.ProductOption", new[] { "ProductId" });
            //DropTable("dbo.Product");
            //DropTable("dbo.ProductOption");
            AddForeignKey("dbo.ProductOption", "ProductId", "dbo.Product", cascadeDelete: true);
        }
    }
}
