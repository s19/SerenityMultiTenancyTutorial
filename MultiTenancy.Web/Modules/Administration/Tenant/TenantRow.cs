using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace MultiTenancy.Administration
{
    //[ConnectionKey("Default"), Module("Administration"), TableName("[dbo].[Tenants]")]
    //[DisplayName("Tenant"), InstanceName("Tenant")]
    //[ReadPermission("Administration:General")]
    //[ModifyPermission("Administration:General")]

    [ConnectionKey("Default"), DisplayName("Tenant"),
        InstanceName("Tenant"), TwoLevelCached]
    [ReadPermission(PermissionKeys.Tenant)]
    [ModifyPermission(PermissionKeys.Tenant)]
    [LookupScript("Administration.Tenant")]
    public sealed class TenantRow : Row<TenantRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Tenant Id"), Identity, IdProperty]
        public int? TenantId
        {
            get => fields.TenantId[this];
            set => fields.TenantId[this] = value;
        }

        [DisplayName("Tenant Name"), Size(100), NotNull, QuickSearch, NameProperty]
        public string TenantName
        {
            get => fields.TenantName[this];
            set => fields.TenantName[this] = value;
        }

        public TenantRow()
            : base()
        {
        }

        public TenantRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
