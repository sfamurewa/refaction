namespace refactor_me.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforeignkeybetweenproductandproductoption : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.ProductOption", "ProductId", "dbo.Product", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOption", "ProductId", "dbo.Product");
        }
    }
}
