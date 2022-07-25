using Microsoft.AspNetCore.Mvc;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;
using MyRepository = MultiTenancy.Administration.Repositories.RolePermissionRepository;
using MyRow = MultiTenancy.Administration.Entities.RolePermissionRow;

namespace MultiTenancy.Administration.Endpoints
{
    [Route("Services/Administration/RolePermission/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class RolePermissionController : ServiceEndpoint
    {
        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, RolePermissionUpdateRequest request,
    [FromServices] ITypeSource typeSource)
        {
            return new MyRepository(Context, typeSource).Update(uow, request);
        }

        public RolePermissionListResponse List(IDbConnection connection, RolePermissionListRequest request,
            [FromServices] ITypeSource typeSource)
        {
            return new MyRepository(Context, typeSource).List(connection, request);
        }

    //    public ListResponse<string> ListRolePermissions(IDbConnection connection, UserPermissionListRequest request,
    //[FromServices] ITypeSource typeSource)
    //    {
    //        return new MyRepository(Context, typeSource).ListRolePermissions(connection, request);
    //    }
    }
}
