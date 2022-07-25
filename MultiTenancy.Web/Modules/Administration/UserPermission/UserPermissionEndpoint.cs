using Microsoft.AspNetCore.Mvc;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;
using System.Linq;
using MyRepository = MultiTenancy.Administration.Repositories.UserPermissionRepository;
using MyRow = MultiTenancy.Administration.Entities.UserPermissionRow;

namespace MultiTenancy.Administration.Endpoints
{
    [Route("Services/Administration/UserPermission/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class UserPermissionController : ServiceEndpoint
    {
        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, UserPermissionUpdateRequest request,
    [FromServices] ITypeSource typeSource)
        {
            return new MyRepository(Context, typeSource).Update(uow, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, UserPermissionListRequest request,
            [FromServices] ITypeSource typeSource)
        {
            return new MyRepository(Context, typeSource).List(connection, request);
        }

        public ListResponse<string> ListRolePermissions(IDbConnection connection, UserPermissionListRequest request,
            [FromServices] ITypeSource typeSource)
        {
            return new MyRepository(Context, typeSource).ListRolePermissions(connection, request);
        }

        public ListResponse<string> ListPermissionKeys(
            [FromServices] ITypeSource typeSource)
        {
            return new ListResponse<string>
            {
                Entities = MyRepository.ListPermissionKeys(Cache.Memory, typeSource).ToList()
            };
        }
    }
}