using Serenity;
using Serenity.Data;
using Serenity.Services;
using System.Data;
using MyRow = MultiTenancy.Administration.Entities.RoleRow;


namespace MultiTenancy.Administration.Repositories
{
    public class RoleRepository : BaseRepository
    {
        public RoleRepository(IRequestContext context)
             : base(context)
        {
        }

        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler(Context).Process(uow, request, SaveRequestType.Create);
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler(Context).Process(uow, request, SaveRequestType.Update);
        }

        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyDeleteHandler(Context).Process(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler(Context).Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyListHandler(Context).Process(connection, request);
        }

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            public MySaveHandler(IRequestContext context)
                 : base(context)
            {
            }

            //protected override void SetInternalFields()
            //{
            //    base.SetInternalFields();

            //    if (IsCreate)
            //        Row.TenantId = User.GetTenantId();
            //}

            //protected override void ValidateRequest()
            //{
            //    base.ValidateRequest();

            //    if (IsUpdate)
            //    {
            //        if (Old.TenantId != User.GetTenantId())
            //            Permissions.ValidatePermission(PermissionKeys.Tenant, Localizer);
            //    }
            //}
        }

        private class MyDeleteHandler : DeleteRequestHandler<MyRow>
        {
            public MyDeleteHandler(IRequestContext context)
                 : base(context)
            {
            }
        }

        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow>
        {
            public MyRetrieveHandler(IRequestContext context)
                 : base(context)
            {
            }

            //protected override void ValidateRequest()
            //{
            //    base.ValidateRequest();

            //    if (Row.TenantId != User.GetTenantId())
            //        Permissions.ValidatePermission(PermissionKeys.Tenant, Localizer);
            //}

            //protected override void PrepareQuery(SqlQuery query)
            //{
            //    base.PrepareQuery(query);

            //    if (!Permissions.HasPermission(PermissionKeys.Tenant))
            //        query.Where(fld.TenantId == User.GetTenantId());
            //}
        }

        private class MyListHandler : ListRequestHandler<MyRow>
        {
            public MyListHandler(IRequestContext context)
                 : base(context)
            {
            }

            //protected override void ApplyFilters(SqlQuery query)
            //{
            //    base.ApplyFilters(query);

            //    if (!Permissions.HasPermission(PermissionKeys.Tenant))
            //        query.Where(fld.TenantId == User.GetTenantId());
            //}
        }

    }
}