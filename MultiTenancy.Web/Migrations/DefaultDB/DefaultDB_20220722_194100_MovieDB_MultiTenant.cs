using FluentMigrator;

namespace MultiTenancy.Migrations.DefaultDB
{
    [Migration(20220722194100)]
    public class DefaultDB_20220722_194100_MovieDB_MultiTenant : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Person").InSchema("mov")
                .AddColumn("TenantId").AsInt32()
                    .NotNullable().WithDefaultValue(1);

            Alter.Table("Genre").InSchema("mov")
                .AddColumn("TenantId").AsInt32()
                    .NotNullable().WithDefaultValue(1);

            Alter.Table("Movie").InSchema("mov")
                .AddColumn("TenantId").AsInt32()
                    .NotNullable().WithDefaultValue(1);
        }
    }
}
